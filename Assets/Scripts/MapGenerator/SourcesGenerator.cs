﻿using System.Collections.Generic;
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
            const int sourcesCount = 20;

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
            }
        }

        private static ResourcePool NewSource(Map theMap, Vector2 around, float r) {
            var position = RandomInCircle(around, r);
            var collider = theMap.GetComponent<PolygonCollider2D>();
            while (!collider.OverlapPoint(position)) {
                //ensures this won't be an infinite loop if previous point lays within the collider
                r /= 2;
                position = RandomInCircle(around, r);
            }
            var gameObject = new GameObject("ResourcePool", typeof(ResourcePool), typeof(SpriteRenderer));
            var renderer = gameObject.GetComponent<SpriteRenderer>();
            var ret = gameObject.GetComponent<ResourcePool>();
            RandomizeResource(ret);

            gameObject.transform.position = new Vector3(position.x, position.y, 0);
            gameObject.transform.SetParent(theMap.transform, true);
            renderer.sprite = Controllers.ConstantData.SourceSprites[ret.Type];
            // place it over the map
            renderer.sortingOrder = 1;
            Util.Rescale(renderer, 50, 50);

            theMap.Sources.Add(ret);
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
            resourcePool.Type = types.ElementAt(rand);
        }
    }
}