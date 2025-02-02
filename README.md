# CineReserve

## Description
CineReserve est une application web de réservation de séances de cinéma développée sous forme d'architecture micro-services. Ce projet s'inscrit dans le cadre de l'évaluation de la matière **Programmation Distribuée** et vise à démontrer la mise en œuvre de micro-services interconnectés pour assurer la gestion des réservations.

## Architecture du projet
Le projet est composé de deux principaux services :
1. **Service Frontend** : Interface utilisateur permettant aux clients de parcourir les films disponibles et de réserver des séances de cinéma.
2. **Service Backend** : Gestion des films et des réservations.

## Technologies utilisées
- **Backend** :
    - **Langage** : API REST Web C# avec ASP.NET 8
  - **Base de données** : PostgreSQL
- **Frontend** :
  - **Framework** : Vue JS 3 + Vuetify
- **Autres outils** :
  - Docker
  - Postman
  - Swagger
  - Kubernetes
  - Git/GitHub

## Fonctionnalités principales
- Consulter la liste des films disponibles.
- Sélectionner un film à voir.
- Choisir l'horaire de la séance du film.
- Réserver la séance de cinéma.
- Visualiser les réservations.

## Installation et exécution
### Étapes d'installation
#### 1. Cloner le projet
```bash
  git clone https://github.com/DiotClement/CineReserve.git
  cd CineReserveProject/k8s
```

#### 2. Déployer sur minikube
```bash
  kubectl apply -f postgres-secret.yaml
  kubectl apply -f postgres-storage.yaml
  kubectl apply -f configmap.yaml
  kubectl apply -f movierent-db-deployment.yaml
  kubectl apply -f movierent-db-service.yaml
  kubectl apply -f movierent-api-deployement.yaml
  kubectl apply -f movierent-api-service.yaml
  kubectl apply -f frontend-deployment.yaml
  kubectl apply -f frontend-service.yaml
  kubectl apply -f ingress.yaml
```

#### 3. Accéder à l'application
- **Frontend** : http://movierent.local/
- **Backend** : http://api.movierent.local/swagger/index.html

## Auteurs
- **Anaïs OUALI**
- **Clément DIOT**

## Licence
Ce projet est sous licence Propriétaire. Tous droits réservés. Il est interdit de copier, distribuer ou modifier ce code sans autorisation expresse des auteurs.

