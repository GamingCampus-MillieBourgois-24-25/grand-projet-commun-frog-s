# Technical Design Document (TDD) - Frog's

## Document Header

**Project Title:** Frog’s - Mobile Simulation Game  
**Version:** 1.0  
**Date:** YYYY-MM-DD  
**Author(s):** [Your Name]  
**Contact:** [your.email@example.com]  

## Revision History

| Date       | Version | Description                 | Author      |
|------------|---------|-----------------------------|-------------|
| YYYY-MM-DD | 1.0     | Initial document creation   | [Your Name] |

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

## 1. Introduction

### 1.1 Purpose
Ce document décrit la conception technique du jeu *Frog's*, un jeu de simulation mobile basé sur Unity. Il définit l'architecture, les modules et la stratégie de développement basée sur le Test-Driven Development (TDD).

### 1.2 Scope
**Objectif:** Développer un jeu de gestion de village de grenouilles, où les joueurs construisent des bâtiments et collectent des ressources.  
**Application:** Mobile (iOS, Android)  

### 1.3 Definitions, Acronyms, and Abbreviations
- **TDD:** Test-Driven Development  
- **API:** Application Programming Interface  
- **FPS:** Frames Per Second  
- **UI:** User Interface  

### 1.4 References
- Unity Documentation  
- C# Scripting API  
- Mobile Performance Optimization Guides  

## 2. System Overview

### 2.1 High-Level Description
*Frog’s* est un jeu mobile développé sous Unity avec une architecture modulaire, permettant la gestion des bâtiments, des grenouilles et des ressources en temps réel.

### 2.2 System Context Diagram
(Schéma de l’architecture du jeu à ajouter)

### 2.3 Major Components
- **Rendering Engine:** Gestion des assets graphiques et animations.
- **Resource System:** Génération et collecte de l'argent (unique ressource).
- **Input Manager:** Captation des actions des joueurs (tactile).
- **Game Logic:** Gestion des mécaniques de construction et d’amélioration.
- **Audio Engine:** Gestion des sons et musiques d’ambiance.

## 3. Requirements

### 3.1 Functional Requirements
- Construire et améliorer des bâtiments.
- Assigner des métiers aux grenouilles.
- Collecter des ressources produites par les bâtiments.

### 3.2 Non-Functional Requirements
- **Performance:** Maintenir 60 FPS sur la majorité des appareils.
- **Scalabilité:** Supporter des mises à jour de contenu régulières.
- **Portabilité:** Fonctionner sur iOS et Android.

## 4. System Architecture & Design

### 4.1 Architectural Overview
Utilisation d’une architecture basée sur des modules indépendants (bâtiments, grenouilles, économie).

### 4.2 Module Breakdown
- **UI Module:** Interface interactive et intuitive.
- **Economy System:** Gestion de l’argent généré et dépensé.
- **Data Storage:** Sauvegarde locale et cloud.

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

## 8. Testing Strategy (TDD Implementation)

### 8.1 Unit Testing
Exemple de test sur la production de ressources :
```csharp
[Test]
public void TestResourceGeneration() {
    BuildingManager bm = new BuildingManager();
    bm.UpgradeBuilding();
    Assert.AreEqual(expectedIncome, bm.GetIncome());
}
```

### 8.2 Integration Testing
- Vérifier la cohérence entre **GrenouilleManager** et **BuildingManager**.
- Tester les sauvegardes locales.

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
| Phase      | Date de début | Date de fin | Description |
|------------|--------------|-------------|-------------|
| Prototype  | YYYY-MM-DD   | YYYY-MM-DD  | Implémentation de base |
| Alpha      | YYYY-MM-DD   | YYYY-MM-DD  | Ajout des mécaniques principales |
| Bêta       | YYYY-MM-DD   | YYYY-MM-DD  | Tests et équilibrage |
| Release    | YYYY-MM-DD   | YYYY-MM-DD  | Version stable |

## 12. Appendices

### 12.1 Glossary
- **Game Loop:** Boucle principale du jeu.
- **Pooling:** Réutilisation des objets au lieu de les recréer.

### 12.2 Additional Diagrams
(Ajouter schémas de classes et diagrammes UML si nécessaire)

---

## Conclusion
Ce TDD fournit une base solide pour le développement technique de *Frog's*. La prochaine étape est l’implémentation des premiers modules en suivant la stratégie TDD.

