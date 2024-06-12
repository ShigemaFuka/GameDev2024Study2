using UnityEngine;

/// <summary>
/// プレイヤーとマウスポインタ位置の角度を割り出して、プレイヤーを回転
/// </summary>
public class Rotate : MonoBehaviour
{
    [SerializeField] private MousePointer _mousePointer = default;
    [SerializeField, Tooltip("回転対象")] private GameObject _target = default;
    private Vector3 _targetPoint = default;
    private float _radian = default;
    private Vector3 _direction = default;

    private void Update()
    {
        _targetPoint = _target.transform.position;
        _direction = _mousePointer.WorldPoint - _targetPoint;
        _radian = Mathf.Atan2(_direction.y, _direction.x);
        var q = Quaternion.AngleAxis(_radian * 180 / Mathf.PI, new Vector3(0, 0, 1));
        _target.transform.rotation = q;
    }
}