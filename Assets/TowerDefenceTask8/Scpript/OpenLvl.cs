using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenLvl : MonoBehaviour
{
    [SerializeField] private int _minStarsOpen;

    private void Update()
    {
        if (AllScene.instance._openLvl < _minStarsOpen)
        {
            gameObject.GetComponent<Button>().interactable = false;
        }
        else
        {
            gameObject.GetComponent<Button>().interactable = true;
        }
    }
}
