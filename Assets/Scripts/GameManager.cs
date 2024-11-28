using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    public TextMeshProUGUI scoreLabel;
    public Lives lifeDisplayer;
    public GameObject virtualCamera;
    public int lives = 3;
    public float timeLimit = 30;
    public Player player;
    public bool isCleared;
    public GameObject resultPopup;
    private void Awake()
    {
        Instance = this;
        Time.timeScale = 1;
        isCleared = false;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lifeDisplayer.SetLives(lives);
        Debug.Log("GameManager : Start");
    }

 
    // Update is called once per frame
    void Update()
    {
        timeLimit -= Time.deltaTime;

        scoreLabel.text = "Time Left " + ((int)timeLimit).ToString();
    }
    public void AddTime(float time)
    {
        timeLimit += time;
    }
    public void StageClear()
    {
        isCleared = true;

        resultPopup.SetActive(true);
        Debug.Log("Score : " + timeLimit);

        Debug.Log("Clear!");
    }

    public void Die()
    {
        virtualCamera.SetActive(false);

        lives--;
        lifeDisplayer.SetLives(lives);
        Invoke("Restart", 2);
    }
    public void Restart()
    {
        if (lives == 0)
        {
            GameOver();
            Debug.Log("GameManager : Restart! lives == 0");
        }
        else
        {
            virtualCamera.SetActive(true);
            player.Restart();
            Debug.Log("GameManager : Restart!");
        }
    }
    public void GameOver()
    {
        isCleared = false;

        resultPopup.SetActive(true);

    }
}


