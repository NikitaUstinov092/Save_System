using System.Collections.Generic;
using Zenject;

public class UnitPropertiesConfig 
{
    private IFindTypeInUnit<UnitObject> _unitObjectData;
    private IFindTypeInUnit<UnitId> _unitIdData;
    private UnitPropertiesStorage _unitStorage;

    [Inject]
    private void Construct(IFindTypeInUnit<UnitObject> unitObjectData, IFindTypeInUnit<UnitId> unitIdData, UnitPropertiesStorage unitObjectStorage)
    {
        _unitObjectData = unitObjectData;
        _unitIdData = unitIdData;
        _unitStorage = unitObjectStorage;
    }

    public void InitializeData(List<UnitObjectData> SavedData)
    {
        var unitsId = _unitIdData.GetTypeData();

        Dictionary<int, UnitObjectData> propertiesDictinary = new Dictionary<int, UnitObjectData>();

        foreach (UnitObjectData unitsavedData in SavedData)
            propertiesDictinary[unitsavedData.Id] = unitsavedData;

        for (var i = 0; i < unitsId.Length; i++)
        {
            var id = unitsId[i].Id;

            if (propertiesDictinary.ContainsKey(id))
            {
                var unitObjectData = _unitObjectData.GetTypeById(id);
                unitObjectData.hitPoints = propertiesDictinary[id].HitPoints;
                unitObjectData.speed = propertiesDictinary[id].Speed;             
                unitObjectData.damage = propertiesDictinary[id].Damage;
            }             
        }
    }
    public void SendUnitPropertiesDataToStorage()
    {
        var unitData = _unitObjectData.GetTypeData();

        for (var i = 0; i < unitData.Length; i++)
        {
            var currentUnitid = _unitObjectData.GetidByType(unitData[i]);
            if (currentUnitid == -1)
                continue;

            var currentUnitData = unitData[i];
            var unitSaveData = new UnitObjectData();
          
            unitSaveData.HitPoints = currentUnitData.hitPoints;
            unitSaveData.Damage = currentUnitData.damage;
            unitSaveData.Speed = currentUnitData.speed;
            unitSaveData.Id = currentUnitid;

            _unitStorage.AddUnitData(unitSaveData);
        }
        
    }
}
