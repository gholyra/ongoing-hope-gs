using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;

    Transform playerTransform;
    Rigidbody2D rigidBody;

    [SerializeField] private float velocity;

    private bool canMove;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
        playerTransform = GetComponent<Transform>();
        rigidBody = GetComponent<Rigidbody2D>();
        canMove = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        if (canMove) 
        {
            float moveX = Input.GetAxisRaw("Horizontal") * velocity * Time.deltaTime;
            playerTransform.Translate(new Vector3(moveX, 0));
        }
        else if (!canMove && TextBalloonManager.instance.GetIsBalloonActive())
        {
            if(Input.GetMouseButtonDown(0))
            {
                StartCoroutine(DisableTalkSettings());
            }
        }
    }

    public IEnumerator DisableTalkSettings()
    {
        canMove = true;
        TextBalloonManager.instance.SetIsBalloonActive(false);
        TextBalloonManager.instance.SetAndHideBalloon();
        CameraManager.instance.SetTarget(playerTransform);
        CameraManager.instance.SetIsTalking(false);
        yield return new WaitForSeconds(.01f);
    }

    public void SetCanMove(bool condition)
    {
        canMove = condition;
    }

    public Transform GetPlayerTransform()
    {
        return playerTransform;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //isOnFloor = true;
    }

}
