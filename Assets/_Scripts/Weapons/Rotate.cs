using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] Vector3 rotationSpeed;

    // Constantly rotates the object
    void Update()
    {
        transform.Rotate(rotationSpeed);
    }
}
