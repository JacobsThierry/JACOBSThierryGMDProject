using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameController : MonoBehaviour
{

    public GameObject player;
    public int money;
    private int round = 1;
    private float difficultyStep = 1f;
    public GameObject playground;
    public GameObject instantiatedPlayground;

    public GameObject mainMenue;
    public float difficultyStepIncreaseSpeed;

    public GameObject hub;
    public GameObject instantiatedHub;

    

    // Start is called before the first frame update
    void Start()
    {
        name = "game";

        PlayerStats.playerSaved = false;
        PlayerStats.weaponsSaved = false;
        PlayerStats.items = new List<GameObject>();
        CreatePlayground();

    }

private void CreatePlayground(){
        instantiatedPlayground = Instantiate(playground, transform);
        playGroundController pgc = instantiatedPlayground.GetComponent<playGroundController>();
        SpawnerController spawn = pgc.gameObject.transform.Find("EnnemiesSpawner").GetComponent<SpawnerController>();
        increaseDifficulty(spawn);

        pgc.player = player;
}

    private void increaseDifficulty(SpawnerController spawn)
    {
        spawn.difficultyIncrase = difficultyStep* (round/3f);
        spawn.baseDifficulty.count += (int) (round/3f);
        spawn.baseDifficulty.maxEnnemies += (int) (round/2f);
        spawn.baseDifficulty.rate += (int) (round/5f);
        spawn.baseDifficulty.strenght += (int) (round/1.5f);
        spawn.ammountOfWaves += (int) (round/2f);
        spawn.breakTime -= (int) (round/5f);
    }

    private void CreateHub(){
    instantiatedHub = Instantiate(hub, transform);
}

private void DestroyHub(){
    Destroy(instantiatedHub);
}

private void DestroyPlayground(){
    
    PlayerStats.savePlayer(instantiatedPlayground.GetComponent<playGroundController>().player.GetComponent<playerController>() );
    PlayerStats.saveWeapon(instantiatedPlayground.GetComponent<playGroundController>().player.transform.Find("Weapons").GetComponent<WeaponsController>() );
    Destroy(instantiatedPlayground);
    
}



    public void addItem(GameObject item ){
        itemController ic = item.GetComponent<itemController>();
        PlayerStats.playerShipStats.addStats(ic.playerModifier.playerShipStats);
        PlayerStats.stamina.addStats(ic.playerModifier.stamina);
        PlayerStats.sprintMultiplier *= ic.playerModifier.sprintMultiplier;
        
        

        PlayerStats.items.Add(item);
    }

    public void pgDone(){
        //playerstats = GameObject.FindGameObjectWithTag("Player").GetComponent<playerController>();
        round++;
        difficultyStep = round*difficultyStepIncreaseSpeed;
        money += moneyGained();
        DestroyPlayground();
        CreateHub();
    }

    public int moneyGained(){
        int moneyGained = 10;

        return moneyGained;
    }

    public void hubDone(){
        DestroyHub();
        CreatePlayground();
    }

    // Update is called once per frame
    void Update()
    {
    }

private void OnDestroy() {
    GameObject menu = Instantiate(mainMenue);
    menu.name = mainMenue.name;
}

}
