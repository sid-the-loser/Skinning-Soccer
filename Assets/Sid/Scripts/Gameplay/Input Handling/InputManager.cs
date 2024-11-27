using UnityEngine;
using UnityEngine.SceneManagement;

namespace Sid.Scripts.Gameplay.Input_Handling
{
    public class InputManager : MonoBehaviour
    {
        [HideInInspector] public bool escapeToMenu;
        [HideInInspector] public Vector3 wasdVector;
        [HideInInspector] public Vector3 udlrVector;
    
        void Update()
        {
            // escapeToMenu = Input.GetKeyDown(KeyCode.Escape);
            if (Input.GetKeyDown(KeyCode.Escape)) SceneManager.LoadScene("Test Menu"); // for now

            if (Input.GetKey(KeyCode.W)) wasdVector.z = 1;
            else wasdVector.z = 0;
            if (Input.GetKey(KeyCode.A)) wasdVector.x = -1;
            else wasdVector.x = 0;
            if (Input.GetKey(KeyCode.S)) wasdVector.z = -1;
            else if (wasdVector.z == 0) wasdVector.z = 0;
            if (Input.GetKey(KeyCode.D)) wasdVector.x = 1;
            else if (wasdVector.x == 0) wasdVector.x = 0;
        
            if (Input.GetKey(KeyCode.UpArrow)) udlrVector.z = 1;
            else udlrVector.z = 0;
            if (Input.GetKey(KeyCode.DownArrow)) udlrVector.z = -1;
            else if (udlrVector.z == 0) udlrVector.z = 0;
            if (Input.GetKey(KeyCode.LeftArrow)) udlrVector.x = -1;
            else udlrVector.x = 0;
            if (Input.GetKey(KeyCode.RightArrow)) udlrVector.x = 1;
            else if (udlrVector.x == 0) udlrVector.x = 0;

            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                SceneManager.LoadScene("Sid/Scenes/Test Menu");
            }
        }
    }
}
