public class PlayerData
{
    public string Name { get; private set; }
    public int Armor { get; private set; }
    public int HitPoint { get; private set; }
    public int Damage { get; private set; }
    public int Score { get; private set; }

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
            UnityEngine.Debug.Log($"dmg={dmg}");
            this.HitPoint += dmg;
        }
        else
        {
            this.HitPoint += health;
        }
    }
}
