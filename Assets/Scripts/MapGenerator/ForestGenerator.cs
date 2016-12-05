using System;
using System.Collections.Generic;
using Assets.Scripts.Interface;
using Assets.Scripts.Utils;
using UnityEngine;
using Random = System.Random;

namespace Assets.Scripts.MapGenerator {
    /// <summary>
    /// Generates forest using Bridson’s algorithm for Poisson-disc sampling.
    /// Praise teh internet.
    /// </summary>
    class ForestGenerator {
        /// <summary>
        /// Mean number of trees as determined by GaussianDistribution.
        /// </summary>
        private const int MeanTrees = 20;

        /// <summary>
        /// Standard deviation of the number of trees determined by GaussianDistribution.
        /// </summary>
        private const int DeviationTrees = 5;

        /// <summary>
        /// Map width to forest width ratio.
        /// </summary>
        private const float ForestScale = 0.1f;

        /// <summary>
        /// Minimum distance between trees as a fraction of forest's width.
        /// </summary>
        private const float MinimumRadiusScale = 0.1f;

        private static readonly GaussianDistribution Distribution = new GaussianDistribution(MeanTrees, DeviationTrees);
        private static readonly Random RandomIndex = new Random();

        private readonly int _treeNumber;
        private readonly RandomVector2 _randomPosition;
        private readonly float _forestSide;
        private readonly float _minimumRadius;

        public ForestGenerator(Map map) {
            Vector2 forestPosition = map.transform.position;
            _forestSide = map.GetComponent<SpriteRenderer>().sprite.textureRect.width * ForestScale;

            _minimumRadius = _forestSide * MinimumRadiusScale;
            _treeNumber = (int) Distribution.Next();
            Vector2 halfDiagonal = new Vector2(1, 1) * ((float) (_forestSide * Math.Sqrt(2)) / 2);
            _randomPosition = new RandomVector2(forestPosition - halfDiagonal, forestPosition + halfDiagonal);
        }

        /// <summary>
        /// Positions of the trees that will make up the forest.
        /// </summary>
        private List<Vector2> _inactiveTrees;

        /// <summary>
        /// Positions of potential trees.
        /// </summary>
        private readonly List<Vector2> _activeTrees = new List<Vector2>();

        /// <summary>
        /// Buckets used to check distances between trees in constant time as opposed to linear without them.
        /// </summary>
        //todo make them initialize in constant/linear time?
        private Vector2[,] buckets;

        public void Generate() {
            _inactiveTrees = new List<Vector2>(_treeNumber);

            int bucketNumber = (int) (1 / MinimumRadiusScale + 1);
            buckets = new Vector2[bucketNumber, bucketNumber];

            _activeTrees.Add(_randomPosition.Next()); //add first active tree

            while (_inactiveTrees.Count != _treeNumber) {
                int indexOfDestiny = RandomIndex.Next(_activeTrees.Count);
                Vector2 theChosenOne = _activeTrees[indexOfDestiny]; //with great power comes great responsibility
                if (!generateActiveTree(theChosenOne)) {
                    //be he worthy?
                    _activeTrees.RemoveAt(indexOfDestiny);
                    _inactiveTrees.Add(theChosenOne);
                }
            }
        }

        private bool generateActiveTree(Vector2 theChosenOne) {
        }
    }
}