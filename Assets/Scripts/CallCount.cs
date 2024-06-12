using UnityEngine;

/// <summary>
/// Destroyする側にアタッチする。
/// </summary>
public class CallCount : MonoBehaviour
{
    private Spawn _spawn = default;
    
    private void Start()
    {
        _spawn = FindObjectOfType<Spawn>();
    }

    private void OnDestroy()
    {
        _spawn.ChangeIsCount();
    }
}