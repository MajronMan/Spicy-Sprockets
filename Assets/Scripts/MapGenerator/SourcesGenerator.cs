using System;
using Assets.Scripts.Interface;
using Assets.Scripts.Sources_of_Resources;
using Assets.Scripts.Utils;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Assets.Scripts.MapGenerator
{
    /// <summary>
    /// Used to created Resource Pools scattered across local map
    /// </summary>
    public static class SourcesGenerator
    {
        private static Sprite _sourceSprite = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/Graphics/Buildings/Source.png");
        /// <summary>
        /// Create actual sources
        /// </summary>
        /// <param name="theMap">Instance of map</param>
        public static void Generate(Map theMap)
        {
            const int sourcesCount = 20;
            
            var collider = theMap.GetComponent<PolygonCollider2D>();

            //create a first random point in a circle roughly inscribed into collider's shape
            float centerX = 0, centerY = 0;
            foreach (var point in collider.points)
            {
                centerX += point.x;
                centerY += point.y;
            }
            centerX /= collider.points.Length;
            centerY /= collider.points.Length;
            var middle = new Vector2(centerX, centerY);
            var r = Math.Abs(centerX - collider.points[0].x)/2.0f;

            //get the first source
            var currentResource = NewSource(theMap, middle, r);
            //and all other
            for (var i = 1; i < sourcesCount; i++)
            {
                middle = new Vector2(currentResource.transform.position.x, currentResource.transform.position.y);
                currentResource = NewSource(theMap, middle, r);
            }

        }

        private static Source NewSource(Map theMap, Vector2 around, float r)
        {
            var position = RandomInCircle(around, r);
            var collider = theMap.GetComponent<PolygonCollider2D>();
            while (!collider.OverlapPoint(position))
            {
                //ensures this won't be an infinite loop
                r /= 2;
                position = RandomInCircle(around, r);
            }
            var gameObject = new GameObject("Source", typeof(Source), typeof(SpriteRenderer));
            var renderer = gameObject.GetComponent<SpriteRenderer>();
            var ret = gameObject.GetComponent<Source>();
            gameObject.transform.position = new Vector3(position.x, position.y, 0);
            gameObject.transform.SetParent(theMap.transform, true);
            renderer.sprite = _sourceSprite;
            Util.Rescale(renderer, 50, 50);
            theMap.Sources.Add(ret);
            return ret;
        }

        private static Vector2 RandomInCircle(Vector2 middle, float r)
        {
            var ret = Random.insideUnitCircle;
            ret.x = middle.x + r*ret.x;
            ret.y = middle.y + r * ret.y;
            return ret;
        }
    }
}
