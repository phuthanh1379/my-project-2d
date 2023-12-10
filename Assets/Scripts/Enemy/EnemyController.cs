using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Rigidbody2D rb2d;

    [SerializeField] private Transform playerCheck;
    [SerializeField] private float playerCheckRadius;
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private float speed;

    [SerializeField] private float maxHealth;
    [SerializeField] private float turnRate;

    [SerializeField] private Slider healthBar;
    [SerializeField] private SpriteRenderer spriteRenderer;

    private bool _isFlippable;
    private float _turnRateCount;
    private float _health;
    private EnemyState _currentState;
    private Collider2D _player;


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(playerCheck.position, playerCheckRadius);
    }

    private void Awake()
    {
        Init();
    }

    private void Update()
    {
        if (CheckPlayer())
        {
            ChangeState(EnemyState.Alert);
        }
        else
        {
            ChangeState(EnemyState.Normal);
        }

        if (_turnRateCount >= turnRate)
        {
            Flip();
            _turnRateCount = default;
        }
        else
        {
            _turnRateCount += Time.deltaTime;
        }
    }

    private void Init()
    {
        ChangeState(EnemyState.Normal);
        _health = maxHealth;
        healthBar.maxValue = maxHealth;
        healthBar.value = maxHealth;
    }

    private void ChangeState(EnemyState state)
    {
        if (_currentState == state)
        {
            return;
        }

        switch (state)
        {
            case EnemyState.Normal:
                {
                    _isFlippable = true;
                    _turnRateCount = default;
                    _player = default;
                    animator.SetInteger("AnimState", 0);
                }
                break;

            case EnemyState.Alert:
                {
                    _isFlippable = false;
                    _player = CheckPlayer();
                    Move();
                }
                break;
        }

        _currentState = state;
    }

    private void Move()
    {
        var moveTowards = Vector2.MoveTowards(transform.position, _player.transform.position, speed * Time.deltaTime);
        rb2d.MovePosition(moveTowards);
        animator.SetInteger("AnimState", 2);
    }

    private void Flip()
    {
        if (!_isFlippable)
        {
            return;
        }

        var x = -transform.localScale.x;
        transform.localScale = new Vector3(x, 1f, 1f);
    }

    private Collider2D CheckPlayer()
    {
        return Physics2D.OverlapCircle(playerCheck.position, playerCheckRadius, playerLayer);
    }

    public void Hurt(int damage)
    {
        _health -= damage;
        healthBar.value = _health;

        if (_health > 0)
        {
            animator.SetTrigger("Hurt");
        }
        else
        {
            OnDead(2f);
        }
    }

    private void OnDead(float time)
    {
        animator.SetTrigger("Death");
        spriteRenderer
            .DOFade(0f, time)
            .OnComplete(() =>
            {
                Destroy(this.gameObject);
            })
            .Play()
            ;
    }
}
