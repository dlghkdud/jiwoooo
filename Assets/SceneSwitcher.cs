using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public string targetScene; // 전환할 씬의 이름

    // 트리거가 시작될 때 호출되는 함수
    void OnTriggerEnter(Collider other)
    {
        // 충돌한 오브젝트가 플레이어인지 확인합니다 (필요 시 태그를 설정해줘야 합니다)
        if (other.CompareTag("Player"))
        {
            // 씬 전환
            SceneManager.LoadScene(targetScene);
        }
    }
}
