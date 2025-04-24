using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class CountdownTimer : MonoBehaviour
{
    public float countdownTime = 60f;
    public TextMeshProUGUI countdownText;
    public string endSceneName = "EndScreen";

    private float remainingTime;
    private float totalTimeSpent;
    private bool isGameOver = false;
    private bool isPaused = false;

    void Start()
    {
        remainingTime = countdownTime;
        totalTimeSpent = 0f;
        UpdateTimerUI();
    }

    void Update()
    {
        if (isGameOver || isPaused) return;

        remainingTime -= Time.deltaTime;
        totalTimeSpent += Time.deltaTime;

     UpdateTimerUI();

        if (remainingTime <= 0f)
        {
         EndGame();
        }
    }

    public void PauseTimer()
    {
      isPaused = true;
    }

    public void ResumeTimer()
    {
       isPaused = false;
    }

    void UpdateTimerUI()
    {
        if (countdownText != null)
        {
            int minutes = Mathf.FloorToInt(remainingTime / 60f);
            int seconds = Mathf.FloorToInt(remainingTime % 60f);
            countdownText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }

    public void AddTime(float extraTime)
    {
        remainingTime += extraTime;
    }

    void EndGame()
    {
        isGameOver = true;
        PlayerPrefs.SetFloat("TotalTimeSpent", totalTimeSpent);
        PlayerPrefs.Save();
        SceneManager.LoadScene(endSceneName);
    }
}