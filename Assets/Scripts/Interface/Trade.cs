using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEditor;

public class Trade : MonoBehaviour {

    private GameObject UI;
    private GameObject TransactionImage;
    private GameObject ItemImage;

    public void Start()
    {
        UI = GameObject.Find("UI").gameObject;
        TransactionImage = GameObject.Find("TradePanel/Transaction");
        ItemImage = GameObject.Find("TradePanel/Item");
    }

    public void Sell()
    {
        ItemImage.GetComponent<Image>().sprite = gameObject.GetComponent<Image>().sprite;
        ItemImage.GetComponent<Image>().preserveAspect = true;
         
        TransactionImage.GetComponent<Image>().sprite = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/Graphics/Interface graphics&textures/Sell.png");
        TransactionImage.GetComponent<Image>().preserveAspect = true;

    }
    public void Buy()
    {
        ItemImage.GetComponent<Image>().sprite = gameObject.GetComponent<Image>().sprite;
        ItemImage.GetComponent<Image>().preserveAspect = true;

        TransactionImage.GetComponent<Image>().sprite = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/Graphics/Interface graphics&textures/Buy.png");
        TransactionImage.GetComponent<Image>().preserveAspect = true;
    }

}
