using System.Linq;
using Assets.Scripts.Game_Controllers;
using Assets.Scripts.Interface;
using Assets.Scripts.ResourcePools;
using Assets.Scripts.Utils;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Assets.Scripts.MapGenerator {
    /// <summary>
    /// Used to created Resource Pools scattered across local map
    /// </summary>
    public static class SourcesGenerator {
        /// <summary>
        /// Create actual sources
        /// </summary>
        /// <param name="theMap">Instance of map</param>
        public static void Generate(Map theMap) {
            int sourcesCount = Random.Range(10, 21);

            var collider = theMap.GetComponent<PolygonCollider2D>();

            //create a first random point in a circle roughly inscribed into collider's shape
            var middle = new Vector2(theMap.transform.position.x, theMap.transform.position.y);
            var mapRenderer = theMap.GetComponent<SpriteRenderer>();
            var r = mapRenderer.sprite.textureRect.width / 4;

            //get the first resourcePool
            var currentResource = NewSource(theMap, middle, r);
            //and all other
            for (var i = 1; i < sourcesCount; i++) {
                middle = new Vector2(currentResource.transform.position.x, currentResource.transform.position.y);
                currentResource = NewSource(theMap, middle, r);
                CreateSecondarySource(3, 0, currentResource, theMap);
            }
        }

        //creating a secondary source inside the parent radius
        public static void CreateSecondarySource(int threshold, int depth, ResourcePool parent, Map theMap) {
            //check if not over
            if (depth == threshold)
                return;

            //max variables for radius and magnitude of new source
            float radius = parent.Radius / 2;
            int magnitude = (parent.Magnitude + 1) / 2;

            //creating a source
            var gameObject = new GameObject("Source", typeof(ResourcePool), typeof(SpriteRenderer));
            var renderer = gameObject.GetComponent<SpriteRenderer>();
            var ret = gameObject.GetComponent<ResourcePool>();
            ret.Resource = parent.Resource;

            //randomizing variables
            var newRadius = Random.Range(radius / 4, radius);
            var newMagnitude = Random.Range(magnitude / 4, magnitude);
            ret.ChangeIntensity(newRadius, newMagnitude);

            //setting it inside the radius of parent source
            var collider = theMap.GetComponent<PolygonCollider2D>();
            var newTransform = RandomInCircle(parent.transform.position, parent.Radius);
            if (collider.OverlapPoint(newTransform)) {
                gameObject.transform.position = new Vector3(newTransform.x, newTransform.y, 0);
                gameObject.transform.SetParent(theMap.transform, true);
                renderer.sprite = Controllers.ConstantData.SourceSprites[ret.Resource];

                // place it over the map
                renderer.sortingOrder = 1;
                Util.Rescale(renderer, 20, 20);
                theMap.Pools.Add(ret);
            }

            //will start one or two new sources, so their number is truly random, not 2, 4, 8 and so on
            CreateSecondarySource(threshold, depth + 1, parent, theMap);
            int ourRandom = Random.Range(0, 2);
            if (ourRandom == 1)
                CreateSecondarySource(threshold, depth + 1, parent, theMap);
        }

        private static ResourcePool NewSource(Map theMap, Vector2 around, float r) {
            var position = RandomInCircle(around, r);
            var collider = theMap.GetComponent<PolygonCollider2D>();
            //checking if our next position lies on the map
            while (!collider.OverlapPoint(position)) {
                //if not, we repeat the process of positioning in the smaller circe
                r /= 2;
                position = RandomInCircle(around, r);
            }
            var gameObject = new GameObject("ResourcePool", typeof(ResourcePool), typeof(SpriteRenderer));
            var renderer = gameObject.GetComponent<SpriteRenderer>();
            var ret = gameObject.GetComponent<ResourcePool>();
            RandomizeResource(ret);
            ret.RandomizeIntensity();

            gameObject.transform.position = new Vector3(position.x, position.y, 0);
            gameObject.transform.SetParent(theMap.transform, true);
            renderer.sprite = Controllers.ConstantData.SourceSprites[ret.Resource];
            // place it over the map
            renderer.sortingOrder = 1;
            Util.Rescale(renderer, 50, 50);

            theMap.Pools.Add(ret);
            return ret;
        }

        private static Vector2 RandomInCircle(Vector2 middle, float r) {
            var ret = Random.insideUnitCircle;

            ret.x = middle.x + r * ret.x;
            ret.y = middle.y + r * ret.y;

            return ret;
        }

        private static void RandomizeResource(ResourcePool resourcePool) {
            var types = Controllers.ConstantData.ResourceTypes;
            var rand = Random.Range(0, types.Count);
            resourcePool.Resource = types.ElementAt(rand);
        }
    }
}