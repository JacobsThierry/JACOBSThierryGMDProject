using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playButtonsController : mainButtonsController
{

    public GameObject nextScreen;
    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
        
    }

    public void onClick(){
        GameObject.Find("CanvasMainMenu").GetComponent<canvasController>().changeScreen(nextScreen);
    }
}
