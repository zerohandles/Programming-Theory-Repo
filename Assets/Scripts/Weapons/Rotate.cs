using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] Vector3 rotationSpeed;

    void Update()
    {
        transform.Rotate(rotationSpeed);
    }
}
