using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;
    public int lives = 3;
    public int score = 0;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livesText;


    void Awake()
    {
        Instance = this;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateUI();
    }

    // Update is called once per frame
    public void AddScore()
    {
        score++;
        UpdateUI();
    }

    public void LoseLife()
    {
        lives--;
        UpdateUI();
        if(lives <= 0)
        {
            Debug.Log("Game Over!");
            TriggerGameOver();
            //later: show restart screen
        }

    }

    void UpdateUI()
    {
        scoreText.text = "Score: " + score;
        livesText.text = "Lives: "+ lives;
    }

    void TriggerGameOver()
    {

    }
}
