using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemShopController : MonoBehaviour
{

    private UnityEngine.UI.Text itemName;
    private UnityEngine.UI.Text itemPrice;
    private UnityEngine.UI.Image itemImage;
    public GameObject item;
    private itemController itemController;

    // Start is called before the first frame update
    void Start()
    {

        setupUi();

    }

    private void setupUi()
    {
        if (item != null)
        {
            itemName = transform.Find("ItemName").GetComponent<UnityEngine.UI.Text>();
            itemController = item.GetComponent<itemController>();
            itemName.text = itemController.itemName;

            itemPrice = transform.Find("Item_price").Find("Text").GetComponent<UnityEngine.UI.Text>();
            itemPrice.text = itemController.defaultItemPrice.ToString();

            itemImage = transform.Find("ItemImage").GetComponent<UnityEngine.UI.Image>();
            itemImage.sprite = itemController.itemSprite;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
