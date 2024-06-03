using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // ĳ���͸� ����ٴ� ���(Ÿ��)�� Transform
    public float minX; // ī�޶� �̵��� �� �ִ� �ּ� x ��ġ
    public float maxX; // ī�޶� �̵��� �� �ִ� �ִ� x ��ġ

    void Update()
    {
        if (target != null)
        {
            // Ÿ���� ���� ��ġ�� �����ͼ� ī�޶��� ��ġ�� Ÿ���� x��ǥ�� ���߰� y�� z��ǥ�� ����
            float targetX = target.position.x;

            // ī�޶��� x ��ǥ�� minX�� maxX ���̿� �ֵ��� ����
            float newX = Mathf.Clamp(targetX, minX, maxX);

            transform.position = new Vector3(newX, transform.position.y, transform.position.z);
        }
    }
}
