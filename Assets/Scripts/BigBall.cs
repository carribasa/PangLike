using UnityEngine;

public class BigBall : MonoBehaviour
{
    public Rigidbody2D rb;
    private Vector2 velocity;
    public float speed = 30;

    void Start()
    {
        velocity.x = -1;
        velocity.y = 1;
        rb.AddForce(velocity.normalized * speed);
    }

    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Verifica si la colisión es con un objeto que tiene la etiqueta "Wall"
        if (collision.gameObject.CompareTag("Wall"))
        {
            // Invierte la dirección y aplica una fuerza
            velocity.x = -velocity.x;
            rb.AddForce(velocity.normalized * speed);
        }
    }
}