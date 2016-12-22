using System.Collections.Generic;
using Assets.Scripts.Dialogues;
using UnityEngine;
using Assets.Scripts.Interface;
using Assets.Static;

namespace Assets.Scripts.Dialogues
{
    public class Dialogue : MonoBehaviour
    {
        
        //change to character class
        private string _character;
        private string[] dOptions;
        
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void showDialog()
        {
            var dialougeGameObject = Instantiate(Prefabs.DialogueBox);

        }
    }


}

