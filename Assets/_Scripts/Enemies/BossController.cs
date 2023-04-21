using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : EnemyController
{
    [SerializeField] private int health;
    [SerializeField] List <GameObject> drop;


    // POLYMORPHISM
    public override void TakeDamage()
    {
        health--;
        if (health <= 0)
        {
            int index = Random.Range(0, drop.Count);
            Instantiate(drop[index], transform.position, drop[index].transform.rotation);
            base.TakeDamage();
        }
    }
}
