using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using Assets.Scripts.Game_Controllers;
using Assets.Scripts.Res;
using Assets.Scripts.Utils;
using Assets.Static;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Interface
{
    /// <summary>
    /// Handles trade panel where player may exchange resources for money
    /// </summary>
    public class Trade : MonoBehaviour
    {
        private Slider theSlider;
        private ResourceType _selected;
        private Dictionary<ResourceType, GameObject> _buttons = new Dictionary<ResourceType, GameObject>();
        private Rect resourceButtonsRect = new Rect(0, 0, 1, 0.2f);
        private bool buying = true;
        private int _selectedAmount;
        private GameObject[] _controlButtons;

        public void Start()
        {
            SetSliderStuff();

            string[] controlButtonNames = {"Buy", "Sell", "Confirm"};
            Rect[] controlRects =
            {
                new Rect(0.1f, 0.8f, 0.2f, 0.1f),
                new Rect(0.7f, 0.8f, 0.2f, 0.1f),
                new Rect(0.4f, 0.3f, 0.2f, 0.1f),
            };
            _controlButtons = new GameObject[3];
            for (var i = 0; i < _controlButtons.Length; i++)
            {
                var button = Instantiate(Prefabs.TextButton);
                button.name = controlButtonNames[i] + "Button";
                button.GetComponentInChildren<Text>().text = controlButtonNames[i];
                Util.SetUIObjectPosition(button, controlRects[i], transform);
                _controlButtons[i] = button;

                if (i >= 2) continue;
                var i1 = i; //closure stuff

                button.GetComponent<Button>().onClick.AddListener(() =>
                {
                    buying = i1 == 0;
                    _controlButtons[1-i1].SetActive(true);
                    button.SetActive(false);
                });
            }

            _controlButtons[2].GetComponent<Button>().onClick.AddListener(FinalizeTransaction);

            var tradeButtons = Instantiate(Prefabs.HorizontalGroupPanel, transform);
            var getRekt = (RectTransform) transform;
            Util.SetUIObjectPosition(tradeButtons, resourceButtonsRect, getRekt);

            foreach (var resType in Controllers.ConstantData.ResourceTypes)
            {
                var button = Instantiate(Prefabs.TradeButton);
                button.GetComponent<Image>().sprite = Sprites.ResourceSprite(resType);
                button.name = resType + "Button";
                _buttons.Add(resType, button);
                button.transform.SetParent(tradeButtons.transform, false);
                var type = resType;
                button.GetComponent<Button>().onClick.AddListener(() =>
                {
                    if(_selected != null)
                        _buttons[_selected].SetActive(true);

                    _selected = type;
                    theSlider.value = 0;
                    button.SetActive(false);
                });
            }
        }

        private void FinalizeTransaction()
        {
            if (_selected == null) return;

            var modifier = buying ? -1 : 1;
            var moneyDelta = modifier * _selectedAmount * _selected.DefaultPrice;
            var resourceDelta = -modifier * _selectedAmount;
            var moneyAmount = Controllers.CurrentInfo.MyMoney.Amount;
            var resourceAmount = Controllers.CurrentInfo.Resources[_selected].Amount;

            Controllers.CurrentInfo.MyMoney = new Money(moneyAmount + moneyDelta);
            Controllers.CurrentInfo[_selected] = new Commodity(_selected, resourceAmount + resourceDelta);

            _controlButtons[Math.Max(0, modifier)].SetActive(true);

            _buttons[_selected].SetActive(true);
            _selected = null;
            transform.parent.gameObject.SetActive(false);
        }

        private void SetSliderStuff()
        {
            var sliderGO = Instantiate(Prefabs.Slider, transform);
            var value = sliderGO.GetComponentInChildren<Text>();
            theSlider = sliderGO.GetComponent<Slider>();
            theSlider.onValueChanged.AddListener((fvalue) =>
            {
                if (_selected == null)
                {
                    value.text = "0";
                    return;
                }

                if (!buying)
                {
                    _selectedAmount = (int) Math.Round(fvalue*Controllers.CurrentInfo.Resources[_selected].Amount);
                    value.text = _selectedAmount.ToString();
                }
                else
                {
                    _selectedAmount = (int) Math.Round(fvalue* Controllers.CurrentInfo.MyMoney.Amount / _selected.DefaultPrice);
                    value.text = _selectedAmount.ToString();
                }
            });
            Util.SetUIObjectPosition(sliderGO, new Rect(0.4f, 0.2f, 0.2f, 0.03f), transform);
        }
    }
}

