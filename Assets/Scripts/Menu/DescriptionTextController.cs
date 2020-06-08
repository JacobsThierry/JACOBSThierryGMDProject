using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DescriptionTextController : MonoBehaviour
{
    UnityEngine.UI.Text text;

    UnityEngine.EventSystems.EventSystem system;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<UnityEngine.UI.Text>();
        system = GameObject.Find("EventSystem").GetComponent<UnityEngine.EventSystems.EventSystem>();
        text.text = "";
    }

    private void FixedUpdate() {
        try{
        if( (!(system.currentSelectedGameObject==null)) && system.currentSelectedGameObject.tag == "itemShop" ) {
        
            text.text = system.currentSelectedGameObject.GetComponent<itemShopController>().item.GetComponent<itemController>().itemDescription;
            
        }else{
            text.text = "";
        }
        }catch{}

    }
}
