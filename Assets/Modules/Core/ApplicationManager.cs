using System;
using Game.GamePlay;
using Game.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.Core
{
    public static class ApplicationManager
    {
        static ApplicationManager()
        { 
            SceneManager.sceneLoaded += OnSceneLoaded; 
        }

        public static void OpenMainMenu()
        {
            //SceneManager.LoadScene(ScenesConfig.MeinMenuScene, LoadSceneMode.Additive);
            
            SceneManager.LoadSceneAsync(ScenesConfig.MeinMenuScene, LoadSceneMode.Additive);
            Time.timeScale = 0f;
        }

        public static void StartGame()
        {
            SceneManager.LoadScene (ScenesConfig.FirstGameLevel, LoadSceneMode.Additive);
            //SceneManager.LoadSceneAsync(ScenesConfig.FirstGameLevel, LoadSceneMode.Additive);
            SceneManager.LoadSceneAsync(ScenesConfig.InGameMenu, LoadSceneMode.Additive);
            SceneManager.UnloadSceneAsync(ScenesConfig.MeinMenuScene);
        }

        public static void BackToMainMenu()
        {
            SceneManager.UnloadSceneAsync(ScenesConfig.FirstGameLevel);
            SceneManager.UnloadSceneAsync(ScenesConfig.InGameMenu );
            SceneManager.LoadSceneAsync(ScenesConfig.MeinMenuScene, LoadSceneMode.Additive);
        }

        public static void BackToMainMenuFromInGameMenu()
        {
          

            Game.GamePlay.GameScoreManager.OnGameSessionOver();
   



            SceneManager.UnloadSceneAsync(ScenesConfig.FirstGameLevel );
            SceneManager.UnloadSceneAsync(ScenesConfig.InGameMenu);
            SceneManager.LoadSceneAsync(ScenesConfig.MeinMenuScene, LoadSceneMode.Additive);
             // GamePlay.GameServices.services.Clear();
             Game.GamePlay.GamePlayController.DeactivateServices();
        }


        private static void OnSceneLoaded(Scene scene, LoadSceneMode arg1)
        {
            switch (scene.name)
            {
                case ScenesConfig.MeinMenuScene:
                    var controllerGameObject = scene.GetRootGameObjects()[0];
                    var mainMenuView = controllerGameObject.GetComponent<IMainMenuView>();

                    OnMainMenuLoaded(mainMenuView);
                    break;

                case ScenesConfig.InGameMenu:
                    var inGameMenuViewGameObject = scene.GetRootGameObjects()[0];
                    var inGameMenuView = inGameMenuViewGameObject.GetComponent<IInGameMenuView>();

                    OnInGameMenuLoaded(inGameMenuView);
                    break;
                case ScenesConfig.FirstGameLevel:
                  
                    
                    break;

                default:
                    throw new InvalidOperationException($"Unknown Scene loaded: {scene.name}");
            }
        }

        private static void OnInGameMenuLoaded(IInGameMenuView inGameMenuView)
        {  
            inGameMenuView.OnBackToMenuRequested += () =>
            {

              
                BackToMainMenuFromInGameMenu();
        }; 
        }

        private static void OnMainMenuLoaded(IMainMenuView mainMenuView)
        {
            mainMenuView.OnStartButtonPressed += StartGame;
            mainMenuView.OnQuitButtonPressed += QuitGame;
        }

        private static void QuitGame()
        {
            Application.Quit();
        }
    }
}
