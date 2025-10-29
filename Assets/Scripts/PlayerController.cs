using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed = 7f;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        rb.linearVelocity = new Vector2(x * speed, rb.linearVelocity.y);
    }
}
