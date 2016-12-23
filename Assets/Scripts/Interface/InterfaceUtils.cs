using Assets.Static;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Assets.Scripts.Interface {
    class InterfaceUtils {
        private static GameObject _activePopup;

        public static GameObject ActivePopup {
            get { return _activePopup; }
        }

        public static bool IsPopupActive() {
            return _activePopup != null;
        }

        public static GameObject CreatePopup(GameObject parent) {
            DestroyActivePopup();

            _activePopup = Object.Instantiate(Prefabs.Popup/*, parent.transform*/);

            //determine if the popup will fit on the screen
            Vector3 position = Input.mousePosition;
            SpriteRenderer renderer = _activePopup.GetComponent<SpriteRenderer>();

            float width = renderer.sprite.textureRect.width;
            float height = renderer.sprite.textureRect.height;

            if (position.x + width > Screen.width) position.x -= width;
            if (position.y - height > Screen.height) position.y += height;

            //move popup, so that the proper corner and not the middle is where the mouse was clicked
            position.x += width / 2;
            position.y -= height / 2;

            _activePopup.transform.position = position;

            return _activePopup;
        }

        public static void DestroyActivePopup() {
            if (ActivePopup != null)
                Object.Destroy(ActivePopup);
        }
    }
}