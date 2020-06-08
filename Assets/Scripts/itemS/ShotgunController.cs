using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunController : itemController
{

    public int projectiles;
    public float spread;

    public override void editProjectile(List<GameObject> gb )
    {
        GameObject projectile = gb[0];
        for(int i=0; i<projectiles;i++){
            gb.Add(Instantiate(projectile));
            int index = gb.Count-1;
            gb[index].transform.position = projectile.transform.position;
            gb[index].transform.rotation = projectile.transform.rotation;
            gb[index].transform.rotation = gb[index].transform.rotation * Quaternion.Euler(0f, Random.Range(-spread,spread), 0f);
            
        }
    }
}
