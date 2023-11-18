using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private int point;

    public int GetObstaclePoint()
    {
        return point;
    }
}
