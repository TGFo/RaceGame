using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DisplayTimer : MonoBehaviour
{
    [SerializeField] TMP_Text timerText;
    [SerializeField] TMP_Text winLossText;
    [SerializeField] GameObject panel;
    string winLossMessage;
    float timer;
    enum winloss
    {
        None,
        win,
        loss
    }
    winloss current = 0;
    [SerializeField] private CheckPointManager checkPointManager;

    private void Update()
    {
        timer = checkPointManager.GetTimer();
        timerText.text = ((int)timer).ToString();
        if(timer <= 0)
        {
            current = winloss.loss;
            winLossMessage = "You Lost";
        }else if(checkPointManager.checkPointStack.Count == 0)
        {
            winLossMessage = "You Win";
            current = winloss.win;
        }
        ShowWinLoss();
    }
    public void ShowWinLoss()
    {
        if(current == 0) { return; }
        panel.SetActive(true);
        winLossText.text = winLossMessage;
        Time.timeScale = 0f;
    }
}