//        /// <summary>
//        /// Image of currently selected resource
//        /// </summary>
//        private static Image _itemImage;
//
//        /// <summary>
//        /// Sprite displayed when player is selling
//        /// </summary>
//        private static Sprite _sellSprite;
//
//        /// <summary>
//        /// Sprite displayed when player is buying
//        /// </summary>
//        private static Sprite _buySprite;
//
//        private static Text _sliderValue;
//        private static Slider _slider;
//
//        private static GameObject _products; //Necessary objects
//        private static GameObject _confirm;
//
//        /// <summary>
//        /// Currently selected resource type
//        /// </summary>
//        private static ResourceType _type;
//
//        private static bool _buying;
//
//        /// <summary>
//        /// Used to load images and find game objects only once
//        /// </summary>
//        private static bool _firstRun = true;
//
//        public void Start() {
//            // Don't load images and stuff each time for each instance of Trade
//            if (!_firstRun) return;
//
//            _transactionImage = GameObject.Find("TradePanel/Transaction").GetComponent<Image>();
//            _itemImage = GameObject.Find("TradePanel/Item").GetComponent<Image>();
//            _slider = GameObject.Find("TradePanel/Slider").GetComponent<Slider>();
//            _sellSprite = UnityEngine.Resources.Load<Sprite>("Graphics/Interface/Sell");
//            _buySprite = UnityEngine.Resources.Load<Sprite>("Graphics/Interface/Buy");
//            _slider.gameObject.SetActive(false);
//            _sliderValue = GameObject.Find("TradePanel/Value").GetComponent<Text>();
//            _products = GameObject.Find("TradePanel/Products"); //Finding necessary objects while they are active
//            _confirm = GameObject.Find("TradePanel/ConfirmButton");
//            _products.gameObject.SetActive(false); //Then disactivating them
//            _confirm.gameObject.SetActive(false);
//
//            _firstRun = false;
//        }
//
//        public void Update() {
//            if (_slider.IsActive()) {
//                var val = (int) _slider.value;
//                _sliderValue.text = val.ToString();
//            } else {
//                _sliderValue.text = "";
//            }
//        }
//
//        /// <summary>
//        /// A method used when a player selects the resource. This method calculates slider max value depending on the transaction (buying/selling) and sets the image to current resource
//        /// </summary>
//<<<<<<< HEAD
//        /// <param name="which">Parameter describing a resource</param>
//        public void ItemSelection(string which)
//        {
//            if (_buying == true) //Buying
//            {
//                _slider.gameObject.SetActive(true);
//                _type = which;
//
//                int price = int.Parse(Controllers.ConstantData.ResourceTypes[_type]["price"]);
//
//                _itemImage.sprite = GetComponent<Image>().sprite; //Setting the resource image
//                _itemImage.preserveAspect = true;
//                _slider.maxValue = Controllers.CurrentInfo.MyMoney.GetAmount() / price;
//            }
//            if (_buying == false) //Selling
//            {
//                _slider.gameObject.SetActive(true);
//                _type = which;
//
//                _itemImage.sprite = GetComponent<Image>().sprite; //Setting the resource image
//                _itemImage.preserveAspect = true;
//                _slider.maxValue = Controllers.CurrentInfo[_type].GetQuantity();
//            }
//=======
//        /// <param name="which">Type of resource that's sold</param>
//        public void Sell(int which) {
//            _slider.gameObject.SetActive(true);
//            _buying = false;
//            _type = Controllers.ConstantData.ResourceTypes[which];
//
//            SetSprites();
//            _slider.maxValue = Controllers.CurrentInfo[_type].Amount;
//>>>>>>> resource
//        }
//
//        /// <summary>
//        /// A method used when player chooses transaction in trade panel. Sets the image, changes bool value and recalculates slider max value
//        /// </summary>
//<<<<<<< HEAD
//        public void Buy()
//        {
//            _buying = true;
//            _transactionImage.sprite = _buySprite; //Setting the transaction image
//            _transactionImage.preserveAspect = true;
//            if (_itemImage.sprite != null) //Recalculating max slider value when any resource is selected, that is when we choose f.e. sell, then some resource and then decide to change it to buy
//            {
//                int price = int.Parse(Controllers.ConstantData.ResourceTypes[_type]["price"]);
//                _slider.maxValue = Controllers.CurrentInfo.MyMoney.GetAmount() / price;
//            }
//        }
//
//        /// <summary>
//        /// A method used when player chooses transaction in trade panel. Sets the image, changes bool value and recalculates slider max value
//        /// </summary>
//        public void Sell()
//        {
//            _buying = false;
//            _transactionImage.sprite = _sellSprite; //Setting the transaction image
//            _transactionImage.preserveAspect = true;
//            if (_itemImage.sprite != null) //Recalculating max slider value when any resource is selected, that is when we choose f.e. sell, then some resource and then decide to change it to buy
//            {
//                _slider.maxValue = Controllers.CurrentInfo[_type].GetQuantity();
//            }
//        }
//
//        /// <summary>
//        /// Clears the trade panel if player decides to exit panel without finishing the transaction
//        /// </summary>
//        public void Clear()
//        {
//            _itemImage.sprite = null;
//            _transactionImage.sprite = null;
//            _slider.gameObject.SetActive(false);
//            _confirm.gameObject.SetActive(false);
//            _products.gameObject.SetActive(false);
//=======
//        /// <param name="which">Type of resource that's bought</param>
//        public void Buy(int which) {
//            _slider.gameObject.SetActive(true);
//            _buying = true;
//            _type = Controllers.ConstantData.ResourceTypes[which];
//
//            int price = _type.DefaultPrice;
//
//            SetSprites();
//            _slider.maxValue = Controllers.CurrentInfo.MyMoney.Amount / price;
//>>>>>>> resource
//        }
//
//        /// <summary>
//        /// Called after click of 'confirm' button
//        /// </summary>
//        public void Confirm() {
//            // get slider value when buying and -slider value when selling
//            int svalue = (int) _slider.value;
//            svalue = _buying ? svalue : -svalue;
//
//            int price = _type.DefaultPrice;
//            ;
//
//            // buy cheap
//            Controllers.CurrentInfo[_type] += svalue;
//            // sell expensive 
//            Controllers.CurrentInfo.MyMoney -= svalue * price;
//            // profit
//
//<<<<<<< HEAD
//            Clear();
//=======
//            SetSprites(true);
//            _slider.gameObject.SetActive(false);
//        }
//
//        /// <summary>
//        /// (un)set transaction and image sprite according to currently clicked resource
//        /// </summary>
//        /// <param name="unset">if true, hides sprites</param>
//        private void SetSprites(bool unset = false) {
//            if (unset) {
//                _itemImage.sprite = null;
//                _transactionImage.sprite = null;
//            } else {
//                // Sets itemImage sprite to selected image/resource sprite
//                _itemImage.sprite = GetComponent<Image>().sprite;
//                _transactionImage.sprite = _buying ? _buySprite : _sellSprite;
//                _itemImage.preserveAspect = _transactionImage.preserveAspect = true;
//            }
//>>>>>>> resource
//        }
//    }
//}