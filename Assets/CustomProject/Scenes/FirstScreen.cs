using CustomProject.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstScreen : MonoBehaviour
{
    [SerializeField] private GameObject Screen;
    public void OpenFirstScreen()
    {
        ScreenNavigator.Instance.GoToScreen(CustomProject.UI.Enums.Screen.PopupDemonstration);
        Screen.SetActive(false);
    }
}
