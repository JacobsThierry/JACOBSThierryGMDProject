using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuShipController : MonoBehaviour
{
    [SerializeField]
    private GameObject ship;
    private GameObject model;
    private GameObject model2;
    public float rotationSpeed = 1f;
    private bool initiated = false;
    private UnityEngine.UI.Button but;

    // Start is called before the first frame update
    void Start()
    {
        
        init();
        but = GetComponent<UnityEngine.UI.Button>();
    }

    private void init()
    {

        if (ship != null)
        {
            UnityEngine.UI.Text text_name = transform.Find("ShipName").GetComponent<UnityEngine.UI.Text>();
            text_name.text = ship.GetComponent<playerController>().player_name;


            model = ship.transform.Find("Modele").gameObject;
            model2 = Instantiate(model, transform);
            model2.transform.Find("Reactors").gameObject.SetActive(false);
            model2.transform.localPosition = new Vector3(50, -30, -85);
            model2.transform.localScale = new Vector3(50, 50, 50); //find the model of the ship and diable the reactor        
            initiated = true;
        } 
    }

private void OnMouseOver() {
    print("wooooooo");
    but.Select();
}

    // Update is called once per frame
    void Update()
    {
        if (initiated)
        {
            model2.transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime, Space.World);
        }
        else
        {
            init();
        }

    }

    public GameObject getShip()
    {
        try{
        ship.transform.Find("Reactors").gameObject.SetActive(true);
        }catch{
            ;
        }
        return ship;
    }
    public void setShip(GameObject shipp)
    {
        ship = shipp;
    }

    public string getShipDesc(){
        return ship.GetComponent<playerController>().player_description;
    }

    public void onClick()
    {
        
        mainMenuController mmc = GameObject.Find("MainMenu").GetComponent<mainMenuController>();
        mmc.player = this.getShip();
        mmc.startGame();
    }
}

