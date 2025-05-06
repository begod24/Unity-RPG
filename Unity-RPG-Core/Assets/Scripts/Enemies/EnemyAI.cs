using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    private enum State { Patrolling, Chasing, Attacking }
    private State currentState;

    [SerializeField] private Transform[] patrolPoints;
    [SerializeField] private Transform player;
    [SerializeField] private float chaseDistance = 10f;
    [SerializeField] private float attackDistance = 1f;
    [SerializeField] private float speed = 2f;

    private int patrolIndex = 0;
    private NavMeshAgent agent;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = speed;
        SetState(State.Patrolling);
    }

    private void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);

        switch (currentState)
        {
            case State.Patrolling:
                if (!agent.pathPending && agent.remainingDistance < 0.5f)
                    GoToNextPoint();
                if (distance < chaseDistance && CanSeePlayer())
                    SetState(State.Chasing);
                break;

            case State.Chasing:
                agent.SetDestination(player.position);
                if (distance < attackDistance)
                    SetState(State.Attacking);
                else if (distance > chaseDistance || !CanSeePlayer())
                    SetState(State.Patrolling);
                break;

            case State.Attacking:
                Debug.Log($"{name}: ATTACKING PLAYER");
                if (distance > attackDistance)
                    SetState(State.Chasing);
                break;
        }
    }

    private void SetState(State state)
    {
        if (currentState == state) return;
        currentState = state;

        switch (state)
        {
            case State.Patrolling:
                Debug.Log($"{name}: PATROLLING");
                GoToNextPoint();
                break;
            case State.Chasing:
                Debug.Log($"{name}: CHASING PLAYER");
                break;
            case State.Attacking:
                Debug.Log($"{name}: ATTACKING");
                break;
        }
    }

    private void GoToNextPoint()
    {
        if (patrolPoints.Length == 0) return;
        agent.SetDestination(patrolPoints[patrolIndex].position);
        patrolIndex = (patrolIndex + 1) % patrolPoints.Length;
    }

    private bool CanSeePlayer()
    {
        Vector3 dirToPlayer = player.position - transform.position;
        Ray ray = new(transform.position + Vector3.up * 1.5f, dirToPlayer.normalized);
        if (Physics.Raycast(ray, out RaycastHit hit, chaseDistance))
        {
            Debug.DrawRay(transform.position + Vector3.up * 1.5f, dirToPlayer.normalized * chaseDistance, Color.red);
            return hit.transform == player;
        }
        return false;
    }
}