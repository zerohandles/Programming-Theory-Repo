using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : EnemyController
{
    [SerializeField] private int health;
    [SerializeField] List <GameObject> drop;
    private Vector3 dropOffset = new Vector3(0, 2, 0);


    // POLYMORPHISM
    public override void TakeDamage()
    {
        health--;
        if (health == 0)
        {
            int index = Random.Range(0, drop.Count);
            Instantiate(drop[index], transform.position + dropOffset, drop[index].transform.rotation);
            base.TakeDamage();
            Debug.Log("Drop");
        }
    }
}
