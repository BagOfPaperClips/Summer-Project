using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 5f;
    [SerializeField] private Vector2 direction = Vector2.zero;
    public Rigidbody2D rb;
    Vector2 movement;

    [SerializeField] private bool canMove = true;
    [SerializeField] private int moveState = 0;
    Animator myAnimator;

    /*
    public Vector2 camDef;
    CameraMovement cm;
    */

    void Start()
    {
        myAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        handleMovement();
    }

    protected void handleMovement()
    {
        if (!canMove) return;
        if (Input.GetKey(KeyCode.A))
        {
            this.transform.position += Vector3.left * this.movementSpeed * Time.deltaTime;
            this.direction.x = -this.movementSpeed;

            moveState = 1;


        }
        if (Input.GetKey(KeyCode.D))
        {
            this.transform.position += Vector3.right * this.movementSpeed * Time.deltaTime;
            this.direction.x = this.movementSpeed;

            moveState = 2;

        }
        if (Input.GetKey(KeyCode.W))
        {
            this.transform.position += Vector3.up * this.movementSpeed * Time.deltaTime;
            this.direction.y = this.movementSpeed;

            moveState = 3;


        }
        if (Input.GetKey(KeyCode.S))
        {
            this.transform.position += Vector3.down * this.movementSpeed * Time.deltaTime;
            this.direction.y = -this.movementSpeed;

            moveState = 4;


        }

        // movement cancellation
        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            this.direction.x = 0;
        }
        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S))
        {
            this.direction.y = 0;
        }

        // idle
        if (!(
            Input.GetKey(KeyCode.W) ||
            Input.GetKey(KeyCode.A) ||
            Input.GetKey(KeyCode.S) ||
            Input.GetKey(KeyCode.D)
            ))
        {
            moveState = 0;
            /*
            camDef = direction;
            cameraDefualt(camDef);
            */
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        myAnimator.SetInteger("moveState", moveState);

    }

    /*
    void cameraDefualt(Vector2 camDef)
    {
        
        cm.transform.position = camDef;
    }
    */
}
