/// <summary>
/// 無敵
/// </summary>
public interface IInvincible
{
    public bool IsInvincible { get; set; }

    public void ToInvincible()
    {
    }

    /// <summary>
    /// 元に戻す
    /// </summary>
    public void ToDefault()
    {
    }
}