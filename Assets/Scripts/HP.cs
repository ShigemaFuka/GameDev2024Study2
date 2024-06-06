using UnityEngine;

public class HP : MonoBehaviour, ICanDamage
{
    [SerializeField] private int _maxHp = default;
    [SerializeField] private int _currentHp = default;
    
    private void Start()
    {
        _currentHp = _maxHp;
    }

    private void Update()
    {
        
    }

    public void AddDamage(int damage)
    {
        _currentHp -= damage;
    }
}
