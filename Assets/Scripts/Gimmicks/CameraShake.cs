using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] private float _shakeDuration = 0.5f;
    [SerializeField] private float _shakeAmount = 0.7f;
    [SerializeField] private float _decreaseFactor = 1.0f;
    private Transform _cameraTransform = default;
    private Vector3 _originalPos = default;
    private float _currentShakeDuration = default;

    private void Start()
    {
        _cameraTransform = Camera.main.transform;
        _originalPos = _cameraTransform.localPosition;
    }

    private void Update()
    {
        Debug.Log("update");
        if (_currentShakeDuration > 0)
        {
            _cameraTransform.localPosition = _originalPos + Random.insideUnitSphere * _shakeAmount;

            _currentShakeDuration -= Time.deltaTime * _decreaseFactor;
        }
        else
        {
            _currentShakeDuration = 0f;
            _cameraTransform.localPosition = _originalPos;
        }
    }

    public void Shake()
    {
        _currentShakeDuration = _shakeDuration;
    }
}