using System.Collections;
using Assets.Scripts.Game_Controllers;
using Assets.Scripts.Res;
using Assets.Scripts.Utils;
using UnityEngine;

namespace Assets.Scripts.Buildings {
    /// <summary>
    /// General class of buildings that processes one set of resources and yield another
    /// </summary>
    public class ProductionBuilding : Building {
        // TODO: Clean it
        /// <summary>
        /// The resource used as base for creating something new
        /// </summary>
        private Commodity _prefabricate = new Commodity(Controllers.ConstantData.ResourceTypes[0], 100); //so it throws no exception

        /// <summary>
        /// The resource that is output from this building
        /// </summary>
        private Commodity _produced = new Commodity(Controllers.ConstantData.ResourceTypes[0], 100); //so it throws no exception

        /// <summary>
        /// How long does production take (seconds)
        /// </summary>
        private int _processTime = 30;

        /// <summary>
        /// How much of produced resource is given in one cycle
        /// </summary>
        private int _efficiency = 1;

        public override void Start() {
            Size = BuildingSize.Big;
            base.Start();

            StartCoroutine(Work());
        }

        public IEnumerator Work() {
            while (true) {
                // If there is enough material to process
                if (_prefabricate.Amount > 0) {
                    Process();
                }
                yield return new WaitForSeconds(_processTime);
            }
        }

        private void Process() {
            // change prefabricate into produced good
            _prefabricate.Sub(_efficiency);
            _produced.Add(_efficiency);
        }
    }
}