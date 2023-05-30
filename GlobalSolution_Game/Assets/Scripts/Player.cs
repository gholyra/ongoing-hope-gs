using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    Transform playerTransform;
    Rigidbody2D rigidBody;


    [SerializeField] private float velocity;
    [SerializeField] private float jumpForce;
    private bool isOnFloor = false;

    // Start is called before the first frame update
    private void Awake()
    {
        playerTransform = GetComponent<Transform>();  
        rigidBody = GetComponent<Rigidbody2D>();  
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        float moveX = Input.GetAxisRaw("Horizontal") * velocity * Time.deltaTime;
        //float moveY = Input.GetAxisRaw("Vertical") * velocity * Time.deltaTime;
        playerTransform.Translate(new Vector3(moveX, 0));

        if (Input.GetButtonDown("Jump") && isOnFloor)
        {
            rigidBody.AddForce(Vector2.up * jumpForce);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isOnFloor = true;
    }

}
