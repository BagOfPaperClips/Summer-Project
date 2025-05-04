using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 5f;
    [SerializeField] private Vector2 direction = Vector2.zero;
    Vector2 movement;

    [SerializeField] private bool canMove = true;


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



        }
        if (Input.GetKey(KeyCode.D))
        {
            this.transform.position += Vector3.right * this.movementSpeed * Time.deltaTime;
            this.direction.x = this.movementSpeed;

        }
        if (Input.GetKey(KeyCode.W))
        {
            this.transform.position += Vector3.up * this.movementSpeed * Time.deltaTime;
            this.direction.y = this.movementSpeed;

        }
        if (Input.GetKey(KeyCode.S))
        {
            this.transform.position += Vector3.down * this.movementSpeed * Time.deltaTime;
            this.direction.y = -this.movementSpeed;

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

        }


    }

}
