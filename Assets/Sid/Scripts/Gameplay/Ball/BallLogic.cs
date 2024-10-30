using Sid.Scripts.Skin_Handler;
using UnityEngine;

namespace Sid.Scripts.Gameplay.Ball
{
    public class BallLogic : MonoBehaviour
    {
        private void Start()
        {
            if (SkinHandler.BallMaterialsList is not null)
            {
                if (SkinHandler.BallMaterialsList.Length > 0)
                {
                    GetComponent<Renderer>().material = SkinHandler.BallMaterialsList[SkinHandler.BallMaterialIndex];
                }
            }
        }
    }
}
