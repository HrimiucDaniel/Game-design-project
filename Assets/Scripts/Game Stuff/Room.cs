using UnityEngine;

public class Room : MonoBehaviour
{
    public Enemy[] enemies;
    public pot[] pots;
    public GameObject virtualCamera;

    public virtual void OnTriggerEnter2D(Collider2D other)
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
        }
    }

    public virtual void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            // Deactivate all enemies and breakables
            for (int i = 0; i < enemies.Length; i++)
            {
                SwitchActive(enemies[i], false);
            }

            for (int i = 0; i < pots.Length; i++)
            {
                SwitchActive(pots[i], false);
            }

            virtualCamera.SetActive(false);
        }
    }

    protected void SwitchActive(Component component, bool active = true)
    {
        component.gameObject.SetActive(active);
    }
}
