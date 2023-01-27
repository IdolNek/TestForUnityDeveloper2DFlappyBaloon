using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private GameEvent _gameEvent;
    public void SetGameEvent(GameEvent gameEvent)
    {
        _gameEvent = gameEvent;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        _gameEvent.GameOver();
    }
}
