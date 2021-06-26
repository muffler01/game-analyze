using System.Collections;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    private GameObject  projectilePrefab;   // ������ �� �����Ǵ� �߻�ü ������
    [SerializeField]
    private float       attackRate = 0.1f;  // ���� �ӵ�
    private AudioSource audioSource;        // ���� ��� ������Ʈ

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void StartFiring()
    {
        StartCoroutine("TryAttack");
    }

    public void StopFiring()
    {
        StopCoroutine("TryAttack");
    }

    private IEnumerator TryAttack()
    {
        while (true)
        {
            // �߻�ü ������Ʈ ����
            Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            // ���� ���� ���
            audioSource.Play();

            // attackRate �ð���ŭ ���
            yield return new WaitForSeconds(attackRate);
        }
    }
}
