using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class reactorManager
{
    float baseLifeTime;
    float baseRate;
    float baseSpeed;
    GameObject particle;
    public reactorManager(GameObject ps)
    {
        particle = ps;
        var pS = ps.GetComponent<ParticleSystem>();
        baseRate = pS.emission.rateOverTime.constant;
        baseLifeTime = pS.main.startLifetime.constant;
        baseSpeed = pS.main.startSpeed.constant;
    }

    public void changePower(float powerMultiplicator, float rateMultiplier, float lifeMultiplier, float speedMultiplier){
        var emiss = particle.GetComponent<ParticleSystem>().emission;
        emiss.rateOverTime = new ParticleSystem.MinMaxCurve(baseRate * powerMultiplicator * rateMultiplier);
        var main = particle.GetComponent<ParticleSystem>().main;
        main.startLifetime = new ParticleSystem.MinMaxCurve(baseLifeTime * powerMultiplicator * lifeMultiplier);
        main.startSpeed = new ParticleSystem.MinMaxCurve(baseSpeed * powerMultiplicator * speedMultiplier);
    }

}

public class reactorController : MonoBehaviour
{

    public float powerMultiplicator=1;
    public float minPower = 0.1f;

    private List<reactorManager> lbp = new List<reactorManager>();
    public float baseReactorePower;
    public float spawnRateMultiplier = 1f;
    public float lifeTimeMultiplier = 1f;
    public float speedMultiplier = 1f;
    public float particleSize = 1f;


    // Start is called before the first frame update
    void Start()
    {

        foreach(Transform child in transform){
            lbp.Add(new reactorManager(child.gameObject));
            child.localScale = new Vector3(particleSize, particleSize, particleSize);
        }
    }

    // Update is called once per frame
    void Update()
    {
        try{
        powerMultiplicator = transform.parent.parent.GetComponent<Ship>().getCurrentForwardSpeed() + baseReactorePower;
        }catch{
            powerMultiplicator = 1f;
        }
        if(powerMultiplicator < minPower) powerMultiplicator = minPower;
            for(int i=0; i<lbp.Count ;i++){
                lbp[i].changePower(powerMultiplicator, spawnRateMultiplier, lifeTimeMultiplier, speedMultiplier);
            }
        
    }
}
