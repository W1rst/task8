using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AllScene : MonoBehaviour
{
    [SerializeField] private string[] sceneNames;
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private Button _mainScene;
    public int[] allStars = new int[8];
    public static AllScene instance;
    string starsCountKey = "ActiveStarsCount";
    [SerializeField] private GameObject[][] starsArrays = new GameObject[8][];

    public int _openLvl;
    void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        _mainScene.onClick.AddListener(BackToMenu);

        for (int i = 0; i < 8; i++)
        {
            starsArrays[i] = new GameObject[3];

            for (int j = 0; j < 3; j++)
            {
                starsArrays[i][j] = GameObject.Find("starLvl" + (i + 1) + (j + 1));
                Debug.Log(GameObject.Find("starLvl" + (i + 1) + (j + 1)).name);
            }
        }
        DeactivateAllStars();

    }

    private void Update()
    {
        GetStars();

        for (int i = 0; i < 8; i++)
        {
            int value = PlayerPrefs.GetInt("ActiveStarsCount_" + i.ToString());

            ActivateStars(i, value);
        }
    }

    void GetStars()
    {
        int totalSum = 0;

        for (int i = 0; i < allStars.Length; i++)
        {
            int value = PlayerPrefs.GetInt("ActiveStarsCount_" + i.ToString());
            totalSum += value;
        }

        _text.text = totalSum.ToString();
        _openLvl = totalSum;
    }

    private void ActivateStars(int levelIndex, int numStarsToActivate)
    {

        DeactivateStars(levelIndex);

        GameObject[] starsArray = starsArrays[levelIndex];
        numStarsToActivate = Mathf.Min(numStarsToActivate, starsArray.Length);

        for (int i = 0; i < numStarsToActivate; i++)
        {
            if (starsArray[i] != null)
                starsArray[i].SetActive(true);
        }
    }

    public void LoadScene(int index)
    {
        SceneManager.LoadScene(sceneNames[index]);
        Time.timeScale = 1;
    }

    void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }

    private void DeactivateAllStars()
    {
        for (int i = 0; i < starsArrays.Length; i++)
        {
            DeactivateStars(i);
        }
    }
    private void DeactivateStars(int levelIndex)
    {
        GameObject[] starsArray = starsArrays[levelIndex];

        foreach (GameObject star in starsArray)
        {
            if (star != null)
                star.SetActive(false);
        }
    }
}
