using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private int                 damage = 1;         // �� ���ݷ�
    [SerializeField]
    private int                 scorePoint = 100;   // �� óġ �� ȹ�� ����
    [SerializeField]
    private GameObject          explosionPrefab;    // ���� ȿ��
    [SerializeField]
    private GameObject[]        itemPrefab;         // ���� �׿��� �� ȹ�� ������ ������

    private PlayerController    playerController;   // �÷��̾��� ����(Score) ������ �����ϱ� ����

    private void Awake()
    {
        // Tip. ���� �ڵ忡���� �ѹ��� ȣ���ϱ� ������ OnDie()���� �ٷ� ȣ���ص� ������
        // ������Ʈ Ǯ���� �̿��� ������Ʈ�� ������ ��쿡�� ���� 1���� Find�� �̿���
        // PlayerController�� ������ �����صΰ� ����ϴ� ���� ���꿡 ȿ�����̴�.
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // ������ �ε��� ������Ʈ�� �±װ� "Player"�̸�
        if (collision.CompareTag("Player"))
        {
            // �� ���ݷ¸�ŭ �÷��̾� ü�� ����
            collision.GetComponent<PlayerHP>().TakeDamage(damage);
            // �� ���
            OnDie();
        }
    }

    public void OnDie()
    {
        // �÷��̾��� ������ scorePoint��ŭ ������Ų��.
        playerController.Score += scorePoint;
        // ���� ����Ʈ ����
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        // ���� Ȯ���� ������ ����
        SpawnItem();
        // �� ������Ʈ ����
        Destroy(gameObject);
    }

    private void SpawnItem()
    {
        // �Ŀ��� (10%), ��ź+1 (5%), ü��ȸ�� (15%)
        int spawnItem = Random.Range(0, 100);
        if (spawnItem < 10)
        {
            Instantiate(itemPrefab[0], transform.position, Quaternion.identity);
        }
        else if (spawnItem < 15)
        {
            Instantiate(itemPrefab[1], transform.position, Quaternion.identity);
        }
        else if (spawnItem < 30)
        {
            Instantiate(itemPrefab[2], transform.position, Quaternion.identity);
        }
    }
}
