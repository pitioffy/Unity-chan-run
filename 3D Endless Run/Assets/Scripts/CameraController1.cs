using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController1 : MonoBehaviour {

    public Transform targetTransform;
    public float smoothSpeed = 12.5f;
    public Vector3 offset;

    public float smoothTime = 0.3f;
    private Vector3 velocity = Vector3.zero;

    void Start()
    {
        offset = transform.position - targetTransform.position;
    }
    void LateUpdate()
    {
        Vector3 desiredPosition = targetTransform.position + offset;
        /*
        // smooth by using linear interpolation > cause jitter problem (should change to FixedUpdate)
        Vector3 smoothPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.position = smoothPosition;
        */

        // smooth by Vector3.SmoothDamp
        transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothTime);

        // always look at target (rotational caluculation)
        //transform.LookAt(targetTransform);
    }
}
