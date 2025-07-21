# Api-restaurant : RestauSimplon

##  RestauSimplon – API de gestion des commandes pour restaurant

### Présentation

RestauSimplon est une API REST développée avec ASP.NET Core et Entity Framework Core, destinée à digitaliser la gestion des commandes du restaurant. Elle permet de gérer les articles du menu, les clients, les commandes et, en bonus, les livraisons.


 ### Fonctionnalités principales

1. **Gestion des Articles du Menu**

- Ajouter, modifier, consulter, supprimer un article

- Champs requis :
    - Nom
    - Prix
    - Catégorie (Entrée, Plat, Dessert)

2. **Gestion des Clients**
- Ajouter, modifier, consulter, supprimer un client

- Champs requis :
    -   Nom
    -   Prénom
    -   Adresse
    -   Téléphone

3. **Gestion des Commandes**
- Créer une commande pour un client avec un ou plusieurs articles

- Calcul automatique du montant total

- Consulter les commandes :
    - Par client
    - Par date
    - Validation : Une commande doit contenir au moins un article
    - Satut de la commande et pouvoir le modifier

4. **Gestion des Livraisons**
    - Statut de commande : `En cours`, `Livrée`.
    - Modification du statut.
    - Endpoint pour consulter les commandes en attente de livraison.


5. **Relations entre entités**
Un client peut passer plusieurs commandes

Une commande peut contenir plusieurs articles

Un article peut appartenir à plusieurs commandes

## Installation

1. **Cloner le repo**
   ```
   git clone https://github.com/abdellah59/Api-restaurant
   
2. **Installer Dotnet EF de manière globale dans votre ordinateur**
   ouvrez votre powershell ou CMD en administrateur et ajoutez cette ligne
   ```powershell
   dotnet tool install --global dotnet-ef

3. **Creer la migration dans la console de la solution**
   ```powershell
   dotnet ef migrations add InitialCreate
   
4. **Appliquer la migration afin qu'un fichier sqLite soit créé**
   ```powershell
   dotnet ef database update

5. **Executer le programme afin d'afficher l'interface Swagger qui s'affiche dans le navigateur**

6. **Pour lancer le Front de l'API cliquer sur le ci-dessous**

### Interface Front-End : [Lien du front de l'API](http://127.0.0.1:5500/Api-restaurant/)

- Développée en HTML/CSS 

- Permet :
    - Consultation des articles du menu, commandes
    - Création de commandes
    - Consulter les commande d'un client

### Technologies utilisées

**Backend** : [.NET 8 SDK](https://dotnet.microsoft.com/download)

**ORM** : Entity Framework Core

**Base de données** : SQLite 

**Documentation** : Swagger

**Contrôle de version** : Git / GitHub

### Outils Utilisés

- ![GitHub](https://img.shields.io/badge/github-%23121011.svg?style=for-the-badge&logo=github&logoColor=white)
- ![Visual Studio](https://img.shields.io/badge/Visual%20Studio-5C2D91.svg?style=for-the-badge&logo=visual-studio&logoColor=white)
- ![Visual Studio Code](https://img.shields.io/badge/Visual%20Studio%20Code-0078d7.svg?style=for-the-badge&logo=visual-studio-code&logoColor=white)
- ![Markdown](https://img.shields.io/badge/markdown-%23000000.svg?style=for-the-badge&logo=markdown&logoColor=white)

### Présentation finale : [Lien de la présentation](https://gamma.app/docs/API-Gestion-de-Commandes-pour-RestauSimplon-tk9sw0p6jyyxbbl)

**Le projet est accompagné d’un diaporama PDF expliquant** :
    - Les objectifs du projet
    - Les fonctionnalités Clés
    - Les cas d'Usage Typique
    - L’architecture
    - Les démonstrations via Swagger et front-end

#### Collaboration & Git
Travail collaboratif avec Git : branches, pull requests, commits réguliers
Communication via Discord

#### Auteur

Projet développé par **Abdellah**, **Loic**, **Othman**, **Nicolas** dans le cadre d’un projet backend pour RestauSimplon.
