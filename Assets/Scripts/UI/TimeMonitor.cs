using System;
using TMPro;
using UnityEngine;

public class TimeMonitor : MonoBehaviour
{
    [SerializeField] private TMP_Text _timeTextDisplay;
    [SerializeField] private Timer _timer;
    private void Update()
    {
        _timeTextDisplay.text = Math.Round(_timer.GamePlayTime, 2).ToString();
    }
}
