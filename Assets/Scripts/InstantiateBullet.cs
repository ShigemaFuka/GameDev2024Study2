using UnityEngine;

/// <summary>
/// 弾の生成と、向きを指定する
/// </summary>
public class InstantiateBullet : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab = default;
    [SerializeField] private float _rotateZ = default;

    void Start()
    {
    }

    protected virtual void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
            Generate();
        OnUpdate();
    }
    
    protected virtual void OnUpdate(){}

    protected void Generate()
    {
        Instantiate(_bulletPrefab, transform.position, Quaternion.Euler(0, 0, _rotateZ));
    }
}