Technical Design Document (TDD) - Frog's

Document Header

Project Title: Frog’s - Mobile Simulation GameVersion: 1.0Date: YYYY-MM-DDAuthor(s): A.PATTE - K.DIFALLAH - G.ANDRE - L.QUEIROS - S.BONDEL 

Contact: [lqueirosdasilva@gaming.tech]

| Date       | Version | Description                 | Author      |

|------------|---------|-----------------------------|-------------|

| 20/02/2025 | 1.0     | Création initiale du document   | Adrien PATTE |  

Table of Contents

Introduction

System Overview

Requirements

System Architecture & Design

Detailed Module Design

Interface Design

Performance and Optimization

Testing Strategy (TDD Implementation)

Tools, Environment, and Deployment

Security and Safety Considerations

Project Timeline and Milestones

Appendices

1. Introduction

1.1 Purpose

Ce document décrit la conception technique du jeu Frog's, un jeu de simulation mobile basé sur Unity. Il définit l'architecture, les modules et la stratégie de développement basée sur le Test-Driven Development (TDD).

1.2 Scope

Objectif: Développer un jeu de gestion de village de grenouilles, où les joueurs construisent des bâtiments et collectent des ressources.Application: Mobile (iOS, Android)

1.3 Justification du choix technologique

Pourquoi Unity plutôt qu'Unreal Engine ?

Critères

Unity

Unreal Engine

Performance mobile

Excellente optimisation pour mobile

Plus orienté hautes performances, lourd sur mobile

Simplicité et rapidité de prototypage

Interface intuitive, prise en main rapide

Courbe d’apprentissage plus complexe

Écosystème et compatibilité

Unity Ads, Firebase, Addressables, support iOS et Android

Moins de support natif pour la monétisation mobile

Poids et exigences techniques

Léger et adapté aux appareils mobiles

Moteur plus gourmand en ressources

Graphismes et rendu

Moins avancé qu’Unreal mais suffisant pour le style visé

Rendu photoréaliste avancé

Coût d’utilisation

Gratuit jusqu’à un certain seuil de revenus

Royalties après 1M$ de revenus

Conclusion : Unity est mieux adapté au projet Frog’s en raison de sa légèreté, de son optimisation mobile et de sa compatibilité avec les outils nécessaires à la monétisation et à l’optimisation des ressources.

1.4 Definitions, Acronyms, and Abbreviations

TDD: Test-Driven Development

API: Application Programming Interface

FPS: Frames Per Second

UI: User Interface

1.5 References

Unity Documentation

C# Scripting API

Mobile Performance Optimization Guides

2. System Overview

2.1 High-Level Description

Frog’s est un jeu mobile développé sous Unity avec une architecture modulaire, permettant la gestion des bâtiments, des grenouilles et des ressources en temps réel.

2.2 System Context Diagram

(Diagramme représentant les interactions principales du jeu)

2.3 Major Components

Rendering Engine: Gestion des assets graphiques et animations.

Resource System: Génération et collecte de l'argent (unique ressource).

Input Manager: Captation des actions des joueurs (tactile).

Game Logic: Gestion des mécaniques de construction et d’amélioration.

Audio Engine: Gestion des sons et musiques d’ambiance.

3. Requirements

3.1 Functional Requirements

Construire et améliorer des bâtiments.

Assigner des métiers aux grenouilles.

Collecter des ressources produites par les bâtiments.

Monétisation via publicités et achats intégrés.

3.2 Non-Functional Requirements

Performance: Maintenir 60 FPS sur la majorité des appareils.

Scalabilité: Supporter des mises à jour de contenu régulières.

Portabilité: Fonctionner sur iOS et Android.

Accessibilité: Interface intuitive et accessible à tous.

4. System Architecture & Design

4.1 Architectural Overview

Utilisation d’une architecture basée sur des modules indépendants (bâtiments, grenouilles, économie).

4.2 Module Breakdown

UI Module: Interface interactive et intuitive.

Economy System: Gestion de l’argent généré et dépensé.

Data Storage: Sauvegarde locale et cloud.

4.3 Gameplay Loop Diagram

(Diagramme détaillant la boucle principale du jeu)

5. Detailed Module Design

5.1 Class Diagrams and Data Structures

GrenouilleManager: Gère les entités grenouilles et leur assignation de tâches.

BuildingManager: Responsable de la construction et de l'amélioration des bâtiments.

6. Interface Design

6.1 Internal Interfaces

GrenouilleManager <-> BuildingManager : Attribution des métiers.

UIManager <-> EconomyManager : Affichage des ressources.

6.2 External APIs and File Formats

Firebase (optionnel) pour la sauvegarde cloud.

Unity Ads & IAP pour la monétisation.

7. Performance and Optimization

7.1 Performance Goals

Maintenir 60 FPS avec des graphismes optimisés.

Réduire la consommation mémoire grâce aux Addressables.

7.2 Optimization Techniques

Utilisation du pooling pour les objets fréquemment générés.

Compression des textures et des sons.

Réduction des appels draw pour limiter l'impact sur le CPU.

8. Testing Strategy (TDD Implementation)

8.1 Unit Testing

Vérifier la cohérence des données de production de ressources.

Tester les interactions entre les modules grenouilles et bâtiments.

8.2 Integration Testing

Vérifier la cohérence entre GrenouilleManager et BuildingManager.

Tester les sauvegardes locales et cloud.

9. Tools, Environment, and Deployment

9.1 Development Tools

Moteur: Unity

Langage: C#

IDE recommandé: Visual Studio, Rider

9.2 Version Control

Git via GitHub ou GitLab

Branche principale: main

Branche de développement: develop

10. Security and Safety Considerations

Validation des entrées utilisateur pour éviter les corruptions de sauvegarde.

Vérification des achats intégrés pour éviter les abus.

11. Project Timeline and Milestones

(Définition détaillée des étapes de production)

12. Appendices

(Ajout des schémas de classes et UML)

Conclusion

Ce TDD fournit une base solide pour le développement technique de Frog's, justifiant les choix technologiques et décrivant en détail l’architecture du jeu.

