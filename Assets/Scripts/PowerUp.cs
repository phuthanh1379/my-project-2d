using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField] private PowerUpEnum powerUp;

    public PowerUpEnum PickUpPowerUp()
    {
        return powerUp;
    }
}
