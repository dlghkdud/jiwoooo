using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f; // �̵� �ӵ� ����
    public float verticalMargin = 1f; // ī�޶� ���κ����� ���� ���� (��/�Ʒ�)
    public float horizontalMargin = 1f; // ī�޶� ���κ����� ���� ���� (�¿�)
    public string targetScene; // ��ȯ�� ���� �̸�
    private Animator animator; // �ִϸ����� ������Ʈ ����
    private SpriteRenderer spriteRenderer; // ��������Ʈ ������ ������Ʈ ����
    private int originalSortingOrder; // ���� sortingOrder ��
    // private bool hasMoved = false; // �÷��̾ ���������� ���� Ȯ��

    void Start()
    {
        animator = GetComponent<Animator>(); // �ִϸ����� ������Ʈ ��������
        spriteRenderer = GetComponent<SpriteRenderer>(); // ��������Ʈ ������ ������Ʈ ��������
        originalSortingOrder = spriteRenderer.sortingOrder; // ���� sortingOrder ���� ����
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal"); // �¿� ȭ��ǥ Ű �Է�
        float verticalInput = Input.GetAxis("Vertical"); // ���Ʒ� ȭ��ǥ Ű �Է�
        float horizontalMovement = horizontalInput * moveSpeed * Time.deltaTime; // ���� �̵��� ���
        float verticalMovement = verticalInput * moveSpeed * Time.deltaTime; // ���� �̵��� ���

        // �÷��̾� �̵�
        transform.Translate(new Vector2(horizontalMovement, verticalMovement));

        // ī�޶� ����Ʈ�� ��� ���
        Vector3 cameraBottomLeft = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, Camera.main.transform.position.z));
        Vector3 cameraTopRight = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, Camera.main.transform.position.z));
        float minY = cameraBottomLeft.y + verticalMargin;
        float maxY = cameraTopRight.y - verticalMargin;
        float minX = cameraBottomLeft.x + horizontalMargin;

        // �÷��̾��� ��ġ�� ī�޶� ����Ʈ ���� ����
        Vector3 clampedPosition = transform.position;
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, minY, maxY);
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, minX, transform.position.x);
        transform.position = clampedPosition;

        // �÷��̾ ���������� sortingOrder�� ����
        if (Mathf.Abs(horizontalInput) > 0 || Mathf.Abs(verticalInput) > 0)
        {
            if (verticalInput > 0) // ���� �̵�
            {
                spriteRenderer.sortingOrder = originalSortingOrder; // ���� sortingOrder�� ����
            }
            else if (verticalInput < 0) // �Ʒ��� �̵�
            {
                spriteRenderer.sortingOrder = originalSortingOrder + 10; // sortingOrder�� ũ�� ����
            }

            //
            // hasMoved = true;
        }

        // �̵� ���̸� walk �ִϸ��̼� ���
        if (Mathf.Abs(horizontalInput) > 0 || Mathf.Abs(verticalInput) > 0)
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
