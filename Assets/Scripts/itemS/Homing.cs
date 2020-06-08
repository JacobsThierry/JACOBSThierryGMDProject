using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Homing : itemController
{


    public float homingStrengh = 1;

    public override void editProjectile(List<GameObject> gb){
        for(int i=0; i<gb.Count;i++){
            gb[i].AddComponent(typeof(HomingEffect)) ;
            gb[i].GetComponent<HomingEffect>().homingStrengh = homingStrengh;
        }
    }

}
