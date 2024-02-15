using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private float maxHP;
    [SerializeField] private Animator animator;
    [SerializeField] private ParticleSystem part;
    
    [HideInInspector]
    public UnityEvent<float> OnEnemyDestroyed;

    private float currentHp;
    private bool isAlive;
    private Rigidbody rb;

    private void Start()
    {
        currentHp = maxHP;
        isAlive = true;
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    public float TakeDamage()
    {
        float damage = Random.Range(2, 5);
        currentHp -= damage;

        part.Play();

        if (currentHp <= 0 && isAlive)
        {
            isAlive = false;
            animator.SetBool("Loose", true);
            OnEnemyDestroyed.Invoke(damage);
            Invoke("DestroyEnemy", 1.3f);
        }

        return damage;
    }

    private void DestroyEnemy()
    {
        GetComponent<Collider>().enabled = false;
        Destroy(gameObject);
    }
}
