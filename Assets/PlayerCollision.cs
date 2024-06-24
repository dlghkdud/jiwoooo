using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerCollision : MonoBehaviour
{
    public GameObject dialogBox;

    void Start()
    {
        if (dialogBox != null)
        {
            dialogBox.SetActive(false); // ���� �� ��ȭâ�� ����ϴ�.
        }
    }

    void ShowDialog()
    {
        if (dialogBox != null)
        {
            dialogBox.SetActive(true); // �浹 �� ��ȭâ�� ǥ���մϴ�.
            StartCoroutine(HideDialogAfterDelay(5.0f)); // 5�� �� ��ȭâ�� �ݽ��ϴ�.

        }
    }

    IEnumerator HideDialogAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay); // delay �ð���ŭ ����մϴ�.
        if (dialogBox != null)
        {
            dialogBox.SetActive(false); // ��ȭâ�� ��Ȱ��ȭ�մϴ�.
        }
    }

    void OnCollision(Collision collision)
    {
        // ������ ��ü�� �����̴� ��ü�� �浹�ߴ��� Ȯ��
        if (collision.gameObject.CompareTag("Mom")) // �����̴� ��ü�� �±װ� "MovingObject"��� ����
        {
            ShowDialog();
            Debug.Log("Hi!");
        }
    }


    // �浹�� ���۵� �� ȣ��Ǵ� �Լ�
    void OnCollisionEnter(Collision collision)
    {
        // �浹�� ������Ʈ�� �±׸� Ȯ���մϴ� (�ʿ�� �±׸� ��������� �մϴ�)
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            // �浹 �� �߻��� �̺�Ʈ�� ���⼭ ó���մϴ�.
            ShowDialog();
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
            Debug.Log("���ӿ���!");

            // ���� ���, ���� ������ ������Ʈ�� ȹ�� ó�� ���� �� �� �ֽ��ϴ�.
            // GameManager.instance.CollectItem();
            // Destroy(other.gameObject);
        }
    }
}
