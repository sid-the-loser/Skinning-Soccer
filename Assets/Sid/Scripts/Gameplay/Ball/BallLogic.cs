using Sid.Scripts.Skin_Handler;
using UnityEngine;

namespace Sid.Scripts.Gameplay.Ball
{
    public class BallLogic : MonoBehaviour
    {
        private void Start()
        {
            if (SkinHandler.MaterialsList is not null)
            {
                if (SkinHandler.MaterialsList.Length > 0)
                {
                    GetComponent<Renderer>().material = SkinHandler.MaterialsList[SkinHandler.BallMaterialIndex];
                }
            }
        }
    }
}
