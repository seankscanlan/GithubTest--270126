using UnityEngine;

public class bulletScript : MonoBehaviour
{

    public float speed = 10f;
    public float damage = 10f;
    public float lifeTime = 2f;

    Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        rb.linearVelocity = transform.right * speed;
        Destroy(gameObject, lifeTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        EnemyAI enemy = other.GetComponent<EnemyAI>();
        if(enemy != null)
        {
            enemy.ApplyDamage(damage);
        }
        Destroy(gameObject);
    }
}
