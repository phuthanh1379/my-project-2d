using UnityEngine;

[CreateAssetMenu(menuName = "Player", fileName = "PlayerData")]
public class PlayerData : ScriptableObject
{
    [SerializeField] private string playerName;
    public string Name
    {
        get => playerName;
        private set => playerName = value;
    }

    [SerializeField] private int armor;
    public int Armor
    {
        get => armor;
        private set => armor = value;
    }

    [SerializeField] private int hitPoint;
    public int HitPoint
    {
        get => hitPoint;
        private set => hitPoint = value;
    }

    [SerializeField] private int maxHitPoint;
    public int MaxHitPoint
    {
        get => maxHitPoint;
        private set => maxHitPoint = value;
    }
     
    [SerializeField] private int damage;
    public int Damage
    {
        get => damage;
        private set => damage = value;
    }

    [SerializeField] private int score;
    public int Score
    {
        get => score;
        private set => score = value;
    }

    public PlayerData(string name, int armor, int hitPoint, int damage, int score)
    {
        this.Name = name;
        this.Armor = armor;
        this.HitPoint = hitPoint;
        this.Damage = damage;
        this.Score = score;
    }

    public void SetScore(int value)
    {
        this.Score = value;
    }

    public void AddScore(int value)
    {
        this.Score += value;
    }

    public void AddHealth(int health)
    {
        if (health < 0)
        {
            var dmg = health + this.Armor;
            this.HitPoint += dmg;
        }
        else
        {
            this.HitPoint += health;
        }
    }

    public void ResetHitPoint()
    {
        this.HitPoint = this.MaxHitPoint;
    }
}
