using System.Collections.Generic;
using Assets.Scripts.Game_Controllers;
using Assets.Scripts.Resources;
using Assets.Scripts.Utils;

namespace Assets.Scripts.Buildings
{
    public class ResidentialBuilding : Building
    {
        public override void Start()
        {
            base.Start();
            Controllers.CurrentInfo.ChangePopulationLimit(10);
        }
    }
}
