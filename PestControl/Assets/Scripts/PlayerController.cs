using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * Frederick Southworth
 * 11/20/2025
 * This script shall control the player, how it acts, moves, and interacts with things within the game
 */

public class PlayerController : MonoBehaviour
{

    //This defines the rigid body on the player and then calls it in void start
    private Rigidbody body;
    //this checks how close to the walls around us are
    private float frontWall, backWall, leftWall, rightWall = 2f;
    //The is_grounded will check if you are .1 unity unit from the ground (referenced from array inventory unity project)
    private bool isGrounded;


    public float playerJump = 7;
    Vector3 playerDirection;


    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float translation = Input.GetAxis("Vertical") * 10 * Time.deltaTime;
        float straffe = Input.GetAxis("Horizontal") * 10 * Time.deltaTime;

        if (!isGrounded)
            straffe /= 2;

        if (!isGrounded)
            translation /= 2;


        //if I get too close to a wall, I stop
        if ((backWall <= .6 && translation < 0) || (frontWall <= .6 && translation > 0))
        {
            translation = 0;
        }
        if ((rightWall < .6 && straffe > 0) || (leftWall < .6 && straffe < 0))
        {
            straffe = 0;
        }

        //Translate to move (this gets it to move)
        transform.Translate(straffe, 0, translation);




        if (Input.GetKeyDown("escape"))
        {
            Cursor.lockState = CursorLockMode.None;
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

    }

    private void FixedUpdate()
    {
        DistanceToWall();
        Vector3 oldRot = transform.rotation.eulerAngles;
        transform.rotation = Quaternion.Euler(0, oldRot.y, 0);
    }

    private void DistanceToWall()
    {
        RaycastHit hit;
        Ray left_ray = new Ray(transform.position, -transform.right);
        Ray front_ray = new Ray(transform.position, transform.forward);
        Ray back_ray = new Ray(transform.position, -transform.forward);
        Ray right_ray = new Ray(transform.position, transform.right);

        //Raycast left to see if I find a wall
        if (Physics.Raycast(left_ray, out hit) && !hit.collider.isTrigger)
        {
            leftWall = hit.distance;
        }
        else
        {
            leftWall = 3;
        }

        //Raycast center forward to find a wall
        if (Physics.Raycast(front_ray, out hit) && !hit.collider.isTrigger)
        {
            frontWall = hit.distance;
        }
        else
        {
            frontWall = 3;
        }

        //Raycast center forward to find a wall
        if (Physics.Raycast(back_ray, out hit) && !hit.collider.isTrigger)
        {
            backWall = hit.distance;
        }
        else
        {
            backWall = 3;
        }

        //Raycast right to find a wall
        if (Physics.Raycast(right_ray, out hit) && !hit.collider.isTrigger)
        {
            rightWall = hit.distance;
        }
        else
        {
            rightWall = 3;
        }


        //Raycast down to find the ground
        if (Physics.Raycast(transform.position, -transform.up, 1.1f))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }

    }
}
