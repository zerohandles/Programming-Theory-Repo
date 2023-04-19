using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public List<GameObject> weapons = new List<GameObject>();

    // Getters and setters for player's 
    [SerializeField] private float m_PlayerHealth = 100;
    public float playerHealth
    {
        get { return m_PlayerHealth; }
        set
        {
            if (value < 0)
            {
                value = 0;
            }
            m_PlayerHealth = value;
        }
    }

    private float turnSpeed = 2;
    [SerializeField] float maxSpeed = 20;
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

    Vector3 bulletOffSet = new Vector3(0,1,1);

    public virtual void Move()
    {
        float horizontalMovement = Input.GetAxis("Horizontal");
        float vertialMovement = Input.GetAxis("Vertical");

        transform.Translate(m_movementSpeed * Time.deltaTime * vertialMovement * Vector3.forward);
        transform.Rotate(turnSpeed * horizontalMovement * Vector3.up);
    }

    public virtual void FireWeapon()
    {
        string weaponName = m_ammoType.name;
        Instantiate(ammoType, transform.position + bulletOffSet, transform.rotation);
    }


    public void OnCollisionEnter(Collision collision)
    {
        string ammo = collision.gameObject.tag;
        
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
}
