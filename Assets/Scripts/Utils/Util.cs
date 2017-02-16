using System;
using UnityEngine;

namespace Assets.Scripts.Utils {
    /// <summary>
    /// General tools
    /// </summary>
    public static class Util
    {
        private static int _objectCount;

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

        public static T NewMonoBehaviour<T>(string s, Transform parent = null)
        {
            var newGameObject = new GameObject(s, typeof(T));
            if (parent != null)
            {
                newGameObject.transform.SetParent(parent);
            }
            return newGameObject.GetComponent<T>();
        }
        public static T NewMonoBehaviour<T>()
        {
            return NewMonoBehaviour<T>("Mono no. " + _objectCount++);
        }

        public static T NewMonoBehaviour<T>(Transform parent)
        {
            return NewMonoBehaviour<T>("Mono no. " + _objectCount++, parent);
        }


    }
}