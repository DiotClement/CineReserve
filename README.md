# CineReserve

## Description
CineReserve est une application web de réservation de séances de cinéma développée sous forme d'architecture micro-services. Ce projet s'inscrit dans le cadre de l'évaluation de la matière **Programmation Distribuée** et vise à démontrer la mise en œuvre de micro-services interconnectés pour assurer la gestion des réservations.

## Architecture du projet
Le projet est composé de deux principaux services :
1. **Service Frontend** : Interface utilisateur permettant aux clients de parcourir les films disponibles et de réserver des séances de cinéma.
2. **Service Backend** : Gestion des films et des réservations.

## Technologies utilisées
- **Backend** :
    - **Langage** :C# avec ASP.NET8
  - **Base de données** : PostgreSQL
  - **API REST**
- **Frontend** :
  - **Framework** : Vue.js
  - **Consommation du micro-service de l'API REST du backend**
- **Autres outils** :
  - Docker (conteneurisation des micro-services)
  - Postman (tests des API REST)
  - Swagger
  - Kubernetes
  - Git/GitHub (gestion de version et collaboration)

## Fonctionnalités principales
- Consulter la liste des films disponibles.
- Séléctionner un film à voir.
- Choisir l'horaire de la séance de cinéma.
- Réserver la séance.

## Installation et exécution
### Prérequis
- **Node.js** (pour le frontend)

- **PostgreSQL**
- **Docker** (optionnel, pour exécuter les services en conteneurs)

### Étapes d'installation
#### 1. Cloner le projet
```bash
  git clone https://github.com/votre-repo/CineReserveNotre.git
  cd CineReserveNotre
```

#### 2. Démarrer le backend
```bash
  cd backend
  mvn spring-boot:run
```

#### 3. Démarrer le frontend
```bash
  cd frontend
  npm install
  npm start
```

#### 4. Accéder à l'application
- **Frontend** : [http://localhost:3000/](http://localhost:3000/)
- **Backend** : [http://localhost:8080/api](http://localhost:8080/api)

## Auteurs
- **Anais OUALI**
- **Clément DIOT**

## Licence
Ce projet est sous licence Propriétaire. Tous droits réservés. Il est interdit de copier, distribuer ou modifier ce code sans autorisation expresse des auteurs.

