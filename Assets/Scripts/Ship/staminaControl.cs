
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class StaminaControl
{

    public float maxStamina = 1f;
    public float stamina = 1f;
    public float staminaConsumtion = 0.2f;
    public float staminaRegeneration = 0.1f;
    private bool running = false;

    public StaminaControl clone()
    {
        StaminaControl s = new StaminaControl();
        s.maxStamina = maxStamina;
        s.stamina = stamina;
        s.staminaConsumtion = staminaConsumtion;
        s.staminaRegeneration = staminaRegeneration;
        s.running = false;
        return s;
    }
    public StaminaControl()
    {
        ;
    }

    public StaminaControl(float maxStamina, float stamina, float staminaConsumtion, float staminaRegeneration)
    {
        this.maxStamina = maxStamina;
        this.stamina = stamina;
        this.staminaConsumtion = staminaConsumtion;
        this.staminaRegeneration = staminaRegeneration;
    }

    public void addStats(StaminaControl s)
    {
        maxStamina *= s.maxStamina;
        s.staminaConsumtion *= s.staminaConsumtion;
        s.staminaRegeneration *= s.staminaRegeneration;
    }

    public void regen()
    {
        if (stamina < maxStamina)
            stamina += staminaRegeneration * Time.deltaTime;

    }

    public void setRunning(bool run)
    {
        running = run;
    }


    public void drainStamina()
    {
        float multiplier = Input.GetAxis("Sprint");
        float hor = Mathf.Abs(Input.GetAxis("Horizontal")) / 2;
        float ver = Mathf.Abs(Input.GetAxis("Vertical")) / 2;
        float dist = hor + ver;
        multiplier *= dist;
        if (stamina > 0)
            stamina -= staminaConsumtion * Time.deltaTime * multiplier; //the stamina drained is relative to how the player use the sprint
    }

    public void tick()
    {
        Debug.Log("Stamina = " + stamina);
        if (!running)
        {
            regen();
        }
        else
        {

            drainStamina();
        }
    }

}