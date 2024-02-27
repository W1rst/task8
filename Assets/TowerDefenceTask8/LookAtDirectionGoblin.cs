using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtDirectionGoblin : MonoBehaviour
{
    private Rigidbody rb; // Переменная для доступа к компоненту Rigidbody

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Получаем компонент Rigidbody при запуске скрипта
    }

    void FixedUpdate()
    {
        // Получаем направление движения объекта
        Vector3 direction = rb.velocity.normalized;

        // Если объект движется, то поворачиваем его в соответствии с направлением движения
        if (direction != Vector3.zero)
        {
            // Создаем новый кватернион, чтобы повернуть объект в направлении движения
            Quaternion rotation = Quaternion.LookRotation(direction, Vector3.up);

            // Поворачиваем объект в нужную сторону
            transform.rotation = rotation;
        }
    }
}
