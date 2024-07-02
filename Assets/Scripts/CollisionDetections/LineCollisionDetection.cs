using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// 線の当たり判定
/// バウンディングボックスと交差しているか
/// </summary>
public class LineCollisionDetection : MonoBehaviour
{
    [SerializeField] private string _targetTagName = default;
    private List<Transform> _boxTransform = default; // AABBの中心を表すTransform
    private List<Vector2> _boxSize = default; // AABBのサイズ（幅、高さ、奥行き）
    private List<Bounds> _boxBounds = default;
    private List<GameObject> _targets = default;
    private Vector2 _rayDirection = default;
    private Vector2 _startPoint = default;
    private bool _isInitialized = default; // 初期化済みか
    private IHit[] _hits = default;

    private void OnEnable()
    {
        if (!_isInitialized) return;
        GetTargetInfo();
    }

    private void Start()
    {
        _targets = new List<GameObject>();
        _boxTransform = new List<Transform>();
        _boxSize = new List<Vector2>();
        _boxBounds = new List<Bounds>();
        _targets = GameObject.FindGameObjectsWithTag(_targetTagName).ToList();
        GetTargetInfo();
        _isInitialized = true;
        _hits = GetComponents<IHit>();
    }

    private void Update()
    {
        _rayDirection = transform.right;

        var halfLength = transform.localScale.x / 2;
        // 方向を正規化
        var normalizedDirection = _rayDirection.normalized;
        var pos = (Vector2)transform.position;
        // 線の始点
        _startPoint = pos - normalizedDirection * halfLength;
        // 線の終点 ※ レーザーがかなり長いから一旦終点無視でも問題なさそう。
        // var endPoint = pos + normalizedDirection * halfLength;

        // AABBの中心とサイズからバウンディングボックスを作成
        if (_targets != null)
        {
            for (var i = 0; i < _targets.Count; i++)
            {
                if(_boxTransform[i] != null) 
                    _boxBounds.Add(new Bounds(_boxTransform[i].position, _boxSize[i]));
            }
        }

        for (var i = 0; i < _targets.Count; i++)
        {
            if (!_boxBounds[i].IntersectRay(new Ray(_startPoint, normalizedDirection))) continue;
            foreach (var hit in _hits)
            {
                if(_targets[i]) hit.Hit(_targets[i]);
            }
        }
    }

    private void GetTargetInfo()
    {
        _targets.Clear();
        _targets = GameObject.FindGameObjectsWithTag(_targetTagName).ToList();
        _boxTransform.Clear();
        _boxSize.Clear();
        _boxBounds.Clear();
        foreach (var target in _targets)
        {
            _boxTransform.Add(target.transform);
            var renderer = target.GetComponent<Renderer>();
            if (renderer != null)
            {
                _boxSize.Add(renderer.bounds.size);
            }
        }
    }
}