using Sound.Value;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private PlayerAnimationController animationController;
    [SerializeField] private Transform enemyCheck;
    [SerializeField] private float enemyCheckRadius;
    [SerializeField] private LayerMask enemyLayer;

    private int _damage;

    private void Awake()
    {
        PlayerProfile.BroadcastPlayerData += OnBroadcastPlayerData;
    }

    private void OnDestroy()
    {
        PlayerProfile.BroadcastPlayerData -= OnBroadcastPlayerData;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(enemyCheck.position, enemyCheckRadius);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }
    }

    private void Attack()
    {
        animationController.Attack();
    }

    private void DoAttack()
    {
        SoundController.Instance.PlayAudio(SoundName.Sword1);
        var enemy = CheckEnemy();
        if ((bool)enemy)
        {
            enemy.GetComponent<EnemyController>().Hurt(_damage);
        }
    }

    private Collider2D CheckEnemy()
    {
        return Physics2D.OverlapCircle(enemyCheck.position, enemyCheckRadius, enemyLayer);
    }

    private void OnBroadcastPlayerData(PlayerData data)
    {
        if (data == null)
        {
            return;
        }

        _damage = data.Damage;
    }
}
