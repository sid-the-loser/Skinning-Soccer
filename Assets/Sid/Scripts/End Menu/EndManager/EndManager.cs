using System;
using Sid.Scripts.Gameplay.Winning_Handler;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Sid.Scripts.End_Menu.EndManager
{
    public class EndManager : MonoBehaviour
    {

        [SerializeField] private TextMeshProUGUI _textMeshProUGUI;
        
        public void MainMenuButton()
        {
            SceneManager.LoadScene("Sid/Scenes/Test Menu");
        }

        private void Start()
        {
            _textMeshProUGUI.text = "Player " + WonHandler.WhoWon;
        }
    }
}
