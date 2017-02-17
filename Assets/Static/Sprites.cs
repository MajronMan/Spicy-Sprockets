using System;
using System.Collections.Generic;
using Assets.Scripts.Res;
using Assets.Scripts.Utils;
using UnityEngine;

namespace Assets.Static {
    public static class Sprites {
        private static Dictionary<ResourceType, Sprite> _resourcePoolSprites = new Dictionary<ResourceType, Sprite>();
        private static Dictionary<ResourceType, Sprite> _resourceSprites = new Dictionary<ResourceType, Sprite>();
        private static Dictionary<Type, Sprite> _buildingSprites = new Dictionary<Type, Sprite>();
        private static Dictionary<Type, Sprite> _specialResources = new Dictionary<Type, Sprite>();

        private static Sprite LoadOrGetCached<TKey>(
            Dictionary<TKey, Sprite> cache, TKey key, string loadPath
        ) {
            if (!cache.ContainsKey(key)) cache.Add(key, Loader.LoadSprite(loadPath));
            return cache[key];
        }

        public static Sprite ResourceSprite(ResourceType type) {
            return LoadOrGetCached(_resourceSprites, type, GraphicsPaths.InterfaceGraphics + type.Name);
        }

        public static Sprite ResourcePoolSprite(ResourceType type) {
            return LoadOrGetCached(_resourcePoolSprites, type, GraphicsPaths.ResourcePoolGraphics + type.Name + "Pool");
        }

        public static Sprite BuildingSprite(Type type) {
            return LoadOrGetCached(_buildingSprites, type, GraphicsPaths.BuildingsGraphics + type.Name);
        }

        public static Sprite SpecialResourceSprite(Type type) {
            return LoadOrGetCached(_specialResources, type, GraphicsPaths.InterfaceGraphics + type.Name);
        }
    }
}