using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public float bulletSpeed = 50f;
    [SerializeField] float lifeTime = 5;

    private void Start()
    {
        StartCoroutine(nameof(LifeTimer));
    }

    // Travel in a straight line
    public void Update()
    {
        transform.Translate(bulletSpeed * Time.deltaTime * Vector3.forward);
    }

    // Destroy object after its lifetime.
    IEnumerator LifeTimer()
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
    }
}
