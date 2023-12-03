using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class IngameUIController : MonoBehaviour
{
    [SerializeField] private TMP_Text playerNameLabel;
    [SerializeField] private TMP_Text playerArmorLabel;
    [SerializeField] private TMP_Text playerHitPointLabel;
    [SerializeField] private TMP_Text playerDamageLabel;
    [SerializeField] private TMP_Text playerScoreLabel;

    private void Awake()
    {
        PlayerProfile.BroadcastPlayerData += OnBroadcastPlayerData;
    }

    private void OnDestroy()
    {
        PlayerProfile.BroadcastPlayerData -= OnBroadcastPlayerData;
    }

    private void OnBroadcastPlayerData(PlayerData data)
    {
        if (data == null)
        {
            return;
        }

        playerNameLabel.text = data.Name;
        playerArmorLabel.text = $"{data.Armor}";
        playerHitPointLabel.text = $"{data.HitPoint}";
        playerDamageLabel.text = $"{data.Damage}";
        playerScoreLabel.text = $"{data.Score}";
    }

    public void OnShowIngameUI()
    {
        Time.timeScale = 0;
    }

    public void OnHideIngameUI()
    {
        Time.timeScale = 1;
    }
}
