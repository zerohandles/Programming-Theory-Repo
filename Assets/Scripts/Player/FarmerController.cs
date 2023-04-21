using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmerController : PlayerController
{
    float fireRate = 0.3f;

    // INHEIRITANCE
    private void Awake()
    {
        playerHealth = 100;
        movementSpeed = 10;
        ammoType = weapons[3];
        InvokeRepeating(nameof(FireWeapon), 0, fireRate);
    }

    // INHEIRITANCE
    void FixedUpdate()
    {
        Move();
    }
}
