using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterSelectionController : MonoBehaviour
{


    public GameObject selectedShip;
    public UnityEngine.UI.Text descText;
    public UnityEngine.EventSystems.EventSystem ev;

    // Start is called before the first frame update
    void Start()
    {
        descText = transform.Find("ShipDescription").GetComponent<UnityEngine.UI.Text>();
        ev = transform.Find("EventSystem").GetComponent<UnityEngine.EventSystems.EventSystem>();

    }

    // Update is called once per frame
    void Update()
    {
        GameObject button = ev.currentSelectedGameObject;
        try { descText.text = button.GetComponent<MenuShipController>().getShipDesc(); } catch {; }
    }
}
