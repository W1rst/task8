using CustomProject;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CubePosition : MonoBehaviour
{
    [SerializeField] private CreateTower _creatTowerScript;

    private void OnMouseDown()
    {
        if (gameObject.CompareTag("Create") && _creatTowerScript._canBuyTower == false)
        {
            _creatTowerScript = FindObjectOfType<CreateTower>();
            _creatTowerScript.ShowTowerPanel(transform.position);
        }
    }
}
