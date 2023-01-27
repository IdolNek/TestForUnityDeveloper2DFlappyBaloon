using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class SpriteAnimation : MonoBehaviour
{
    [SerializeField] private float _frameDeltaTime;
    [SerializeField] private Sprite[] _sprites;
    [SerializeField] private bool _loop;
    private int _currentFrame;
    private float _currentFrameTime;
    private SpriteRenderer _spriteRenderer;
    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _currentFrame = 0;
        _currentFrameTime = 0;
    }
    private void Update()
    {
        _currentFrameTime += Time.deltaTime;
        if (_currentFrameTime < _frameDeltaTime) 
            return;
        if (_currentFrame >= _sprites.Length && _loop) 
            _currentFrame = 0;
        if(_currentFrame >= _sprites.Length && !_loop)
        {
            enabled = false;
            return;
        }
        _currentFrameTime = 0;
        _spriteRenderer.sprite = _sprites[_currentFrame];
        _currentFrame += 1;
    }
}
