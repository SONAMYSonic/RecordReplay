using UnityEngine;
using UnityEngine.InputSystem;

public class NotMine_PlayerMove : MonoBehaviour
{
    Rigidbody2D rb;                 // 플레이어 Rigidbody2D 컴포넌트 변수
    BoxCollider2D playerBoxCollider;// 플레이어 BoxCollider2D 컴포넌트 변수
    public float speed = 7f;        // 플레이어 이동 속도

    [SerializeField]
    private float jumpForce = 10f;  // 점프력 (클수록 높게)
    public bool isGrounded;       // 플레이어가 땅에 닿아있는지 여부

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>(); // Rigidbody2D 컴포넌트 가져오기
        playerBoxCollider = GetComponent<BoxCollider2D>(); // BoxCollider2D 컴포넌트 가져오기
    }
    void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");   // 좌우 입력 값 가져오기 (-1, 0, 1)
        rb.linearVelocity= new Vector2(x * speed, rb.linearVelocity.y); // 속도 설정
        // 땅에 닿아있는지 확인, 레이어는 7번 Ground
        isGrounded = Physics2D.BoxCast(playerBoxCollider.bounds.center, playerBoxCollider.bounds.size, 0f, Vector2.down, 0.1f, 1 << 7);
    }

    private void Update()
    {
        // 스페이스바 입력 감지
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            // 점프
            Jump();
        }
    }

    public void Jump()
    {
        // 땅에 닿아있으면 점프
        if (isGrounded == true)
        {
            rb.linearVelocity = Vector2.up * jumpForce;

        }
    }
}