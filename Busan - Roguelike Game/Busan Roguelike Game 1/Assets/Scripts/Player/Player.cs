using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance;

    public Rigidbody rb;

    private void Awake()
    {
        Instance = this;

        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Move();
        Rotate();
    }

    public void Move()
    {
        float x = Input.GetAxisRaw("Horizontal") * AttackManager.Instance.speed;
        float z = Input.GetAxisRaw("Vertical") * AttackManager.Instance.speed;

        rb.velocity = new Vector3(x,0,z);
    }

    public void Rotate()
    {
        Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane);
        Physics.Raycast(Camera.main.ScreenPointToRay(mousePos), out RaycastHit hit, 100);

        transform.LookAt(new Vector3(hit.point.x, transform.position.y, hit.point.z));
    }
}
