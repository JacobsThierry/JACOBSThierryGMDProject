using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shopController : MonoBehaviour
{


    public List<GameObject> itemsList;
    public GameObject shopHud;
    //private List<itemController> itemControllersList = new List<itemController>();
    private GameObject shop;

    // Start is called before the first frame update
    void Start()
    {
        /*
        for(int i=0;i<itemsList.Count;i++){
            itemControllersList.Add(itemsList[i].GetComponent<itemController>());
        }*/
    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player"){
            shop = Instantiate(shopHud, transform);
            shop.transform.Find("Canvas").Find("bg").Find("Window").Find("ItemsList").GetComponent<itemListController>().items = itemsList;
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.tag == "Player")
        {
            Destroy(shop);
        }
    }

}
