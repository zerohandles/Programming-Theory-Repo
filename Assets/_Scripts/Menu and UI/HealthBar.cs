using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBar : MonoBehaviour
{
    GameObject player;
    PlayerHealth health;
    Slider healthSlider;
    public TextMeshProUGUI healthText;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        health = player.GetComponent<PlayerHealth>();
        healthSlider = GetComponent<Slider>();

        healthSlider.maxValue = health.playerHealth;
        // Set health bar size based on character starting health here
    }

    // Update health slider value and text
    void Update()
    {
        healthSlider.value = health.playerHealth;
        healthText.text = $"{healthSlider.value}/{healthSlider.maxValue}";
    }
}
