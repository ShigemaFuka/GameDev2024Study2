using UnityEngine;

public class AddDamageOnHit : MonoBehaviour, IHit
{
    [Header("ダメージ量"), SerializeField] private int _damageValue = 1;
    
    public void Hit(GameObject go)
    {
        var iCanDamage = go.GetComponent<ICanDamage>();
        iCanDamage?.AddDamage(_damageValue);
    }
}
