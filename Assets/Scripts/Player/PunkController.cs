using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunkController : PlayerController
{
    float fireRate = 0.5f;

    // INHEIRITANCE
    private void Awake()
    {
        playerHealth = 150;
        movementSpeed = 7;
        ammoType = weapons[2];
        InvokeRepeating(nameof(FireWeapon), 0, fireRate);
    }

    // INHEIRITANCE
    void FixedUpdate()
    {
        Move();
    }
       

}
