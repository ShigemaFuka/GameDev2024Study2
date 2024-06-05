using UnityEngine;

/// <summary>
/// 左右移動のみ
/// </summary>
public class Move : MonoBehaviour
{
    [SerializeField] private float _speed = default;
    
    void Start()
    {
    }

    void Update()
    {
        var h = Input.GetAxis("Horizontal");
        if (h != 0)
            LRMove(h);
    }

    void LRMove(float value)
    {
        transform.position += new Vector3(value, 0, 0) * (Time.deltaTime * _speed);
    }
}