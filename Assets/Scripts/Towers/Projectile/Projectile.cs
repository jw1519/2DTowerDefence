using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Transform target;
    public float speed;
    public int damage;

    private void Update()
    {
        if (target == null || !target.gameObject.activeInHierarchy)
        {
            gameObject.SetActive(false);
            return;
        }
        Vector2 direction = target.position - transform.position;
        Vector3 movement = transform.forward * speed;
        //transform.LookAt(target.position);
        //transform.rotation = Quaternion.Slerp(transform.rotation,Quaternion.LookRotation(direction),Time.deltaTime);
        //transform.position += movement * Time.deltaTime;
        float distance = speed * Time.deltaTime;

        if (direction.magnitude <= distance)
        {
            gameObject.SetActive(false);
        }
        transform.Translate(direction.normalized * distance);
        
    }
    public void Seek(Transform target)
    {
        this.target = target;
    }
}
