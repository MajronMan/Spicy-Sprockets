using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Interface
{
    /// <summary>
    /// Creates random game events
    /// </summary>
    public class Events : MonoBehaviour {

        public GameObject Content;
        private bool _activeEvent;
        public GameObject EventPrefab;
        public GameObject EventbuttonPrefab;

        public void Start ()
        {
            StartCoroutine("GetEvent");
        }

        /// <summary>
        /// Uses Event() method after random amount of time
        /// </summary>
        public IEnumerator GetEvent()
        {
            while (true)
            {
                yield return new WaitForSeconds(new System.Random().Next(60, 120));
                if (_activeEvent == false)
                {
                    Event();
                }
            }
        }

        /// <summary>
        /// A method used to create new event panel from a prefab
        /// </summary>
        void Event()
        {
            _activeEvent = true; //Prevents from opening new event when other is active

            GameObject eventInstance = Instantiate(EventPrefab); //New instance of event panel
            eventInstance.transform.SetParent(transform, false); //Somehow it sets prefab position where it used to be when it was GameObject
            eventInstance.name = "EventPanel";

            //TODO: Here there would be reading information from a file and loading it into panel elements like text, title and image

            //TODO: Here there would be reading button options from file and also creating earlier defined amount of options
            //for(int i=1, i<=options i++){}
            GameObject optionInstance = Instantiate(EventbuttonPrefab); //New instance of event option button
            optionInstance.transform.SetParent(eventInstance.transform.Find("Options"), false);
            optionInstance.name = "Option";
            optionInstance.GetComponent<Button>().onClick.AddListener(() => { Destroy(eventInstance); SetEventFalse(); }); //On click function which closes event for now

            News();
        }

        /// <summary>
        /// A method used to save last events to the newspaper in the info panel
        /// </summary>
        public void News() //It's just a stub
        {
            GameObject newsInstance = Instantiate(EventPrefab) as GameObject;
            newsInstance.transform.SetParent(Content.transform, false);
            newsInstance.name = "News";
        }
        /// <summary>
        /// Used in onClick function, permits to open new event
        /// </summary>
        public void SetEventFalse()
        {
            _activeEvent = false;
        }

    }
}
