using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class canvasController : MonoBehaviour
{

    private GameObject nextCanvas;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeScreen(GameObject next){
        nextCanvas = next;
        GetComponent<Animator>().SetTrigger("Animate");
    }

    void nextScreen(){
        Destroy(transform.GetChild(0).gameObject);
        GameObject go = Instantiate(nextCanvas, transform );
        go.name = "Screen";
    }
}
