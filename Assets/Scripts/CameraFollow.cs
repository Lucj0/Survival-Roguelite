using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float offset = -10f;

    void LateUpdate()
    {
        transform.position = new Vector3(target.position.x, target.position.y, offset);
    }
}
