using Assets.Scripts.Game_Controllers;
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

        public static GameObject CreatePopup(MonoBehaviour parent) {
            DestroyActivePopup();

            _activePopup = Object.Instantiate(Prefabs.Popup, parent.transform);
            _activePopup.transform.position = Controllers.MainCamera.ScreenToWorldPoint(Input.mousePosition);

            //move the popup, so that the proper corner is at mouse position and not the middle
            SpriteRenderer renderer = _activePopup.GetComponent<SpriteRenderer>();
            float unitsPerPixel = 1 / renderer.sprite.pixelsPerUnit;
            float halfWidth = renderer.sprite.textureRect.width / 2;
            float halfHeight = renderer.sprite.textureRect.height / 2;

            Vector3 rightBottomShift = new Vector3(halfWidth * unitsPerPixel, (-halfHeight) * unitsPerPixel);

            _activePopup.transform.position += rightBottomShift;

            //check whether popup fits on the screen and move properly if not
            Vector3 rightBottomCorner = _activePopup.transform.position + rightBottomShift;
            //move to screen space
            rightBottomCorner = Controllers.MainCamera.WorldToScreenPoint(rightBottomCorner);

            if (rightBottomCorner.x > Screen.width)
                _activePopup.transform.position += Vector3.left * 2 * halfWidth * unitsPerPixel;
            if (rightBottomCorner.y < 0)
                _activePopup.transform.position += Vector3.up * 2 * halfHeight * unitsPerPixel;

            return _activePopup;
        }

        public static void DestroyActivePopup() {
            if (ActivePopup != null)
                Object.Destroy(ActivePopup);
        }
    }
}