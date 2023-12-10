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
    private bool _isOnGround;
    private bool _isJumping;
    private bool _isDash;
    private int _jumpCount;
    private int _moveDownCount;

    private const int JumpMax = 2;

    public event Action PlayerMoveDownPlatform;

    private void Awake()
    {
        Init();   
    }

    private void Update()
    {
        _horizontal = Input.GetAxisRaw("Horizontal");
    
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump(ref _isOnGround, ref _isJumping);
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            Dash();
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
        CheckAnimation(_horizontal, rigidBody.velocity.y, _isOnGround);
    }

    private void Init()
    {
        Application.targetFrameRate = 60;

        _horizontal = default;
        _vertical = default;
        _isOnGround = default;
        _isJumping = default;
        _isDash = default;
        _jumpCount = default;
        _moveDownCount = default;
    }

    private void CheckAnimation(float horizontal, float yVelocity, bool isGrounded)
    {
        animationController.CheckAnimation(horizontal, yVelocity, isGrounded);
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
            _isOnGround = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.transform.CompareTag("Ground"))
        {
            return;
        }
        
        _isJumping = false;
        _jumpCount = default;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Ground"))
        {
            _isOnGround = false;
        }
    }
}
