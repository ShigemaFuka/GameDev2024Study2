using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// N秒おきに敵の出現チェック
/// 敵がいない：生成、 敵がいる：何もしない
/// </summary>
public class Spawn : MonoBehaviour
{
    [Header("スポーン位置の親オブジェクト"), SerializeField]
    private GameObject _spawnPointParent = default;
    [Header("チェック時間のインターバル"), SerializeField]
    private float _interval = default;
    [Header("生成するオブジェクト"), SerializeField] private GameObject _prefab = default;
    [Tooltip("key: スポーン場所, value: エネミー")] private Dictionary<GameObject, GameObject> _dictionary = new();
    private GameObject[] _spawnPoints = default;
    private float _timer = default;
    private bool _isCount = default;

    private void Start()
    {
        _spawnPoints = new GameObject[_spawnPointParent.transform.childCount];
        // スポーン位置取得と初期生成
        for (var i = 0; i < _spawnPointParent.transform.childCount; i++)
        {
            _spawnPoints[i] = _spawnPointParent.transform.GetChild(i).gameObject;
            var go = Instantiate(_prefab, _spawnPoints[i].transform.position, Quaternion.identity);
            _dictionary.Add(_spawnPoints[i], go);
        }
    }

    private void Update()
    {
        if (_isCount) _timer += Time.deltaTime;
        if (_timer >= _interval)
        {
            foreach (var value in _dictionary.Values.ToArray())
            {
                if (value == null) // エネミーがnullなら
                {
                    var pair = _dictionary.FirstOrDefault(c => c.Value == value); // ペアを取得
                    var pos = pair.Key.transform.position; // nullの箇所の情報
                    var go = Instantiate(_prefab, pos, Quaternion.identity);
                    _dictionary[pair.Key] = go; // Valueにgoを格納
                }
            }

            _timer = 0;
            _isCount = false;
        }
    }

    /// <summary> オブジェクトが破棄されたときに呼び出す </summary>
    public void ChangeIsCount()
    {
        _isCount = true;
    }
}