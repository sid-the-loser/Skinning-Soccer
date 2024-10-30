using UnityEngine;
using UnityEngine.SceneManagement;

namespace Sid.Scripts.Gameplay.Winning_Handler
{
    public class PostDetection : MonoBehaviour
    {
        [SerializeField] private int whoWins = 1;

        private void OnTriggerEnter(Collider other)
        {
            WonHandler.WhoWon = whoWins;
            SceneManager.LoadScene("Sid/Scenes/Ending");
        }
    }
}
