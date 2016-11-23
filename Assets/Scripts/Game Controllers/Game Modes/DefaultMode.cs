using System.IO;
using System.Runtime.Serialization.Formatters;
using Newtonsoft.Json;
using UnityEngine;

namespace Assets.Scripts.Game_Controllers.Game_Modes {
    /// <summary>
    /// Defines behaviour of user's actions in game
    /// </summary>
    public class DefaultMode : IGameMode {
        // just for debug
        private int i = 0;

        /// <summary>
        /// Defines default action for right mouse click
        /// </summary>
        public void RightMouseClicked() {
            Debug.Log("Right" + i);
            i++;
        }

        /// <summary>
        /// Defines default action for left mouse click
        /// </summary>
        public void LeftMouseClicked() {
            Debug.Log("Left" + i);
            i++;
        }

        /// <summary>
        /// Defines actions to be taken every frame; needs to be called manually since it's not a MonoBehaviour
        /// </summary>
        public void Update() {
//            string path = Application.dataPath + "/GameData.json";
//            File.WriteAllText(path,
//                JsonConvert.SerializeObject(Controllers.Data, Formatting.Indented, new JsonSerializerSettings() {
//                    PreserveReferencesHandling = PreserveReferencesHandling.Objects,
//                    TypeNameHandling = TypeNameHandling.Auto,
//                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
//                    TypeNameAssemblyFormat = FormatterAssemblyStyle.Simple
//                }));
//            Debug.Break();
        }

        /// <summary>
        /// Defines what happens when the game mode changes
        /// </summary>
        public void Exit() {
        }

        // not quite sure why is that here
        public void Select(GameObject gameObject) {
        }
    }
}