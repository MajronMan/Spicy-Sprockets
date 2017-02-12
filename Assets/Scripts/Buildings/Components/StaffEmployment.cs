using Assets.Scripts.Game_Controllers;
using UnityEngine;

namespace Assets.Scripts.Buildings.Components {
    public sealed class StaffEmployment : MonoBehaviour, IStaffEmployment {
        private int _staff;

        public void Start() {
            //todo inject
            MaxStaff = 100;
            MinStaff = 0;
            Staff = 0;
        }

        public int MaxStaff { get; private set; }
        public int MinStaff { get; private set; }

        public int Staff {
            get { return _staff; }
            set {
                if (value < 0 || MaxStaff < value
                    || Controllers.CurrentInfo.ThePeople.Employ(value - Staff)) return;
                _staff = value;
            }
        }

        public bool IsEnoughStaff() {
            return Staff >= MinStaff;
        }
    }
}