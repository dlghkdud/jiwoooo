using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f; // �̵� �ӵ� ����
    private Animator animator; // �ִϸ����� ������Ʈ ����
    private SpriteRenderer spriteRenderer; // ��������Ʈ ������ ������Ʈ ����

    void Start()
    {
        animator = GetComponent<Animator>(); // �ִϸ����� ������Ʈ ��������
        spriteRenderer = GetComponent<SpriteRenderer>(); // ��������Ʈ ������ ������Ʈ ��������
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal"); // �¿� ȭ��ǥ Ű �Է�
        float horizontalMovement = horizontalInput * moveSpeed * Time.deltaTime; // �̵��� ���

        // ���� ��ġ�� �̵��� �߰��Ͽ� �� ��ġ ���
        transform.Translate(new Vector2(horizontalMovement, 0f));

        // �������� ȭ�� ������ ������ �ʵ��� ����
//        float screenWidth = Camera.main.orthographicSize * Screen.width / Screen.height;
//        Vector3 clampedPosition = transform.position;
//        clampedPosition.x = Mathf.Clamp(clampedPosition.x, -screenWidth, screenWidth);
//        transform.position = clampedPosition;

        // �̵� ���̸� walk �ִϸ��̼� ���
        if (Mathf.Abs(horizontalInput) > 0)
        {
            animator.SetBool("walk", true);
        }
        else
        {
            animator.SetBool("walk", false);
        }

        // ���⿡ ���� ĳ������ ������ ����
        if (horizontalInput < 0)
        {
            spriteRenderer.flipX = false; // �������� �ٶ󺸰� ����
        }
        else if (horizontalInput > 0)
        {
            spriteRenderer.flipX = true; // ������ �ٶ󺸰� ����
        }
    }
}
