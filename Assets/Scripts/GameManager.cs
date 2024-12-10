using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using JetBrains.Annotations;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int timer = 121;
    [SerializeField] private int timerInsgesamt = 90;
    [SerializeField] private TMP_Text timerText;
    [SerializeField] private GameObject RestartPanel;

    private void Start()
    {
        Time.timeScale = 1;
        timer = timerInsgesamt;
        timerText.text = "Time left: " + timer.ToString();
        InvokeRepeating(nameof(CountDown), 1, 1);
        RestartPanel.SetActive(false);
    }

    private void CountDown()
    {
        timer--;
        timerText.text = "Time left: " + timer.ToString();
        
        if (timer == 0)
        {
            print("Time ran out!!!");
            Time.timeScale = 0;
            RestartPanel.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
        }
        
    }
    public void Restart()
    {
        print("Hat geklappt");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
    }
}
