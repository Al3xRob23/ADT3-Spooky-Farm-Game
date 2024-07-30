using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{
    public Slider slider;



    //---------------------------------------------------------
public float Stamina = 10.0f;
public float MaxStamina = 10.0f;

//---------------------------------------------------------
private float StaminaRegenTimer = 0.0f;

//---------------------------------------------------------
private const float StaminaDecreasePerFrame = 1.0f;
private const float StaminaIncreasePerFrame = 5.0f;
private const float StaminaTimeToRegen = 3.0f;

//---------------------------------------------------------


private void Update()
{
    bool isRunning = Input.GetKey(KeyCode.LeftShift);

    if (isRunning)
    {
        Stamina = Mathf.Clamp(Stamina - (StaminaDecreasePerFrame * Time.deltaTime), 0.0f, MaxStamina);
        StaminaRegenTimer = 2.0f;
        slider.value = Stamina;
    }
    else if (Stamina < MaxStamina)
    {
        if (StaminaRegenTimer >= StaminaTimeToRegen)
            Stamina = Mathf.Clamp(Stamina + (StaminaIncreasePerFrame * Time.deltaTime), 1.0f, MaxStamina);
        else
            StaminaRegenTimer += Time.deltaTime;
            slider.value = Stamina;
    }
}
}
