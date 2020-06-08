using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hubPlayerController : MonoBehaviour
{

    private Animator anim;
    public float speed = 1f;
    public float roationSpeed = 90f;
    public float sprintModifier = 2f;

    // Start is called before the first frame update
    void Start()
    {
        anim = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate() {
        moveCharacter();
    }

    void moveCharacter(){
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
        float sprint = Input.GetAxis("Sprint");
        float animspeed = ver * 0.5f + sprint * ver * 0.5f;
        anim.SetFloat("Speed", animspeed);
        anim.SetFloat("Rotation", hor);
        anim.SetFloat("Blend", Mathf.Abs(hor) - Mathf.Abs(animspeed) );
        

        
        transform.Rotate(Vector3.up * hor * roationSpeed * Time.deltaTime);
        float sprt = sprintModifier * (sprint + 1.1f);
        transform.Translate(new Vector3(0f, 0f, ver) * sprt * speed * Time.deltaTime, Space.Self );
        
    }

}
