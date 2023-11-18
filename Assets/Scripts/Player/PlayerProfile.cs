using UnityEngine;
using UnityEngine.UI;

public class PlayerProfile : MonoBehaviour
{
    [SerializeField] private Slider healthBar;

    private PlayerData _playerData;

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        _playerData = new PlayerData(
            "MyPlayer",
            13,
            100,
            20,
            0
        );

        healthBar.maxValue = _playerData.HitPoint;
        healthBar.value = _playerData.HitPoint;
    }

    public void AddPlayerHealth(int health)
    {
        _playerData.AddHealth(health);
        healthBar.value = _playerData.HitPoint;
    }

    public void SetPlayerScore(int score)
    {
        _playerData.SetScore(score);
    }

    public void AddPlayerScore(int score)
    {
        _playerData.AddScore(score);
    }

    private void AnimationEventHandler()
    {
        Debug.LogWarning("Event!");
    }
}
