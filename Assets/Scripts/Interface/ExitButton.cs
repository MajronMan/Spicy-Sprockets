using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.Scripts.Interface
{
    public class ExitButton : Button
    {
        protected override void Start()
        {
            base.Start();
            onClick.AddListener(() => transform.parent.gameObject.SetActive(false));
        }
    }
}
