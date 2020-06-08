using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingEffect : MonoBehaviour
{

    public float homingStrengh = 1;
    private void FixedUpdate() {
        GameObject[] list = GameObject.FindGameObjectsWithTag("Ennemie");
        if(list.Length > 0){
            Transform close = GetClosestEnemy(list);

            float speed = homingStrengh * Time.deltaTime;
            
            var targetRotation = Quaternion.LookRotation(close.position - transform.position);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, speed);

        }
    }



//From the unity forum
    private Transform GetClosestEnemy(GameObject[] ennemies){
        Transform tMin = null;
        float minDist = Mathf.Infinity;
        Vector3 currentPos = transform.position;
        foreach(GameObject t in ennemies){
            float dist = Vector3.Distance(t.transform.position, currentPos);
            if(dist < minDist){
                tMin = t.transform;
                minDist = dist;
            }
        }
        return tMin;
    }
}
