using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class weaponModifier{
    public float rateOfFireMultiplier = 1f;
    public float projectileSpeedMultiplier = 1f;
    public float rangeMultiplier = 1f;
    public Color projectilesColors = new Color(0,0,0,0);
    public int damages = 0;
}

[System.Serializable]
public class playerModifier{
    public  shipStat playerShipStats;

    public  StaminaControl stamina;
    public  float sprintMultiplier;
}

public abstract class itemController : MonoBehaviour{ 

    public Sprite itemSprite;
    public string itemName ="Default Item Name";
    public string itemDescription = "Default item decription";
    public int defaultItemPrice = 1;

    public playerModifier playerModifier;
    public weaponModifier weaponModifier;

    

    public virtual void editProjectile(List<GameObject> projectile) {
        
    }    
    

}
