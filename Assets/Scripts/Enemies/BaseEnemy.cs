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
        if (endLocation != null)
        {
            agent.SetDestination(endLocation.position);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(endLocation.gameObject.name);
        if (collision.gameObject.name == endLocation.gameObject.name)
        {
            gameObject.SetActive(false);
        }
    }
}