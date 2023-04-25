using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    // ENCAPSULATION
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
}
