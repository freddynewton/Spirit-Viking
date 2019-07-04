using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;
    
    private void Start()
    {
        target = GameObject.Find("Player").transform;
    }

    private void Update()
    {
       
        Vector3 desiredPosition = target.position + offset;
        //Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        Vector3 smoothedPosition = desiredPosition;
        transform.position = smoothedPosition;

        transform.LookAt(target);
    }
}
