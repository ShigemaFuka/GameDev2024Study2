using System.Collections;
using UnityEngine;

/// <summary>
/// 一定間隔で処理を呼び出す
/// 呼び出したい処理は継承先で定義する
/// </summary>
public class Repeat : MonoBehaviour
{
    [Header("実行間隔"), SerializeField] private float _interval = default;
    private WaitForSeconds _wfs = default;
    protected bool _canExecution = default; // 実行できるか

    private void Start()
    {
        _wfs = new WaitForSeconds(_interval);
        _canExecution = true;
        OnStart();
    }

    protected virtual void OnStart()
    {
    }

    protected IEnumerator RepeatCall()
    {
        yield return _wfs;
        _canExecution = true;
    }
}