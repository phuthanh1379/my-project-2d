using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerProfile : MonoBehaviour
{
    [SerializeField] private Slider healthBar;
    [SerializeField] private PlayerData data;

    public event Action PlayerDead;
    public static event Action<PlayerData> BroadcastPlayerData;

    private void Awake()
    {
        NewGame();
        Init();
    }

    private void Start()
    {
        BroadcastPlayerData?.Invoke(data);
    }

    private void Init()
    {
        healthBar.maxValue = data.HitPoint;
        healthBar.value = data.HitPoint;
    }

    private void NewGame()
    {
        data.ResetHitPoint();
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
