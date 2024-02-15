using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform _player;

    [SerializeField] private float _speed;
    [SerializeField] private Animator enemyAnim;

    private void Update()
    {
        if (gameObject.activeSelf)
        {
            Vector3 direction = (_player.position - transform.position).normalized;
            transform.Translate(direction * _speed * Time.deltaTime, Space.World);
            transform.LookAt(_player.position);
            enemyAnim.SetFloat("Walk", _speed);
        }
    }
}
