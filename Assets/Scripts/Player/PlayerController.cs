using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerProfile profileController;
    [SerializeField] private PlayerPhysics physicsController;
    [SerializeField] private PlayerMove moveController;
    [SerializeField] private PlayerAnimationController animationController;

    private void Awake()
    {
        physicsController.CollideObstacle += OnCollideObstacle;
        profileController.PlayerDead += OnPlayerDead;
        moveController.PlayerMoveDownPlatform += OnPlayerMoveDownPlatform;
    }

    private void OnDestroy()
    {
        physicsController.CollideObstacle -= OnCollideObstacle;
        profileController.PlayerDead -= OnPlayerDead;
        moveController.PlayerMoveDownPlatform -= OnPlayerMoveDownPlatform;
    }

    private void OnPlayerDead()
    {
        animationController.Dead();
        physicsController.SetColliderToTrigger();
    }

    private void OnCollideObstacle(int obstaclePoint)
    {
        profileController.AddPlayerHealth(obstaclePoint);

        if (obstaclePoint < 0)
        {
            animationController.Hurt();
        }
    }

    private void OnPlayerMoveDownPlatform()
    {
        physicsController.SetColliderToTrigger();
    }
}
