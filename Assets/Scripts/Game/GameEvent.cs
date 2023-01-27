using UnityEngine;

public class GameEvent : MonoBehaviour
{
    [SerializeField] private GameObject _gameOverMenu;
    [SerializeField] private GameObject _timeDisplay;
    [SerializeField] private GameData GameData;
    private int _difficult = 0;
    private string _saveKey = "try";
    public int Difficult => _difficult;
    private void Awake()
    {
        Time.timeScale = 0;
        Load();
    }
    public void SetDifficult(int difficult)
    {
        _difficult = difficult;
        if (difficult < 0) _difficult = 0;
        if (difficult > 2) _difficult = 2;
    }
    public void GameOver()
    {
        Time.timeScale = 0;
        _gameOverMenu.GetComponent<GameOverMenu>().UpdateDisplay();
        _gameOverMenu.SetActive(true);
        _timeDisplay.SetActive(false);
    }
    public void StartNewGame()
    {
        GameData.TryTimes++;
        Save();
        Time.timeScale = 1;
        _gameOverMenu.SetActive(false);
        _timeDisplay.SetActive(true);
    }
    private void Load()
    {
        if (PlayerPrefs.HasKey(_saveKey))
        {
            GameData.TryTimes = PlayerPrefs.GetInt(_saveKey);
        }
        else GameData.TryTimes = 0;
    }
    private void Save()
    {
        PlayerPrefs.SetInt(_saveKey, GameData.TryTimes);
    }
}
