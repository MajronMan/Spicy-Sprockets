using Assets.Scripts.Buildings;
using UnityEngine;

namespace Assets.Scripts
{
    public class Map : MonoBehaviour
    {
        private StrategyManager _strategyManager;
        public Building BuildingPrefab;

        public void Start()
        {
            Physics.queriesHitTriggers = true;
            _strategyManager = gameObject.transform.parent.GetComponent<StrategyManager>();
        }

        public void OnMouseDown()
        {
            _strategyManager.MapClicked();
        }

        public int objectIndex()
        {
            return gameObject.transform.GetSiblingIndex();
        }
    }
}
