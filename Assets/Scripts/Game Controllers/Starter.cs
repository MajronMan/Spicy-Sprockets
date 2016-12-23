using UnityEngine;

namespace Assets.Scripts.Game_Controllers
{
    public class Starter : MonoBehaviour {
        // Fucking static methods
        public void Start()
        {
            var unused = Controllers.GameController.transform;
        }
    }
}