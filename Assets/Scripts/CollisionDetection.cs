using UnityEngine;

/// <summary>
/// 弾側の当たり判定と、プレイヤーへのダメージ処理
/// </summary>
public class CollisionDetection : MonoBehaviour
{
    #region 変数

    private SpriteRenderer _spriteRenderer =default;
    private Vector2 _originPoint = default;
    private float _width = default;
    private float _height = default;
    
    private GameObject _target = default;
    private SpriteRenderer _targetSpriteRenderer = default;
    private Vector2 _targetOriginPoint = default;
    private float _targetWidth = default;
    private float _targetHeight = default;

    #endregion

    private void Start()
    {
        _target = GameObject.FindGameObjectWithTag("Player");
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _targetSpriteRenderer = _target.GetComponent<SpriteRenderer>();
        _width = _spriteRenderer.size.x;
        _height = _spriteRenderer.size.y;
        _targetWidth = _targetSpriteRenderer.size.x;
        _targetHeight = _targetSpriteRenderer.size.y;
    }

    private void Update()
    {
        _originPoint = transform.position;
        _targetOriginPoint = _target.transform.position;
        if (Check())
        {
            _target.GetComponent<ICanDamage>().AddDamage(1);
            Destroy(gameObject);
        }
    }

    private bool Check()
    {
        var xMinA = _originPoint.x - _width / 2;
        var xMinB = _targetOriginPoint.x - _targetWidth / 2;
        var xMaxA = _originPoint.x + _width / 2;
        var xMaxB = _targetOriginPoint.x + _targetWidth / 2;

        var yMinA = _originPoint.y - _height / 2;
        var yMinB = _targetOriginPoint.y - _targetHeight / 2;
        var yMaxA = _originPoint.y + _height / 2;
        var yMaxB = _targetOriginPoint.y + _targetHeight / 2;

        if (xMinB < xMaxA && xMinA < xMaxB 
                          && yMinB < yMaxA && yMinA < yMaxB)
        {
            return true;
        }

        return false;
    }
}