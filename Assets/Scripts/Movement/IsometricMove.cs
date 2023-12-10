using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsometricMove : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Rigidbody2D rb2d;

    private float _horizontal;
    private float _vertical;
    private bool _isRun => (_horizontal != 0 || _vertical != 0);

    private void Update()
    {
        _horizontal = Input.GetAxisRaw("Horizontal");
        _vertical = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", _horizontal);
        animator.SetFloat("Vertical", _vertical);
        animator.SetBool("isRun", _isRun);
    }

    private void FixedUpdate()
    {
        rb2d.velocity = new Vector2(_horizontal, _vertical);
    }
}
