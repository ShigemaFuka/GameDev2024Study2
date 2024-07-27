using UnityEngine;

/// <summary>
/// プレイヤーの弾にのみアタッチ
/// Hitで自滅をするタイプに使う
/// </summary>
public class CallHitStopOnHit : MonoBehaviour, IHit
{
    [SerializeField] private bool _isLaser = default;
    private CallHitStop _callHitStop = default;
    // private bool _canCall = default;

    private void Start()
    {
        _callHitStop = FindObjectOfType<CallHitStop>();
    }

    public void Hit(GameObject go)
    {
        if (_callHitStop) _callHitStop.Call(_isLaser);
    }
}