using System;
using Sid.Scripts.Skin_Handler;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Sid.Scripts.Main_Menu
{
    public class MenuManager : MonoBehaviour
    {
        [SerializeField] private int currentMenuIndex;
        [SerializeField] private GameObject[] menuGameObjects;
        [SerializeField] private Material[] materialsList;

        [SerializeField] private GameObject ballGameObject;

        private void OnEnable()
        {
            SkinHandler.MaterialsList = materialsList;
        }

        private void Start()
        {
            UpdateCurrentMenu();
            UpdateBallMaterial();
        }
        
        #region General
        
        public void SetCurrentMenuIndex(int currentIndex)
        {
            currentMenuIndex = currentIndex;
            UpdateCurrentMenu();
        }

        private void UpdateCurrentMenu()
        {
            
            foreach (var menu in menuGameObjects)
            {
                menu.SetActive(false);
            }
            
            menuGameObjects[currentMenuIndex].SetActive(true);
            
        }
        
        #endregion

        #region Main Menu

        public void QuitButtonLogic()
        {
            Application.Quit();
        }

        #endregion

        #region Skin Select
        
        public void BallSkinNextButtonLogic()
        {
            SkinHandler.BallMaterialIndex += 1;
            if (SkinHandler.BallMaterialIndex >= SkinHandler.MaterialsList.Length)
            {
                SkinHandler.BallMaterialIndex = 0;
            }
            UpdateBallMaterial();
        }
        
        public void BallSkinPreviousButtonLogic()
        {
            SkinHandler.BallMaterialIndex -= 1;
            if (SkinHandler.BallMaterialIndex < 0)
            {
                SkinHandler.BallMaterialIndex = SkinHandler.MaterialsList.Length - 1;
            }
            UpdateBallMaterial();
        }

        private void UpdateBallMaterial()
        {
            ballGameObject.GetComponent<Renderer>().material = SkinHandler.MaterialsList[SkinHandler.BallMaterialIndex];
        }
        
        #endregion
        
        #region Timer Select

        public void StartPlayingGame()
        {
            SceneManager.LoadScene("Test Scene");
        }
        
        #endregion
    }
}
