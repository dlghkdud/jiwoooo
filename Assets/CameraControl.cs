using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // ĳ���͸� ����ٴ� ���(Ÿ��)�� Transform
    public float maxX; // ī�޶� �̵��� �� �ִ� �ִ� x ��ġ

    void Update()
    {
        if (target != null)
        {
            // Ÿ���� ���� ��ġ�� �����ͼ� ī�޶��� ��ġ�� Ÿ���� x��ǥ�� ���߰� y�� z��ǥ�� ����
            float targetX = target.position.x;

            // ī�޶��� x ��ǥ�� maxX�� ���� �ʵ��� ����
            float newX = Mathf.Min(targetX, maxX);

            transform.position = new Vector3(newX, transform.position.y, transform.position.z);
        }
    }
}
