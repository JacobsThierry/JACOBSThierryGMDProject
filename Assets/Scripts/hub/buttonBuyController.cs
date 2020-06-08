using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonBuyController : MonoBehaviour
{
    UnityEngine.UI.Button button;
    int playerMoney;

    itemController selectedItem;
    GameObject selectedItemObject;

    UnityEngine.EventSystems.EventSystem eventSystem;

    // Start is called before the first frame update
    void Start()
    {
        eventSystem = GameObject.Find("EventSystem").GetComponent<UnityEngine.EventSystems.EventSystem>();
        getPlayerMoney();
        button = GetComponent<UnityEngine.UI.Button>();
        button.interactable = false;
    }

    void getPlayerMoney(){
        try{
        playerMoney = GameObject.FindGameObjectWithTag("Game").GetComponent<gameController>().money;
        }catch{
            playerMoney = 0;
        }
    }

    public void onClick(){
        getPlayerMoney();
        
        if(selectedItem.defaultItemPrice <= playerMoney){
            GameObject.FindGameObjectWithTag("Game").GetComponent<gameController>().money -= selectedItem.defaultItemPrice;
            print("bbc additem " + selectedItem);
            GameObject.FindGameObjectWithTag("Game").GetComponent<gameController>().addItem(selectedItem.gameObject);
            Destroy(selectedItemObject);
        }
    }

    public void updateButton(GameObject igb ){
        getPlayerMoney();
        itemController item = igb.GetComponent<itemController>();
        print("updateButton");
        selectedItem = item;
        button.interactable = !(item == null || item.defaultItemPrice > playerMoney); //the button is green only if the player has selectd an item and has enought money to buy it
        
    }

    // Update is called once per frame
    void Update()
    {
        if(eventSystem.currentSelectedGameObject != null && eventSystem.currentSelectedGameObject.tag == "itemShop"){
            selectedItemObject = eventSystem.currentSelectedGameObject;
            itemShopController isc = eventSystem.currentSelectedGameObject.GetComponent<itemShopController>();
            
            GameObject item = isc.item;
            itemController ic = item.GetComponent<itemController>();
            updateButton(item);
        }
    }
}
