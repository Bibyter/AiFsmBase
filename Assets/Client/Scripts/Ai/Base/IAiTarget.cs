namespace Client.Ai
{
    public interface IAiTarget
    {
        bool isAlive { get; }
        UnityEngine.Transform transform { get; }
    }
}
