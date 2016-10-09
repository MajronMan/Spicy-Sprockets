using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Utils
{
    public static class Util  {
        public static void Rescale(SpriteRenderer renderer, float desiredX, float desiredY)
        {
            var sprite = renderer.sprite;
            if (sprite == null) return;

            float resX = sprite.rect.width, resY = sprite.rect.height;
            float scaleX = desiredX/resX, scaleY = desiredY/resY;

            renderer.gameObject.transform.localScale = new Vector3(scaleX, scaleY, 0);
        }
    }
}
