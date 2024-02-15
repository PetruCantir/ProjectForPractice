using UnityEngine;
using UnityEngine.UI;

public class BulletCreator : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float bulletVelocity;
    [SerializeField] private float weaponRange = 20f;
    [SerializeField] private Text scoreText;
    [SerializeField] private ParticleSystem part;

    private int score = 0;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;

            if (Physics.Raycast(transform.position, transform.forward, out hit, weaponRange))
            {
                if (hit.collider.CompareTag("Enemy"))
                {
                    Health enemyHealth = hit.collider.GetComponent<Health>();

                    if (enemyHealth != null)
                    {
                        score += (int)enemyHealth.TakeDamage();
                        UpdateScoreText();
                    }
                }
            }

            GameObject newBullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            Rigidbody bulletRigidbody = newBullet.GetComponent<Rigidbody>();
            bulletRigidbody.velocity = transform.forward * bulletVelocity;

            if (part != null)
            {
                part.Play();
            }

            Destroy(newBullet, 0.7f);
        }
    }

    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = score.ToString();
        }
    }
}
