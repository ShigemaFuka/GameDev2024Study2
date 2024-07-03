using UnityEngine;

/// <summary>
/// レーザーの表示・非表示を制御する。
/// </summary>
public class LaserBullet : MonoBehaviour
{
    [Header("表示時間"), SerializeField] private float _appear = 0.2f;
    [SerializeField] private InstantiateBullet _instantiateBullet = default;
    [SerializeField] private GameObject _laser = default;
    private float _pressTimer = default;
    private float _showTimer = default;

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
            _laser.SetActive(true);
        }

        if (_laser.activeSelf) _showTimer += Time.deltaTime;

        if (_showTimer >= _appear) // 表示時間を超えたら
        {
            _laser.SetActive(false);
            _showTimer = 0f;
            _instantiateBullet.enabled = true;
        }
    }
}