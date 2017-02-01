using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Interface
{
    public class ExitablePanel: MonoBehaviour
    {
        private GameObject _content;
        public GameObject Content {
            get { return _content; }
            set
            {
                if (_content == null)
                        _content = value;
            }
        }
    }
}
