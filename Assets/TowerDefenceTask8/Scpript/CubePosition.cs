using CustomProject;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubePosition : MonoBehaviour
{
    [SerializeField] private CreateTower _creatTowerScript;

   

    private void OnMouseDown()
    {
        if (gameObject.tag == "Create")
        {
            _creatTowerScript = FindObjectOfType<CreateTower>();
            _creatTowerScript.ShowTowerPanel(transform.position);
        } else
        {
            Debug.Log("lox");
        }
    }
}
