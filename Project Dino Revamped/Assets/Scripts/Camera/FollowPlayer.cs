using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform target;

    public float smoothSpeed = 0.125f;

    void LateUpdate()
    {
        transform.position = target.position;
    }
   
}
