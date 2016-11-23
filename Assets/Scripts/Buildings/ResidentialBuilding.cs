using Assets.Scripts.Game_Controllers;

namespace Assets.Scripts.Buildings {
    /// <summary>
    /// A building that provides housing and increases population limit
    /// </summary>
    public class ResidentialBuilding : Building {
        public override void Start() {
            base.Start();
            //increase the population limit
            Controllers.CurrentInfo.ChangePopulationLimit(10);
        }
    }
}