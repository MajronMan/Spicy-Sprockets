using System;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Assets.Scripts.Utils
{
    public static class Loader
    {
        public static GameObject LoadPrefab(string path)
        {
            var ret = AssetDatabase.LoadAssetAtPath<GameObject>(path);
            if (ret == null)
                throw new NullReferenceException("There is no game object at path " + path);
            return ret;
        }

        public static GameObject NewInstance(string path)
        {
            var ret = Object.Instantiate(LoadPrefab(path));
            if (ret == null)
                throw new NullReferenceException("Cannot create new object from path " + path);
            return ret;
        }

        public static Sprite LoadSprite(string path)
        {
            var ret = AssetDatabase.LoadAssetAtPath<Sprite>(path);
            if (ret == null)
                throw new NullReferenceException("There is no sprite at path " + path);
            return ret;
        }
    }
}
