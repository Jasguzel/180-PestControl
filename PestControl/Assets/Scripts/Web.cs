using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Web : MonoBehaviour
{
    public int webDamage = 1;
    void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
