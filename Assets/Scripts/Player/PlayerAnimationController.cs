using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    [SerializeField] protected Animator animator;

    public virtual void CheckAnimation(float horizontal, float yVelocity, bool isGrounded, bool isAttack)
    {
    }

    public virtual void Hurt()
    {
    }

    public virtual void Dead()
    {
    }
}
