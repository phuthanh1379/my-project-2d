using System;
using UnityEngine;

public class PlayerPhysics : MonoBehaviour
{
    [SerializeField] private Collider2D playerCollider;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float checkRadius;

    public event Action<int> CollideObstacle;

    private bool IsTrigger => playerCollider.isTrigger;
    private float _cooldown;

    private const float CooldownThreshold = 0.5f;

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundCheck.position, checkRadius);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.collider.CompareTag("Obstacle"))
        {
            return;
        }

        var obstacle = collision.collider.GetComponent<Obstacle>();
        if (obstacle != null)
        {
            var obstaclePoint = obstacle.GetObstaclePoint();
            CollideObstacle?.Invoke(obstaclePoint);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("PowerUp"))
        {
            return;
        }

        var obstacle = collision.GetComponent<PowerUp>();
        if (obstacle != null)
        {
            var powerUp = obstacle.PickUpPowerUp();
            switch (powerUp)
            {
                case PowerUpEnum.Armor:

                    break;

                case PowerUpEnum.HitPoint:
                    break;

                case PowerUpEnum.Damage:
                    break;

                case PowerUpEnum.Immortal:

                    break;
            }
        }
    }

    private void Update()
    {
        if (IsTrigger)
        {
            _cooldown -= Time.deltaTime;
            if (_cooldown <= 0 && IsGrounded())
            {
                playerCollider.isTrigger = false;
            }
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer);
    }

    public void SetColliderToTrigger()
    {
        playerCollider.isTrigger = true;
        _cooldown = CooldownThreshold;
    }
}
