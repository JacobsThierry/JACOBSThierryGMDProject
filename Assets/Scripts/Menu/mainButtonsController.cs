using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainButtonsController : MonoBehaviour
{

    protected UnityEngine.UI.Button but;

    // Start is called before the first frame update
    protected void Start()
    {
        but = GetComponent<UnityEngine.UI.Button>();
    }

    // Update is called once per frame
    void Update()
    {
        //GameObject.Find("title").GetComponent<titleController>().CurrentColor
        UnityEngine.UI.ColorBlock cb = but.colors;
        UnityEngine.UI.Text text = but.GetComponentInChildren<UnityEngine.UI.Text>();
        try{
        cb.normalColor = GameObject.Find("Title").GetComponent<titleController>().CurrentColor;
        but.colors = cb;
        text.color = new Color(1f - cb.normalColor.r, 1f - cb.normalColor.g, 1f - cb.normalColor.b, 1);
        }catch{
            text.color = Color.white;
        }
    }
}
