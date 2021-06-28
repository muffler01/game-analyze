using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    private int damage = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // �߻�ü�� �ε��� ������Ʈ�� �±װ� "Enemy"�̸�
        if (collision.CompareTag("Enemy"))
        {
            // �ε��� ������Ʈ ���ó�� (��)
            // collision.GetComponent<Enemy>().OnDie(); 
            collision.GetComponent<EnemyHP>().TakeDamage(damage);
            // �� ������Ʈ ���� (�߻�ü)
            Destroy(gameObject);
        }
    }
}
