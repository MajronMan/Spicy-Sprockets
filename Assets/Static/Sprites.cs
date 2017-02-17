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

        private static int _pixelsPerUnit = 100;

        /// <summary>
        /// All sprites should have exactly this value set in their preferences
        /// </summary>
        public static int PixelsPerUnit {
            get { return _pixelsPerUnit; }
        }

        /// <summary>
        /// Resize Sprite instance attached to renderer parameter
        /// </summary>
        /// <param name="renderer">Renderer which displays the sprite</param>
        /// <param name="xUnits">Width in units</param>
        /// <param name="yUnits">Height in units</param>
        /// <returns>The created building</returns>
        public static void Rescale(SpriteRenderer renderer, float xUnits, float yUnits) {
            // Get the sprite we want to rescale
            var sprite = renderer.sprite;
            if (sprite == null) return;

            // Original resource size
            float resX = sprite.rect.width, resY = sprite.rect.height;

            // Desired scale
            float scaleX = xUnits / resX * PixelsPerUnit, scaleY = yUnits / resY * PixelsPerUnit;

            // Actual scaling
            renderer.gameObject.transform.localScale = new Vector3(scaleX, scaleY, 0);
        }


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