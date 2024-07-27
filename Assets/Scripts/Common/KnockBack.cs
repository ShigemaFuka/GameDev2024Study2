using UnityEngine;

public class KnockBack : MonoBehaviour, IKnockBack
{
    // 0.0001fとかにするとノックバック中の無敵が分かりやすい
    [SerializeField] private float _power = 0.01f;
    private Vector2 _selfPos = default;
    private Vector2 _targetPos = default; // 移動先
    private bool _isReach = default;
    private Vector2 _offset = default;
    private float _sqrLen = default;
    private float _defaultY = default; // 初期位置のY
    private IInvincible _invincible = default;

    private void Start()
    {
        _defaultY = transform.position.y;
        _isReach = true;
        _invincible = GetComponent<IInvincible>();
    }

    private void Update()
    {
        if (_isReach)
        {
            if (_invincible != null) _invincible.IsInvincible = false;
            return;
        }

        if (_invincible != null) _invincible.IsInvincible = true; // 無敵モードを真にする
        _offset = _targetPos - (Vector2)transform.position;
        _sqrLen = _offset.sqrMagnitude;
        if (_sqrLen < 0.1) _isReach = true;
        transform.position =
            Vector2.MoveTowards(transform.position, _targetPos, Time.time * _power);
    }

    /// <summary>
    /// 当たった方と逆方向に下がる
    /// </summary>
    /// <param name="go"> 自身にぶつかったもの </param>
    public void KnockBackMovement(GameObject go)
    {
        if(_invincible is { IsInvincible: true }) return; // 無敵中はノックバックしない
        _isReach = false;
        _selfPos = transform.position;
        var direction = (Vector2)go.transform.position - _selfPos;

        // 地面めり込み防止
        if (transform.position.y < _defaultY)
        {
            _targetPos = new Vector2(_selfPos.x - direction.normalized.x, _defaultY);
        }
        else
        {
            _targetPos = _selfPos - direction.normalized;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(_targetPos, 0.3f);
    }
}