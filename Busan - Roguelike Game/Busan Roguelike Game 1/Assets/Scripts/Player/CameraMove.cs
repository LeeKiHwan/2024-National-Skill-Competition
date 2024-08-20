using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Vector3 targetPos;
    public Transform lookPos;
    public float speed;

    private void FixedUpdate()
    {
        transform.LookAt(lookPos);
        transform.position = Vector3.Lerp(transform.position, lookPos.position + targetPos, speed * Time.deltaTime);
    }
}
