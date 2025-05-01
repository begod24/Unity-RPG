using UnityEngine;
using UnityEngine.AI;

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

    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = speed;
        SetState(State.Patrolling);
    }

    void Update()
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
                Debug.Log($"{name}: АТАКУЕТ игрока!");
                if (distance > attackDistance)
                    SetState(State.Chasing);
                break;
        }
    }

    void SetState(State state)
    {
        if (currentState == state) return;

        currentState = state;

        switch (state)
        {
            case State.Patrolling:
                Debug.Log($"<color=gray>{name}: Переход в режим ПАТРУЛИРОВАНИЯ</color>");
                GoToNextPoint();
                break;
            case State.Chasing:
                Debug.Log($"<color=yellow>{name}: УВИДЕЛ игрока — ПРЕСЛЕДОВАНИЕ!</color>");
                break;
            case State.Attacking:
                Debug.Log($"<color=red>{name}: АТАКУЕТ игрока!</color>");
                break;
        }
    }

    void GoToNextPoint()
    {
        if (patrolPoints.Length == 0) return;
        agent.SetDestination(patrolPoints[patrolIndex].position);
        patrolIndex = (patrolIndex + 1) % patrolPoints.Length;
    }

    bool CanSeePlayer()
    {
        Vector3 dirToPlayer = player.position - transform.position;
        Ray ray = new Ray(transform.position + Vector3.up * 1.5f, dirToPlayer.normalized);
        if (Physics.Raycast(ray, out RaycastHit hit, chaseDistance))
        {
            Debug.DrawRay(transform.position + Vector3.up * 1.5f, dirToPlayer.normalized * chaseDistance, Color.red);
            return hit.transform == player;
        }
        return false;
    }
}
