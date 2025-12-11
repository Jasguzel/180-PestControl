using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


/*
 * Frederick Southworth
 * 11/12/2025
 * This script will control the bullet's behavior
 */

public class Bullet : MonoBehaviour
{
    public int bulletDamage = 1;
    Rigidbody rb;
    [SerializeField] float bulletSpeed;
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * bulletSpeed;
    }
}
