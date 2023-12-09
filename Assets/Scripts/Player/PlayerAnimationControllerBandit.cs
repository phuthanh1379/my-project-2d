using Player.Value;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationControllerBandit : PlayerAnimationController
{
    private const string AnimStateKey = "AnimState"; // int
    private const string GroundedKey = "Grounded"; // bool
    private const string AttackKey = "Attack"; // trigger
    private const string RecoverKey = "Recover"; // trigger
    private const string JumpKey = "Jump"; // trigger
    private const string HurtKey = "Hurt"; // trigger
    private const string DeathKey = "Death"; // trigger
    private const string AirSpeedKey = "AirSpeed"; // float

    private PlayerIdleState _state;

    public override void CheckAnimation(float horizontal, float yVelocity, bool isGrounded)
    {
        _state = PlayerIdleState.Idle;
        
        animator.SetBool(GroundedKey, isGrounded);
        
        if (horizontal > 0f || horizontal < 0f)
        {
            _state = PlayerIdleState.Run;
        }
        else
        {

        }

        if (yVelocity > .1f)
        {
            animator.SetTrigger(JumpKey);
        }
        else if (yVelocity < -.1f)
        {

        }

        animator.SetInteger(AnimStateKey, (int)_state);
    }

    public override void Attack()
    {
        _state = PlayerIdleState.Combat;
        animator.SetTrigger(AttackKey);
    }

    public override void Hurt()
    {
        animator.SetTrigger(HurtKey);
    }

    public override void Dead()
    {
        animator.SetTrigger(DeathKey);
    }
}
