using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace transport {
    public abstract class Vehicle : MonoBehaviour {
        // Use this for initialization
        private int max_speed;
        private int current_speed;
        private List<Resource> load = new List<Resource>();
        private int weight_capacity;
        private int volume_capacity;
        private MovementEnvironment environment;
        private List<Resource> cost = new List<Resource>();
        private Quality quality;
        private Resource fuel;
        private int burning;
        private Vector3 destination;
        private bool moving = false;

        protected virtual void Start() {
           
        }

        

        public int GetSpeed()
        {
            return max_speed;
        }
        public int GetWeightCapacity()
        {
            return weight_capacity;
        }
        public int GetVolumeCapacity()
        {
            return volume_capacity;
        }

        public virtual void StartMoving(Vector3 destination)
        {
            moving = true;
            this.destination = destination;
        }

        public virtual bool CloseEnough()
        {
            return true;
        }

        public virtual void Move()
        {
            if (!moving) return;
            
            if(CloseEnough())
            {
                moving = false;
                return;
            }


            
        }

        public virtual void Load(List<Resource> package)
        {

        }

        public virtual void Maintain()
        {

        }

    }
}
