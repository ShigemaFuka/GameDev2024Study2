using UnityEngine;

/// <summary>
/// 一定距離以下に対象が近づいたときに追尾をする。
/// </summary>
public class Follow : MonoBehaviour, IArea
{
    [SerializeField] private float _speed = 5f;
    private GameObject _target = default;

    private void Start()
    {
        _target = GameObject.FindWithTag("Player");
    }

    public void EnterArea()
    {
        transform.position =
            Vector2.MoveTowards(transform.position, _target.transform.position, Time.deltaTime * _speed);
    }
}