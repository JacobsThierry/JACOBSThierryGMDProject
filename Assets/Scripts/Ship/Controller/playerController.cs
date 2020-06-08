using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum friendOrFoe
{
    friend = 1,
    foe = 2
}


public class playerController : MonoBehaviour
{

    public string player_name;
    public string player_description;
    public StaminaControl stamina;
    private Rigidbody rb;
    public float sprintMultiplier = 5;
    [System.NonSerialized]
    public WeaponsController WeaponsController;
    private Vector3 curmov;
    public Ship playerShip;

    

    public void setStats(playerController pc){
        player_name = pc.player_name;
        player_description = pc.player_description;
        sprintMultiplier = pc.sprintMultiplier;
        stamina = pc.stamina;
    }

    // Start is called before the first frame update
    void Start()
    {
        
        playerShip = GetComponent<Ship>();
        playerShip.friendOrFoe = friendOrFoe.friend;
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
        List<float> L = new List<float>();
        WeaponsController = transform.Find("Weapons").gameObject.GetComponent<WeaponsController>();

        if (playerShip.stats.health <= 0) playerShip.stats.health = playerShip.stats.maxHealth;

        
        if(PlayerStats.playerSaved) PlayerStats.loadPlayer(this);
        playerShip.init();


    }
    // Update is called once per frame
    void Update()
    {

        if (Input.GetButton("Fire1"))
        {
            WeaponsController.fire();
        }
    }

    private void FixedUpdate()
    {
        stamina.tick( );
        moveCharacter();
    }

    private void moveCharacter()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
        float rot = Input.GetAxis("Rotation");

        curmov = new Vector3(hor, 0f, ver) * playerShip.stats.speed;

        //rb.AddTorque( new Vector3(0,1,0) * stats.speed * rot* Time.deltaTime);
        Quaternion deltaRotation = Quaternion.Euler(new Vector3(0, playerShip.stats.speed, 0) * rot * playerShip.stats.rotationSpeed);
        if (Input.GetAxis("Sprint") > 0)
        {
            stamina.setRunning(true); //stop the stamina regenartion even if the stamina barr is empty
            if (stamina.stamina > 0)
            {
                curmov *= Input.GetAxis("Sprint") * sprintMultiplier;
            }
        }
        else
        {
            stamina.setRunning(false);
            if (Input.GetAxis("Sprint") < 0)
            {
                curmov *= (Input.GetAxis("Sprint") + 2f) / sprintMultiplier;
            }
        }

        


        rb.MoveRotation(rb.rotation * deltaRotation);

        if (rot > 0.1f && rot > -0.1f)
        {
            rb.angularVelocity = new Vector3(0, 0, 0);
        }

        rb.velocity = curmov;
    }
    /*
        public float getCurrentForwardstats.speed()
        {
            return curmov.x >= -0.2 ? curmov.magnitude : -curmov.magnitude;
        }
        */
}
