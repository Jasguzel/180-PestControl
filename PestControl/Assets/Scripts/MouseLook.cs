using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Frederick Southworth
 * 12/10/2025
 * This script shall control the player mouse look around
 */

public class MouseLook : MonoBehaviour
{
    //This defines the bullet and firing position
    public GameObject BulletPrefab;
    public GameObject FirePos;

    Vector2 mouseLook;
    Vector2 smoothV;
    public float sensitivity = 5.0f;
    public float smoothing = 2.0f;

    GameObject character;


    void Start()
    {
        character = this.transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {


        var md = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

        md = Vector2.Scale(md, new Vector2(sensitivity * smoothing, sensitivity * smoothing));
        smoothV.x = Mathf.Lerp(smoothV.x, md.x, 1f / smoothing);
        smoothV.y = Mathf.Lerp(smoothV.y, md.y, 1f / smoothing);
        mouseLook += smoothV;

        mouseLook.y = Mathf.Clamp(mouseLook.y, -90f, 90f);
        //s mouseLook.x = Mathf.Clamp(mouseLook.x, -90f, 90f);

        transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
        character.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, character.transform.up);


    }
}
