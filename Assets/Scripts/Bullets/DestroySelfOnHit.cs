using UnityEngine;

/// <summary>
/// 当たり判定次第で
/// ダメージ処理を呼ぶ、自身を破棄する
/// </summary>
public class DestroySelfOnHit : MonoBehaviour, IDestroy, IHit
{
    public void Hit(GameObject go)
    {
        Destroy();
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}