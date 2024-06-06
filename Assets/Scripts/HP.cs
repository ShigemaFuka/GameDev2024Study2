using UnityEngine;

public class HP : MonoBehaviour, ICanDamage
{
    [SerializeField] private int _maxHp = default;
    [SerializeField] private int _currentHp = default;
    [SerializeField, Tooltip("HP0で消えるか")]
    private bool _isDestroy = default;
    
    private void Start()
    {
        _currentHp = _maxHp;
    }

    private void Update()
    {
        if(!_isDestroy) return;
        if(_currentHp <= 0) Destroy(gameObject);
    }

    public void AddDamage(int damage)
    {
        _currentHp -= damage;
    }
}
