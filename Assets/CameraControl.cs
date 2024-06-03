using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // 캐릭터를 따라다닐 대상(타겟)의 Transform
    public float minX; // 카메라가 이동할 수 있는 최소 x 위치
    public float maxX; // 카메라가 이동할 수 있는 최대 x 위치

    void Update()
    {
        if (target != null)
        {
            // 타겟의 현재 위치를 가져와서 카메라의 위치를 타겟의 x좌표에 맞추고 y와 z좌표는 유지
            float targetX = target.position.x;

            // 카메라의 x 좌표가 minX와 maxX 사이에 있도록 제한
            float newX = Mathf.Clamp(targetX, minX, maxX);

            transform.position = new Vector3(newX, transform.position.y, transform.position.z);
        }
    }
}
