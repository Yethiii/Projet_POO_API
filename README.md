# 📌 Projet_POO_API  

Ce projet est une application en **C#** et **Blazor WebAssembly** qui utilise l'API [Open Trivia Database](https://opentdb.com/) pour récupérer et afficher des quiz interactifs.  

---

## 🚀 Fonctionnalités  

✅ Récupération des quiz depuis l’API  
✅ Affichage des questions avec choix multiples  
✅ Ajout des quiz aux favoris (stockage local)  
✅ Sélection des catégories et niveaux de difficulté  

---

## 🛠️ Installation et exécution  

### 1⃣ Cloner le projet  
```bash  
git clone https://github.com/ton-repo/Projet_POO_API.git  
cd Projet_POO_API  
```

### 2⃣ Ouvrir dans un IDE  
Ouvrir le projet dans **Rider**, **Visual Studio**, ou **VS Code**.  

### 3⃣ Lancer l’application  
```bash  
dotnet run  
```

---

## 📂 Structure du projet  

- **`Services/TriviaAPIService.cs`** → Connexion et récupération des données de l’API  
- **`Services/FavorisService.cs`** → Gestion des favoris (stockage local)  
- **`Pages/Quizz.razor`** → Affichage du quiz et gestion des réponses  

---

## 🌍 Utilisation de l'API  

L’application interroge l’API Open Trivia Database pour obtenir des questions de quiz.  
Voici un exemple de requête générée :  
```
https://opentdb.com/api.php?amount=10&category=9&difficulty=medium&type=multiple
```

---

## ✅ Tests unitaires  

Des tests unitaires sont inclus pour valider le bon fonctionnement des services.  

### 📌 Exécuter les tests  
```bash  
dotnet test  
```

### 📋 Scénarios de test  

#### 1⃣ Test de récupération des catégories depuis l'API  
**Étapes :**  
✔ Appeler `GetCategoriesAsync()`  
✔ Vérifier que la réponse contient une liste non vide  

#### 2⃣ Test de génération de l'URL de requête à l'API  
**Étapes :**  
✔ Appeler `GenererUrl("1", "easy", "multiple")`  
✔ Vérifier que `SetupUrl` contient bien l'URL attendue  

#### 3⃣ Test d'ajout d'un quiz aux favoris  
**Étapes :**  
✔ Simuler un `IJSRuntime` avec un Mock  
✔ Appeler `AjouterAuxFavoris()` avec un quiz factice  
✔ Vérifier que `localStorage.setItem` a été appelé une fois  

---

## 🔗 API utilisée  
[Open Trivia Database](https://opentdb.com/)  

---

📝 **Auteur :** Laetitia 
📅 **Dernière mise à jour :** 15 Mars 2025  

