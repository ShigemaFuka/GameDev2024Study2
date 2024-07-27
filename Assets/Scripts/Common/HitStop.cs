using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// 描画用のレンダラーと、これ自身以外のコンポーネントを偽にして、
/// 停止しているように見せる
/// </summary>
public class HitStop : MonoBehaviour, IStop
{
    private List<MonoBehaviour> _filteredComponents = default;

    public float StopTime { get; set; }

    private void Start()
    {
        // 除外して取得
        _filteredComponents = new List<MonoBehaviour>();
        _filteredComponents = GetComponents<MonoBehaviour>()
            .Where(component => component.GetType() != typeof(Renderer) && component != this)
            .ToList();
    }

    public void Stop()
    {
        foreach (var component in _filteredComponents)
        {
            if(component) component.enabled = false;
        }

        Debug.Log("stop");
        StartCoroutine(LateCallPlay());
    }


    private void Play()
    {
        foreach (var component in _filteredComponents)
        {
            component.enabled = true;
        }
        Debug.Log("play");
    }

    private IEnumerator LateCallPlay()
    {
        yield return new WaitForSeconds(StopTime);
        Play();
    }
}