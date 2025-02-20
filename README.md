# Technical Design Document (TDD) - Frog's

## Document Header

**Project Title:** Frog’s \
**Version:** 1.0 \
**Date:** 2025-02-20 \
**Author(s):** A.PATTE / L.QUEIROS / G.ANDRE / K.DIFALLAH / S.BONDEL \
**Contact:** [[Leo Queiros](mailto\:lqueirosdasilva@gaming.tech)]

## &#x20; Revision History

| Date       | Version | Description               | Author      |
| ---------- | ------- | ------------------------- | ----------- |
| 2025-02-20 | 1.0     | Ecriture initiale du document | A.PATTE |

## Table of Contents

1. Introduction
2. Overview du systeme
3. Exigences
4. Architecture du systeme et design
5. Conception détaillée du module
6. Conception de l'interface
7. Performance et optimisation
8. Stratégie de test (mise en œuvre du TDD)
9. Outils, environnement et déploiement

## Introduction

### Objectif du projet

Ce projet a pour but de proposer une expérience de gestion relaxante où le joueur construit et développe un village de grenouilles. Chaque bâtiment a une fonction spécifique et permet d’optimiser la production de ressources. Le joueur est amené à collecter ces ressources afin d’améliorer les infrastructures existantes et attirer davantage de grenouilles.

L’économie du jeu repose sur une seule ressource, **l’argent**, qui peut être obtenue passivement via les bâtiments ou activement via des mécaniques de monétisation telles que les **publicités et les achats intégrés**.

### Notre choix technologique : Pourquoi Unity ?

Le jeu est développé sous **Unity** pour plusieurs raisons :

| Critères                        | Unity | Unreal Engine |
|---------------------------------|-------|--------------|
| **Performance mobile**         | ✅ Optimisé pour mobile | ❌ Plus gourmand en ressources |
| **Simplicité et rapidité**     | ✅ Facile d’accès et prototypage rapide | ❌ Courbe d’apprentissage plus complexe |
| **Écosystème et compatibilité** | ✅ Unity Ads, Firebase, support iOS/Android | ❌ Moins de support pour la monétisation mobile |
| **Poids et exigences**         | ✅ Léger et optimisé | ❌ Plus lourd pour les appareils mobiles |
| **Graphismes et rendu**        | ✅ Suffisant pour le style visé | ✅ Plus avancé pour le photoréalisme |
| **Coût d’utilisation**         | ✅ Gratuit jusqu'à un seuil de revenus | ❌ Royalties appliquées après 1M$ de revenus |

Donc Unity est le choix idéal pour notre jeu *Frog's*, car il offre une excellente **optimisation mobile**, une **monétisation simplifiée** et une **interface plus accessible** pour un développement rapide et efficace.

---

### 📌 Informations complémentaires
- **Plateformes ciblées** : Android (trop de problemes avec iOS)
- **Langage utilisé** : C# avec Unity
- **Modèle économique** : Freemium (achats intégrés et publicités)
- **Sauvegarde des données** : Locale

---

Ce projet est en cours de développement et vise à offrir une **expérience de gestion immersive et relaxante** avec un gameplay accessible et une direction artistique soignée. 🐸

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

L’ensemble des **données du jeu** est sauvegardé **localement** pour éviter toute perte de progression.  
L’utilisation de **Unity Addressables** permet :
- **Une gestion optimisée de la mémoire**, en chargeant uniquement les ressources nécessaires.  
- **Une réduction du poids du jeu** sur les appareils mobiles.  

---

### 🔹 Points Clés de l’Architecture :
✔ **Modularité** : Chaque composant fonctionne indépendamment tout en interagissant avec les autres.  
✔ **Optimisation mémoire** avec Unity Addressables pour limiter la consommation de ressources.  
✔ **Expérience fluide** : Systèmes interconnectés garantissant une progression sans ralentissements.

Cette architecture garantit **une flexibilité d’évolution** et **une performance stable** sur mobile, permettant d’intégrer facilement de nouvelles fonctionnalités au fil du temps. 🐸


## 3. Exigences

### 3.1 Functional Requirements

- Construire et améliorer des bâtiments.
- Assigner des métiers aux grenouilles.
- Collecter des ressources produites par les bâtiments.
- Monétisation via publicités et achats intégrés.

