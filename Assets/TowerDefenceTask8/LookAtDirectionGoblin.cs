using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtDirectionGoblin : MonoBehaviour
{
    private Rigidbody rb; // ���������� ��� ������� � ���������� Rigidbody

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // �������� ��������� Rigidbody ��� ������� �������
    }

    void FixedUpdate()
    {
        // �������� ����������� �������� �������
        Vector3 direction = rb.velocity.normalized;

        // ���� ������ ��������, �� ������������ ��� � ������������ � ������������ ��������
        if (direction != Vector3.zero)
        {
            // ������� ����� ����������, ����� ��������� ������ � ����������� ��������
            Quaternion rotation = Quaternion.LookRotation(direction, Vector3.up);

            // ������������ ������ � ������ �������
            transform.rotation = rotation;
        }
    }
}
