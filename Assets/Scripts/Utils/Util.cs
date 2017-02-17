using System;
using Assets.Static;
using UnityEngine;

namespace Assets.Scripts.Utils {
    /// <summary>
    /// General tools
    /// </summary>
    public static class Util {
        public static void SetUIObjectPosition(GameObject what, Rect how, Transform parent) {
            var rectTransform = what.GetComponent<RectTransform>();
            if (rectTransform == null) {
                throw new NullReferenceException("Given object is not a part of UI");
            }
            rectTransform.SetParent(parent);
            rectTransform.anchorMax = how.position + new Vector2(how.width, how.height);
            rectTransform.anchorMin = how.position;
            rectTransform.offsetMax = rectTransform.offsetMin = Vector2.zero;
        }
    }
}