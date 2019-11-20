# Kata Mars Rover en C♯

## Contexte

Masterclass Craft, Tests & TDD, Session n°3 :

- Suite d’une session assez théorique (75%) + [Kata FooBarQix](https://github.com/rdeneau/masterclass-tdd)
- Session à 90% consacrée à la pratique
- Pratique du Kata [Mars Rover](https://kata-log.rocks/mars-rover-kata), variante du kata de la "tondeuse".
- Découverte du *TDD outside-in*, des _Test Doubles_ (en particulier du _Spy_), mêlé avec le TDD classique par pragmatisme (cf. cette solution en C#)

## Exercice

[Kata Mars Rover](https://kata-log.rocks/mars-rover-kata)

- Ce n'est pas un kata d'algo mais de construction d'un système par tranches, ce qui est plus proche de ce que l'on rencontre en informatique de gestion.
- Liste de tests conseillée :
  - Orientation/Direction: North, South...
    - Given direction
    - When Rover.TurnLeft() / TurnRight()
    - Then new direction...
  - Localisation du Rover sur une grille infinie
    - Given direction and location
    - When MoveForward() / Backward
    - Then new Location...
  - Grille planète circulaire
    - Given Location At X=0
    - When Decrement X
    - Then X = Width - 1
    - Etc...
  - Guidage du Rover par suite de commandes depuis la Terre
    - Test d'acceptation du type test d'intégration : reste Red tant que les tests unitaires qui suivent ne couvre pas toute la feature
    - Tests unitaires :
      - Guidage d'un "IVehicule" (Spy pour vérifier par ex que commande "L" déclenche vehicle .TurnLeft)
      - Succession de commandes
  - Détection d'obstacles...

## Solution

Voici quelques éléments concernant la solution proposée actuellement :

### Builder

- Introduit à la fin du 1er test (sur les directions), en phase de refacto pour faciliter l'écriture des prochains tests. Les méthodes sont ajoutées au fur et à mesure des besoins en tests.
- API fluent pour se lire comme de l'anglais, en soignant le nommage et en faisant en sorte que chaque méthode renvoie l'instance courante du builder.
  - N.B. l'utilisation du builder est restreint aux tests. Il convient bien tel quel. Pour une utilisation plus intensive, un design plus safe serait de le rendre immuable, en renvoyant une nouvelle instance à la fin de chaque méthode.
- Syntaxe spéciale pour obtenir le builder : `MarsRover.ThatIs()`. Renforce la _fluent API_.
- La sortie du builder se fait par une conversion vers un `MarsRover`, la méthode `Build()` étant alors implicitement appelée. En pratique dans les tests c'est transparent, car on utilise le champ `sut` :

```cs
public class MarsRoverShould
{
    private MarsRover sut;

    [Theory, InlineData("N")...]
    public void Have_An_Initial_Direction(string directionLetter)
    {
        sut = MarsRover.ThatIs().Facing(directionLetter); // Cast from `MarsRoverBuilder` to `MarsRover`
        ...
    }
}

public class MarsRoverBuilder
{
    private string DirectionLetter { get; set; } = "?";

    public MarsRoverBuilder Facing(string direction)
    {
        DirectionLetter = direction;
        return this;
    }

    public static implicit operator MarsRover(MarsRoverBuilder builder) =>
        builder.Build();

    private MarsRover Build() =>
        new MarsRover(...);
}
```

J'aime bien les méthodes sous forme de _"fat arrow"_ : le code est plus succinct et respecte mieux l'idée de _small functions_ en _clean code_. On peut réécrire le fluent builder ainsi :

```cs
public class MarsRoverBuilder
{
    public MarsRoverBuilder Facing(string direction) =>
        With(() => DirectionLetter = direction);

    public MarsRoverBuilder LocatedAt(int x, int y) =>
        With(() =>
        {
            LocationX = x;
            LocationY = y;
        });

    private MarsRoverBuilder With(Action action)
    {
        action();
        return this;
    }
}
```

### Placement des fichiers des tests

Une particularité : les classes de prod (`Xxx.cs`) et les fichiers de tests (`XxxShould.cs`) sont côte à côte ds le même répertoire. Pas du tout la norme en C#. Mais pratique pr un kata.

### Indication d'un obstacle

Pour indiquer un obstacle et arrêter une séquence de mouvements :

- Pas de _"throw exception"_
- Renvoi d'un objet de type spécifique pour indiquer une rotation, un déplacement ou un obstacle.
- Pour les regrouper, en l'absence de "type union" en C#, ils ont une interface commune `IVehicleEvent`. L'interface est vide : c'est juste une _marker interface_.

### Mutabilité

Le design actuel utilise la mutation des objets, par exemple les méthodes `Increment()` et `Decrement()` modifie l'instance courante de `Coordinate`. On pourrait refaire le kata avec un design immuable / fonctionnel en objectif. On pourrait s'inspirer de ce qui se fait en CQRS/ES ?

### Style de TDD

Le kata a été exécuté majoritairement en TDD classicist / Chicago school, en ayant par exemple des unités sous tests plus ou moins grande, tout en garantissant la couverture du code par les tests.

Les _Mocks_ ont été utilisé une fois, en tant que _"Spy"_ pour vérifier qu'une commande induit bien le mouvement escompté sur le véhicule cible :

```cs
public class CommandCollectionShould
{
    [Fact]
    public void Guide_Vehicle()
    {
        var sut = CommandCollection.Create("FFRLB");

        var vehicleMock = new Mock<IVehicle>();
        sut.Guide(vehicleMock.Object);

        vehicleMock.Verify(x => x.MoveForward(),  Times.Exactly(2));
        vehicleMock.Verify(x => x.MoveBackward(), Times.Once);
        vehicleMock.Verify(x => x.RotateLeft(),   Times.Once);
        vehicleMock.Verify(x => x.RotateRight(),  Times.Once);
    }
}
```

Le test `Be_Guided_By_Received_Commands` représente ainsi une unité très large. On pourrait écrire cette partie en utilisant une double boucle TDD, en considérant ce test comme un test d'intégration et d'acceptation, et en créant le système par petites parties en TDD sur tests unitaires avec des unités ne dépassant pas la taille d'une classe. L'utilisation des _Mocks_ serait alors bien plus conséquente.

Mais je n'aime pas trop ce style dit _Outside-in_, car il peut induire beaucoup de tests trop petits et parfois des classes trop petites. Voici un exemple de repo où ce kata écrit de cette manière : https://github.com/upsd/mars-rover-2.

### Pseudo pattern Visitor

Le guidage du véhicule `MarsRover::ReceiveCommands()` est délégué à la collection de commandes associées :

```cs
public class MarsRover : IVehicle
{
    public IVehicleEvent ReceiveCommands(string commands) =>
        CommandCollection
            .Create(commands)
            .Guide(this);
}
```

On notera que l'interface `IVehicle` appartient à son client, la `CommandCollection`. Le fichier se situe donc dans le répertoire `Commands`. Cela permet de respecter l'inversion de dépendances (principe SOLID _DIP_).

La `CommandCollection` parcourt l'ensemble des commandes internes et déclenche le mouvement associé : `Commands.Select(command => command.Move(vehicle))`. La méthode `Command::Move()` est polymorphique mais les variations ne se font pas en créant des sous-types mais par instance, sous la forme de propriété de type `Func<IVehicle, IVehicleEvent>`, les commandes instances étant définies sous la forme de *Singletons* (ce qui est possible car elles sont immuables, sinon il faudrait des méthodes *Factory*) :

```cs
public class Command
{
    private static readonly Command Left     = new Command("L", x => x.RotateLeft());
    private static readonly Command Right    = new Command("R", x => x.RotateRight());
    private static readonly Command Forward  = new Command("F", x => x.MoveForward());
    private static readonly Command Backward = new Command("B", x => x.MoveBackward());

    public string Letter { get; }

    public Func<IVehicle, IVehicleEvent> Move { get; }

    private Command(string letter, Func<IVehicle, IVehicleEvent> move)
    {
        Letter = letter;
        Move   = move;
    }
}
```

Au final, chaque commande renvient "visiter" le véhicule pour le déplacer. C'est une variante ad hoc du pattern _Visitor_ et de son double dispatch.
