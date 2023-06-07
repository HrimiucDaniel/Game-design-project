using System.Collections;
using UnityEngine;

public enum EnemyState
{
    idle,
    walk,
    attack,
    stagger
}

public class Enemy : MonoBehaviour
{
    [Header("State Machine")]
    public EnemyState currentState;

    [Header("Enemy Stats")]
    public FloatValue maxHealth;
    public float health;
    public string enemyName;
    public int baseAttack;
    public float moveSpeed;
    public Vector2 homePosition;

    [Header("Death Effects")]
    public GameObject deathEffect;
    private float deathEffectDelay = 1f;
    public LootTable lootTable;

    [Header("Death Signals")]
    public SignalSender roomSignal;

    private void Awake()
    {
        health = maxHealth.initialValue;
        homePosition = transform.position;
    }

    private void DropLoot()
    {
        if (lootTable != null)
        {
            Powerup current = lootTable.GenerateLoot();

            if (current != null)
            {
                Instantiate(current.gameObject, transform.position, Quaternion.identity);
            }
        }
    }

    private void OnEnable()
    {
        transform.position = homePosition;
        health = maxHealth.initialValue;
        currentState = EnemyState.idle;
    }

    private void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0 ) 
        {
            DeathEffect();
            DropLoot();

            if (roomSignal != null)
            {
                roomSignal.Raise();
            }

            this.gameObject.SetActive(false);
        }
    }

    private void DeathEffect(){
        if (deathEffect  != null){
            GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(effect, deathEffectDelay);
        }
    }

    public void Knock(Rigidbody2D rigidBody, float knockTime, float damage)
    {
        StartCoroutine(KnockCo(rigidBody, knockTime));
        TakeDamage(damage);
    }

    private IEnumerator KnockCo(Rigidbody2D rigidBody, float knockTime)
    {
        if (rigidBody != null)
        {
            yield return new WaitForSeconds(knockTime);
            rigidBody.velocity = Vector2.zero;
            currentState = EnemyState.idle;
            rigidBody.velocity = Vector2.zero;
        }
    }
}
