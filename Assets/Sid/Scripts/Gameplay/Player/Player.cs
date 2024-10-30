using Sid.Scripts.Gameplay.Input_Handling;
using Sid.Scripts.Skin_Handler;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Sid.Scripts.Gameplay.Player
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private InputManager inputManager;
        [SerializeField] private bool useWasd;
    
        [SerializeField] private float speed = 100;

        [SerializeField] private GameObject[] materialObjects;

        private Material[] _myMaterialList;
        private int _myMaterialIndex;
        
        private Rigidbody _rb;

        private void Start()
        {
            _rb = GetComponent<Rigidbody>();

            _myMaterialList = useWasd ? SkinHandler.Player1MaterialList : SkinHandler.Player2MaterialList;
            _myMaterialIndex = useWasd ? SkinHandler.Player1MaterialIndex : SkinHandler.Player2MaterialIndex;
            
            if (_myMaterialList is not null)
            {
                if (_myMaterialList.Length > 0)
                {
                    foreach (var obj in materialObjects)
                    {
                        obj.GetComponent<Renderer>().material = _myMaterialList[_myMaterialIndex];
                    }
                }
            }
        }

        private void FixedUpdate()
        {
            Vector3 currentVel;
            
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
