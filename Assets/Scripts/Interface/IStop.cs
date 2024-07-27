/// <summary>
/// 停止
/// </summary>
public interface IStop
{
    /// <summary> 停止 </summary>
    public void Stop();

    public float StopTime { get; set; }
}