using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hubCameraController : MonoBehaviour
{

    private Camera cam;
    private Bounds bounds;
    private List<BoxCollider> colliders = new List<BoxCollider>();

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player")
        {

            cam.enabled = true; //if the player enter a square => enable the camera and audioListener of the square

        }
    }

    private void OnTriggerExit(Collider other) {
        
        if (other.gameObject.tag == "Player")
        {
            for(int i=0; i< colliders.Count;i++){ //Only remove the camera if the player is no longuer in the box
                if(colliders[i].bounds.Contains(other.transform.position)){ //it prevent a bug where the camera get disabled when there is more than one collider for a given camera
                    return;
                }
            }

            cam.enabled = false;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
        cam.enabled = false;

        foreach(Transform child in transform){
            try{
                BoxCollider cbc = child.GetComponent<BoxCollider>();
                colliders.Add(cbc);
            }catch{
                ;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
