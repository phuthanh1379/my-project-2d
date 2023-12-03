using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerProfile : MonoBehaviour
{
    [SerializeField] private Slider healthBar;
    [SerializeField] private PlayerData data;

    public int Health => PlayerPrefs.GetInt("health");


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
        data.AddHealth(health);
        healthBar.value = data.HitPoint;

        if (data.HitPoint <= 0)
        {
            PlayerDead?.Invoke();
        }
    }

    public void SetPlayerScore(int score)
    {
        data.SetScore(score);
    }

    public void AddPlayerScore(int score)
    {
        data.AddScore(score);
    }
}
