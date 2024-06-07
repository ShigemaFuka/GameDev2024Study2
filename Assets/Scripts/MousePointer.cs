using UnityEngine;

public class MousePointer : MonoBehaviour
{
    [SerializeField] private Camera _camera = default;
    [SerializeField] private GameObject _ui = default;
    private Vector3 _screenPoint = default;
    private Vector3 _worldPoint = default;

    /// <summary> マウスポインタの位置 </summary>
    public Vector3 WorldPoint => _worldPoint;
    
    private void Start()
    {
    }

    private void Update()
    {
        _screenPoint = Input.mousePosition;
        _screenPoint.z = 1f;
        _worldPoint = _camera.ScreenToWorldPoint(_screenPoint);
        _ui.transform.position = _worldPoint;
    }
}
