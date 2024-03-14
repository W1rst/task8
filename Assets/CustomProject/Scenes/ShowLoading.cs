using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CustomProject.UI;
using UnityEngine.UI;
using CustomProject;
using System.Reflection;

public class ShowLoading : MonoBehaviour
{
    [SerializeField] private Button _loading;
    [SerializeField] private Button _error;
    [SerializeField] private Button _message;

    private GameSceneUIMediator _mediator;

    private void Start()
    {
        _mediator = FindObjectOfType<GameSceneUIMediator>();

        _loading.onClick.AddListener(ShowL);
        _error.onClick.AddListener(ShowE);
        _message.onClick.AddListener(ShowM);
    }

    void ShowL()
    {
        _mediator.OpenLoadingPopup();
    }

    void ShowE()
    {
        _mediator.OpenErrorPopup();
    }
    void ShowM()
    {
        _mediator.OpenMessagePopup();
    }
}
