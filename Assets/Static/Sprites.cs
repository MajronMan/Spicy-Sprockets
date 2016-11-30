using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Utils;
using UnityEngine;

namespace Assets.Static
{
    public static class Sprites
    {
        private static Sprite _food;
        private static Sprite _coal;
        private static Sprite _metal;
        private static Sprite _wood;
        private static Sprite _stone;
        private static Sprite _mineral;

        public static Sprite Food { get { return _food ?? (_food = Loader.LoadSprite(GraphicsPaths.Food)); } }
        public static Sprite Coal { get { return _coal ?? (_coal = Loader.LoadSprite(GraphicsPaths.Coal)); } }
        public static Sprite Metal { get { return _metal ?? (_metal = Loader.LoadSprite(GraphicsPaths.Metal)); } }
        public static Sprite Wood { get { return _wood ?? (_wood = Loader.LoadSprite(GraphicsPaths.Wood)); } }
        public static Sprite Stone { get { return _stone ?? (_stone = Loader.LoadSprite(GraphicsPaths.Stone)); } }
        public static Sprite Mineral { get { return _mineral ?? (_mineral = Loader.LoadSprite(GraphicsPaths.Mineral)); } }

        public static Sprite[] ResourcesSprites = { Food, Coal, Metal, Wood, Stone, Mineral };
    }
}
