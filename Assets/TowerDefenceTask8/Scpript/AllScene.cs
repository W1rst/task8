using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AllScene : MonoBehaviour
{
    [SerializeField] private string[] sceneNames;

    [SerializeField] private Button _mainScene;

    private void Start()
    {
        _mainScene.onClick.AddListener(BackToMenu);
    }

    public void LoadScene(int index)
    {
       SceneManager.LoadScene(sceneNames[index]);
    }

    void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
