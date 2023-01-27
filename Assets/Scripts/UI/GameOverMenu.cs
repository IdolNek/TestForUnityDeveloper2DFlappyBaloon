using System;
using TMPro;
using UnityEngine;

public class GameOverMenu : MonoBehaviour
{
    [SerializeField] private TMP_Text _gamePlayTime;
    [SerializeField] private TMP_Text _try;
    [SerializeField] private TMP_Dropdown _setdifficulty;
    [SerializeField] private Timer _timer;
    [SerializeField] private GameEvent _gameEvent;
    [SerializeField] private GameData _gameData;
    private void Start()
    {
        UpdateDisplay();
    }
    public void SetDifficult()
    {
        _gameEvent.SetDifficult(_setdifficulty.value);       
    }
    public void UpdateDisplay()
    {
        _gamePlayTime.text = $"You time: {Math.Round(_timer.GamePlayTime, 2)}";
        _try.text = $"You try: {_gameData.TryTimes} times";
    }
}
