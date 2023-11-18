using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float speed;

    private void Update()
    {
        var diff = player.position - transform.position;
        transform.Translate(diff * speed);
    }
}
