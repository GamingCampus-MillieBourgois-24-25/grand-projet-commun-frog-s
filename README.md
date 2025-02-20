# Technical Design Document (TDD) - Frog's

## Document Header

**Project Title:** Frog’s - Mobile Simulation Game\
**Version:** 1.0\
**Date:** YYYY-MM-DD\
**Author(s):** [Your Name]\
**Contact:** [[your.email@example.com](mailto\:your.email@example.com)]

## &#x20; Revision History

| Date       | Version | Description               | Author      |
| ---------- | ------- | ------------------------- | ----------- |
| YYYY-MM-DD | 1.0     | Initial document creation | [Your Name] |

## Table of Contents

1. Introduction
2. System Overview
3. Requirements
4. System Architecture & Design
5. Detailed Module Design
6. Interface Design
7. Performance and Optimization
8. Testing Strategy (TDD Implementation)
9. Tools, Environment, and Deployment
10. Security and Safety Considerations
11. Project Timeline and Milestones
12. Appendices

## Introduction

### Objectif du projet

L’objectif principal de ce projet est de proposer une expérience de gestion relaxante où le joueur construit et développe un village de grenouilles. Chaque bâtiment a une fonction spécifique et permet d’optimiser la production de ressources. Le joueur est amené à collecter ces ressources afin d’améliorer les infrastructures existantes et attirer davantage de grenouilles.

L’économie du jeu repose sur une seule ressource, **l’argent**, qui peut être obtenue passivement via les bâtiments ou activement via des mécaniques de monétisation telles que les **publicités et les achats intégrés**.

### Choix technologique : Pourquoi Unity ?

Le jeu est développé sous **Unity** pour plusieurs raisons :

| Critères                        | Unity | Unreal Engine |
|---------------------------------|-------|--------------|
| **Performance mobile**         | ✅ Optimisé pour mobile | ❌ Plus gourmand en ressources |
| **Simplicité et rapidité**     | ✅ Facile d’accès et prototypage rapide | ❌ Courbe d’apprentissage plus complexe |
| **Écosystème et compatibilité** | ✅ Unity Ads, Firebase, support iOS/Android | ❌ Moins de support pour la monétisation mobile |
| **Poids et exigences**         | ✅ Léger et optimisé | ❌ Plus lourd pour les appareils mobiles |
| **Graphismes et rendu**        | ✅ Suffisant pour le style visé | ✅ Plus avancé pour le photoréalisme |
| **Coût d’utilisation**         | ✅ Gratuit jusqu'à un seuil de revenus | ❌ Royalties appliquées après 1M$ de revenus |

**Conclusion** : Unity est le choix idéal pour *Frog's*, car il offre une excellente **optimisation mobile**, une **monétisation simplifiée** et une **interface plus accessible** pour un développement rapide et efficace.

---

### 📌 Informations complémentaires
- **Plateformes ciblées** : iOS & Android
- **Langage utilisé** : C# avec Unity
- **Modèle économique** : Freemium (achats intégrés et publicités)
- **Sauvegarde des données** : Locale & Cloud (via Firebase)

---

Ce projet est en cours de développement et vise à offrir une **expérience de gestion immersive et relaxante** avec un gameplay accessible et une direction artistique soignée. 🚀🐸

## 2. Vue d’ensemble du système

### 2.1 Description Générale  

*Frog’s* est un jeu mobile développé sous **Unity** avec une **architecture modulaire** permettant la gestion en temps réel des **bâtiments**, des **grenouilles** et des **ressources**. Le jeu repose sur plusieurs **modules interconnectés**, chacun ayant un rôle bien défini pour assurer une **expérience fluide et optimisée**.

---

### 2.2 Architecture du Système  

Le jeu est structuré en plusieurs **composants clés** :

- 🎨 **Moteur de Rendu (Rendering Engine)** : Gère l’affichage des assets graphiques et les animations pour assurer une expérience immersive.
- 💰 **Système de Ressources (Resource System)** : Responsable de la génération et de la collecte de l’argent, la ressource principale du jeu.
- 🎮 **Gestion des Entrées (Input Manager)** : Capture les actions du joueur (tactile) comme la construction, l’amélioration des bâtiments et l’interaction avec l’environnement.
- 🔄 **Logique du Jeu (Game Logic)** : Orchestre les interactions entre les différents systèmes pour garantir une **progression fluide** et équilibrée.
- 🎵 **Moteur Audio (Audio Engine)** : Gère les sons et musiques d’ambiance pour renforcer l’immersion et le dynamisme du jeu.

