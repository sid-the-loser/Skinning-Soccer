using Sid.Scripts.Gameplay.Input_Handling;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Sid.Scripts.Gameplay.Player
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private InputManager inputManager;
        [SerializeField] private bool useWasd;
    
        [SerializeField] private float speed = 1;

        private Rigidbody _rb;

        private void Start()
        {
            _rb = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            var currentVel = Vector3.zero;
            
            if (useWasd)
            {
                currentVel = inputManager.wasdVector.normalized * (speed * Time.deltaTime);
            }
            else
            {
                currentVel = inputManager.udlrVector.normalized * (speed * Time.deltaTime);
            }

            _rb.velocity = currentVel;
        }
    }
}
