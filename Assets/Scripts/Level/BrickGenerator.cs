using UnityEngine;

public class BrickGenerator : ObjectPool
{
    [SerializeField] private GameObject _template;
    [SerializeField] private float _distanceBetweenSpawn;
    [SerializeField] private float _maxBrickSpawnPositionY;
    [SerializeField] private float _minBrickSpawnPositionY;
    [SerializeField] private MoveBackground _moveBackground;
    private float _gameMoveSpeed;
    private float _elapseDistance = 0;
    private void Awake()
    {
        Initialize(_template);
        _moveBackground.OnSpeedChanged += OnSpeedChanged;
    }
    private void Update()
    {
        _elapseDistance += Time.deltaTime * _gameMoveSpeed;
        if (_elapseDistance >= _distanceBetweenSpawn)
        {
            if (TryGetObject(out GameObject Brick))
            {
                _elapseDistance = 0;
                float spawnPositionY = Random.Range(_minBrickSpawnPositionY, _maxBrickSpawnPositionY);
                Brick.SetActive(true);
                Vector3 spawnPoint = new Vector3 (transform.position.x, spawnPositionY, transform.position.z);
                Brick.transform.position = spawnPoint;
                DisableObjectAbroadScreen();
            }
        }
    }
    private void OnSpeedChanged(float newSpeed)
    {
        _gameMoveSpeed = newSpeed;
    }
    private void OnDisable()
    {
        _moveBackground.OnSpeedChanged -= OnSpeedChanged;
    }
}
