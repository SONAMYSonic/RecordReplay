using UnityEngine;
using UnityEngine.InputSystem;

public class NotMine_PlayerMove : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed = 7f;

    [SerializeField]
    private float jumpForce = 10f;  // 점프력 (클수록 높게)

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>(); 
    }
    void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        rb.linearVelocity= new Vector2(x * speed, rb.linearVelocity.y);

        
    }

    private void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            Jump();
        }
    }

    public void Jump()
    {
        // jumpForce 만큼 윗쪽 방향으로 속력 설정
        rb.linearVelocity = Vector2.up * jumpForce;
    }
}