using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunkController : PlayerController
{
    // INHEIRITANCE
    private void Awake()
    {
        movementSpeed = 7;
        ammoType = weapons[2];
        InvokeRepeating(nameof(FireWeapon), 0, fireRate);
    }

    // ABSTRACTION
    void FixedUpdate()
    {
        Move();
    }

}
