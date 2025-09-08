using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Transform target;
    public float speed;
    public int damage;
    Vector3 direction;

    private void Update()
    {
        if (target == null || !target.gameObject.activeInHierarchy)
        {
            gameObject.SetActive(false);
            return;
        }
        float distance = speed * Time.deltaTime;
        //transform.Translate(direction.normalized * distance);
        transform.position += direction * speed * Time.deltaTime;
    }
    public void Launch()// projectile goes in straightline
    {
        direction = (target.position - transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log("here");
        if (collision.gameObject.name == "Range")
            gameObject.SetActive (false);
    }
    public void Seek(Transform target)
    {
        this.target = target;
        Launch();
    }
}
