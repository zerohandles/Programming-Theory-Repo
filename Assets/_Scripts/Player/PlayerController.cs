using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public List<GameObject> weapons = new List<GameObject>();
    Vector3 bulletOffSet = new Vector3(0,1,0);
    private float xBoundry = 52;
    private float zBoundry = 29;

    // ENCAPSULATION
    // Getters and setters for player's movement speed, fire rate and ammo type.
    [SerializeField] private float m_fireRate = 0.5f;
    public float fireRate
    {
        get { return m_fireRate; }
        set 
        {
            if (fireRate >= 0.2f)
            {
                m_fireRate = value;
                CancelInvoke();
                InvokeRepeating(nameof(FireWeapon), 0, fireRate);
            }
            else
            {
                m_fireRate = 0.1f;
                CancelInvoke();
                InvokeRepeating(nameof(FireWeapon), 0, fireRate);
            }
        }
    }
    [SerializeField] float maxSpeed = 20;

    // ENCAPSULATION
    [SerializeField] private float m_movementSpeed = 10;
    public float movementSpeed
    {
        get { return m_movementSpeed; }
        set 
        { 
            if (value < 0)
            {
                Debug.Log("Movement speed cannot be negative.");
                return;
            }

            if (value > maxSpeed)
            {
                value = maxSpeed;
            }

            m_movementSpeed = value;
        }
    }

    // ENCAPSULATION
    [SerializeField] private GameObject m_ammoType;
    public GameObject ammoType
    {
        get { return m_ammoType; }
        set
        {
            if (!value.gameObject.CompareTag("Ammo"))
            {
                return;
            }
            m_ammoType = value;
        }
    }

    // Keeps player within the game bounds
    private void Update()
    {
        if (transform.position.x < -xBoundry)
        {
            transform.position = new Vector3(-xBoundry, transform.position.y, transform.position.z);
        }
        if (transform.position.z < -zBoundry)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zBoundry);
        }
        if (transform.position.x > xBoundry)
        {
            transform.position = new Vector3(xBoundry, transform.position.y, transform.position.z);
        }
        if (transform.position.z > zBoundry)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zBoundry);
        }
    }


    // Move player on the X and Z
    public virtual void Move()
    {
        float horizontalMovement = Input.GetAxis("Horizontal");
        float vertialMovement = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontalMovement, 0, vertialMovement);
        Vector3 lookDirection = direction + gameObject.transform.position;

        transform.Translate(m_movementSpeed * Time.deltaTime * direction, Space.World);
        
        // Character model will look in the direction of movement
        gameObject.transform.LookAt(lookDirection);
    }

    //  Fire weapons depending on the ammo type currently equipped
    public virtual void FireWeapon()
    {
        string weaponName = m_ammoType.name;
        switch (weaponName)
        {
            default:
                {
                    Instantiate(ammoType, transform.position + bulletOffSet, transform.rotation);
                    break;
                }
            case "BananaAmmo":
                {
                    Instantiate(ammoType, transform.position + bulletOffSet, Quaternion.Euler(0, 0, 0));
                    Instantiate(ammoType, transform.position + bulletOffSet, Quaternion.Euler(0,120, 0));
                    Instantiate(ammoType, transform.position + bulletOffSet, Quaternion.Euler(0, 240, 0));
                    break;
                }
        }
        
    }

    public void OnCollisionEnter(Collision collision)
    {
        string ammo = collision.gameObject.tag;
        
        // Change ammo type depending on the powerup
        switch(ammo)
        {
            case "Pizza":
                {
                    ammoType = weapons[0];
                    Destroy(collision.gameObject);
                    break;
                }
            case "Banana":
                {
                    ammoType = weapons[1];
                    Destroy(collision.gameObject);
                    break;
                }
            case "Bone":
                {
                    ammoType = weapons[2];
                    Destroy(collision.gameObject);
                    break;
                }
            case "Carrot":
                {
                    ammoType = weapons[3];
                    Destroy(collision.gameObject);
                    break;
                }
            default:
                {
                    break;
                }
        }
    }

    // Additional power up effects added on collision
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Fire"))
        {
            fireRate -= 0.2f;
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("Speed"))
        {
            movementSpeed += 3f;
            Destroy(other.gameObject);
        }
    }
}
