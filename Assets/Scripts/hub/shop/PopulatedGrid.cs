using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopulatedGrid : MonoBehaviour
{
    public GameObject shipButton;
    private GameObject[] characterList;
    // Start is called before the first frame update
    void Start()
    {
        characterList = Resources.LoadAll<GameObject>("Characters/Player");
        print(characterList);
        populate();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void populate(){
        for(int i=0; i< characterList.Length;i++){
            GameObject newObject = Instantiate(shipButton, transform);
            MenuShipController cont = newObject.GetComponent<MenuShipController>();
            if (i == 0)
            {
                newObject.GetComponent<UnityEngine.UI.Button>().Select();
            }
            cont.setShip(characterList[i]);
        }
    }
}
