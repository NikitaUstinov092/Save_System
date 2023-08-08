using Zenject;

public class UnitSpawnAdapter : IStartListner, IDisableListner
{
    private UnitSpawDataConfig _unitSpawnConfig;
    private UnitSpawner _unitSpawner;
    private SaveLoadManager _saveLoadManager;
    private UnitBaseDataStorage _unitStorage;

    [Inject]
    public void Construct(UnitBaseDataStorage unitStorage, SaveLoadManager saveLoadManager, UnitSpawDataConfig unitSpawnConfig, UnitSpawner unitSpawner)
    {
        _unitStorage = unitStorage;
        _saveLoadManager = saveLoadManager;
        _unitSpawnConfig = unitSpawnConfig;
        _unitSpawner = unitSpawner;
    }
    void IStartListner.StartGame()
    {
        _saveLoadManager.OnStartSaving += _unitSpawnConfig.SendUnitsToStorage;
        _unitStorage.OnUnitsLoaded += _unitSpawnConfig.InitializeData;
        _saveLoadManager.OnLoaded += _unitStorage.ClearList;
        _unitSpawnConfig.OnUnitFoundInSaveList += (firstData, secondData) => _unitSpawner.CheckParentNull();
        _unitSpawnConfig.OnUnitFoundInSaveList += _unitSpawner.SpawnUnits;
        _unitSpawnConfig.OnUnitFoundExtra += _unitSpawner.RamoveUnit;
    }

    void IDisableListner.Disable()
    {
        _saveLoadManager.OnStartSaving -= _unitSpawnConfig.SendUnitsToStorage;
        _unitStorage.OnUnitsLoaded -= _unitSpawnConfig.InitializeData;
        _saveLoadManager.OnLoaded -= _unitStorage.ClearList;
        _unitSpawnConfig.OnUnitFoundInSaveList -= (firstData, secondData) => _unitSpawner.CheckParentNull();
        _unitSpawnConfig.OnUnitFoundInSaveList -= _unitSpawner.SpawnUnits;
        _unitSpawnConfig.OnUnitFoundExtra -= _unitSpawner.RamoveUnit;
    }
}
