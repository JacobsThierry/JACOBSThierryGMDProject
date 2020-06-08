using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shopExitController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void onClick(){
        Time.timeScale = 1f;
        Destroy(transform.parent.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
