using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Game_Controllers;
using UnityEngine;

namespace Assets.Scripts.Res {
   

    /// <summary>
    /// People living in a certain city
    /// </summary>
    public class Population : TypelessResource {
        public Population()
        {
            Amount = 100;
        }
    }
}