using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class uiStaminaController : MonoBehaviour
{

    private playerController player;
    public Gradient staminaGradiant;
    private UnityEngine.UI.Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        try{
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<playerController>();
        }catch{;}
        slider = transform.Find("Slider").GetComponent<UnityEngine.UI.Slider>();

    }

    Color ColorFromGradient(float act, float max)
    { //Get the color of the lifebar for a given health
        float value = act / max;
        return staminaGradiant.Evaluate(value);
    }

    void updateStamina(){
        slider.value = player.stamina.stamina / player.stamina.maxStamina;
        slider.fillRect.GetComponent<UnityEngine.UI.Image>().color = ColorFromGradient(player.stamina.stamina, player.stamina.maxStamina);
    }



    // Update is called once per frame
    void Update()
    {
        if(player != null) updateStamina();
        else try { player = GameObject.FindGameObjectWithTag("Player").GetComponent<playerController>(); } catch {; }
    }
}
