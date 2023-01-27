using UnityEngine;

public class Timer : MonoBehaviour
{
    private float _gamePlayTime;
    public float GamePlayTime => _gamePlayTime;
    public void ResetTime()
    {
        _gamePlayTime = 0;
    }
    private void Update()
    {
        _gamePlayTime +=Time.deltaTime;
    }
}
