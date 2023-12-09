using UnityEngine;

[CreateAssetMenu(menuName = "Player", fileName = "PlayerData")]
public class PlayerData : ScriptableObject
{
    [SerializeField] private string playerName;
    public string Name
    {
        get => playerName;
        set
        {
            playerName = value;
        }
    }

    [SerializeField] private int armor;
    public int Armor
    {
        get => armor;
        set
        {
            armor = value;
        }
    }

    [SerializeField] private int hitPoint;
    public int HitPoint
    {
        get => hitPoint;
        set
        {
            hitPoint = value;
        }
    }

    [SerializeField] private int maxHitPoint;
    public int MaxHitPoint
    {
        get => maxHitPoint;
        set
        {
            maxHitPoint = value;
        }
    }
     
    [SerializeField] private int damage;
    public int Damage
    {
        get => damage;
        set
        {
            damage = value;
        }
    }

    [SerializeField] private int score;
    public int Score
    {
        get => score;
        set
        {
            score = value;
        }
    }

    public PlayerData(string name, int armor, int hitPoint, int damage, int score)
    {
        this.Name = name;
        this.Armor = armor;
        this.HitPoint = hitPoint;
        this.Damage = damage;
        this.Score = score;
    }

    public void SetScore(int score)
    {
        this.Score = score;
    }

    public void AddScore(int score)
    {
        this.Score += score;
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
