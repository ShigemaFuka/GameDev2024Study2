using UnityEngine;

public class HP : MonoBehaviour, ICanDamage
{
    [SerializeField] private int _maxHp = default;
    [SerializeField] private int _currentHp = default;
    [SerializeField, Tooltip("HP0で消えるか")] private bool _isDestroy = default;
    private IInvincible _invincible = default;

    private void Start()
    {
        _currentHp = _maxHp;
        _invincible = GetComponent<IInvincible>();
    }

    private void Update()
    {
        if (!_isDestroy) return;
        if (_currentHp <= 0) Destroy(gameObject);
    }

    public void AddDamage(int damage)
    {
        if (_invincible is { IsInvincible: true }) return; // 無敵なら減算しないでリターン
        _currentHp -= damage;
    }
}