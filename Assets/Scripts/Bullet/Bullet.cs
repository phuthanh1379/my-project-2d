using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb2d;
    [SerializeField] private Obstacle obstacleSetting;
    [SerializeField] private float duration;
    
    public void Shoot(Vector2 force, int damage)
    {
        rb2d.AddForce(force, ForceMode2D.Impulse);
        obstacleSetting.SetObstaclePoint(-damage);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            CancelInvoke();
            SelfDestroy();
        }
    }

    private void OnEnable()
    {
        Invoke(nameof(SelfDestroy), duration);
    }

    private void SelfDestroy()
    {
        Destroy(this.gameObject);
    }
}
