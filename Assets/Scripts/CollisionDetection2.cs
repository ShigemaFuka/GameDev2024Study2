using UnityEngine;

/// <summary>
/// 矩形と点
/// 当たり判定と敵へのダメージ処理
/// </summary>
public class CollisionDetection2 : MonoBehaviour
{ 
    [SerializeField] private SpriteRenderer _spriteRenderer =default;
    [SerializeField] private Vector2 _originPoint = default;
    [SerializeField] private float _width = default;
    [SerializeField] private float _height = default;
    
    [SerializeField] private GameObject[] _target = default;
    [SerializeField] private Vector2[] _targetOriginPoint = default;
    [SerializeField] private string _targetTagName = default;
    
    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _width = _spriteRenderer.size.x;
        _height = _spriteRenderer.size.y;
        _target = GameObject.FindGameObjectsWithTag(_targetTagName);
        _targetOriginPoint = new Vector2[_target.Length];
    }

    void Update()
    {
        _originPoint = transform.position;
        for (var i = 0; i < _target.Length; i++)
        {
            if (_target[i] == null) continue; // nullなら以下を飛ばす
            _targetOriginPoint[i] = _target[i].transform.position;
            if (Check(i))
            {
                _target[i].GetComponent<ICanDamage>().AddDamage(1);
                Destroy(gameObject);
            }
        }
    }

    bool Check(int index)
    {
        var xMinA = _originPoint.x - _width / 2;
        var xMaxA = _originPoint.x + _width / 2;
        var yMinA = _originPoint.y - _height / 2;
        var yMaxA = _originPoint.y + _height / 2;
        if (xMinA <= _targetOriginPoint[index].x && xMaxA >= _targetOriginPoint[index].x
            && yMinA <= _targetOriginPoint[index].y && yMaxA >= _targetOriginPoint[index].y)
        {
            return true;
        }

        return false;
    }
}
