using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Game_Controllers;
using Assets.Scripts.Res;
using Assets.Scripts.Utils;
using UnityEngine;

namespace Assets.Static
{
    public static class Sprites
    {
       
        private static Dictionary<ResourceType, Sprite> _resourcePoolSprites = new Dictionary<ResourceType, Sprite>();
        private static Dictionary<ResourceType, Sprite> _resourceSprites = new Dictionary<ResourceType, Sprite>();
        private static Dictionary<Type, Sprite> _buildingSprites = new Dictionary<Type, Sprite>();

        public static Sprite ResourceSprite(ResourceType type)
        {
            if (!_resourceSprites.ContainsKey(type))
                _resourceSprites.Add(type, Loader.LoadSprite(GraphicsPaths.InterfaceGraphics + type.InterfaceSpriteName()));
            
            return _resourceSprites[type];
        }

        public static Sprite ResourcePoolSprite(ResourceType type)
        {
            if (!_resourcePoolSprites.ContainsKey(type))
                _resourcePoolSprites.Add(type, Loader.LoadSprite(GraphicsPaths.ResourcePoolGraphics + type.PoolSpriteName()));

            return _resourcePoolSprites[type];
        }

        public static Sprite BuildingSprite(Type type)
        {
            if (!_buildingSprites.ContainsKey(type))
                _buildingSprites.Add(type, Loader.LoadSprite(GraphicsPaths.BuildingGraphics + type.ToString()));

            return _buildingSprites[type];
        }

    }
}
