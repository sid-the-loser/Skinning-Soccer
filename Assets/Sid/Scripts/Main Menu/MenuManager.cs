using System;
using Sid.Scripts.Skin_Handler;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

namespace Sid.Scripts.Main_Menu
{
    public class MenuManager : MonoBehaviour
    {
        [SerializeField] private int currentMenuIndex;
        [SerializeField] private GameObject[] menuGameObjects;
        [SerializeField] private Material[] ballMaterialsList;
        [SerializeField] private Material[] player1MaterialsList;
        [SerializeField] private Material[] player2MaterialsList;

        [SerializeField] private GameObject ballGameObject;
        [SerializeField] private GameObject[] player1GameObject;
        [SerializeField] private GameObject[] player2GameObject;

        private void OnEnable()
        {
            SkinHandler.BallMaterialsList = ballMaterialsList;
            SkinHandler.Player1MaterialList = player1MaterialsList;
            SkinHandler.Player2MaterialList = player2MaterialsList;
        }

        private void Start()
        {
            UpdateCurrentMenu();
            UpdatePlaceholderMaterials();
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

        #region Ball Skin Select
        
        public void BallSkinNextButtonLogic()
        {
            SkinHandler.BallMaterialIndex += 1;
            if (SkinHandler.BallMaterialIndex >= SkinHandler.BallMaterialsList.Length)
            {
                SkinHandler.BallMaterialIndex = 0;
            }
            UpdatePlaceholderMaterials();
        }
        
        public void BallSkinPreviousButtonLogic()
        {
            SkinHandler.BallMaterialIndex -= 1;
            if (SkinHandler.BallMaterialIndex < 0)
            {
                SkinHandler.BallMaterialIndex = SkinHandler.BallMaterialsList.Length - 1;
            }
            UpdatePlaceholderMaterials();
        }
        
        #endregion
        
        #region Player 1 Skin Select

        public void Player1SkinNextButton()
        {
            SkinHandler.Player1MaterialIndex += 1;
            if (SkinHandler.Player1MaterialIndex >= SkinHandler.Player1MaterialList.Length)
            {
                SkinHandler.Player1MaterialIndex = 0;
            }
            UpdatePlaceholderMaterials();
        }
        
        public void Player1SkinPreviousButton()
        {
            SkinHandler.Player1MaterialIndex -= 1;
            if (SkinHandler.Player1MaterialIndex < 0)
            {
                SkinHandler.Player1MaterialIndex = SkinHandler.Player1MaterialList.Length - 1;
            }
            UpdatePlaceholderMaterials();
        }
        
        #endregion
        
        #region Player 2 Skin Select

        public void Player2SkinNextButton()
        {
            SkinHandler.Player2MaterialIndex += 1;
            if (SkinHandler.Player2MaterialIndex >= SkinHandler.Player2MaterialList.Length)
            {
                SkinHandler.Player2MaterialIndex = 0;
            }
            UpdatePlaceholderMaterials();
        }
        
        public void Player2SkinPreviousButton()
        {
            SkinHandler.Player2MaterialIndex -= 1;
            if (SkinHandler.Player2MaterialIndex < 0)
            {
                SkinHandler.Player2MaterialIndex = SkinHandler.Player2MaterialList.Length - 1;
            }
            UpdatePlaceholderMaterials();
        }
        
        #endregion
        
        private void UpdatePlaceholderMaterials()
        {
            ballGameObject.GetComponent<Renderer>().material = SkinHandler.BallMaterialsList[SkinHandler.BallMaterialIndex];
            foreach (var obj in player1GameObject)
            {
                obj.GetComponent<Renderer>().material = SkinHandler.Player1MaterialList[SkinHandler.Player1MaterialIndex];
            }
            
            foreach (var obj in player2GameObject)
            {
                obj.GetComponent<Renderer>().material = SkinHandler.Player2MaterialList[SkinHandler.Player2MaterialIndex];
            }
        }

        #region Level Select

        public void TestSceneButton()
        {
            SceneManager.LoadScene("Sid/Scenes/Test Scene");
        }
        
        public void SandySceneButton()
        {
            SceneManager.LoadScene("Ryan/Scenes/SandyScene");
        }
        
        public void SnowySceneButton()
        {
            SceneManager.LoadScene("Ryan/Scenes/SnowyScene");
        }

        #endregion
    }
}
