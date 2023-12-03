using Player.Value;
using System;
using UnityEngine;

public class PlayerMoveByPhysic : MonoBehaviour
{
    [SerializeField] private PlayerAnimationController animationController;
    [SerializeField] private Rigidbody2D rigidBody;
    [SerializeField] private Transform playerModel;
    [SerializeField] private Vector3 baseScale;
    [SerializeField] private float MoveSpeed = 5f;
    [SerializeField] private float JumpForce = 5f;

    private float _horizontal;
    private float _vertical;
    private bool isOnGround;
    private bool isJumping;
    private bool _isDash = false;
    private int _jumpCount = default;
    private int _moveDownCount = default;

    private const int JumpMax = 2;

    public event Action PlayerMoveDownPlatform;

    private void Awake()
    {
        Application.targetFrameRate = 60;
        _jumpCount = default;
    }

    private void Update()
    {
        _horizontal = Input.GetAxisRaw("Horizontal");
    
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump(ref isOnGround, ref isJumping);
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            Dash();
        }

        var isAttack = false;
        if (Input.GetMouseButtonDown(0))
        {
            isAttack = true;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            _moveDownCount++;
            if (_moveDownCount >= 1)
            {
                MoveDownPlatform();
                _moveDownCount = default;
            }
        }

        Flip(_horizontal);
        CheckAnimation(_horizontal, rigidBody.velocity.y, isOnGround, isAttack);
    }

    private void CheckAnimation(float horizontal, float yVelocity, bool isGrounded, bool isAttack)
    {
        animationController.CheckAnimation(horizontal, yVelocity, isGrounded, isAttack);
    }

    private void MoveDownPlatform()
    {
        PlayerMoveDownPlatform?.Invoke();
    }

    private void Dash()
    {
        _isDash = true;
        rigidBody.AddForce(new Vector2(1f, 0f) * JumpForce, ForceMode2D.Impulse);
        //_isDash = false;
    }

    private void Jump(ref bool isOnGround, ref bool isJumping)
    {
        if (!isOnGround || isJumping)
        {
            if (_jumpCount >= JumpMax)
            {
                return;
            }
        }

        isOnGround = false;
        isJumping = true;
        _jumpCount++;
        rigidBody.AddForce(new Vector2(0, 1f) * JumpForce, ForceMode2D.Impulse);
    }

    private void Move()
    {
        if (!_isDash)
        {
            rigidBody.velocity = new Vector2(_horizontal * MoveSpeed, rigidBody.velocity.y);
        }
    }

    private void Flip(float horizontal)
    {
        // Move right -> left
        if (horizontal < 0)
        {
            playerModel.localScale = new Vector3(baseScale.x * -1f, baseScale.y, baseScale.z);
        }

        // Move left -> right
        if (horizontal > 0)
        {
            playerModel.localScale = baseScale;
        }
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
            _jumpCount = default;
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
