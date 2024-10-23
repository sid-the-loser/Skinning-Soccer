using UnityEngine;

namespace Sid.Scripts.Main_Menu
{
    public class MenuManager : MonoBehaviour
    {
        [SerializeField] private int currentMenuIndex;
        [SerializeField] private GameObject[] menuGameObjects;

        public void SetCurrentMenuIndex(int currentIndex)
        {
            currentMenuIndex = currentIndex;
        }

        private void UpdateCurrentMenu()
        {
            
            foreach (var menu in menuGameObjects)
            {
                menu.SetActive(false);
            }
            
            menuGameObjects[currentMenuIndex].SetActive(true);
            
        }
    }
}
