using UnityEngine;
using Zenject;

public class UnitTransformAdapter : IStartListner, IDisableListner
{

    private SaveLoadManager _saveLoadManager;
    private TransformStorage _transformStorage;
    private TransformDataConfig _transformDataSender;

    [Inject]
    public void Construct(SaveLoadManager saveLoadManager,  TransformStorage transformStorage,  TransformDataConfig transformDataSender)
    {
        _saveLoadManager = saveLoadManager;
        _transformStorage = transformStorage;
        _transformDataSender = transformDataSender;
    }
    void IStartListner.StartGame()
    {
        _saveLoadManager.OnStartSaving += _transformDataSender.SendDataToStorage;
        _saveLoadManager.OnLoaded += _transformStorage.ClearList;
        _transformStorage.OntransformLoaded += _transformDataSender.InitializeData;
    }

    void IDisableListner.Disable()
    {
        _saveLoadManager.OnStartSaving -= _transformDataSender.SendDataToStorage;
        _saveLoadManager.OnLoaded -= _transformStorage.ClearList;
        _transformStorage.OntransformLoaded -= _transformDataSender.InitializeData;
    }
}
