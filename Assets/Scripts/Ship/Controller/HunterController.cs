using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HunterController : DefaultEnnemieController
{

    
    protected override void moveToRange()
    {
        print("hunter");
        if (Vector3.Distance(transform.position, player.transform.position) > rangeMax)
        { // if the enemy is too far from the player, he will get closer
            rb.velocity = Vector3.Normalize(player.transform.position - transform.position) * stats.speed;
        }
        else if (Vector3.Distance(transform.position, player.transform.position) < rangeMin && isOnScreen())
        {//if he his too close, he will go away
            rb.velocity = Vector3.Normalize(transform.position - player.transform.position) * stats.speed;
        }
        else
        {//otherwise he will go slowly get closer to the middle between his max range et min range
            float middle = (rangeMax - rangeMin);
            print("Middle = " + middle + " distance = " + Vector3.Distance(transform.position, player.transform.position));

            if (Vector3.Distance(transform.position, player.transform.position) > middle + middle * 0.7f)
            {
                print("foo");
                rb.velocity = Vector3.Normalize(player.transform.position - transform.position) * stats.speed / 1.5f;
            }
            else if (Vector3.Distance(transform.position, player.transform.position) < middle - middle * 0.7f && isOnScreen())
            {
                rb.velocity = Vector3.Normalize(player.transform.position - transform.position) * stats.speed / 1.5f;
            }
            else // and if the ennemy is in his "confort zone", he will slow down
            {
                rb.velocity *= 0.95f;
            }

        }


    }
}
