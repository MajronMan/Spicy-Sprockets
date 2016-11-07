using UnityEngine;

namespace Assets.Scripts.Interface
{
    //que que
    public class ToggleLocalMap : MonoBehaviour
    {
        public void Toggle()
        {
            gameObject.SetActive(!gameObject.activeInHierarchy);
        }
    }
}