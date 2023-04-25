using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    GameObject player;
    PlayerHealth health;
    Slider healthSlider;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        health = player.GetComponent<PlayerHealth>();
        healthSlider = GetComponent<Slider>();

        healthSlider.maxValue = health.playerHealth;
        // Set healthbar size here
    }

 
    void Update()
    {
        healthSlider.value = health.playerHealth;
    }
}
