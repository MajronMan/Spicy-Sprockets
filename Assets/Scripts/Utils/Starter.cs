using Assets.Scripts.Game_Controllers;
using UnityEngine;

namespace Assets.Scripts.Utils
{
    /// <summary>
    /// I don't know how to create Controllers static class instance in other way, so...
    /// </summary>
    public class Starter : MonoBehaviour {

        public void Start () {
	        Controllers.Begin();
            Destroy(gameObject);
        }
    }
}
