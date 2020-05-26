using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{

    public float Health;
    public float healthOverTimer;

    public float Stamina;
    public float staminaOverTime;

    public float Hunger;
    public float hungerOverTime;

    public float Thirst;
    public float thirstOverTime;

    public float Radiation;
    public float radiationOverTime;



    public Slider HealthBar;
    public Slider StaminaBar;
    public Slider HungerBar;
    public Slider ThirstBar;
    public Slider RadiationBar;

    public float minAmount = 5f;
    public float sprintSpeed = 5f;

    Rigidbody myBody;

    private void Start()
    {
        myBody = GetComponent<Rigidbody>();
        HealthBar.maxValue = Health;
        StaminaBar.maxValue = Stamina;
        HungerBar.maxValue = Hunger;
        ThirstBar.maxValue = Thirst;
        RadiationBar.maxValue = Radiation;

        updateUI();
    }

    private void Update()
    {
        CalculateValues();
    }

    private void CalculateValues()
    {
        Hunger -= hungerOverTime * Time.deltaTime;
        Thirst -= thirstOverTime * Time.deltaTime;

        if (Hunger <= minAmount || Thirst <= minAmount)
        {
            Health -= healthOverTimer * Time.deltaTime;
            Stamina -= staminaOverTime * Time.deltaTime;
        }

        if (myBody.velocity.magnitude >= sprintSpeed && myBody.velocity.y == 0)
        {
            Stamina -= staminaOverTime * Time.deltaTime;
            Hunger -= hungerOverTime * Time.deltaTime;
            Thirst -= thirstOverTime * Time.deltaTime;
        }
        else
        {
            Stamina += staminaOverTime * Time.deltaTime;
        }


        if (Health <= 0)
        {
            print("PLAYER HAS DIED");
        }

        updateUI();
    }

    private void updateUI()
    {
        Health = Mathf.Clamp(Health, 0, 100f);
        Stamina = Mathf.Clamp(Stamina, 0, 100f);
        Hunger = Mathf.Clamp(Hunger, 0, 100f);
        Thirst = Mathf.Clamp(Thirst, 0, 100f);
        Radiation = Mathf.Clamp(Radiation, 0, 100f);

        HealthBar.value = Health;
        StaminaBar.value = Stamina;
        HungerBar.value = Hunger;
        ThirstBar.value = Thirst;
        RadiationBar.value = Radiation;
    }

    public void TakeDamage(float pDam)
    {
        Health -= pDam;
        updateUI();
    }

}