using System.Xml.Serialization;
using Assets.Scripts.Buildings;
using UnityEngine;

namespace Assets.Scripts.Data
{
    public class BuildingData{

        [XmlAttribute("Name")]
        public string Name;

        [XmlElement("PosX")]
        public float PosX;

        [XmlElement("PosY")]
        public float PosY;

        [XmlElement("PosZ")]
        public float PosZ;


        public static BuildingData NewData(Building building){
            BuildingData data = new BuildingData();
            data.Name = "1";
            Vector3 pos = building.transform.position;
            data.PosX = pos.x;
            data.PosY = pos.y;
            data.PosZ = pos.z;
            return data;
        }
    }
}