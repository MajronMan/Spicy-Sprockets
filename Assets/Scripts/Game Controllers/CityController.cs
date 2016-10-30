using System.Collections.Generic;
using Assets.Scripts.Interface;
using Assets.Scripts.Sources_of_Resources;
using Assets.Scripts.Utils;
using UnityEditor;
using UnityEngine;
using UnityEngine.SocialPlatforms;

namespace Assets.Scripts.Game_Controllers
{
    public class CityController : MonoBehaviour
    {
        public Map MapInstance;
        private BuildingManager _buildingManagerInstance;
        public Info MyInfo;
        private IntVector2 _mapSize = new IntVector2(10000, 10000);
        public List<Source> Sources = new List<Source>();

        public void BeginGame(Map mapPrefab)
        {
            
            var mapPosition = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width/2, Screen.height/2));
            mapPosition.z = 0;
            MapInstance = Instantiate(mapPrefab, mapPosition, transform.rotation) as Map;
            MapInstance.transform.SetParent(transform);
            Util.Rescale(MapInstance.GetComponent<SpriteRenderer>(), _mapSize.x, _mapSize.y);
            MapInstance.name = "Map";
            var newGameObject = new GameObject("Building Manager", typeof(BuildingManager));
            _buildingManagerInstance = newGameObject.GetComponent<BuildingManager>();
            _buildingManagerInstance.transform.SetParent(transform);
            _buildingManagerInstance.SetMapInstance(MapInstance);
            MyInfo = new Info();
            CreateSources();
        }

        public BuildingManager GetBuildingManager()
        {
            return _buildingManagerInstance;
        }

        public void CreateSources()
        {
            Sprite sourceSprite = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/Graphics/Buildings/Source.png");
            var mrenderer = MapInstance.GetComponent<Renderer>();
            var xmax = mrenderer.bounds.size.x/2;
            var ymax = mrenderer.bounds.size.y/2;
            for (var i = 0; i < 20; i++)
            {
                var go = new GameObject("Source " + i);
                Sources.Add(go.AddComponent<Source>());
                var srenderer = go.AddComponent<SpriteRenderer>();
                srenderer.sprite = sourceSprite;
                srenderer.sortingOrder = 1;
                Util.Rescale(srenderer, 50, 50);
                go.transform.SetParent(MapInstance.transform);
                go.transform.localPosition = new Vector3(xmax, ymax, 0);
                var x = Random.Range(-xmax, xmax);
                var y = Random.Range(-ymax, ymax);
                go.transform.Translate(x, y, 0);
            }
        }
    }
}
