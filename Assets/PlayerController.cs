using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f; // 이동 속도 조절
    private Animator animator; // 애니메이터 컴포넌트 참조
    private SpriteRenderer spriteRenderer; // 스프라이트 렌더러 컴포넌트 참조

    void Start()
    {
        animator = GetComponent<Animator>(); // 애니메이터 컴포넌트 가져오기
        spriteRenderer = GetComponent<SpriteRenderer>(); // 스프라이트 렌더러 컴포넌트 가져오기
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal"); // 좌우 화살표 키 입력
        float horizontalMovement = horizontalInput * moveSpeed * Time.deltaTime; // 이동량 계산

        // 현재 위치에 이동량 추가하여 새 위치 계산
        transform.Translate(new Vector2(horizontalMovement, 0f));

        // 움직임이 화면 밖으로 나가지 않도록 제한
//        float screenWidth = Camera.main.orthographicSize * Screen.width / Screen.height;
//        Vector3 clampedPosition = transform.position;
//        clampedPosition.x = Mathf.Clamp(clampedPosition.x, -screenWidth, screenWidth);
//        transform.position = clampedPosition;

        // 이동 중이면 walk 애니메이션 재생
        if (Mathf.Abs(horizontalInput) > 0)
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
}
