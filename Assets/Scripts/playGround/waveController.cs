using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waveController : MonoBehaviour
{

    private SpawnerController spawner;

    public WaveDifficulty waveDifficulty;
    private float lastSpawned;

    // Start is called before the first frame update
    void Start()
    {
        spawner = transform.parent.GetComponent<SpawnerController>();

        if(spawner.getAmmountOfEnnemies() < 2) lastSpawned += Time.time; //the first spawn will come faster than the followings if there is only a few ennemies
    }

    private void FixedUpdate() {
        spawner.currentDifficulty = waveDifficulty;
        //print("delay = " + (lastSpawned + 1/waveDifficulty.rate - Time.time) + " ammount : " + spawner.getAmmountOfEnnemies() +  " out of " + waveDifficulty.maxEnnemies);
        if(Time.time > lastSpawned + 1f/waveDifficulty.rate && waveDifficulty.maxEnnemies > spawner.getAmmountOfEnnemies() ){
            lastSpawned = Time.time;
            spawner.spawnRandom();
            waveDifficulty.count--; //each time an ennemy spawn, reduce the ammount of ennemies left to spawn
            if(waveDifficulty.count <= 0){
                Destroy(gameObject); //when enough enemy spawned, the wave destroy itselfs allowing the next wave to start
            }
        }
    }
    
}
