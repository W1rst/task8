using UnityEngine;
using UnityEngine.UI;
using CustomProject.UI.Enums;
using CustomProject.UI;
using CustomProject;

public class NextPrevious : MonoBehaviour
{
    [SerializeField] private Button _previousButton;
    [SerializeField] private Button _nextButton;

    private GameSceneUIMediator _gameSceneUIMediator;

    private CustomProject.UI.Enums.Screen _currentScreen;

    private void Start()
    {
        _gameSceneUIMediator = FindObjectOfType<GameSceneUIMediator>();
        _currentScreen = CustomProject.UI.Enums.Screen.Start;

        _previousButton.onClick.AddListener(GoToPreviousScreen);
        _nextButton.onClick.AddListener(GoToNextScreen);
    }

    void GoToPreviousScreen()
    {
        int previousIndex = (int)_currentScreen - 1;
        if (previousIndex < 0)
            previousIndex = System.Enum.GetValues(typeof(CustomProject.UI.Enums.Screen)).Length - 1;
        _currentScreen = (CustomProject.UI.Enums.Screen)previousIndex;
        NavigateToScreen(_currentScreen);
    }

    void GoToNextScreen()
    {
        int nextIndex = (int)_currentScreen + 1;
        if (nextIndex >= System.Enum.GetValues(typeof(CustomProject.UI.Enums.Screen)).Length)
            nextIndex = 0;
        _currentScreen = (CustomProject.UI.Enums.Screen)nextIndex;
        NavigateToScreen(_currentScreen);
    }

    void NavigateToScreen(CustomProject.UI.Enums.Screen screen)
    {
        switch (screen)
        {
            case CustomProject.UI.Enums.Screen.Start:
                _gameSceneUIMediator.ShowStartScreen();
                break;
            case CustomProject.UI.Enums.Screen.PopupDemonstration:
                _gameSceneUIMediator.ShowPopupScreen();
                break;
            case CustomProject.UI.Enums.Screen.JustScreen:
                _gameSceneUIMediator.ShowJustScreen();
                break;
            case CustomProject.UI.Enums.Screen.PlayScreen:
                _gameSceneUIMediator.ShowPlayScreen();
                break;
            default:
                Debug.LogError("Неизвестный экран: " + screen);
                break;
        }
    }
}
