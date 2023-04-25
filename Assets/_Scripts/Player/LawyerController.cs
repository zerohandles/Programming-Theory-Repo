using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LawyerController : PlayerController
{
    // INHEIRITANCE
    private void Awake()
    {
        movementSpeed = 13;
        ammoType = weapons[0];
        InvokeRepeating(nameof(FireWeapon), 0, fireRate);
    }

    // ABSTRACTION
    void FixedUpdate()
    {
        Move();
    }

}
