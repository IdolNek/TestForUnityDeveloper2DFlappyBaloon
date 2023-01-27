using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _playerGameObject;
    [SerializeField] private Transform _playerSpawnPoint;
    [SerializeField] private GameEvent _gameEvent;
    private GameObject _player;
    private void Start()
    {
        _player = Instantiate(_playerGameObject, null,_playerSpawnPoint);
        _player.GetComponent<PlayerCollision>().SetGameEvent(_gameEvent);
    }
    public void StartNewGame()
    {
        _player.transform.position = _playerSpawnPoint.position;
        _player.GetComponent<MovePlayer>().ResetBaloon();
    }
}
