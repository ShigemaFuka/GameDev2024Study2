using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// 矩形同士
/// 当たり判定と、対象へのダメージ処理
/// </summary>
public class CollisionDetection : MonoBehaviour
{
    #region 変数

    private Vector2 _originPoint = default;
    private float _width = default;
    private float _height = default;

    private List<GameObject> _target = default;
    private Vector2[] _targetOriginPoint = default;
    private float[] _targetWidth = default;
    private float[] _targetHeight = default;
    private IHit[] _hits = default;
    [SerializeField] private string _targetTagName = default;

    #endregion

    private void Start()
    {
        _target = GameObject.FindGameObjectsWithTag(_targetTagName).ToList();
        _targetOriginPoint = new Vector2[_target.Count];
        _targetWidth = new float[_target.Count];
        _targetHeight = new float[_target.Count];
        _hits = GetComponents<IHit>();

        _width = transform.localScale.x;
        _height = transform.localScale.y;
        for (var i = 0; i < _target.Count; i++)
        {
            _targetWidth[i] = _target[i].transform.localScale.x;
            _targetHeight[i] = _target[i].transform.localScale.y;
        }
    }

    public void UpdateList()
    {
        if (_target.Contains(null))
        {
            _target.Clear();
            _target = GameObject.FindGameObjectsWithTag(_targetTagName).ToList();
        }
    }

    private void Update()
    {
        _originPoint = transform.position;
        for (var i = 0; i < _target.Count; i++)
        {
            if (_target[i] == null) continue; // nullなら以下を飛ばす
            _targetOriginPoint[i] = _target[i].transform.position;
            if (!Check(i)) continue; // 接触していないなら以下を飛ばす
            _target[i].GetComponent<IKnockBack>()?.KnockBackMovement(gameObject);
            
            foreach (var hit in _hits)
            {
                if (_target[i] == null) continue;
                hit.Hit(_target[i]);
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