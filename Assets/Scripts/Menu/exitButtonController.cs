using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exitButtonController : mainButtonsController
{
    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
        but.GetComponentInChildren<UnityEngine.UI.Text>().text = "Exit";
    }


    public void onClick()
    {
        print("quit");
        Application.Quit();
    }
}
