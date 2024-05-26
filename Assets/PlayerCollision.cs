using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    // �浹�� ���۵� �� ȣ��Ǵ� �Լ�
    void OnCollisionEnter(Collision collision)
    {
        // �浹�� ������Ʈ�� �±׸� Ȯ���մϴ� (�ʿ�� �±׸� ��������� �մϴ�)
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            // �浹 �� �߻��� �̺�Ʈ�� ���⼭ ó���մϴ�.
            Debug.Log("�÷��̾ ��ֹ��� �浹�߽��ϴ�!");

            // ���� ���, ��ֹ��� �浹 �� ���� ���� ó�� ���� �� �� �ֽ��ϴ�.
            // GameManager.instance.GameOver();
        }
    }

    // Ʈ���� �浹�� ���۵� �� ȣ��Ǵ� �Լ�
    void OnTriggerEnter(Collider other)
    {
        // Ʈ���� �浹�� ������Ʈ�� �±׸� Ȯ���մϴ� (�ʿ�� �±׸� ��������� �մϴ�)
        if (other.CompareTag("Collectible"))
        {
            // Ʈ���� �浹 �� �߻��� �̺�Ʈ�� ���⼭ ó���մϴ�.
            Debug.Log("�÷��̾ ���� ������ ������Ʈ�� �浹�߽��ϴ�!");

            // ���� ���, ���� ������ ������Ʈ�� ȹ�� ó�� ���� �� �� �ֽ��ϴ�.
            // GameManager.instance.CollectItem();
            // Destroy(other.gameObject);
        }
    }
}
