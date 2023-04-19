using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public float bulletSpeed = 50f;


    public void Update()
    {
        transform.Translate(bulletSpeed * Time.deltaTime * Vector3.forward);
    }
}
