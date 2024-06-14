using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f; // 이동 속도 조절
    public float verticalMargin = 1f; // 카메라 경계로부터의 여유 마진 (위/아래)
    public float horizontalMargin = 1f; // 카메라 경계로부터의 여유 마진 (좌우)
    public string targetScene; // 전환할 씬의 이름
    private Animator animator; // 애니메이터 컴포넌트 참조
    private SpriteRenderer spriteRenderer; // 스프라이트 렌더러 컴포넌트 참조
    private int originalSortingOrder; // 원래 sortingOrder 값
    // private bool hasMoved = false; // 플레이어가 움직였는지 여부 확인

    void Start()
    {
        animator = GetComponent<Animator>(); // 애니메이터 컴포넌트 가져오기
        spriteRenderer = GetComponent<SpriteRenderer>(); // 스프라이트 렌더러 컴포넌트 가져오기
        originalSortingOrder = spriteRenderer.sortingOrder; // 원래 sortingOrder 값을 저장
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal"); // 좌우 화살표 키 입력
        float verticalInput = Input.GetAxis("Vertical"); // 위아래 화살표 키 입력
        float horizontalMovement = horizontalInput * moveSpeed * Time.deltaTime; // 수평 이동량 계산
        float verticalMovement = verticalInput * moveSpeed * Time.deltaTime; // 수직 이동량 계산

        // 플레이어 이동
        transform.Translate(new Vector2(horizontalMovement, verticalMovement));

        // 카메라 뷰포트의 경계 계산
        Vector3 cameraBottomLeft = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, Camera.main.transform.position.z));
        Vector3 cameraTopRight = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, Camera.main.transform.position.z));
        float minY = cameraBottomLeft.y + verticalMargin;
        float maxY = cameraTopRight.y - verticalMargin;
        float minX = cameraBottomLeft.x + horizontalMargin;

        // 플레이어의 위치를 카메라 뷰포트 내로 제한
        Vector3 clampedPosition = transform.position;
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, minY, maxY);
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, minX, transform.position.x);
        transform.position = clampedPosition;

        // 플레이어가 움직였으면 sortingOrder를 변경
        if (Mathf.Abs(horizontalInput) > 0 || Mathf.Abs(verticalInput) > 0)
        {
            if (verticalInput > 0) // 위로 이동
            {
                spriteRenderer.sortingOrder = originalSortingOrder; // 원래 sortingOrder로 설정
            }
            else if (verticalInput < 0) // 아래로 이동
            {
                spriteRenderer.sortingOrder = originalSortingOrder + 10; // sortingOrder를 크게 변경
            }

            //
            // hasMoved = true;
        }

        // 이동 중이면 walk 애니메이션 재생
        if (Mathf.Abs(horizontalInput) > 0 || Mathf.Abs(verticalInput) > 0)
        {
            animator.SetBool("walk", true);
        }
        else
        {
            animator.SetBool("walk", false);
        }

        // 방향에 따라 캐릭터의 스케일 조정
        if (horizontalInput < 0)
        {
            spriteRenderer.flipX = false; // 오른쪽을 바라보게 설정
        }
        else if (horizontalInput > 0)
        {
            spriteRenderer.flipX = true; // 왼쪽을 바라보게 설정
        }
    }

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
