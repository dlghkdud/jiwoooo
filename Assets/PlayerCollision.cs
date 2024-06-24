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
            dialogBox.SetActive(false); // 시작 시 대화창을 숨깁니다.
        }
    }

    void ShowDialog()
    {
        if (dialogBox != null)
        {
            dialogBox.SetActive(true); // 충돌 시 대화창을 표시합니다.
            StartCoroutine(HideDialogAfterDelay(5.0f)); // 5초 후 대화창을 닫습니다.

        }
    }

    IEnumerator HideDialogAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay); // delay 시간만큼 대기합니다.
        if (dialogBox != null)
        {
            dialogBox.SetActive(false); // 대화창을 비활성화합니다.
        }
    }

    void OnCollision(Collision collision)
    {
        // 고정된 물체와 움직이는 물체가 충돌했는지 확인
        if (collision.gameObject.CompareTag("Mom")) // 움직이는 물체의 태그가 "MovingObject"라고 가정
        {
            ShowDialog();
            Debug.Log("Hi!");
        }
    }


    // 충돌이 시작될 때 호출되는 함수
    void OnCollisionEnter(Collision collision)
    {
        // 충돌한 오브젝트의 태그를 확인합니다 (필요시 태그를 설정해줘야 합니다)
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            // 충돌 시 발생할 이벤트를 여기서 처리합니다.
            ShowDialog();
            Debug.Log("플레이어가 장애물과 충돌했습니다!");

            // 예를 들어, 장애물과 충돌 시 게임 오버 처리 등을 할 수 있습니다.
            // GameManager.instance.GameOver();
        }
    }

    // 트리거 충돌이 시작될 때 호출되는 함수
    void OnTriggerEnter(Collider other)
    {
        // 트리거 충돌한 오브젝트의 태그를 확인합니다 (필요시 태그를 설정해줘야 합니다)
        if (other.CompareTag("Collectible"))
        {
            // 트리거 충돌 시 발생할 이벤트를 여기서 처리합니다.
            Debug.Log("게임오버!");

            // 예를 들어, 수집 가능한 오브젝트를 획득 처리 등을 할 수 있습니다.
            // GameManager.instance.CollectItem();
            // Destroy(other.gameObject);
        }
    }
}
