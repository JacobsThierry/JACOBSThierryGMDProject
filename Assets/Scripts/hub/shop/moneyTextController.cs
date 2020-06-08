using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moneyTextController : MonoBehaviour
{

    private UnityEngine.UI.Text text;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<UnityEngine.UI.Text>();
    }

    // Update is called once per frame
    void Update()
    {
        try{
            text.text = GameObject.FindGameObjectWithTag("Game").GetComponent<gameController>().money.ToString();;
        }catch{
            text.text = "000000";
        }
    }
}
