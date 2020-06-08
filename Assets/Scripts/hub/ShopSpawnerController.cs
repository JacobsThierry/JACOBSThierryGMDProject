using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopSpawnerController : MonoBehaviour
{


    public GameObject shop;
    public int minItem;
    public int maxItem;
    public float spawnChance;

    private GameObject InstantiateShop;

    // Start is called before the first frame update
    void Start()
    {
        

        if(Random.Range(0f,1f) < spawnChance){
            print("spawn");
            createShop();

        }

    }

    void createShop(){
        InstantiateShop = Instantiate(shop, transform);
        shopController sc = InstantiateShop.GetComponent<shopController>();
        try{
        sc.itemsList = pickRandomItems();
        }catch{
            sc.itemsList = new List<GameObject>();
        }

    }

    private List<GameObject> pickRandomItems(){
        int itemCount = (int) Random.Range(minItem, maxItem);
        List<GameObject> l = itemPool.get_items_from_pool(itemCount); //ThE NamE "ItemPoOl DoeS nOT ExiSt In THiS ConText
        return l;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
