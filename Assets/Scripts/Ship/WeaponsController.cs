using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsController : MonoBehaviour
{

    private List<GameObject> weaponsList = new List<GameObject>();
    public GameObject projectile;

    [System.NonSerialized]
    public friendOrFoe friendOrFoe;

    public float rateOfFire=1f;    //round per sec
    private float lastShot=0f;
    private int weaponRotation=0;

    public float projectileSpeed=50f;

    private GameObject player;

    private Transform projectileContainer;
    public float range=3f;

    public bool autofire;
    public Color projectilesColors = new Color(255,255,255,255);
    public int damages=1;
    private int olddamages;
    public float minRof = 0.01f;
    public float minRange = 0.1f;
    public float minProjectileSpeed = 0.001f;
    public AudioClip weaponSound;
    private AudioSource AudioSource;


    // Start is called before the first frame update
    void Start()
    {
        olddamages = damages;
        player = transform.parent.gameObject;
        friendOrFoe = player.GetComponent<Ship>().friendOrFoe;
        projectileContainer = GameObject.Find("Projectile").transform;

        foreach(Transform child in transform){
            weaponsList.Add(child.gameObject);
        }
        Ship ship = player.GetComponent<Ship>();


        for (int i = 0; i < ship.items.Count; i++)
        {
            weaponModifier wm = ship.items[i].GetComponent<itemController>().weaponModifier;
            rateOfFire *= wm.rateOfFireMultiplier;

            projectileSpeed *= wm.projectileSpeedMultiplier;
            range += wm.rangeMultiplier;

            projectilesColors += wm.projectilesColors;
            damages += wm.damages;

        }
        if (range < minRange)
        {
            range = minRange;
        }
        if (rateOfFire < minRof)
        {
            rateOfFire = minRof;
        }
        if (projectileSpeed < minProjectileSpeed)
        {
            projectileSpeed = minProjectileSpeed;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if(autofire) fire();
    }

    public void fire(){
        if(Time.time > lastShot + 1/rateOfFire){
                lastShot = Time.time;
                
                List<GameObject> gb = new List<GameObject>();
                gb.Add(Instantiate(projectile));

                GameObject wep = weaponsList[weaponRotation];
                
                
                editProjectile(gb[0], wep, wep.transform.rotation);

                List<GameObject> items = player.GetComponent<Ship>().items;

                for(int i=0; i<items.Count;i++){
                    try{
                        items[i].GetComponent<itemController>().editProjectile(gb);
                    }catch{;}
                }

                for(int i=0; i<gb.Count;i++){
                    gb[i].transform.parent = projectileContainer;
                }

                        audioManager.playPiouSound(gb.Count, gb[0].GetComponent<ProjectileController>().damages);

                

                
            }
    }

    public void editProjectile(GameObject gb, GameObject wep,  Quaternion rot){
        incrementeWeaponRotation();
        gb.transform.position = wep.transform.position;
        gb.transform.rotation = rot;

        try
        {
            ProjectileController pc = gb.GetComponent<ProjectileController>();
            pc.damages = damages;
            pc.projectileColor = projectilesColors;
            pc.Speed = projectileSpeed;
            pc.range = range;
        }
        catch
        {
            ;
        }

        
        gb.tag = friendOrFoe == friendOrFoe.friend ? "FriendlyProjectile" : "EnnemyProjectile";
    }

    private void incrementeWeaponRotation(){
        weaponRotation++;
        if(weaponRotation >= weaponsList.Count){
            weaponRotation=0;
        }
    }

}