### 3.2 Non-Functional Requirements

- **Performance:** Maintenir 30 FPS sur la majorité des appareils.
- **Scalabilité:** Supporter des mises à jour de contenu régulières.
- **Portabilité:** Fonctionner sur Android.
- **Accessibilité:** Interface intuitive et accessible à tous.

## 4. Architecture du Système et Optimisation des Performances  

### 4.1 Vue d’Ensemble de l’Architecture  

Le jeu utilise une **architecture modulaire** où chaque composant fonctionne indépendamment tout en interagissant avec les autres. Cette approche permet une **meilleure flexibilité**, facilitant l’évolution du projet avec l’ajout de nouvelles fonctionnalités.

Les principaux modules du jeu sont les suivants :

- 🖥 **UI Module** : Gère l’interface utilisateur et assure une interaction intuitive avec le joueur.
- 💰 **Economy System** : Responsable de la gestion de l’argent généré et dépensé, influençant la progression.
- 📂 **Data Storage** : Assure la **sauvegarde locale** pour éviter toute perte de données.

---

### 4.2 Optimisation et Performances  

Le jeu vise à **maintenir une fluidité constante** sur une large gamme d’appareils mobiles. Pour cela, plusieurs techniques d’optimisation sont mises en place :

- 🚀 **Object Pooling** : Réduction des allocations dynamiques de mémoire pour minimiser les instanciations coûteuses.
- 🎨 **Compression des Assets** : Textures et sons compressés pour limiter l’empreinte mémoire.
- 🔄 **Minimisation des Draw Calls** : Regroupement des objets pour optimiser le rendu et alléger la charge CPU/GPU.
- 🎯 **Gestion efficace du chargement des ressources** : Utilisation des **Unity Addressables** pour ne charger que les assets nécessaires au bon moment.

L’optimisation du **code source** est également une priorité, avec une **séparation claire des responsabilités** entre les modules, assurant ainsi une **meilleure maintenabilité** et une réduction des risques de bugs.

---

### 4.3 Boucle de Gameplay  

*(Diagramme illustrant la boucle principale du jeu ici)*  

Le **cœur du gameplay** suit une boucle optimisée qui permet au joueur d’interagir efficacement avec son environnement. Chaque action (construction, amélioration, collecte) est gérée par des systèmes indépendants, garantissant **une expérience fluide et sans latence**.

---

### 🔹 Principaux Axes d’Optimisation :
✔ **Architecture modulaire** : Chaque module peut être amélioré indépendamment.  
✔ **Réduction de la consommation mémoire** avec des assets compressés et du pooling d’objets.  
✔ **Optimisation du rendu** avec une limitation des draw calls pour améliorer les performances.  
✔ **Gestion intelligente du chargement des données** grâce aux **Addressables**.  

Grâce à ces optimisations, *Frog’s* aura une **expérience fluide et performante** sur les appareils mobiles, même les plus anciens. 🐸


## 5. Conception Détaillée des Modules et Stratégie de Test  

### 5.1 Conception des Modules  

L’architecture du jeu repose sur **des classes indépendantes**, chacune ayant un rôle précis pour structurer les mécaniques principales.  

#### 📌 Principales Classes et Structures de Données :  

- 🐸 **GrenouilleManager** (optionnel) :  
  - Gère les entités grenouilles et leur assignation de tâches.  
  - Associe des comportements spécifiques en fonction des bâtiments.  
  - Assure une gestion efficace des déplacements et interactions.  

- 🏗 **BuildingManager** :  
  - Responsable de la construction et de l’amélioration des bâtiments.  
  - Gère les **coûts et temps de construction**.  
  - Assure la compatibilité entre les bâtiments et les grenouilles assignées.  

Chaque module est conçu pour fonctionner de manière **autonome**, tout en interagissant avec les autres composants du jeu pour garantir une **progression fluide et logique**.

---

### 5.2 Stratégie de Test et Validation  

Le développement du jeu suit une approche **Test-Driven Development (TDD)** afin d’assurer une **stabilité maximale** et une **réduction des erreurs** avant l’intégration de nouvelles fonctionnalités.  

