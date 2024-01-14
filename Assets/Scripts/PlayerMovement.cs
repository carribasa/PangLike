using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // attributes ----------------------------------------
    public Rigidbody2D rb;
    public Animator _animator;

    [SerializeField]
    private float moveSpeed;

    private bool isFacingLeft = false;
    private float edgeLeft = -2.7382f;
    private float edgeRight = 2.73638f;


    // initial methods -----------------------------------

    void Start()
    {

    }

    void Update()
    {
        movePlayer();
    }

    // ----------------------------------------------------
    void movePlayer()
    {
        float moveDirection = Input.GetAxisRaw("Horizontal");
        Vector2 movement = new Vector2(moveDirection, 0f);

        if (movement.magnitude > 0)
        {
            Vector2 newPosition = new Vector2(transform.position.x, transform.position.y) + movement * moveSpeed * Time.deltaTime;
            float clampedX = Mathf.Clamp(newPosition.x, edgeLeft, edgeRight);
            transform.position = new Vector2(clampedX, newPosition.y);

            _animator.SetBool("isWalking", true);

            if (moveDirection < 0 && !isFacingLeft)
            {
                Flip();
            }
            else if (moveDirection > 0 && isFacingLeft)
            {
                Flip();
            }
        }
        else
        {
            _animator.SetBool("isWalking", false);
        }
    }

    void Flip()
    {
        isFacingLeft = !isFacingLeft;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
