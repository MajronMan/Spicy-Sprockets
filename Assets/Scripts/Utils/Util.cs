using UnityEngine;
using System.Collections;

public static class Util  {

    public static void rescale(SpriteRenderer renderer, float desiredX, float desiredY)
    {
        Sprite sprite = renderer.sprite;
        if (sprite != null)
        {
            float resX = sprite.rect.width;
            float resY = sprite.rect.height;
            float scaleX = desiredX/resX;
            float scaleY = desiredY/resY;
            renderer.gameObject.transform.localScale = new Vector3(scaleX, scaleY, 0);
            Debug.Log(scaleX);
        }
    }
}
