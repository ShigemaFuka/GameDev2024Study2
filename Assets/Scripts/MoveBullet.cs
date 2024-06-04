using UnityEngine;
/// <summary>
/// localPosition.y方向へ移動する
/// </summary>
public class MoveBullet : MonoBehaviour
{
    [SerializeField] private float _speed = default;

    void Start()
    {
        
    }

    void Update()
    {
        transform.position += transform.TransformDirection(Vector3.up) * (Time.deltaTime * _speed);
    }
}
