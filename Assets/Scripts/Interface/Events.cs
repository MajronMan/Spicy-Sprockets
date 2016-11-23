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
        private int _numberofevents = 0;
        private GameObject eventInstance; //Have to pass the reference to News method

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

            eventInstance = Instantiate(EventPrefab); //New instance of event panel
            eventInstance.transform.SetParent(transform, false); //Somehow it sets prefab position where it used to be when it was GameObject
            eventInstance.name = "EventPanel";

            //TODO: Here there would be reading information from a file and loading it into panel elements like text, title and image

            //TODO: Here there would be reading button options from file and also creating earlier defined amount of options
            //for(int i=1, i<=options i++){}
            GameObject optionInstance = Instantiate(EventbuttonPrefab); //New instance of event option button
            optionInstance.transform.SetParent(eventInstance.transform.Find("Options"), false);
            optionInstance.transform.localPosition = new Vector3(0, 0, 0);
            optionInstance.name = "Option";
            optionInstance.GetComponent<Button>().onClick.AddListener(() => { Destroy(eventInstance); SetEventFalse(); }); //On click function which closes event for now

            //This fragment is just temporary
            GameObject optionInstance1 = Instantiate(EventbuttonPrefab); //New instance of event option button
            optionInstance1.transform.SetParent(eventInstance.transform.Find("Options"), false);
            optionInstance1.transform.localPosition = new Vector3(0, 50, 0);
            optionInstance1.name = "Option1";

            GameObject optionInstance2 = Instantiate(EventbuttonPrefab); //New instance of event option button
            optionInstance2.transform.SetParent(eventInstance.transform.Find("Options"), false);
            optionInstance2.transform.localPosition = new Vector3(0, -50, 0);
            optionInstance2.name = "Option2";

            _numberofevents++;
            News();
        }

        /// <summary>
        /// A method used to save last events to the newspaper in the info panel
        /// </summary>
        public void News() //It's just a stub
        {
            //TODO: There should also be something about destroying option prefabs etc.
            //TODO: And scaling the shit out of it because it looks terrible in the newspaper menu, maybe something with transform.localScale
            //TODO: Also I wrote here some constant values, should change it I think
            //TODO: And try to think what happens when more than 6 events have occured already
            switch (_numberofevents)
            {
                case 1:
                    GameObject newsInstance1 = Instantiate(eventInstance) as GameObject;
                    newsInstance1.transform.SetParent(Content.transform, false);
                    newsInstance1.transform.localPosition = new Vector3(-500, 450, 0);
                    newsInstance1.name = "News1";
                    break;
                case 2:
                    GameObject newsInstance2 = Instantiate(eventInstance) as GameObject;
                    newsInstance2.transform.SetParent(Content.transform, false);
                    newsInstance2.transform.localPosition = new Vector3(0, 450, 0);
                    newsInstance2.name = "News2";
                    break;
                case 3:
                    GameObject newsInstance3 = Instantiate(eventInstance) as GameObject;
                    newsInstance3.transform.SetParent(Content.transform, false);
                    newsInstance3.transform.localPosition = new Vector3(500, 450, 0);
                    newsInstance3.name = "News3";
                    break;
                case 4:
                    GameObject newsInstance4 = Instantiate(eventInstance) as GameObject;
                    newsInstance4.transform.SetParent(Content.transform, false);
                    newsInstance4.transform.localPosition = new Vector3(-500, -450, 0);
                    newsInstance4.name = "News4";
                    break;
                case 5:
                    GameObject newsInstance5 = Instantiate(eventInstance) as GameObject;
                    newsInstance5.transform.SetParent(Content.transform, false);
                    newsInstance5.transform.localPosition = new Vector3(0, -450, 0);
                    newsInstance5.name = "News5";
                    break;
                case 6:
                    GameObject newsInstance6 = Instantiate(eventInstance) as GameObject;
                    newsInstance6.transform.SetParent(Content.transform, false);
                    newsInstance6.transform.localPosition = new Vector3(500, -450, 0);
                    newsInstance6.name = "News6";
                    break;
                default:                   
                    break;
            }
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
