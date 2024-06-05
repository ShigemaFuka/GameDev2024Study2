using UnityEngine;

/// <summary>
/// ジャンプ機能
/// 二段階ジャンプまでできる
/// </summary>
public class Jump : MonoBehaviour
{
    private float _velocity = default;
    private float _groundY = default;
    private Vector3 _startJumpPoint = default;
    private int _jumpCount = 0;
    [SerializeField] private float _jumpForce = 20;
    [SerializeField] private float _maxHeight = 2;
    [SerializeField] private bool _isUp = default;
    [SerializeField] private bool _isDown = default;
    [SerializeField] private int _maxJumpCount = 2;

    void Start()
    {
        _groundY = transform.position.y;
    }

    void Update()
    {
        if (_isUp)
        {
            transform.Translate(new Vector3(0, _velocity, 0) * (Time.deltaTime * 0.7f));
            if (transform.position.y > _startJumpPoint.y + _maxHeight) // ジャンプ開始地点から上限を再設定
            {
                _isUp = false;
                _isDown = true;
            }
        }
        else if (_isDown)
        {
            transform.Translate(new Vector3(0, -_velocity, 0) * (Time.deltaTime * 0.5f));
            if (transform.position.y < _groundY)
            {
                _isDown = false;
                var pos = transform.position;
                transform.position = new Vector3(pos.x, _groundY, pos.z);
                _jumpCount = 0;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_jumpCount < _maxJumpCount)
            {
                _jumpCount++;
                _startJumpPoint = transform.position;
                _isUp = true;
            }
            _velocity = _jumpForce;
        }
    }
}