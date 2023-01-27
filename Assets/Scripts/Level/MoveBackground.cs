using UnityEngine;
using UnityEngine.Events;

public class MoveBackground : MonoBehaviour
{
    [SerializeField] private GameEvent _gameEvent;
    [SerializeField] private float _bckgLenght;
    [SerializeField] private float _timeIntervalToChangeSpeed;
    [SerializeField] private float _easyMoveSpeed = 3f;
    [SerializeField] private float _normalMoveSpeed = 4f;
    [SerializeField] private float _difficultMoveSpeed = 5f;
    [SerializeField] private float _deltaMoveSpeed = 1f;
    private float _moveSpeed;
    private Transform _bckgTransform;
    private float _bckgCurrentPosition;
    private Vector3 _startPoint;
    private float _currentTime;
    public float MoveSpeed => _moveSpeed;
    public event UnityAction<float> OnSpeedChanged;
    private void Awake()
    {
        _bckgTransform = GetComponent<Transform>();
        _startPoint = _bckgTransform.position;
        SetMoveSpeed(_gameEvent.Difficult);
    }
    private void Start()
    {
        OnSpeedChanged?.Invoke(_moveSpeed);
    }
    private void Update()
    {
        _currentTime += Time.deltaTime;
        if (_currentTime > _timeIntervalToChangeSpeed) 
        {
            _currentTime = 0;
            _moveSpeed += _deltaMoveSpeed;
            OnSpeedChanged?.Invoke(_moveSpeed);
        }
        _bckgCurrentPosition -= _moveSpeed * Time.deltaTime;
        _bckgCurrentPosition = Mathf.Repeat(_bckgCurrentPosition, _bckgLenght);
        _bckgTransform.position = new Vector3(_bckgCurrentPosition, 0, 0);
    }
    private void SetMoveSpeed(int difficult)
    {
        if (difficult == 0) _moveSpeed = _easyMoveSpeed;
        if (difficult == 1) _moveSpeed = _normalMoveSpeed;
        if (difficult == 2) _moveSpeed = _difficultMoveSpeed;
        OnSpeedChanged?.Invoke(_moveSpeed);
    }
    public void StartNewGame()
    {
        _bckgTransform.position = _startPoint;
        SetMoveSpeed(_gameEvent.Difficult);
        _bckgCurrentPosition = 0;
        _currentTime = 0;
    }
}
