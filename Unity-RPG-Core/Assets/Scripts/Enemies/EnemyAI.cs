using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public enum State { Patrolling, Chasing, Attacking }
    private State currentState;

    public Transform[] patrolPoints;
    private int patrolIndex = 0;
    public Transform player;
    public float chaseDistance = 10f;
    public float attackDistance = 1f;
    public float speed = 2f;

    private void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);
        switch (currentState)
        {
            case State.Patrolling:
                Patrol();
                if (distance < chaseDistance)
                    SetState(State.Chasing);
                break;

            case State.Chasing:
                Chase();
                if (distance < attackDistance)
                    SetState(State.Attacking);
                else if (distance > chaseDistance)
                    SetState(State.Patrolling);
                break;

            case State.Attacking:
                Attack();
                if (distance > attackDistance)
                    SetState(State.Chasing);
                break;
        }
    }

    private void SetState(State newState)
    {
        currentState = newState;
    }

    private void Patrol()
    {
        Transform target = patrolPoints[patrolIndex];
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, target.position) < 0.5f)
            patrolIndex = (patrolIndex + 1) % patrolPoints.Length;
    }

    private void Chase()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }

    private void Attack()
    {
        Debug.Log("Атака игрока!");
    }
}