#### ✅ Types de Tests Implémentés :  

1. **Tests Unitaires** 🛠  
   - Vérifient les fonctionnalités de chaque module individuellement.  
   - Exemple : Validation de la gestion de l’économie et des interactions entre grenouilles et bâtiments.  

2. **Tests d’Intégration** 🔄  
   - Assurent la communication correcte entre les différents systèmes du jeu.  
   - Exemple : Vérifier que le **GrenouilleManager** interagit correctement avec le **BuildingManager**.  

3. **Tests de Performance** 🚀  
   - Mesurent la stabilité et la fluidité du jeu sur différentes plateformes mobiles.  
   - Objectif : Maintenir **30 FPS** sur la majorité des appareils.  

4. **Tests Utilisateur** 🎮  
   - Permettent de collecter des **retours sur l’expérience de jeu**.  
   - Ajustements effectués en fonction des observations et des sessions de test.  

---

### 🔹 Sécurisation et Automatisation des Tests  

✔ **Tests automatisés réguliers** pour prévenir toute régression.  
✔ **Suivi des performances** pour garantir une **expérience fluide** sur mobile.  
✔ **Phase de validation utilisateur** avant toute mise à jour majeure.  

Grâce à cette approche rigoureuse, *Frog’s* assure **une expérience de jeu stable, optimisée et sans bugs majeurs** avant chaque déploiement ! 🐸


## 6. Conception de l’Interface et Déploiement  

### 6.1 Interfaces Internes  

Le jeu repose sur **des interfaces bien définies** permettant une communication fluide entre les différents modules.  

- 🔄 **GrenouilleManager ↔ BuildingManager** :  
  - Gère l’**attribution des métiers** des grenouilles en fonction des bâtiments disponibles.  
  - Assure une **mise à jour dynamique** des grenouilles lorsqu’un bâtiment est construit ou amélioré.  

- 📊 **UIManager ↔ EconomyManager** :  
  - Affiche en temps réel les **ressources collectées** et disponibles.  
  - Met à jour les **éléments de l’interface utilisateur** en fonction des actions du joueur (gain d’argent, construction de bâtiments, etc.).  

---

### 6.2 APIs Externes et Formats de Fichiers  

Pour assurer des fonctionnalités avancées et une **meilleure gestion des données**, plusieurs services externes peuvent être intégrés :  

- 💰 **Unity Ads & IAP** :  
  - Permet la **monétisation** via des **publicités et des achats intégrés**.  
  - Gestion simplifiée des transactions avec Android.  

---

## 6.3 Déploiement et Maintenance  

Le jeu sera **disponible sur Android**, avec des mises à jour régulières pour **maintenir l’engagement des joueurs** et assurer la **stabilité du système**.  

### 📌 Cycle de Déploiement Structuré  

1. **Développement et Tests Internes** 🛠  
   - Implémentation de nouvelles fonctionnalités.  
   - Corrections de bugs avant la mise en production.  

2. **Phase Bêta** 🔄  
   - Tests réalisés par un échantillon d’utilisateurs.  
   - Détection et correction des **problèmes majeurs** avant le déploiement global.  

3. **Déploiement Progressif** 🚀  
   - Lancement contrôlé par vagues pour éviter des **problèmes critiques** à grande échelle.  

---

### 6.4 Suivi et Améliorations  

✔ **Outils d’analyse intégrés** pour surveiller la **performance du jeu** et identifier les problèmes techniques.  
✔ **Mise en place d’un support utilisateur** pour répondre aux **retours des joueurs** et proposer des améliorations continues.  
✔ **Versioning sous Git** pour une gestion efficace des mises à jour et des différentes branches de développement.  

Grâce à cette approche, *Frog’s* garantit une **expérience fluide et bien maintenue**, avec un cycle de mises à jour optimisé pour éviter les interruptions et améliorer continuellement le jeu ! 🐸


## 7. Performance, Optimisation et Sécurité  

### 7.1 Objectifs de Performance  

Le jeu est conçu pour offrir une **expérience fluide et optimisée**, même sur des appareils mobiles aux capacités limitées. Les principaux objectifs de performance sont :  

