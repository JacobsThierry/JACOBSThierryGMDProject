using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemListController : MonoBehaviour
{

    private RectTransform container;

    private List<GameObject> shopItems = new List<GameObject>();
    public List<GameObject> items;
    private UnityEngine.EventSystems.EventSystem eventSystem;
    public GameObject itemshop;

    // Start is called before the first frame update
    void Start()
    {
        eventSystem = GameObject.Find("EventSystem").GetComponent<UnityEngine.EventSystems.EventSystem>();
        

        populate();
    }

    void populate(){

        container = transform.Find("ItemContainer").GetComponent<RectTransform>();

        for (int i = 0; i < items.Count; i++)
        {
            shopItems.Add(Instantiate(itemshop, container, false));
            shopItems[i].AddComponent(typeof(itemShopController));
            itemShopController isc = shopItems[i].GetComponent<itemShopController>();
            isc.item = items[i];
        }

        if(shopItems.Count > 0){


        try{
            eventSystem.SetSelectedGameObject(container.transform.GetChild(0).gameObject);
        }catch{;}
        }
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
