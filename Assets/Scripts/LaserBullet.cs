using UnityEngine;

/// <summary>
/// レーザーの表示・非表示を制御する。
/// </summary>
public class LaserBullet : MonoBehaviour
{
    [Header("表示時間"), SerializeField] private float _appear = 0.2f;
    [Header("ダメージ量"), SerializeField] private int _damage = 3;
    [Header("レーザー"), SerializeField] private GameObject _laserPrefab = default;
    [SerializeField] private InstantiateBullet _instantiateBullet = default;
    private float _pressTimer = default;
    private float _showTimer = default;
    private GameObject _laser = default;

    private void Update()
    {
        if (Input.GetKey(KeyCode.G))
        {
            _pressTimer += Time.deltaTime;
        }
        else _pressTimer = 0;

        if (_pressTimer >= 1f) // 一定時間押しきったら
        {
            _instantiateBullet.enabled = false; // 通常弾を生成させない
            _pressTimer = 0f;
            _laser = Instantiate(_laserPrefab, transform);
        }

        if (_laserPrefab.activeSelf) _showTimer += Time.deltaTime;

        if (_showTimer >= _appear) // 表示時間を超えたら
        {
            Destroy(_laser);
            _showTimer = 0f;
            _instantiateBullet.enabled = true;
        }
    }
}
