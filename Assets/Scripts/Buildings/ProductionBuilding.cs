using System.Collections;
using Assets.Scripts.Game_Controllers;
using Assets.Scripts.Resources;
using Assets.Scripts.Utils;
using UnityEngine;

namespace Assets.Scripts.Buildings
{
    public class ProductionBuilding : Building
    {
        private Resource _prefabricate;
        private Resource _produced;
        private int _processTime = 30;
        private int _efficiency = 1;

        public override void Start()
        {
            MySize = BuildingSize.Big;
            base.Start();

            _prefabricate = new Resource("stone", 10);
            _produced = new Resource("coal", 0);

            StartCoroutine("Work");
        }

        public IEnumerator Work()
        {
            while (true)
            {
                if (_prefabricate.GetQuantity() > 0)
                {
                    Process();
                }
                yield return new WaitForSeconds(_processTime);
            }
        }

        private void Process()
        {
            _prefabricate -= _efficiency;
            _produced += _efficiency;
        }
    }
}
