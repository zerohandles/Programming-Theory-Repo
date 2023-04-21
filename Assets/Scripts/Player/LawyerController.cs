using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LawyerController : PlayerController
{
    float fireRate = 0.5f;

    // INHEIRITANCE
    private void Awake()
    {
        playerHealth = 100;
        movementSpeed = 13;
        ammoType = weapons[0];
        InvokeRepeating(nameof(FireWeapon), 0, fireRate);
    }

    // INHEIRITANCE
    void FixedUpdate()
    {
        Move();
    }
}
