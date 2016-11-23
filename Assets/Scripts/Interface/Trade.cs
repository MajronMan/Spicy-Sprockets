using Assets.Scripts.Game_Controllers;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Interface {
    /// <summary>
    /// Handles trade panel where player may exchange resources for money
    /// </summary>
    public class Trade : MonoBehaviour {
        /// <summary>
        /// Image of current action (buy/sell)
        /// </summary>
        private static Image _transactionImage;

        /// <summary>
        /// Image of currently selected resource
        /// </summary>
        private static Image _itemImage;

        /// <summary>
        /// Sprite displayed when player is selling
        /// </summary>
        private static Sprite _sellSprite;

        /// <summary>
        /// Sprite displayed when player is buying
        /// </summary>
        private static Sprite _buySprite;

        private static Text _sliderValue;
        private static Slider _slider;

        /// <summary>
        /// Currently selected resource type
        /// </summary>
        private static string _type;

        private static bool _buying;

        /// <summary>
        /// Used to load images and find game objects only once
        /// </summary>
        private static bool _firstRun = true;

        public void Start() {
            // Don't load images and stuff each time for each instance of Trade
            if (!_firstRun) return;

            _transactionImage = GameObject.Find("TradePanel/Transaction").GetComponent<Image>();
            _itemImage = GameObject.Find("TradePanel/Item").GetComponent<Image>();
            _slider = GameObject.Find("TradePanel/Slider").GetComponent<Slider>();
            _sellSprite = UnityEngine.Resources.Load<Sprite>("Graphics/Interface/Sell");
            _buySprite = UnityEngine.Resources.Load<Sprite>("Graphics/Interface/Buy");
            _slider.gameObject.SetActive(false);
            _sliderValue = GameObject.Find("TradePanel/Value").GetComponent<Text>();

            _firstRun = false;
        }

        public void Update() {
            if (_slider.IsActive()) {
                var val = (int) _slider.value;
                _sliderValue.text = val.ToString();
            } else {
                _sliderValue.text = "";
            }
        }

        /// <summary>
        /// Used after click of resource from 'sell' column
        /// </summary>
        /// <param name="which">Type of resource that's sold</param>
        public void Sell(string which) {
            _slider.gameObject.SetActive(true);
            _buying = false;
            _type = which;

            SetSprites();
            _slider.maxValue = Controllers.CurrentInfo[_type].GetQuantity();
        }

        /// <summary>
        /// Called after click of resource from 'buy' column
        /// </summary>
        /// <param name="which">Type of resource that's bought</param>
        public void Buy(string which) {
            _slider.gameObject.SetActive(true);
            _buying = true;
            _type = which;

            int price = int.Parse(Controllers.ConstantData.ResourceTypes[_type]["price"]);

            SetSprites();
            _slider.maxValue = Controllers.CurrentInfo.MyMoney.GetAmount() / price;
        }

        /// <summary>
        /// Called after click of 'confirm' button
        /// </summary>
        public void Confirm() {
            // get slider value when buying and -slider value when selling
            int svalue = (int) _slider.value;
            svalue = _buying ? svalue : -svalue;

            int price = int.Parse(Controllers.ConstantData.ResourceTypes[_type]["price"]);

            // buy cheap
            Controllers.CurrentInfo[_type] += svalue;
            // sell expensive 
            Controllers.CurrentInfo.MyMoney -= svalue * price;
            // profit

            SetSprites(true);
            _slider.gameObject.SetActive(false);
        }

        /// <summary>
        /// (un)set transaction and image sprite according to currently clicked resource
        /// </summary>
        /// <param name="unset">if true, hides sprites</param>
        private void SetSprites(bool unset = false) {
            if (unset) {
                _itemImage.sprite = null;
                _transactionImage.sprite = null;
            } else {
                // Sets itemImage sprite to selected image/resource sprite
                _itemImage.sprite = GetComponent<Image>().sprite;
                _transactionImage.sprite = _buying ? _buySprite : _sellSprite;
                _itemImage.preserveAspect = _transactionImage.preserveAspect = true;
            }
        }
    }
}