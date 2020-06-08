using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{

    public float Speed = 3f;
    private Rigidbody rb;

    public float range=3; //range (in units) of the proj
    private Vector3 startpos; //if start + curpos > range --> rip

    public Color projectileColor = new Color(255,255,255,255);

    public int damages=1;
    public float damageSizeModifier=1.5f;

    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ProjectileBound")
        {
            Destroy(gameObject, 0f);
        }
    }

    void Start()
    {
        startpos = transform.position;
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionY;
        ParticleSystem ps = GetComponent<ParticleSystem>();
        var main = ps.main;
        main.startColor = projectileColor;
        transform.localScale = Vector3.one + Vector3.one * (damages-1) * damageSizeModifier;
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, startpos) > range ){
            Destroy(gameObject);
        }

        
    }

    private void FixedUpdate() {
        Vector3 vec = transform.rotation * Vector3.forward * Speed;
        rb.velocity = vec;
    }
}
