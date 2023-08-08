public interface IGameListener
{

}
public interface IStartListner : IGameListener
{
    void StartGame();
}
public interface IInitListner : IGameListener
{
    void OnInit();
}
public interface IDisableListner : IGameListener
{
    void Disable();
}
public interface IUpdateListner : IGameListener
{
    void Update();
}