- 🎯 **Maintenir un framerate stable à 60 FPS** avec des graphismes optimisés.  
- 📉 **Réduire la consommation mémoire** en utilisant **Unity Addressables** pour gérer efficacement le chargement des assets.  

---

### 7.2 Techniques d'Optimisation  

Pour atteindre ces performances, plusieurs techniques sont mises en place :  

- 🚀 **Pooling d’objets** : Réutilisation des objets fréquemment générés afin de limiter les allocations de mémoire dynamiques.  
- 🎨 **Compression des textures et des sons** : Réduction de la taille des fichiers pour améliorer les performances et diminuer le temps de chargement.  
- 🔄 **Réduction des Draw Calls** : Optimisation du rendu graphique pour limiter l’impact sur le CPU et le GPU.  

Ces optimisations garantissent **une meilleure fluidité**, une **consommation réduite de la batterie**, et une **expérience sans ralentissements**.

---

## 7.3 Sécurité et Protection des Données  

La **sécurité des joueurs** et la **protection de leurs données** sont une priorité absolue. Plusieurs mesures sont mises en place pour éviter tout abus ou exploitation malveillante :  

- 🔐 **Chiffrement des sauvegardes**  
  - Protection contre toute altération ou corruption des fichiers de jeu.  
  - Sauvegarde sécurisée des données locales et cloud.  

- 🛡 **Validation des entrées utilisateur**  
  - Vérification des interactions pour **prévenir les exploits** et empêcher les comportements anormaux.  

- 💰 **Protection des achats intégrés**  
  - Sécurisation des transactions pour éviter la fraude et garantir un système d’achats fiable.  

- 📜 **Respect des Réglementations**  
  - **RGPD (Europe)** : Protection des données personnelles des joueurs.  
  - **COPPA (États-Unis)** : Conformité aux règles de protection des enfants en ligne.  

---

### 🔹 Principaux Bénéfices de ces Mesures :
✔ **Jeu optimisé** pour une **expérience fluide sur mobile**.  
✔ **Données des joueurs protégées** avec un **chiffrement avancé**.  
✔ **Achat in-app sécurisé** pour éviter les fraudes et garantir la confiance des utilisateurs.  
✔ **Respect des normes internationales** assurant la conformité légale du jeu.  

Grâce à ces stratégies, *Frog’s* assure **une performance optimale et une sécurité renforcée**, garantissant une **expérience utilisateur fluide, fiable et conforme aux meilleures pratiques**. 🐸  


## 8. Stratégie de Test et Environnement de Développement  

### 8.1 Implémentation du Test-Driven Development (TDD)  

Le développement du jeu suit une **approche basée sur le Test-Driven Development (TDD)** pour assurer une **stabilité maximale** et détecter les erreurs avant l’intégration de nouvelles fonctionnalités.  

#### 🛠 Tests Unitaires  

Les tests unitaires garantissent que chaque module fonctionne correctement de manière isolée :  
- 🔄 **Vérification des données de production de ressources** : S’assurer que la génération et la collecte de l’argent suivent les règles économiques définies.  
- 🐸 **Test des interactions entre les modules GrenouilleManager et BuildingManager** : Validation des attributions de tâches et de la gestion des bâtiments.  

#### 🔄 Tests d’Intégration  

Ces tests permettent de vérifier la **communication entre les différents systèmes** du jeu :  
- 🏗 **Cohérence entre GrenouilleManager et BuildingManager** : Assurer un fonctionnement fluide entre la gestion des grenouilles et la construction.  
- ☁ **Tests des sauvegardes locales et cloud** : Vérifier l’intégrité des données et la bonne synchronisation des sauvegardes via Firebase (optionnel).  

---

## 8.2 Outils et Environnement de Développement  

Le développement s’appuie sur un **environnement structuré** permettant une **collaboration efficace** et un **déploiement fluide**.  

- 🎮 **Moteur de jeu** : *Unity*, utilisé pour ses performances optimisées sur mobile.  
- 💻 **Langage de programmation** : *C#*, offrant une bonne gestion des objets et une intégration native avec Unity.  
- 🛠 **IDE recommandé** :  
  - *Visual Studio* pour son intégration avec Unity.  
  - *JetBrains Rider* pour son analyse avancée du code et ses outils de refactoring.  
