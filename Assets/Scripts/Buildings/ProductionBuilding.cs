using System.Collections;
using Assets.Scripts.Resources;
using Assets.Scripts.Utils;
using UnityEngine;

namespace Assets.Scripts.Buildings {
    /// <summary>
    /// General class of buildings that processes one set of resources and yield another
    /// </summary>
    public class ProductionBuilding : Building {
        /// <summary>
        /// The resource used as base for creating something new
        /// </summary>
        private Resource _prefabricate;

        /// <summary>
        /// The resource that is output from this building
        /// </summary>
        private Resource _produced;

        /// <summary>
        /// How long does production take (seconds)
        /// </summary>
        private int _processTime = 30;

        /// <summary>
        /// How much of produced resource is given in one cycle
        /// </summary>
        private int _efficiency = 1;

        public override void Start() {
            MySize = BuildingSize.Big;
            base.Start();

            _prefabricate = new Resource("stone", 10);
            _produced = new Resource("coal", 0);

            StartCoroutine("Work");
        }

        public IEnumerator Work() {
            while (true) {
                // If there is enough material to process
                if (_prefabricate.GetQuantity() > 0) {
                    Process();
                }
                yield return new WaitForSeconds(_processTime);
            }
        }

        private void Process() {
            // change prefabricate into produced good
            _prefabricate -= _efficiency;
            _produced += _efficiency;
        }
    }
}