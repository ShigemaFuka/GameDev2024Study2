using UnityEngine;

/// <summary>
/// プレイヤーに持続ダメージを与える
/// </summary>
public class Poison : Repeat, IArea
{
    [Header("ダメージ量"), SerializeField] private int _damageValue = 1;
    private GameObject _target = default;
    private ICanDamage _canDamage = default;
    
    protected override void OnStart()
    {
        _target = GameObject.FindWithTag("Player");
        _canDamage = _target.GetComponent<ICanDamage>();
    }

    public void EnterArea()
    {
        if (!_canExecution) return;
        _canDamage?.AddDamage(_damageValue);
        _canExecution = false;
        StartCoroutine(RepeatCall());
    }
}
