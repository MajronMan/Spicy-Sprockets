using UnityEngine;

namespace Assets.Scripts.Game_Controllers
{
    public class Starter : MonoBehaviour {
        // Fucking static methods
        public void Awake()
        {
            var unused = Controllers.GameController.transform;
        }
    }
}