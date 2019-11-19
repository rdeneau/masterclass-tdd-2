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
