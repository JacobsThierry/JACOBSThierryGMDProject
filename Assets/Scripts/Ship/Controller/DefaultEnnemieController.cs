using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public enum Behaviours
{
    enterScreen = 0,
    position = 1,
    attack = 2
}

public class DefaultEnnemieController : MonoBehaviour
{

    protected Rigidbody rb;

    public Behaviours beah;

    public float rangeMax;
    public float rangeMin = 1f;
    protected GameObject player;
    protected WeaponsController wp;
    public int tiere;
    public Ship ennemyShip;
    protected shipStat stats;


    public bool isOnScreen()
    {
        GameObject Bounds = GameObject.Find("PlayerBoundary");
        Collider b = Bounds.GetComponent<BoxCollider>();
        return b.bounds.Contains(transform.position);

    }

    public void enterScreen()
    {
        GameObject Bounds = GameObject.Find("PlayerBoundary");
        Collider b = Bounds.GetComponent<BoxCollider>();
        if (isOnScreen())
        {
            beah++;
        }
        else
        {
            Vector3 movement = Vector3.Normalize(Bounds.transform.position - this.transform.position);
            lookAtPlayer();
            rb.velocity = movement * ennemyShip.stats.speed * 1.5f;
        }
    }

    public virtual void position()
    {
        lookAtPlayer();
        moveToRange();
        if (isInRange()) beah++;


    }





    public virtual void attack()
    {
        lookAtPlayer();
        moveToRange();

        wp.fire();

        if (!isOnScreen())
        {
            //beah = Behaviours.enterScreen;
        }
        else if (!isInRange())
        {
            beah = Behaviours.position;
        }

    }

    public bool isInRange()
    {
        return (Vector3.Distance(transform.position, player.transform.position) < rangeMax);

    }

    void lookAtPlayer()
    {
        Quaternion targetRotation = Quaternion.LookRotation(player.transform.position - transform.position);

        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, ennemyShip.stats.rotationSpeed);
    }

    protected virtual void moveToRange()
    {
        if (Vector3.Distance(transform.position, player.transform.position) > rangeMax)
        { // if the enemy is too far from the player, he will get closer
            rb.velocity = Vector3.Normalize(player.transform.position - transform.position) * ennemyShip.stats.speed;
        }
        else if (Vector3.Distance(transform.position, player.transform.position) < rangeMin && isOnScreen()) // the ennemy won't go back if he his outside the screen, preventing him from swaping between go on screen and attack until the player moves
        {//if he his too close, he will go away
            rb.velocity = Vector3.Normalize(transform.position - player.transform.position) * ennemyShip.stats.speed;
        }
        else
        {//otherwise => slow down

            rb.velocity *= 0.95f;


        }


    }


    public GameObject pickRandomEnnemy()
    {
        Transform ennemies = GameObject.Find("ennemies").transform;
        int ennemyIndex = (int)Random.Range(0, ennemies.childCount);
        int i = 0;
        foreach (Transform child in ennemies)
        {
            if (i == ennemyIndex)
            {
                return child.gameObject;
            }

        }
        return new GameObject();
    }
    // Start is called before the first frame update
    void Start()
    {
        ennemyShip = GetComponent<Ship>();
        stats = ennemyShip.stats;
        ennemyShip.init();
        ennemyShip.friendOrFoe = friendOrFoe.foe;
        wp = transform.Find("Weapons").GetComponent<WeaponsController>();
        wp.range = rangeMax * 1.2f;
        beah = Behaviours.enterScreen;
        rb = GetComponent<Rigidbody>();
        rb.constraints = rb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotationX |
            RigidbodyConstraints.FreezeRotationZ;
        try
        {
            player = GameObject.FindGameObjectsWithTag("Player")[0];
        }
        catch
        {
            player = pickRandomEnnemy(); //if there is no player, the ennemy will try to attack a random ennemy.
        }

    }



    private void FixedUpdate()
    {
        if (!isOnScreen())
        {
            //beah = Behaviours.enterScreen;
        }
        if (player == null)
        {
            player = pickRandomEnnemy();
        }

        switch (beah)
        {
            case Behaviours.enterScreen: enterScreen(); break;
            case Behaviours.position: position(); break;
            case Behaviours.attack: attack(); break;
        }
    }



}
