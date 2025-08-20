using UnityEngine;
using UnityEngine.AI;

public class BaseEnemy : MonoBehaviour
{
    [Header("Stats")]
    public int maxHealth;
    public int health;
    public float speed;
    public int goldEarned;

    [Header("navigation")]
    NavMeshAgent agent;
    public Transform endLocation;
    public virtual void Awake()
    {
        gameObject.name = "Enemy";
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        health = maxHealth;
    }
    void OnEnable()
    {
        if (agent != null && !agent.isOnNavMesh)
        {
            NavMeshHit hit;
            if (NavMesh.SamplePosition(agent.transform.position, out hit, 10f, NavMesh.AllAreas))
            {
                agent.Warp(hit.position); //forces agent onto NavMesh
            }
            else
            {
                Debug.LogWarning("Agent is too far from the NavMesh!");
            }
        }
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
        if (collision.gameObject.name == endLocation.gameObject.name)
        {
            gameObject.SetActive(false);
        }
        if (collision.gameObject.CompareTag("Projectile"))
        {
            health -= collision.gameObject.GetComponent<Projectile>().damage;
            if (health <= 0)
            {
                //increase gold
                gameObject.SetActive(false);
                health = maxHealth; 
            }
        }
    }
}