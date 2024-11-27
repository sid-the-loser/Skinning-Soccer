using System;
using Sid.Scripts.Skin_Handler;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

namespace Sid.Scripts.Gameplay.Ball
{
    public class BallLogic : MonoBehaviour
    {
        [SerializeField] private float maxVelocity = 2f;
        
        private Vector3 _startingPos;

        private Rigidbody _rb;
        
        private void Start()
        {
            _rb = GetComponent<Rigidbody>();
            
            _startingPos = transform.position;
            
            if (SkinHandler.BallMaterialsList is not null)
            {
                if (SkinHandler.BallMaterialsList.Length > 0)
                {
                    GetComponent<Renderer>().material = SkinHandler.BallMaterialsList[SkinHandler.BallMaterialIndex];
                }
            }
        }

        void FixedUpdate()
        {
            if (_rb.velocity.magnitude > maxVelocity)
            {
                _rb.velocity = _rb.velocity.normalized * maxVelocity;
            }
        }

        private void Update()
        {
            if (transform.position.y < -10)
            {
                _rb.isKinematic = true;
                transform.position = _startingPos;
                _rb.isKinematic = false;
            }
        }
    }
}
