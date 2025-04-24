using UnityEngine;
using TMPro;

public class TimeDisplay : MonoBehaviour
{
    public TextMeshProUGUI timeText;

    void Start()
    {
        float totalTime = PlayerPrefs.GetFloat("TotalTimeSpent", 0f);
        int minutes = Mathf.FloorToInt(totalTime / 60f);
        int seconds = Mathf.FloorToInt(totalTime % 60f);

        timeText.text = "Total Time Spent: " + string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
