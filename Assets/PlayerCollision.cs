using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    // 충돌이 시작될 때 호출되는 함수
    void OnCollisionEnter(Collision collision)
    {
        // 충돌한 오브젝트의 태그를 확인합니다 (필요시 태그를 설정해줘야 합니다)
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            // 충돌 시 발생할 이벤트를 여기서 처리합니다.
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
            Debug.Log("플레이어가 수집 가능한 오브젝트와 충돌했습니다!");

            // 예를 들어, 수집 가능한 오브젝트를 획득 처리 등을 할 수 있습니다.
            // GameManager.instance.CollectItem();
            // Destroy(other.gameObject);
        }
    }
}
