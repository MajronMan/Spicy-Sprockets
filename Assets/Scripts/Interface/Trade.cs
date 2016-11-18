using Assets.Scripts.Game_Controllers;
using UnityEditor;
using UnityEngine;
using UnityEngine.Networking.NetworkSystem;
using UnityEngine.UI;

namespace Assets.Scripts.Interface
{
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

        private static GameObject _products; //Necessary objects
        private static GameObject _confirm;

        /// <summary>
        /// Currently selected resource type
        /// </summary>
        private static string _type;
        private static bool _buying;
        /// <summary>
        /// Used to load images and find game objects only once
        /// </summary>
        private static bool _firstRun = true;
        
        public void Start()
        {
            // Don't load images and stuff each time for each instance of Trade
            if (!_firstRun) return;

            _transactionImage = GameObject.Find("TradePanel/Transaction").GetComponent<Image>();
            _itemImage = GameObject.Find("TradePanel/Item").GetComponent<Image>();
            _slider = GameObject.Find("TradePanel/Slider").GetComponent<Slider>();
            _sellSprite = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/Graphics/Interface graphics&textures/Sell.png");
            _buySprite = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/Graphics/Interface graphics&textures/Buy.png");
            _slider.gameObject.SetActive(false);
            _sliderValue = GameObject.Find("TradePanel/Value").GetComponent<Text>();
            _products = GameObject.Find("TradePanel/Products"); //Finding necessary objects while they are active
            _confirm = GameObject.Find("TradePanel/ConfirmButton");
            _products.gameObject.SetActive(false); //Then disactivating them
            _confirm.gameObject.SetActive(false);

            _firstRun = false;
        }

        public void Update()
        {
            if (_slider.IsActive())
            {
                var val = (int)_slider.value;
                _sliderValue.text = val.ToString();
            }
            else
            {
                _sliderValue.text = "";
            }
        }

        /// <summary>
        /// A method used when a player selects the resource. This method calculates slider max value depending on the transaction (buying/selling) and sets the image to current resource
        /// </summary>
        /// <param name="which">Parameter describing a resource</param>
        public void ItemSelection(string which)
        {
            if (_buying == true) //Buying
            {
                _slider.gameObject.SetActive(true);
                _type = which;

                int price = int.Parse(Controllers.ConstantData.ResourceTypes[_type]["price"]);

                _itemImage.sprite = GetComponent<Image>().sprite; //Setting the resource image
                _itemImage.preserveAspect = true;
                _slider.maxValue = Controllers.CurrentInfo.MyMoney.GetAmount() / price;
            }
            if (_buying == false) //Selling
            {
                _slider.gameObject.SetActive(true);
                _type = which;

                _itemImage.sprite = GetComponent<Image>().sprite; //Setting the resource image
                _itemImage.preserveAspect = true;
                _slider.maxValue = Controllers.CurrentInfo[_type].GetQuantity();
            }
        }

        /// <summary>
        /// A method used when player chooses transaction in trade panel. Sets the image, changes bool value and recalculates slider max value
        /// </summary>
        public void Buy()
        {
            _buying = true;
            _transactionImage.sprite = _buySprite; //Setting the transaction image
            _transactionImage.preserveAspect = true;
            if (_itemImage.sprite != null) //Recalculating max slider value when any resource is selected, that is when we choose f.e. sell, then some resource and then decide to change it to buy
            {
                int price = int.Parse(Controllers.ConstantData.ResourceTypes[_type]["price"]);
                _slider.maxValue = Controllers.CurrentInfo.MyMoney.GetAmount() / price;
            }
        }

        /// <summary>
        /// A method used when player chooses transaction in trade panel. Sets the image, changes bool value and recalculates slider max value
        /// </summary>
        public void Sell()
        {
            _buying = false;
            _transactionImage.sprite = _sellSprite; //Setting the transaction image
            _transactionImage.preserveAspect = true;
            if (_itemImage.sprite != null) //Recalculating max slider value when any resource is selected, that is when we choose f.e. sell, then some resource and then decide to change it to buy
            {
                _slider.maxValue = Controllers.CurrentInfo[_type].GetQuantity();
            }
        }

        /// <summary>
        /// Clears the trade panel if player decides to exit panel without finishing the transaction
        /// </summary>
        public void Clear()
        {
            _itemImage.sprite = null;
            _transactionImage.sprite = null;
            _slider.gameObject.SetActive(false);
            _confirm.gameObject.SetActive(false);
            _products.gameObject.SetActive(false);
        }

        /// <summary>
        /// Called after click of 'confirm' button
        /// </summary>
        public void Confirm()
        {
            // get slider value when buying and -slider value when selling
            int svalue = (int)_slider.value;
            svalue = _buying ? svalue : -svalue;

            int price = int.Parse(Controllers.ConstantData.ResourceTypes[_type]["price"]);
           
            // buy cheap
            Controllers.CurrentInfo[_type] += svalue;
            // sell expensive 
            Controllers.CurrentInfo.MyMoney -= svalue*price;
            // profit

            Clear();
        }
    }
}