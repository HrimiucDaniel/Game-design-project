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
    public EnemyState currentState;
    public FloatValue maxHealth;
    public float health;
    public string enemyName;
    public int baseAttack;
    public float moveSpeed;
    public GameObject deathEffect;

    private void Awake()
    {
        health = maxHealth.initialValue;
    }

    private void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0 ) 
        {
            DeathEffect();
            this.gameObject.SetActive(false);
        }
    }
    private void DeathEffect(){
        if (deathEffect  != null){
            GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(effect, 1f);
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
