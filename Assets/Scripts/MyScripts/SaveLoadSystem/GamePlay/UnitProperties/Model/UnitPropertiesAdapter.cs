using Zenject;
public class UnitPropertiesAdapter : IStartListner, IDisableListner
{
    private UnitPropertiesConfig _config;
    private SaveLoadManager _saveLoadManager;
    private UnitPropertiesStorage _storage;

    [Inject]
    private void Contruct(UnitPropertiesConfig config, SaveLoadManager saveLoadManager, 
        UnitPropertiesStorage storage)
    {
        _config = config;
        _saveLoadManager = saveLoadManager;
        _storage = storage;
    }
    void IStartListner.StartGame()
    {
        _saveLoadManager.OnStartSaving += _config.SendUnitPropertiesDataToStorage;
        _saveLoadManager.OnLoaded += _storage.ClearList;
        _storage.OnUnitObjectDataLoaded += _config.InitializeData;
    }
    void IDisableListner.Disable()
    {
        _saveLoadManager.OnStartSaving -= _config.SendUnitPropertiesDataToStorage;
        _saveLoadManager.OnLoaded -= _storage.ClearList;
        _storage.OnUnitObjectDataLoaded -= _config.InitializeData;
    }
}
