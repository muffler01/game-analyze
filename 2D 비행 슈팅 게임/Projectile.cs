using UnityEngine;

public class Projectile : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // ����� �ε��� ������Ʈ�� �±װ� "Enemy"�̸�
        if (collision.CompareTag("Enemy"))
        {
            // �ε��� ������Ʈ ���ó�� (��)
            Destroy(collision.gameObject);
            // �� ������Ʈ ���� (�߻�ü)
            Destroy(gameObject);
        }
    }
}
