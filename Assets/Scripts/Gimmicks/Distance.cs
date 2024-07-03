using UnityEngine;


public class Distance : MonoBehaviour
{
    [Header("範囲"), SerializeField] private float _range = 2f;
    [Tooltip("対象")] private GameObject _target = default;
    private Vector3 _offset = default;
    private float _sqrLen = default;
    private IArea _area = default; // 1つしかないときだけ正しく機能する

    private void Start()
    {
        _target = GameObject.FindWithTag("Player");
        _area = GetComponent<IArea>();
    }

    private void Update()
    {
        _offset = _target.transform.position - transform.position;
        _sqrLen = _offset.sqrMagnitude;
        if (_sqrLen > _range * _range) return; // 範囲外なら以下の処理を行わない
        _area?.EnterArea();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, _range);
    }
}