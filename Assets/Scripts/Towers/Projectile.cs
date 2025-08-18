using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Transform target;
    public float speed;

    private void Update()
    {
        if (target == null)
        {
            gameObject.SetActive(false);
            return;
        }
        Vector2 direction = target.position - transform.position;
        float distance = speed * Time.deltaTime;

        if (direction.magnitude <= distance)
        {
            gameObject.SetActive(false);
        }
        transform.Translate(direction.normalized * distance, Space.World);
    }
    public void Seek(Transform target)
    {
        this.target = target;
    }
}
