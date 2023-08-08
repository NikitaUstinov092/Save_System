using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
public class UnitPropertiesStorage 
{
    public event Action<List<UnitObjectData>> OnUnitObjectDataLoaded;
    public List<UnitObjectData> GetUnitObjectsData() => _currentListUnitObjectData;

    [ReadOnly]
    [ShowInInspector]
    private List<UnitObjectData> _currentListUnitObjectData = new();
    public void AddUnitData(UnitObjectData unitObjectData)
    {
        if (!_currentListUnitObjectData.Contains(unitObjectData))
            _currentListUnitObjectData.Add(unitObjectData);
    }
    public void SetObjectsUnitData(List<UnitObjectData> data)
    {
        _currentListUnitObjectData = data;
        OnUnitObjectDataLoaded?.Invoke(_currentListUnitObjectData);
    }
    public void ClearList()
    {
        _currentListUnitObjectData.Clear();
    }
}
