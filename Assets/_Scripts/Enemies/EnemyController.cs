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

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerHealth.playerHealth -= damageDealt;
        }
    }
}