---

### 2.3 Sauvegarde et Gestion des Données  

L’ensemble des **données du jeu** est sauvegardé **localement** avec une **option de synchronisation sur le cloud** pour éviter toute perte de progression.  
L’utilisation de **Unity Addressables** permet :
- **Une gestion optimisée de la mémoire**, en chargeant uniquement les ressources nécessaires.  
- **Une réduction du poids du jeu** sur les appareils mobiles.  

---

### 🔹 Points Clés de l’Architecture :
✔ **Modularité** : Chaque composant fonctionne indépendamment tout en interagissant avec les autres.  
✔ **Optimisation mémoire** avec Unity Addressables pour limiter la consommation de ressources.  
✔ **Sauvegarde hybride** : Stockage local avec possibilité de sauvegarde cloud.  
✔ **Expérience fluide** : Systèmes interconnectés garantissant une progression sans ralentissements.

Cette architecture garantit **une flexibilité d’évolution** et **une performance stable** sur mobile, permettant d’intégrer facilement de nouvelles fonctionnalités au fil du temps. 🚀🐸


## 3. Requirements

### 3.1 Functional Requirements

- Construire et améliorer des bâtiments.
- Assigner des métiers aux grenouilles.
- Collecter des ressources produites par les bâtiments.
- Monétisation via publicités et achats intégrés.

### 3.2 Non-Functional Requirements

- **Performance:** Maintenir 60 FPS sur la majorité des appareils.
- **Scalabilité:** Supporter des mises à jour de contenu régulières.
- **Portabilité:** Fonctionner sur iOS et Android.
- **Accessibilité:** Interface intuitive et accessible à t
  ### ous.

## 4. System Architecture & Design

### 4.1 Architectural Overview

Utilisation d’une architecture basée sur des modules indépendants (bâtiments, grenouilles, économie).

### 4.2 Module Breakdown

- **UI Module:** Interface interactive et intuitive.
- **Economy System:** Gestion de l’argent généré et dépensé.
- **Data Storage:** Sauvegarde locale et cloud.

### 4.3 Gameplay Loop Diagram

(Diagramme détaillant la boucle principale du jeu)

## 5. Detailed Module Design

### 5.1 Class Diagrams and Data Structures

- **GrenouilleManager**: Gère les entités grenouilles et leur assignation de tâches.
- **BuildingManager**: Responsable de la construction et de l'amélioration des bâtiments.

## 6. Interface Design

### 6.1 Internal Interfaces

- **GrenouilleManager** <-> **BuildingManager** : Attribution des métiers.
- **UIManager** <-> **EconomyManager** : Affichage des ressources.

### 6.2 External APIs and File Formats

- **Firebase** (optionnel) pour la sauvegarde cloud.
- **Unity Ads & IAP** pour la monétisation.

## 7. Performance and Optimization

### 7.1 Performance Goals

- Maintenir 60 FPS avec des graphismes optimisés.
- Réduire la consommation mémoire grâce aux **Addressables**.

### 7.2 Optimization Techniques

- Utilisation du pooling pour les objets fréquemment générés.
- Compression des textures et des sons.
- Réduction des appels draw pour limiter l'impact sur le CPU.

## 8. Testing Strategy (TDD Implementation)

### 8.1 Unit Testing

- Vérifier la cohérence des données de production de ressources.
- Tester les interactions entre les modules grenouilles et bâtiments.

### 8.2 Integration Testing

- Vérifier la cohérence entre **GrenouilleManager** et **BuildingManager**.
- Tester les sauvegardes locales et cloud.

## 9. Tools, Environment, and Deployment

### 9.1 Development Tools

- **Moteur:** Unity
- **Langage:** C#
- **IDE recommandé:** Visual Studio, Rider

### 9.2 Version Control

- **Git** via GitHub ou GitLab
- **Branche principale:** `main`
- **Branche de développement:** `develop`

## 10. Security and Safety Considerations

- Validation des entrées utilisateur pour éviter les corruptions de sauvegarde.
- Vérification des achats intégrés pour éviter les abus.

## 11. Project Timeline and Milestones

(Définition détaillée des étapes de production)

## 12. Appendices

(Ajout des schémas de classes et UML)

---

## Conclusion

Ce TDD fournit une base solide pour le développement technique de *Frog's*, justifiant les choix technologiques et décrivant en détail l’architecture du jeu.

