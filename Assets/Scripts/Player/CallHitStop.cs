using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// HitStopに取得されない空オブジェクトにアタッチすること
/// </summary>
public class CallHitStop : MonoBehaviour
{
    [SerializeField] private float _stopTimeOfNormalBullet = default;
    [SerializeField] private float _stopTimeOfLaserBullet = default;
    private float _stopTime = default;
    private List<MonoBehaviour> _monos = default;
    private List<IStop> _stops = default;

    private void Start()
    {
        _monos = new List<MonoBehaviour>();
        _stops = new List<IStop>();
        _monos = FindObjectsOfType<MonoBehaviour>().ToList();
    }

    private void GetMono()
    {
        _monos.Clear();
        _monos = FindObjectsOfType<MonoBehaviour>().ToList();
        // todo:「FindObjectsOfType」以外のいい方法ない、、？
    }

    /// <summary>
    /// 停止を呼び出す
    /// </summary>
    public void Call(bool isLaser)
    {
        // todo:Callが何度も呼ばれるため、長時間停止している可能性がある
        _stopTime = isLaser ? _stopTimeOfLaserBullet : _stopTimeOfNormalBullet;

        GetMono();
        _stops.Clear();
        _stops = _monos.OfType<IStop>().ToList();
        foreach (var stop in _stops)
        {
            if (stop == null) return;
            stop.StopTime = _stopTime;
            stop.Stop();
        }

        Debug.Log("call");
    }
}