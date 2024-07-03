using UnityEngine;

/// <summary>
/// すてみタックル君
/// </summary>
public class AddDamageOnHit : MonoBehaviour, IHit
{
    [Header("ダメージ量"), SerializeField] private int _damageValue = 1;
    [Header("すてみタックルか"), SerializeField] private bool _toDead = default;
    private bool _processed = false; // 既に一度処理済みか
    
    public void Hit(GameObject go)
    {
        if(_processed) return;
        var canDamage = go.GetComponent<ICanDamage>();
        canDamage?.AddDamage(_damageValue);
        if(_toDead) Destroy(this);
        _processed = true;
    }
}
