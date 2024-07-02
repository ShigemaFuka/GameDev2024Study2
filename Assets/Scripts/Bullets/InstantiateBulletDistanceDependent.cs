using UnityEngine;

/// <summary>
/// 生成の可否を距離で判断する
/// </summary>
public class InstantiateBulletDistanceDependent : InstantiateBullet
{
    [SerializeField, Tooltip("生成間隔")] private float _interval = 1f;
    [SerializeField, Tooltip("射程距離")] private float _range = default;
    [Tooltip("対象")] private GameObject _target = default;
    private Vector3 _offset = default;
    private float _sqrLen = default;
    private float _timer = default;

    private void Start()
    {
        _target = GameObject.FindWithTag("Player");
    }

    protected override void Update()
    {
        _offset = _target.transform.position - transform.position;
        _sqrLen = _offset.sqrMagnitude;
        if (_sqrLen > _range * _range) return; // 射程範囲外なら以下の処理を行わない
        _timer += Time.deltaTime;
        if (_timer >= _interval)
        {
            Generate();
            _timer = 0f;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, _range);
    }
}