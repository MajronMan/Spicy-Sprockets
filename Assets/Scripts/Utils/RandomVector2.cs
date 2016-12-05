using UnityEngine;
using Random = System.Random;

namespace Assets.Scripts.Utils {
    class RandomVector2 {
        private Random _random = new Random();

        private readonly float _minX;
        private readonly float _xRange;
        private readonly float _minY;
        private readonly float _yRange;

        public RandomVector2(Vector2 leftBottom, Vector2 rightTop) {
            _minX = leftBottom.x;
            _xRange = rightTop.x - leftBottom.x;
            _minY = leftBottom.y;
            _yRange = rightTop.y - leftBottom.y;
        }

        public Vector2 Next() {
            float x = (float) (_minX + _random.NextDouble() * _xRange);
            float y = (float) (_minY + _random.NextDouble() * _yRange);
            return new Vector2(x, y);
        }
    }
}