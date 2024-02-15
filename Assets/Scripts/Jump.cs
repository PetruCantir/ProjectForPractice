using UnityEngine;

public class Jump : MonoBehaviour
{
    private bool onGround;
    private Rigidbody rb;

    [SerializeField] private Animator anim;
    [SerializeField] private float jumpForce;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionStay()
    {
        onGround = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && onGround)
        {
            onGround = false;
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            anim.SetTrigger("Jumping");
        }
    }
}
