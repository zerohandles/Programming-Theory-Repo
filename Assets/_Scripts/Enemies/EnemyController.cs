using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private GameObject player;
    private PlayerHealth playerHealth;
    public float movementSpeed = 5f;
    [SerializeField] float damageDealt;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
    }

    // Enemies face the player and constantly move toward them. 
    void Update()
    {
        transform.LookAt(player.transform.position);
        transform.Translate(movementSpeed * Time.deltaTime * Vector3.forward);
    }

    // Trigger damage to player on collision
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ammo"))
        {
            TakeDamage();
            Destroy(other.gameObject);
        }
    }

    // ABSTRACTION / POLYMORPHISM
    public virtual void TakeDamage()
    {
        Destroy(gameObject);
    }


    // Deal damage to player when colliding with them
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerHealth.playerHealth -= damageDealt;
        }
    }
}
