using UnityEngine;

/// <summary>
/// 弾の生成と、向きを指定する
/// </summary>
public class InstantiateBullet : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab = default;
    [SerializeField, Tooltip("※相対的")] private float _rotateZ = default;

    /// <summary> 生成する弾の回転 </summary>
    public float RotateZ { get => _rotateZ; set => _rotateZ = value; }

    protected virtual void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
            Generate();
        OnUpdate();
    }
    
    protected virtual void OnUpdate(){}

    protected void Generate()
    {
        Quaternion relativeRotation = transform.rotation * Quaternion.Euler(0, 0, _rotateZ);
        Instantiate(_bulletPrefab, transform.position, relativeRotation);
    }
} 