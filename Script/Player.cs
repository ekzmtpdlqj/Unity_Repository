using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public VariableJoystick joy;        // joystick �� ���� �������� �����̵��� ��   

    Rigidbody2D rigid;
    PolygonCollider2D polygon;

    public bool isDiscovering = false;
    private Vector2 moveVec;    // rigid.MovePosition�� ���� �����̵��� ����
    float walkSpeed = 5f;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        polygon = GetComponent<PolygonCollider2D>();
    }

    void FixedUpdate()
    {
        float x = joy.Horizontal;
        float y = joy.Vertical;

        // Move
        moveVec = new Vector2(x, y) * walkSpeed * Time.deltaTime;
        rigid.MovePosition(rigid.position + moveVec);

        if (moveVec.sqrMagnitude == 0)
            return; // no input = no rotation

        Quaternion dirQuat = Quaternion.LookRotation(moveVec);  // ȸ���Ϸ��� ����

        float angle = Mathf.Atan2(moveVec.y, moveVec.x) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 0.3f);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("OtherPlayer"))
        {
            isDiscovering = true;
        }        
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("OtherPlayer"))
        {
            isDiscovering = false;
        }
    }
}
