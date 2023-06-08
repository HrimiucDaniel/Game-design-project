using UnityEngine;

public class DungeonEnemyRoom : DungeonRoom
{
    public Door[] doors;
    public GameObject chest;

    public void CheckEnemies()
    {
        for (int i = 0; i < enemies.Length; i++)
        {
            if (enemies[i].gameObject.activeInHierarchy && i < enemies.Length - 1)
            {
                return;
            }
        }

        OpenDoors();
    }

    public void OpenDoors()
    {
        for (int i = 0; i < doors.Length; i++)
        {
            chest.SetActive(true);
            doors[i].Open();
        }
    }

    public void CloseDoors()
    {
        for (int i = 0; i < doors.Length; i++)
        {
            doors[i].Close();
        }
    }

    public override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            // Activate all enemies and breakables
            for (int i = 0; i < enemies.Length; i++)
            {
                SwitchActive(enemies[i]);
            }

            for (int i = 0; i < pots.Length; i++)
            {
                SwitchActive(pots[i]);
            }

            virtualCamera.SetActive(true);
            CloseDoors();
        }
    }
}
