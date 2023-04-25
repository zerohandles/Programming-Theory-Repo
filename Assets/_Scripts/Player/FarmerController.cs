using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmerController : PlayerController
{
    // INHEIRITANCE
    private void Awake()
    {
        fireRate = 0.3f;
        movementSpeed = 10;
        ammoType = weapons[3];
        InvokeRepeating(nameof(FireWeapon), 0, fireRate);
    }

    // ABSTRACTION
    void FixedUpdate()
    {
        Move();
    }
}
