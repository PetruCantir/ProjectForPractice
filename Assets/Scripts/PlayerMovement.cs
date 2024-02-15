using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);
    private const string Vertical = nameof(Vertical);

    private Rigidbody _rb;
    private Vector2 movement;
    private bool isRunning = false;

    [SerializeField] private float moveSpeed;
    [SerializeField] private float runSpeed;
    [SerializeField] private float rotateSpeed;
    [SerializeField] private Animator playerAnim;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        Rotate();
        Move();
        CheckRunning();
    }

    private void Rotate()
    {
        float rotation = Input.GetAxis(Horizontal);
        transform.Rotate(rotation * rotateSpeed * Time.deltaTime * Vector3.up);
    }

    private void Move()
    {
        float direction = Input.GetAxis(Vertical);
        float currentSpeed = isRunning ? runSpeed : moveSpeed;
        float distance = direction * currentSpeed * Time.deltaTime;
        playerAnim.SetFloat("Walk", Mathf.Abs(direction));

        transform.Translate(distance * Vector3.forward);
    }

    private void CheckRunning()
    {
        if (Input.GetAxis("Run") > 0)
        {
            isRunning = true;
            playerAnim.SetBool("Run", true);
        }
        else
        {
            isRunning = false;
            playerAnim.SetBool("Run", false);
        }
    }
}
