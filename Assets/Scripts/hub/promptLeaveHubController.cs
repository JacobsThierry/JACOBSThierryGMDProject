using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class promptLeaveHubController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0f;
        GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(transform.Find("Image").Find("yesButton").gameObject);
    }


private void OnDestroy() {
    Time.timeScale = 1f;
}

    // Update is called once per frame
    void Update()
    {
        
    }
}
