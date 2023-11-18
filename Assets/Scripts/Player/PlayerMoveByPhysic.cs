using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveByPhysic : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigibody;
    [SerializeField] private Transform playerModel;
    [SerializeField] private Vector3 baseScale;
    private float _horizontal;
    private float _vertical;
    public float MoveSpeed = 5f;
    public float JumpForce = 5f;
    private bool isOnGround;
    private bool isJumping;

    private void Awake()
    {
        Application.targetFrameRate = 60;
    }

    private void Update()
    {
        _horizontal = Input.GetAxisRaw("Horizontal");
    
        if (Input.GetMouseButtonDown(0) && isOnGround && !isJumping)
        {
            Jump();
        }
        else if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !isJumping)
        {
            Jump();
        }

    }

    private void Jump()
    {
        isOnGround = false;
        isJumping = true;
        rigibody.AddForce(new Vector2(0, 1f) * JumpForce, ForceMode2D.Impulse);
    }

    private void Move()
    {
        rigibody.velocity = new Vector2(_horizontal * MoveSpeed, rigibody.velocity.y);
    }

    private void FixedUpdate()
    {
        Move();
    }
    
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Ground"))
        {
            isOnGround = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Ground"))
        {
            isJumping = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Ground"))
        {
            isOnGround = false;
        }
    }
}
