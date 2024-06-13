using System;
using UnityEngine;

/// <summary>
/// 一定距離以下ならそのときのプレイヤーの方向取得、そこめがけて移動、触れたらダメージを与える
/// 画面外でDestroy
/// </summary>
public class Rush : MonoBehaviour, IDestroy
{
    [Header("範囲"), SerializeField] private float _range = 2f;
    [Tooltip("対象")] private GameObject _target = default;
    private Vector3 _offset = default;
    private float _sqrLen = default;
    private Vector3 _targetDirection = default;
    private bool _haveTargetDirection = default;
    
    private void Start()
    {
        _target = GameObject.FindWithTag("Player");
    }

    private void Update()
    {
        if (_haveTargetDirection) transform.position = Vector2.MoveTowards(transform.position, _targetDirection * 3f, Time.deltaTime * 10);
        
        _offset = _target.transform.position - transform.position;
        _sqrLen = _offset.sqrMagnitude;
        if (_sqrLen > _range * _range) return; // 範囲外なら以下の処理を行わない
        
        if (_haveTargetDirection) return; // 取得済みなら以下を行わない
        _targetDirection = _target.transform.position - transform.position;
        _haveTargetDirection = true;
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, _range);
    }

    private void OnBecameInvisible()
    {
        Destroy();
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
