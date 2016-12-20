using System;
using Assets.Scripts.Interface;
using Assets.Static;
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
            var ret = (GameObject) Resources.Load(path);
            var why = Resources.Load<Map>(@"Prefabs/Map");
            //var ret = Resources.Load<Canvas>(path);
            if (ret == null)
                throw new NullReferenceException("There is no game object at path " + path);
            return ret;
        }

        public static Sprite LoadSprite(string path)
        {
            var ret = Resources.Load<Sprite>(path);
            if (ret == null)
                throw new NullReferenceException("There is no sprite at path " + path);
            return ret;
        }
    }
}
