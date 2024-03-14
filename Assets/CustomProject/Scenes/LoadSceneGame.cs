using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadSceneGame : MonoBehaviour
{
    [SerializeField] private Button _loadScene;


    private void Start()
    {
        _loadScene.onClick.AddListener(Load);
    }

    void Load()
    {
        SceneManager.LoadScene(1);
    }
}
