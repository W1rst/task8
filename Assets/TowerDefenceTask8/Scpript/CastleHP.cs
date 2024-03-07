using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastleHP : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            MainScript.instance.DecreaseHP(1);
            Destroy(other.gameObject);
        }
    }
}
