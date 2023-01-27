using UnityEngine;

public class BrickMove : MonoBehaviour
{
    [SerializeField] private MoveBackground _moveBackground;
    private float _brickSpeedMove;
    private float _brickCurrentPosition;
    private void Awake()
    {
        _moveBackground.OnSpeedChanged += OnSpeedChanged;
    }
    public void ResetPosition()
    {
        transform.position = Vector3.zero;
    }
    private void OnSpeedChanged(float newSpeed)
    {
        _brickSpeedMove = newSpeed;
    }
    private void Update()
    {
        _brickCurrentPosition -= _brickSpeedMove * Time.deltaTime;
        transform.position = new Vector3(_brickCurrentPosition, 0, 0);
    }
    private void OnDisable()
    {
        _moveBackground.OnSpeedChanged -= OnSpeedChanged;
    }
}
