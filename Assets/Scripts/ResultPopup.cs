using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
public class ResultPopup : MonoBehaviour
{
    public TextMeshProUGUI titleLabel;

    public TextMeshProUGUI scoreLabel;

    public bool isCleared;
    public GameObject highScorePopup;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
        {
        
        }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayAgainPressed()
    {
        SceneManager.LoadScene("GameScene");
        Debug.Log("ResultPopup : PlayAgainPressed");
    }
    private void OnEnable()
    {
        Time.timeScale = 0;
        if (GameManager.Instance.isCleared)
        {
            SaveHighScore();
            titleLabel.text = "Cleared!";
            scoreLabel.text = GameManager.Instance.timeLimit.ToString("#.##");
        }
        else
        {

            titleLabel.text = "Game Over..";
            scoreLabel.text = "";
        }
    }
    void SaveHighScore()
    {
        float score = GameManager.Instance.timeLimit;
        string currentScoreString = score.ToString("#.###");

        string savedScoreString = PlayerPrefs.GetString("HighScores", "");

        if (savedScoreString == "")
        {
            PlayerPrefs.SetString("HighScores", currentScoreString);
        }
        else
        {
            string[] scoreArray = savedScoreString.Split(",");
            List<string> scoreList = new List<string>(scoreArray);

            for (int i = 0; i < scoreList.Count; i++)
            {
                float savedScore = float.Parse(scoreList[i]);
                if (savedScore < score)
                {
                    scoreList.Insert(i, currentScoreString);
                    break;
                }
            }

            if (scoreArray.Length == scoreList.Count)
            {
                scoreList.Add(currentScoreString);
            }

            if (scoreList.Count > 10)
            {
                scoreList.RemoveAt(10);
            }

            string result = string.Join(",", scoreList);
            PlayerPrefs.SetString("HighScores", result);

        }

        PlayerPrefs.Save();
    }
    public void HighScorePressed()
    {
        highScorePopup.SetActive(true);
    }
}
