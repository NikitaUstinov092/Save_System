using Zenject;
public class ObjectResourseAdapter : IStartListner, IDisableListner
{
    private ObjectResourcesDataConfig _objectResourseDataConfig;
    private SaveLoadManager _saveLoadManager;
    private ObjectResourcesStorage _objectResourceStorage;
  
    [Inject]
    public void Construct(ObjectResourcesDataConfig objectResourseDataConfig, SaveLoadManager saveLoadManager, ObjectResourcesStorage objectResourceStorage)
    {
        _objectResourseDataConfig = objectResourseDataConfig;
        _saveLoadManager = saveLoadManager;
        _objectResourceStorage = objectResourceStorage;
    }
    void IStartListner.StartGame()
    {
        _saveLoadManager.OnStartSaving += _objectResourseDataConfig.SendDataToStorage;
        _saveLoadManager.OnLoaded += _objectResourceStorage.ClearList;
        _objectResourceStorage.OnResorceObjectsLoaded += _objectResourseDataConfig.InitializeData;
    }

    void IDisableListner.Disable()
    {
        _saveLoadManager.OnStartSaving -= _objectResourseDataConfig.SendDataToStorage;
        _saveLoadManager.OnLoaded -= _objectResourceStorage.ClearList;
        _objectResourceStorage.OnResorceObjectsLoaded -= _objectResourseDataConfig.InitializeData;
    }
}
