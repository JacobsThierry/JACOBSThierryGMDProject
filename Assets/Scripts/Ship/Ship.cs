using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class shipStat{

    public float speed;
    public int maxHealth;
    public int health;
    public float rotationSpeed = 1f;
    
    public void addStats(shipStat s ){
        speed *= s.speed;
        maxHealth += s.maxHealth;
        health += s.health;
        if(health > maxHealth) health = maxHealth;
        health += s.health;
        rotationSpeed *= s.rotationSpeed;

    }

    public void setStats(shipStat s){
        speed = s.speed;
        maxHealth = s.maxHealth;
        health = s.health;
        rotationSpeed = s.rotationSpeed;
    }

    public shipStat clone(){
        shipStat s = new shipStat();
        s.speed = speed;
        s.maxHealth = maxHealth;
        s.health = health;
        s.rotationSpeed = rotationSpeed;
        return s;
    }

}

public class Ship : MonoBehaviour
{

    public friendOrFoe friendOrFoe;
    
    public shipStat stats;
    public List<GameObject> items;

    public delegate void ShipDelegate();
    public static event ShipDelegate PlayerHitEvent;
    public static event ShipDelegate EnnemyKilled;
    public GameObject explosion;
    private void OnTriggerEnter(Collider other) {
        
        GameObject go = other.gameObject;
        ProjectileController pc = go.GetComponent<ProjectileController>();
        if (pc == null) return; //return if the ship is not hit by a projectile 
        else
        {

            if (canHitMe(go.tag))
            {               
                hit(pc);
                Destroy(go);
                if(tag == "Player" ){
                    GameObject.Find("HealthBar").GetComponent<uiLifeController>().updateHealth();
                }
            }
        }
        
    }

    public void addHealth(int healthAdded)
    {
        stats.health += healthAdded;
        if (stats.health > stats.maxHealth) stats.health = stats.maxHealth;
    }


    public void hit(ProjectileController pc){
        print("hit");
        stats.health -= pc.damages;
        
        if(PlayerHitEvent != null && tag == "Player") PlayerHitEvent();

        if(stats.health <= 0){
            Destroy(gameObject);
        }
    }
public void init() {
    if(tag != "Player") stats.health = stats.maxHealth; //the hp of the player (=) max hp
    PlayerHitEvent();
    
}
    public bool canHitMe(string tag){
        string friendlyTag = friendOrFoe == friendOrFoe.friend?"FriendlyProjectile":"EnnemyProjectile"; //give the tag that is friendly toward the ship
        return !string.Equals(friendlyTag, tag);
    }

    public float getCurrentForwardSpeed(){
        Rigidbody rb = GetComponent<Rigidbody>();
        Vector3 curmov = - transform.InverseTransformPoint(rb.velocity);
        return curmov.x >= -0.2 ? curmov.magnitude : -curmov.magnitude;
    }
  
  private void OnDestroy() {
      if(tag == "Ennemie" && EnnemyKilled != null){
          EnnemyKilled();
      }
      if(explosion != null){
          GameObject exp = Instantiate(explosion, transform.position, transform.rotation);
          exp.transform.localScale = transform.localScale/2f;
          audioManager.playExplosion(transform.localScale.x);
          
      }
  }

}
