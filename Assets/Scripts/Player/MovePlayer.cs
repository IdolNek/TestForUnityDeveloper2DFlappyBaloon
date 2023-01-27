using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class MovePlayer : MonoBehaviour
{
    [SerializeField] private float _flyForce;
    private Vector3 _startPosition;
    private Rigidbody2D _rigidbody;

    private void Start()
    {
        _startPosition = transform.position;
        _rigidbody = GetComponent<Rigidbody2D>();
        ResetBaloon();
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow) )
        {
            _rigidbody.AddForce(Vector2.up * _flyForce, ForceMode2D.Force);
        }
    }
    public void ResetBaloon()
    {
        transform.position = _startPosition;
        _rigidbody.velocity = Vector2.zero;
    }
}
