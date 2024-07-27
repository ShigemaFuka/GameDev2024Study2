using UnityEngine;

public class CallCameraShakeOnHit : MonoBehaviour, IHit
{
    private CameraShake _cameraShake = default;

    private void Start()
    {
        _cameraShake = FindObjectOfType<CameraShake>();
    }

    public void Hit(GameObject go)
    {
        if(_cameraShake) _cameraShake.Shake();
        Debug.Log($"{go} call shake");
    }
}