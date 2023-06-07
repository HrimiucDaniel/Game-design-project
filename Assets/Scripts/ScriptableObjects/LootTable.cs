using UnityEngine;

[System.Serializable]
public class Loot
{
    public Powerup powerup;
    public int chance;
}

[CreateAssetMenu]
public class LootTable : ScriptableObject
{
    public Loot[] loot;

    public Powerup GenerateLoot()
    {
        int cumulativeProbability = 0;
        int currentProbability = Random.Range(0, 100);

        for (int i = 0; i < loot.Length; i++)
        {
            cumulativeProbability += loot[i].chance;

            if (currentProbability <= cumulativeProbability)
            {
                return loot[i].powerup;
            }
        }

        return null;
    }
}
