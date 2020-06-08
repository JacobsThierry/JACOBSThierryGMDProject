using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WaveDifficulty
{
    public int count=5;
    public int maxEnnemies=5;
    public float rate=0.1f; //time between spawnes
    public float strenght=1;
    public float strenghtDelta=0;

    public WaveDifficulty(int count, int maxEnnemies, float rate, float strenght, float strenghtDelta)
    {
        this.count = count;
        this.maxEnnemies = maxEnnemies;
        this.rate = rate;
        this.strenght = strenght;
        this.strenghtDelta = strenghtDelta;
    }

    public WaveDifficulty(){
        ;
    }

    public WaveDifficulty(WaveDifficulty wd){
        count = wd.count; maxEnnemies = wd.maxEnnemies ; rate = wd.rate ; strenght = wd.strenght ; strenghtDelta = wd.strenghtDelta;

    }
    public void copy(WaveDifficulty wd){
        count = wd.count; maxEnnemies = wd.maxEnnemies; rate = wd.rate; strenght = wd.strenght; strenghtDelta = wd.strenghtDelta;
    }

    public void UpdateDifficulty(WaveDifficulty baseDifficulty, WaveDifficulty difficultyMultiplier, float difficultyIncrase){
        this.count = (int)(baseDifficulty.count + difficultyIncrase * difficultyMultiplier.count);
        this.maxEnnemies = (int)(baseDifficulty.maxEnnemies + difficultyIncrase * difficultyMultiplier.maxEnnemies);
        this.rate = (baseDifficulty.rate + difficultyIncrase * difficultyMultiplier.rate);
        Debug.Log("base rate = " + baseDifficulty.rate + " increase = " + difficultyIncrase + " multiplyer : " + difficultyMultiplier.rate);
        Debug.Log("rate = " + rate);
        this.strenght = (baseDifficulty.strenght + difficultyIncrase * difficultyMultiplier.strenght);
    }

}

public class SpawnerController : MonoBehaviour
{

    
    private List<GameObject> ennemies;
    public int ammountOfWaves;
    public WaveDifficulty baseDifficulty;

    [Tooltip("Difficulty of a wave = base difficulty + difficulty increase * difficulty multiplier. Strenght delta not affected")]
    public WaveDifficulty difficultyMultiplier;
    public float difficultyIncrase;
    public float difficultyIncraseStep;
    public float spawnRange;

    [System.NonSerialized]
    public waveController currentWave= null;
    private Transform ennemiesContainer;
    public WaveDifficulty currentDifficulty;
    public float breakTime;
    private float lastWave;


    // Start is called before the first frame update
    void Start()
    {   //if the distance at wich ennemies must spawn is not set, it will be 1 times the distances between the spawner and the player's boundaries
        ennemies = new List<GameObject>(Resources.LoadAll<GameObject>("Characters/Enemies"));
        lastWave = Time.time - breakTime;
        if(spawnRange == 0) spawnRange = Vector3.Distance(transform.position, GameObject.Find("RWall").transform.position) * 1f;
        currentWave = null;
        ennemiesContainer = GameObject.Find("ennemies").transform;
    }

    public GameObject spawn(GameObject ennemy, Vector3 position){
        GameObject en = Instantiate(ennemy);
        en.transform.parent = ennemiesContainer;
        en.transform.position = position;
        return en;
    }
    public GameObject spawnAtRandomPos(GameObject ennemy){
        Vector2 v = Random.insideUnitCircle.normalized * spawnRange; // a random point in the spawnrange
        return spawn(ennemy, transform.TransformPoint(new Vector3(v.x, 0, v.y)));
    }
    public GameObject spawnRandom(){
        return spawnAtRandomPos(getRandomEnnemy());
    }

    public GameObject getRandomEnnemy(){
        GameObject en;
        float tier;
        do{
            en = ennemies[Random.Range(0, ennemies.Count)];
            tier = (float) en.GetComponent<DefaultEnnemieController>().tiere;
            print(en.name);
            print("chances de restart : " + 1f / ((tier) * 2f));
        }while(
            (!(tier==0)) &&
            (tier > currentDifficulty.strenght
             ||
            (Random.Range(0f,1f) > (1f/((tier)*2f)) ))
        );
        
        
        return en;
        


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void nextWave(){
        GameObject wave = createWave(); // creating a new GameObject instanciate the object
        difficultyIncrase += difficultyIncraseStep;
        currentWave = wave.GetComponent<waveController>();
        currentWave.transform.parent = this.transform;
        
    }

    GameObject createWave(){
        GameObject wave = new GameObject();
        wave.name = "currentWave";
        waveController wc = wave.AddComponent<waveController>();
        wc.waveDifficulty = getWaveDifficulty();
        return wave;
    }

    public WaveDifficulty getWaveDifficulty(){
        WaveDifficulty wd = new WaveDifficulty();
        wd.UpdateDifficulty(baseDifficulty, difficultyMultiplier, difficultyIncrase);
        return wd;
    }

    private void FixedUpdate() {
        
        if(currentWave==null && (ammountOfWaves > 0 || ammountOfWaves < -30 /* endless if ammount < -30 */ ) && lastWave + breakTime < Time.time ) { //if this is the first wave or the current wave is finished => next wave
            lastWave = Time.time;
            ammountOfWaves--; 
            nextWave();
        }
    }

    public int getAmmountOfEnnemies(){
        return ennemiesContainer.childCount;
    }

}
