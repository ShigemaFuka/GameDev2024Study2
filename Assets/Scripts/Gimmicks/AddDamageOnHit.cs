using UnityEngine;

/// <summary>
/// すてみタックル君
/// </summary>
public class AddDamageOnHit : MonoBehaviour, IHit
{
    [Header("ダメージ量"), SerializeField] private int _damageValue = 1;
    [Header("すてみタックルか"), SerializeField] private bool _toDead = default;
    
    public void Hit(GameObject go)
    {
        var iCanDamage = go.GetComponent<ICanDamage>();
        iCanDamage?.AddDamage(_damageValue);
        if(_toDead) Destroy(this);
    }
}
