using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;
    float normalSpeed;

    void Start()
    {
        normalSpeed = agent.speed;
    }

    void Update()
    {
        agent.SetDestination(player.position);
    }

    public void SlowDown(float amount, float duration)
    {
        agent.speed = normalSpeed / amount;
        CancelInvoke();
        Invoke(nameof(RestoreSpeed), duration);
    }

    void RestoreSpeed()
    {
        agent.speed = normalSpeed;
    }
}
