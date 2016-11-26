using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Game_Controllers;
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
        /// <summary>
        /// Create actual sources
        /// </summary>
        /// <param name="theMap">Instance of map</param>
        public static void Generate(Map theMap)
        {
            int sourcesCount = Random.Range(10, 21);
            
            var collider = theMap.GetComponent<PolygonCollider2D>();

            //create a first random point in a circle roughly inscribed into collider's shape
            var middle = new Vector2(theMap.transform.position.x, theMap.transform.position.y);
            var mapRenderer = theMap.GetComponent<SpriteRenderer>();
            var r = mapRenderer.sprite.textureRect.width/4;
            
            //get the first source
            var currentResource = NewSource(theMap, middle, r);
            //and all other
            for (var i = 1; i < sourcesCount; i++)
            {
                middle = new Vector2(currentResource.transform.position.x, currentResource.transform.position.y);
                currentResource = NewSource(theMap, middle, r);
                CreateSecondarySource(3, 0, currentResource, theMap);
            }

        }

        //creating a secondary source inside the parent radius
        public static void CreateSecondarySource(int treshold, int depth, Source parent, Map theMap)
        {
            //check if not over
            if (depth == treshold)
                return;

            //max variables for radius and magnitude of new source
            float radius = parent.GetRadius() / 2;
            int magnitude = parent.GetMagnitude();
            if (magnitude % 2 == 1)
                magnitude = (magnitude + 1) / 2;
            else
                magnitude = magnitude / 2;

            //creating a source
            var gameObject = new GameObject("Source", typeof(Source), typeof(SpriteRenderer));
            var renderer = gameObject.GetComponent<SpriteRenderer>();
            var ret = gameObject.GetComponent<Source>();
            ret.MyResource = parent.MyResource;

            //randomizing variables
            var newRadius = Random.Range(0.0f, radius / 2);
            var newMagnitude = Random.Range(0, magnitude);
            ret.ChangeVar(newRadius, newMagnitude);

            //setting it inside the radius of parent source
            var newTransform = RandomInCircle(parent.transform.position, parent.GetRadius());
            gameObject.transform.position = new Vector3(newTransform.x, newTransform.y, 0);
            gameObject.transform.SetParent(theMap.transform, true);
            renderer.sprite = Controllers.ConstantData.SourceSprites[ret.MyResource];
            
            // place it over the map
            renderer.sortingOrder = 1;
            Util.Rescale(renderer, 50, 50);
            theMap.Sources.Add(ret);

            //will start one or two new sources, so their number is truly random, not 2, 4, 8 and so on
            CreateSecondarySource(treshold, depth + 1, parent, theMap);
            int ourRandom = Random.Range(0, 2);
            if (ourRandom == 1)
                CreateSecondarySource(treshold, depth + 1, parent, theMap);
        }

        private static Source NewSource(Map theMap, Vector2 around, float r)
        {
            var position = RandomInCircle(around, r);
            var collider = theMap.GetComponent<PolygonCollider2D>();
            //checking if our next position lies on the map
            while (!collider.OverlapPoint(position))
            {
                //if not, we repeat the process of positioning in the smaller circe
                r /= 2;
                position = RandomInCircle(around, r);
            }
            var gameObject = new GameObject("Source", typeof(Source), typeof(SpriteRenderer));
            var renderer = gameObject.GetComponent<SpriteRenderer>();
            var ret = gameObject.GetComponent<Source>();
            RandomizeResource(ret);

            gameObject.transform.position = new Vector3(position.x, position.y, 0);
            gameObject.transform.SetParent(theMap.transform, true);
            renderer.sprite = Controllers.ConstantData.SourceSprites[ret.MyResource];
            // place it over the map
            renderer.sortingOrder = 1;
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

        private static void RandomizeResource(Source source)
        {
            var types = new List<string>(Controllers.ConstantData.ResourceTypes.Keys);
            var rand = Random.Range(0, types.Count);
            source.MyResource = types.ElementAt(rand);
        }
    }
}
