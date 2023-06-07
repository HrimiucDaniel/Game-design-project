using UnityEngine;

public class AreaEnemy : Log
{
    public Collider2D boundary;

    public override void CheckDistance(){
        if (Vector3.Distance(target.position, transform.position) <= chaseRadius
            && Vector3.Distance(target.position, transform.position) > attackRadius
            && boundary.bounds.Contains(target.transform.position))
        {
            if (currentState == EnemyState.idle || currentState == EnemyState.walk
                && currentState != EnemyState.stagger)
            {
                Vector3 temp = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
                ChangeDirection(temp - transform.position);
                rigidBody.MovePosition(temp);
                ChangeState(EnemyState.walk);
                animator.SetBool("active", true);
            }
        }
        else if (Vector3.Distance(target.position, transform.position) > chaseRadius
                || !boundary.bounds.Contains(target.transform.position))
        {
            animator.SetBool("active", false);
        }
    }
}
