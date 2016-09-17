using System.Collections.Generic;
using Assets.Scripts.Resources;
using UnityEngine;

namespace Assets.Scripts {
    public abstract class Vehicle : MonoBehaviour {
        // Use this for initialization
        private int _maxSpeed;
        private int _currentSpeed;
        private List<Resource> load = new List<Resource>();
        private int _weightCapacity;
        private int _volumeCapacity;
        private MovementEnvironment _environment;
        private List<Resource> cost = new List<Resource>();
        private Quality _quality;
        private Resource _fuel;
        private int _burning;
        private Vector3 _destination;
        private bool _moving = false;

        protected virtual void Start() {
           
        }

        

        public int GetSpeed()
        {
            return _maxSpeed;
        }
        public int GetWeightCapacity()
        {
            return _weightCapacity;
        }
        public int GetVolumeCapacity()
        {
            return _volumeCapacity;
        }

        public virtual void StartMoving(Vector3 destination)
        {
            _moving = true;
            this._destination = destination;
        }

        public virtual bool CloseEnough()
        {
            return true;
        }

        public virtual void Move()
        {
            if (!_moving) return;
            
            if(CloseEnough())
            {
                _moving = false;
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
