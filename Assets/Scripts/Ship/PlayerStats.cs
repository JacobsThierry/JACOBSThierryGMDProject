using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerStats
{

public static shipStat playerShipStats;
public static string player_name;
public static string player_description;
public static StaminaControl stamina;
public static float sprintMultiplier;
public static List<GameObject> items;


    public static bool playerSaved = false;
    public static bool weaponsSaved = false;
    
    public static GameObject projectile;
    public static friendOrFoe friendOrFoe;
    public static float rateOfFire = 1f;
    public static float projectileSpeed = 50f;
    public static float range = 3f;
    public static bool autofire;
    public static Color projectilesColors = new Color(255, 255, 255, 255);
    public static int damages = 1;




public static void savePlayer(playerController pc){
    playerSaved = true;
    playerShipStats = pc.playerShip.stats.clone();
    Debug.Log("player hp clone = " + playerShipStats.health);
    player_name = pc.player_name;
    player_description = pc.player_description;
    sprintMultiplier = pc.sprintMultiplier;
    stamina = pc.stamina.clone();
    items = new List<GameObject>(pc.playerShip.items);
}

    public static void loadPlayer(playerController pc)
    {
        pc.playerShip.stats = playerShipStats.clone();
        Debug.Log("player hp = " + pc.playerShip.stats.health);
        pc.player_name = player_name;
        pc.player_description = player_description;
        pc.sprintMultiplier = sprintMultiplier;
        pc.stamina = stamina.clone();
        pc.playerShip.items = new List<GameObject>(items);
    }

public static void saveWeapon(WeaponsController w){
    weaponsSaved = true;
    projectile = w.projectile;
    
    friendOrFoe = w.friendOrFoe;
    rateOfFire = w.rateOfFire;
     projectileSpeed = w.projectileSpeed;
     range = w.range;
    autofire = w.autofire;
    projectilesColors = w.projectilesColors;
    damages = w.damages;
}

    public static void loadWeapon(WeaponsController w)
    {
        w.projectile = projectile;
        w.friendOrFoe = friendOrFoe;
        w.rateOfFire = rateOfFire;
        w.projectileSpeed = projectileSpeed;
        w.range = range;
        w.autofire = autofire;
        w.projectilesColors = projectilesColors;
        w.damages = damages;

    }


}
