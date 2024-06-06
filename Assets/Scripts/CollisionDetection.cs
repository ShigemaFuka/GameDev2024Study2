using UnityEngine;

/// <summary>
/// 矩形同士
/// 当たり判定と、プレイヤーへのダメージ処理
/// </summary>
public class CollisionDetection : MonoBehaviour
{
    #region 変数

   [SerializeField] private SpriteRenderer _spriteRenderer =default;
   [SerializeField] private Vector2 _originPoint = default;
   [SerializeField] private float _width = default;
   [SerializeField] private float _height = default;
    
   [SerializeField] private GameObject[] _target = default;
   [SerializeField] private SpriteRenderer[] _targetSpriteRenderer = default;
   [SerializeField] private Vector2[] _targetOriginPoint = default;
   [SerializeField] private float[] _targetWidth = default;
   [SerializeField] private float[] _targetHeight = default;
    [SerializeField] private string _targetTagName = default;

    #endregion

    private void Start()
    {
        _target = GameObject.FindGameObjectsWithTag(_targetTagName);
        _targetSpriteRenderer = new SpriteRenderer[_target.Length];
        _targetOriginPoint = new Vector2[_target.Length];
        _targetWidth = new float[_target.Length];
        _targetHeight = new float[_target.Length];
            
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _width = _spriteRenderer.size.x;
        _height = _spriteRenderer.size.y;
        for (var i = 0; i < _target.Length; i++)
        {
            _targetSpriteRenderer[i] = _target[i].GetComponent<SpriteRenderer>();
            _targetWidth[i] = _targetSpriteRenderer[i].size.x;
            _targetHeight[i] = _targetSpriteRenderer[i].size.y;
        }
    }

    private void Update()
    {
        _originPoint = transform.position;
        for (var i = 0; i < _target.Length; i++)
        {
            _targetOriginPoint[i] = _target[i].transform.position;
            if (Check(i))
            {
                _target[i].GetComponent<ICanDamage>().AddDamage(1);
                Destroy(gameObject);
            }
        }
    }

    private bool Check(int index)
    {
        var xMinA = _originPoint.x - _width / 2;
        var xMinB = _targetOriginPoint[index].x - _targetWidth[index] / 2;
        var xMaxA = _originPoint.x + _width / 2;
        var xMaxB = _targetOriginPoint[index].x + _targetWidth[index] / 2;

        var yMinA = _originPoint.y - _height / 2;
        var yMinB = _targetOriginPoint[index].y - _targetHeight[index] / 2;
        var yMaxA = _originPoint.y + _height / 2;
        var yMaxB = _targetOriginPoint[index].y + _targetHeight[index] / 2;

        if (xMinB < xMaxA && xMinA < xMaxB 
                          && yMinB < yMaxA && yMinA < yMaxB)
        {
            return true;
        }

        return false;
    }
}