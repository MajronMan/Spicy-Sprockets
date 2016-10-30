using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEditor;
using Assets.Scripts.Game_Controllers;

public class Trade : MonoBehaviour {

    private GameObject UI;
    private GameObject TransactionImage;
    private GameObject ItemImage;
    private GameObject Slider;
    private float money;
    private string Type;
    private float resource;

    public void Start()
    {
        UI = GameObject.Find("UI").gameObject;
        TransactionImage = GameObject.Find("TradePanel/Transaction");
        ItemImage = GameObject.Find("TradePanel/Item");
        Slider = GameObject.Find("TradePanel/Slider");
        money = Controllers.CurrentInfo.MyMoney.GetAmount();
    }

    public void Sell()
    {
        ItemImage.GetComponent<Image>().sprite = gameObject.GetComponent<Image>().sprite;
        ItemImage.GetComponent<Image>().preserveAspect = true;
         
        TransactionImage.GetComponent<Image>().sprite = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/Graphics/Interface graphics&textures/Sell.png");
        TransactionImage.GetComponent<Image>().preserveAspect = true;

        if (ItemImage.GetComponent<Image>().sprite == AssetDatabase.LoadAssetAtPath<Sprite>("Assets/Graphics/Interface graphics&textures/Bread.png"))
        {
            Type = "food";
        }
        if (ItemImage.GetComponent<Image>().sprite == AssetDatabase.LoadAssetAtPath<Sprite>("Assets/Graphics/Interface graphics&textures/Coal.png"))
        {
            Type = "coal";
        }
        if (ItemImage.GetComponent<Image>().sprite == AssetDatabase.LoadAssetAtPath<Sprite>("Assets/Graphics/Interface graphics&textures/Metal.png"))
        {
            Type = "metal";
        }
        if (ItemImage.GetComponent<Image>().sprite == AssetDatabase.LoadAssetAtPath<Sprite>("Assets/Graphics/Interface graphics&textures/Mineral.png"))
        {
            Type = "mineral";
        }
        if (ItemImage.GetComponent<Image>().sprite == AssetDatabase.LoadAssetAtPath<Sprite>("Assets/Graphics/Interface graphics&textures/Stone.png"))
        {
            Type = "stone";
        }
        if (ItemImage.GetComponent<Image>().sprite == AssetDatabase.LoadAssetAtPath<Sprite>("Assets/Graphics/Interface graphics&textures/Wood.png"))
        {
            Type = "wood";
        }

        resource = Controllers.CurrentInfo[Type].GetQuantity();
        Slider.GetComponent<Slider>().maxValue = resource;
    }
    public void Buy()
    {
        ItemImage.GetComponent<Image>().sprite = gameObject.GetComponent<Image>().sprite;
        ItemImage.GetComponent<Image>().preserveAspect = true;

        TransactionImage.GetComponent<Image>().sprite = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/Graphics/Interface graphics&textures/Buy.png");
        TransactionImage.GetComponent<Image>().preserveAspect = true;

        Slider.GetComponent<Slider>().maxValue = money;
    }
    public void Confirm()
    {
        if (TransactionImage.GetComponent<Image>().sprite == AssetDatabase.LoadAssetAtPath<Sprite>("Assets/Graphics/Interface graphics&textures/Buy.png"))
        {
            name = "Buy";
        }
        if (TransactionImage.GetComponent<Image>().sprite == AssetDatabase.LoadAssetAtPath<Sprite>("Assets/Graphics/Interface graphics&textures/Sell.png"))
        {
            name = "Sell";
        }

        switch (name)
        {
            case "Sell":
                resource -= Slider.GetComponent<Slider>().value;
                money += Slider.GetComponent<Slider>().value;
                break;
            case "Buy":
                money -= Slider.GetComponent<Slider>().value;
                resource += Slider.GetComponent<Slider>().value;
                break;
        }

    }
}