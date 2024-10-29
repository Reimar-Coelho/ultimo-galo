using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimerCtrl : MonoBehaviour
{
    public Image timer_linear_image;
    public float time_remaining;
    public float max_time = 5.0f;
    public TMPro.TextMeshProUGUI text_timer;

    void Start()
    {
        time_remaining = max_time;
    }

    void Update()
    {
        if (time_remaining > 0)
        {
            time_remaining -= Time.deltaTime;
            timer_linear_image.fillAmount = time_remaining / max_time;
            //tempo em minutos e segundos
            int minutes = Mathf.FloorToInt(time_remaining / 60);
            int seconds = Mathf.FloorToInt(time_remaining % 60);
            text_timer.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
        else
        {
            SceneManager.LoadScene("Arena");
        }
    }
}