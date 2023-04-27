using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    public float thrust;
    public float knockTime;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("breakable") && this.gameObject.CompareTag("Player"))
        {
            collision.GetComponent<pot>().Smash();
        }

        if (collision.gameObject.CompareTag("enemy") || collision.gameObject.CompareTag("Player"))
        {
            Rigidbody2D target = collision.GetComponent<Rigidbody2D>();

            if (target != null)
            {
                Vector2 difference = target.transform.position - transform.position;
                difference = difference.normalized * thrust;
                target.AddForce(difference, ForceMode2D.Impulse);

                if (collision.gameObject.CompareTag("enemy"))
                {
                    target.GetComponent<Enemy>().currentState = EnemyState.stagger;
                    collision.GetComponent<Enemy>().Knock(target, knockTime);
                }

                if (collision.gameObject.CompareTag("Player"))
                {
                    target.GetComponent<PlayerMovement>().currentState = PlayerState.stagger;
                    collision.GetComponent<PlayerMovement>().Knock(knockTime);
                }    
            }
        }
    }
}
