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

    [Header("Referances")]
    [SerializeField] GameObject PreGame;
    [SerializeField] GameObject InGame;
    [SerializeField] GameObject LoseGame;
    
    [Header("In Game")]
    [SerializeField] TextMeshProUGUI currentLevelIndex;
    [SerializeField] TextMeshProUGUI nextLevelIndex;
    [SerializeField] Image[] progress;
    [SerializeField] TextMeshProUGUI currentScoreText;

    [Header("EndLevelScoreText")]
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI highScoreText;

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

        for (int i = 0; i < progressCount; i++)
        {
            progress[i].gameObject.SetActive(true);
        }
    }

    public void ProgressBarResetOnNextLevel()
    {
        ResetProgress();
    }

    private void ScoreUpdate()
    {
        currentScoreText.text = ScoreManager.score.ToString();
    }

    private void OpenLoseGameUi()
    {
        LoseGame.SetActive(true);
    }

    private void ScoreText()
    {
        scoreText.gameObject.SetActive(true);
        scoreText.text = "Your Score is: " + ScoreManager.score.ToString() + "\nYour Best Score is: " + PlayerPrefs.GetInt("HighScore").ToString();
    }

    private void HighScoreText()
    {
        highScoreText.gameObject.SetActive(true);
        highScoreText.text = "You beat yourself! New High score is: " + PlayerPrefs.GetInt("HighScore").ToString();
    }

    private void OnEnable()
    {
        ProgressManager.OnProgressIncrease += SetProggress;
        ScoreManager.OnScoreUpdate += ScoreUpdate;
        GameManager.OnLevelLose += OpenLoseGameUi;
        ScoreManager.OnHighScoreBeaten += HighScoreText;
        ScoreManager.OnHighScoreNotBeaten += ScoreText;
    }

    private void OnDisable()
    {
        ProgressManager.OnProgressIncrease -= SetProggress;
        ScoreManager.OnScoreUpdate -= ScoreUpdate;
        GameManager.OnLevelLose -= OpenLoseGameUi;
        ScoreManager.OnHighScoreBeaten -= HighScoreText;
        ScoreManager.OnHighScoreNotBeaten -= ScoreText;
    }
}