using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public VariableJoystick joy;        // joystick �� ���� �������� �����̵��� ��   

    Rigidbody2D rigid;
    private Vector2 moveVec;    // rigid.MovePosition�� ���� �����̵��� ����
    float walkSpeed = 5f;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
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

}