- 🔄 **Système de versioning** :  
  - Utilisation de *Git* (*GitHub* ou *GitLab*) pour la gestion collaborative et le suivi des versions.  
- ☁ **Services tiers intégrés** :  
  - *Firebase* (optionnel) pour **l’analyse et la sauvegarde cloud**.  
  - *Unity Ads & IAP* pour **la monétisation via publicités et achats intégrés**.  

---

### 🔹 Avantages de cette Approche :  
✔ **Fiabilité du code** grâce aux tests automatisés et au TDD.  
✔ **Développement optimisé** avec des outils performants et adaptés.  
✔ **Collaboration fluide** via un système de versioning clair et structuré.  
✔ **Sauvegarde et monétisation efficaces** grâce aux services tiers intégrés.  

En combinant **tests rigoureux**, **environnement de développement bien structuré**, et **gestion optimisée des ressources**, *Frog’s* garantit **une expérience fluide et évolutive** sur mobile. 🐸  


## 9. Outils, Environnement et Déploiement  

### 9.1 Outils de Développement  

Le jeu est conçu en utilisant une **stack technologique optimisée** pour assurer **performance et flexibilité** :  

- 🎮 **Moteur de jeu** : *Unity*, pour ses capacités d’optimisation mobile et sa gestion avancée des assets.  
- 💻 **Langage de programmation** : *C#*, pour sa compatibilité avec Unity et sa gestion efficace des objets.  
- 🛠 **Environnements de Développement** :  
  - *Visual Studio* : Intégration native avec Unity et support des plugins.  
  - *JetBrains Rider* : Analyse avancée du code et outils de refactoring performants.  

---

### 9.2 Gestion de Version et Contrôle du Code  

Le projet utilise **Git** (*GitHub* ou *GitLab*) pour un suivi efficace du développement.  

- 🌳 **Branches principales** :  
  - `main` : Version stable et prête pour la mise en production.  
  - `develop` : Branche principale de développement, où sont intégrées les nouvelles fonctionnalités avant validation.  
- 🔄 **Workflow Git** :  
  - Utilisation de branches **feature** pour chaque nouvelle fonctionnalité avant intégration dans `develop`.  
  - Revues de code et tests avant toute fusion dans `main`.  

---

## 9.3 Planification et Jalons du Projet  

Le projet suit une **feuille de route claire et structurée** afin d’assurer une progression fluide et une gestion efficace du temps.  

### 📌 Étapes Clés du Développement  

1️⃣ **Phase de Pré-Production** 🎯  
   - Définition des **mécaniques de jeu** et élaboration des **documents techniques**.  
   - Création des **premiers prototypes** pour valider les concepts.  

2️⃣ **Développement Alpha** 🛠  
   - Implémentation des **fonctionnalités principales**.  
   - Premiers tests unitaires et validation des modules de base.  

3️⃣ **Phase Bêta** 🔄  
   - Intégration des **tests d’interaction et de performance**.  
   - Amélioration du gameplay et correction des erreurs majeures.  

4️⃣ **Lancement Soft** 🚀  
   - Mise en ligne **restreinte** pour tester le jeu sur un **échantillon de joueurs**.  
   - Ajustements basés sur les retours avant le lancement global.  

5️⃣ **Sortie Officielle** 🌍  
   - **Déploiement du jeu** sur iOS et Android.  
   - Campagne de communication pour assurer une bonne visibilité.  

6️⃣ **Suivi Post-Lancement** 🔧  
   - **Maintenance régulière** et correction des bugs restants.  
   - Ajouts de **nouveaux contenus** et fonctionnalités via des mises à jour.  

---

### 🔹 Avantages de cette Organisation :  
✔ **Développement fluide** avec un cycle structuré.  
✔ **Déploiement progressif** pour minimiser les risques techniques.  
✔ **Support et mises à jour continues** pour assurer l’évolution du jeu.  
✔ **Gestion optimisée du code** via Git et des environnements bien définis.  

Avec cette approche, notre jeu *Frog’s* est garantit d'avoir **une production efficace**, un **lancement maîtrisé**, et **un suivi post-lancement rigoureux** pour une expérience de jeu toujours plus appreciee par nos joueurs ! 🐸  

