using UnityEngine;

namespace Assets.Scripts.Interface
{
    public class ToggleLocalMap : MonoBehaviour
    {
        public void Toggle()
        {
            gameObject.SetActive(!gameObject.activeInHierarchy);
        }
    }
}