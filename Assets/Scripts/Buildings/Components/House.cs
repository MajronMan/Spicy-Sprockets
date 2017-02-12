using Assets.Scripts.Game_Controllers;
using UnityEngine;

namespace Assets.Scripts.Buildings.Components {
    public sealed class House : MonoBehaviour, IHouse {
        public int PeopleLimitIncrease { get; set; }

        public void Start() {
            //todo inject
            PeopleLimitIncrease = 10;
            Controllers.CurrentInfo.ChangePopulationLimit(PeopleLimitIncrease);
        }
    }
}