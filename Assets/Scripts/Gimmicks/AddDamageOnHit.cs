using UnityEngine;

public class AddDamageOnHit : MonoBehaviour, IHit
{
    [Header("ダメージ量"), SerializeField] private int _damageValue = 1;
    [Header("すてみタックルか"), SerializeField] private bool _toDead = default;

    public void Hit(GameObject go)
    {
        var canDamage = go.GetComponent<ICanDamage>();
        canDamage?.AddDamage(_damageValue);
        if (_toDead) Destroy(this);
    }
}
