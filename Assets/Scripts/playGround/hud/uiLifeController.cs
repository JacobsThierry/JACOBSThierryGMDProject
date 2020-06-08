using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


public class uiLifeController : MonoBehaviour
{

    private playerController player;
    
    private int life;
    public Gradient healthGradient;
    private Color colour;
    public GameObject barFilled;
    public GameObject barEmpty;
    public float barDistance;

    

    // Start is called before the first frame update
    void Start()
    {
        setPlayer();
    }

private void OnEnable() {
    Ship.PlayerHitEvent += updateHealth;
}

private void OnDisable() {
        Ship.PlayerHitEvent -= updateHealth;
}

    Color ColorFromGradient(float heal, float max){ //Get the color of the lifebar for a given health
        float value = heal/max;
        return healthGradient.Evaluate(value);
    }

    public void updateHealth(){

        if (player == null)
        {
            setPlayer();
        }

        Transform parent = transform.Find("heart");
        foreach(Transform child in parent){
            Destroy(child.gameObject);
        }

        RectTransform rt = parent.GetComponent<RectTransform>();
        float actpos = parent.localPosition.x + rt.rect.width + barDistance; //x value for the next bar
        
        if(player.playerShip != null){
         for(int i=0;i<player.playerShip.stats.maxHealth;i++){
             GameObject bar;
             if(player.playerShip.stats.health > i) bar = barFilled;
             else bar = barEmpty;
            GameObject barr = Instantiate(bar, new Vector3(0f, actpos, 0f), Quaternion.Euler(0,0,0));
            barr.transform.SetParent(parent);
            barr.transform.localPosition = new Vector3(actpos, parent.transform.position.y , parent.transform.position.z );
            RectTransform rt2 = barr.GetComponent<RectTransform>();
            float scaler = rt2.rect.height/ rt.rect.height; //used to scale the barrs
            float newHeight = rt2.rect.height/scaler;
            print("newHeight " + newHeight);
            float newWidth = rt2.rect.width / scaler;
            
            rt2.sizeDelta = new Vector3(newWidth, newHeight, scaler);

            var img = barr.GetComponent<UnityEngine.UI.Image>();
            img.color = ColorFromGradient(player.playerShip.stats.health, player.playerShip.stats.maxHealth);
            actpos += barDistance + rt2.rect.width;


             
             
         }}
    }

    void setPlayer(){
        try{player = GameObject.FindGameObjectWithTag("Player").GetComponent<playerController>();}catch{;};
        if(player != null) updateHealth();
    }

    // Update is called once per frame
    void Update()
    {
         //if we get the player on start --> null pointer exception, the ui must be loaded first
        
        
        
        
         
        
        //print("health :" + player.health);
        
    }
}
