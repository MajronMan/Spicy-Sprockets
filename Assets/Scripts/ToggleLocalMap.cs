using UnityEngine;
using System.Collections;
public class ToggleLocalMap : MonoBehaviour
{
    public void Toggle()
    {
        if (gameObject.activeInHierarchy)
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
        }
    }
}