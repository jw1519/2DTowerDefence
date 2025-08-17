using UnityEngine;
using UnityEngine.AI;

public class BaseEnemy : MonoBehaviour
{
    [Header("Stats")]
    public int health;
    public float speed;

    [Header("navigation")]
    NavMeshAgent agent;
    public Transform endLocation;
    public virtual void Awake()
    {
        gameObject.name = "Enemy";
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }
    private void Update()
    {
        agent.SetDestination(endLocation.position);
    }
}