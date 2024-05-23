using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public string targetScene; // ��ȯ�� ���� �̸�

    // Ʈ���Ű� ���۵� �� ȣ��Ǵ� �Լ�
    void OnTriggerEnter(Collider other)
    {
        // �浹�� ������Ʈ�� �÷��̾����� Ȯ���մϴ� (�ʿ� �� �±׸� ��������� �մϴ�)
        if (other.CompareTag("Player"))
        {
            // �� ��ȯ
            SceneManager.LoadScene(targetScene);
        }
    }
}
