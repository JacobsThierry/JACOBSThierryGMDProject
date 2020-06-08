using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrollController : MonoBehaviour
{

    // Scrolling inspired by Jason Weimann's tutorial

    public float scrollSpeed = -10f;

    private float speed;

    private float topEdge;
    private float bottomEdge;
    private Vector3 distanceBetweenEdges;

public void setSpeed(float spd){
    speed = spd;
}

    // Start is called before the first frame update
    void Start()
    {
        speed = scrollSpeed;
        var spriteRenderer = GetComponent<SpriteRenderer>();
        Vector2 v = spriteRenderer.size;
        v.y = v.y*3;
        spriteRenderer.size = v;

        CalculateEdges();
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition += speed * Vector3.up * Time.deltaTime;

        if(PassedEdge()){
            MoveSpriteToOppositeEdge();
        }

    }

    private bool PassedEdge(){
        
        return speed > 0 && transform.localPosition.y > topEdge
        || speed < 0 && transform.localPosition.y < bottomEdge;
    }

    private void MoveSpriteToOppositeEdge(){
        if(speed > 0) transform.localPosition -= distanceBetweenEdges;
        else transform.localPosition += distanceBetweenEdges;
    }

    private void CalculateEdges()
    {
        var spriteRenderer = GetComponent<SpriteRenderer>();
        topEdge =  transform.localPosition.y + transform.localScale.y * Mathf.Abs(transform.InverseTransformPoint(spriteRenderer.bounds.extents).y) / 3f;
        bottomEdge =  transform.localPosition.y - transform.localScale.y * Mathf.Abs(transform.InverseTransformPoint(spriteRenderer.bounds.extents).y) / 3f;
        distanceBetweenEdges = new Vector3(0f, topEdge - bottomEdge, 0f);
    }
}
