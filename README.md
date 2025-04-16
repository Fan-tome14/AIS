# AloneInSpace - Instructions pour lancer le jeu sur votre casque VR


**Sommaire**

* [Prérequis](#prérequis)
* [Étapes pour construire et lancer le jeu](#étapes-pour-construire-et-lancer-le-jeu)
* [Avertissements Importants](#avertissements-importants)

## Prérequis

* **Meta Quest Developer Hub :** Assurez-vous que le logiciel Meta Quest Developer Hub est installé sur votre ordinateur.
* **Casque VR Connecté :** Votre casque Meta Quest doit être allumé et connecté à votre ordinateur à l'aide d'un câble USB.
* **Unity :** Le projet AloneInSpace doit être ouvert dans l'éditeur Unity sur votre ordinateur.

## Étapes pour construire et lancer le jeu

1.  **Ouvrir Meta Quest Developer Hub :**
    * Lancez l'application Meta Quest Developer Hub sur votre ordinateur. Vous la trouverez probablement dans votre menu Démarrer (sur Windows) ou dans vos Applications (sur Mac).

2.  **Connecter votre casque :**
    * Si votre casque est correctement connecté et allumé, il devrait apparaître dans la fenêtre du Developer Hub. Assurez-vous qu'il est bien reconnu comme un appareil connecté.

3.  **Configurer le Build pour Android dans Unity :**
    * Retournez à la fenêtre de votre projet AloneInSpace dans l'éditeur Unity.
    * Dans la barre de menu en haut d'Unity, cliquez sur **File** (Fichier).
    * Dans le menu déroulant, sélectionnez **Build Settings...** (Paramètres de construction...).
    * Dans la fenêtre "Build Settings", sur la gauche, choisissez **Android**.
    * Si Android n'est pas déjà sélectionné comme plateforme, cliquez sur le bouton **Switch Platform** (Changer de plateforme) en bas à droite. Unity va alors configurer le projet pour Android, ce qui peut prendre un petit moment.

4.  **Vérifier l'ordonnancement des scènes :**
    * Toujours dans la fenêtre "Build Settings", regardez la liste des **Scenes In Build** (Scènes dans la construction). Assurez-vous que toutes les scènes de notre jeu y sont présentes et qu'elles sont dans le bon ordre. Vous pouvez ajouter des scènes en les faisant glisser depuis la fenêtre "Project" (Projet) vers cette liste, et vous pouvez changer leur ordre en les faisant glisser vers le haut ou le bas.

5.  **Construire et Lancer (Build and Run) :**
    * Une fois que la plateforme Android est sélectionnée et que les scènes sont vérifiées, cliquez sur le bouton **Build And Run** (Construire et Lancer) en bas de la fenêtre "Build Settings".
    * Unity va alors commencer à construire le jeu pour votre casque. Vous devrez choisir un nom pour le fichier de construction et l'endroit où l'enregistrer sur votre ordinateur (ce n'est pas le fichier qui ira directement sur le casque, mais un fichier intermédiaire).
    * Une fois la construction terminée, Unity va automatiquement essayer d'installer et de lancer le jeu sur votre casque connecté via le Developer Hub.

6.  **Profiter du jeu !**
    * Si tout s'est bien passé, vous devriez voir AloneInSpace se lancer directement dans votre casque VR. Amusez-vous bien !

Si vous rencontrez des problèmes, n'hésitez pas à en parler à l'équipe pour qu'on puisse s'entraider ! Bon développement !

## Avertissements Importants

* **Scripts Sensibles :** Soyez très prudents lorsque vous modifiez les scripts nommés `checkmission` et `bed`. Changer des choses dans ces scripts pourrait faire que le jeu ne fonctionne plus correctement dès le début. Il est préférable de ne pas les modifier à moins d'être sûr de ce que vous faites.

* **Vérification des Importations :** Pour chaque script que vous utilisez dans Unity, assurez-vous que toutes les "importations" nécessaires sont bien connectées directement dans l'éditeur Unity. Les importations sont comme des liens vers d'autres outils ou fonctions dont le script a besoin pour marcher. Si ces liens ne sont pas corrects, le script pourrait ne pas fonctionner comme prévu. Vérifiez bien cela !
