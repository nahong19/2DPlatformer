using UnityEngine;
using TMPro;
public class HighScorePopup : MonoBehaviour
{

    public TextMeshProUGUI scoresLabel;

    private void OnEnable()
    {
        string[] scores = PlayerPrefs.GetString("HighScores", "").Split(",");

        string result = "";

        for (int i = 0; i < scores.Length; i++)
        {
            result += (i + 1) + ". " + scores[i] + "\n";
        }

        scoresLabel.text = result;

    }

    public void ClosePressed()
    {
        gameObject.SetActive(false);
    }


// Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
