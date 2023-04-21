using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private GameObject player;
    public float movementSpeed = 5f;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }


    void Update()
    {
        transform.LookAt(player.transform.position);
        transform.Translate(movementSpeed * Time.deltaTime * Vector3.forward);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ammo"))
        {
            TakeDamage();
            Destroy(other.gameObject);
        }
    }

    public virtual void TakeDamage()
    {
        Destroy(gameObject);
    }
}
