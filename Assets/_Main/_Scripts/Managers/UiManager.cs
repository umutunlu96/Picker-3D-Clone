using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UiManager : MonoBehaviour
{
    public static UiManager instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    [SerializeField] GameObject PreGame;
    [SerializeField] GameObject InGame;
    [SerializeField] GameObject WinGame;
    [SerializeField] GameObject LoseGame;
    [SerializeField] TextMeshProUGUI currentLevelIndex;
    [SerializeField] TextMeshProUGUI nextLevelIndex;
    [SerializeField] Image[] progress;
    [SerializeField] TextMeshProUGUI scoreText;

    private void Start()
    {
        SetLevelIndexText();
    }

    public void SetLevelIndexText()
    {
        currentLevelIndex.text = GameManager.levelIndex.ToString();
        nextLevelIndex.text = (GameManager.levelIndex + 1).ToString();
    }

    public void ResetProgress()
    {
        for (int i = 0; i < progress.Length; i++)
        {
            progress[i].gameObject.SetActive(false);
        }
    }

    public void SetProggress(int progressCount)
    {
        ResetProgress();

        int index = progressCount % 4;

        for (int i = 0; i < index; i++)
        {
            progress[i].gameObject.SetActive(true);
        }
    }

    private void ScoreUpdate()
    {
        scoreText.text = ScoreManager.score.ToString();
    }


    private void OnEnable()
    {
        ProgressManager.OnProgressIncrease += SetProggress;
        ScoreManager.OnScoreUpdate += ScoreUpdate;
    }

    private void OnDisable()
    {
        ProgressManager.OnProgressIncrease -= SetProggress;
        ScoreManager.OnScoreUpdate -= ScoreUpdate;
    }
}