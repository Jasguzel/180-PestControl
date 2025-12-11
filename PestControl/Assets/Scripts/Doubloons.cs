using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Guzeldere, Jasmine
 * 12/10/2015
 * Handles the behaviour/existance of coin objects
 */
public class Doubloons : MonoBehaviour
{
    public int doubloonsValue = 1;
    public float doubloonRotateSpeed = 10f;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, doubloonRotateSpeed * Time.deltaTime * 10, 0);
    }
    /// <summary>
    /// Checks for player collision with dooubloons
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerController>())
        {
            other.GetComponent<PlayerController>().doubloons += doubloonsValue;
            Destroy(gameObject);
        }
    }
}
