using System;
using Assets.Static;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Assets.Scripts.Utils
{
    public static class Loader
    {
        /// <summary>
        /// Basicly the same as AssetDatabase.LoadAssetAtPath, but with better checking.
        /// Use with PrefabPaths
        /// </summary>
        /// <param name="path">path to the prefab</param>
        /// <returns></returns>
        public static GameObject LoadPrefab(string path)
        {
            //var ret = UnityEngine.Resources.Load<GameObject>(path);
            var ret = AssetDatabase.LoadAssetAtPath<GameObject>(path);
            if (ret == null)
                throw new NullReferenceException("There is no game object at path " + path);
            return ret;
        }
        /// <summary>
        /// Shorthand for Instantiate(AssetDatabase.Load). Use with PrefabPaths.
        /// </summary>
        /// <param name="path">Path to prefab</param>
        /// <returns></returns>
        public static GameObject NewInstance(string path)
        {
      
            var ret = Object.Instantiate(Prefabs.PathsToObjects[path]);
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
