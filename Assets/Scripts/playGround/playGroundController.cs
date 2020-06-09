using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class playGroundController : MonoBehaviour
{

    public GameObject player;

    public bool done; //if the player has beaten every waves --> true

    [System.NonSerialized]
    public bool doneAnimation;
    [System.NonSerialized]
    public float animationStart;

    public float animationTime=30f;

    public float animationBackgroundAceleration = 1f;
    private UnityEngine.UI.Image fadeImage;
    private Background_Controller bg;

    // Start is called before the first frame update
    void Start()
    {
        done = false;
        doneAnimation = false;
        if(player == null){
            print("foo");
            player = (GameObject) Resources.Load<GameObject>("Characters/Player/defaultPlayer");
        }
        GameObject player2 = Instantiate(player, transform);
        audioManager.playPlaygroundMusic(gameObject);
    }

    void playFinishedAnimation(){
        print("animation !!");
        
        if(!doneAnimation){
            bg = transform.Find("Background").GetComponent<Background_Controller>();
            fadeImage = transform.Find("gameUi").Find("FadeImage").GetComponent<UnityEngine.UI.Image>();
            doneAnimation = true;
            animationStart = Time.time;
            StartCoroutine(fadingOut());
        }else{

            
            if(animationStart + animationTime < Time.time){
                player = GameObject.FindGameObjectWithTag("Player");
                GameObject.Find("game").GetComponent<gameController>().pgDone();
            }
        }
        

    }

    IEnumerator fadingOut(){
        while(true){
            bg.speedMultiplier += animationBackgroundAceleration * Time.deltaTime;
            print("at = " + (animationStart + Time.time) + " 1/animt = " + 1 / animationTime);
            float timePassed = (Time.time - animationStart);
            float alphaValue = (1f / animationTime) * timePassed; //the alpha value the gradiant mask should take
            fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, alphaValue);
            yield return null;
}
    }

    private void OnDestroy() {
        StopCoroutine(fadingOut());
    }

    // Update is called once per frame
    void Update()
    {
        
        SpawnerController spawner = transform.Find("EnnemiesSpawner").GetComponent<SpawnerController>();
        print("pg ammount of waves : " + spawner.ammountOfWaves + " ennemies : " + spawner.getAmmountOfEnnemies());
        if( (spawner.ammountOfWaves <= 0 && spawner.getAmmountOfEnnemies() == 0) || doneAnimation){
            playFinishedAnimation();
        }
    }
}
