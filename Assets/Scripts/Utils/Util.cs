using System;
using UnityEngine;

namespace Assets.Scripts.Utils {
    /// <summary>
    /// General tools
    /// </summary>
    public static class Util {
        /// <summary>
        /// Change size of the object to match desired size(in pixels) 
        /// </summary>
        /// <param name="renderer">Renderer which displays the sprite</param>
        /// <param name="desiredX">Width in pixels</param>
        /// <param name="desiredY">Height in pixels</param>
        /// <returns>The created building</returns>
        public static void Rescale(SpriteRenderer renderer, float desiredX, float desiredY) {
            //Get the sprite we want to rescale
            var sprite = renderer.sprite;
            if (sprite == null) return;

            //Calculate the scale so that currentSize * scale = desiredSize
            float resX = sprite.rect.width, resY = sprite.rect.height;
            float scaleX = desiredX / resX, scaleY = desiredY / resY;

            //Actual scaling
            renderer.gameObject.transform.localScale = new Vector3(scaleX, scaleY, 0);
        }

        public static void SetUIObjectPosition(GameObject what, Rect how, Transform parent)
        {
            var rectTransform = what.GetComponent<RectTransform>();
            if (rectTransform == null)
            {
                throw new NullReferenceException("Given object is not a part of UI");
            }
            rectTransform.SetParent(parent);
            rectTransform.anchorMax = how.position + new Vector2(how.width, how.height);
            rectTransform.anchorMin = how.position;
            rectTransform.offsetMax = rectTransform.offsetMin = Vector2.zero;
        }
    }
}