using UnityEngine;
using UnityEngine.AI;

public class BaseEnemy : MonoBehaviour
{
    [Header("Stats")]
    public int maxHealth;
    public int health;
    public float speed;
    public int damage;
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