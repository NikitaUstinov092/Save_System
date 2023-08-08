using System;
using System.Collections.Generic;
public class UnitBaseDataStorage
{
    public event Action<List<UnitBaseData>> OnUnitsLoaded;
    public List<UnitBaseData> GetCurrentUnits() => _currentUnits;

    private List <UnitBaseData> _currentUnits = new();   
    public void SetUpUnits(List<UnitBaseData> units)
    {
        _currentUnits = units;
        OnUnitsLoaded?.Invoke(_currentUnits);
    }
    public void AddUnit(UnitBaseData UnitData)        
    {
        if(!_currentUnits.Contains(UnitData))
         _currentUnits.Add(UnitData);
    }  
    public void ClearList()
    {
        _currentUnits.Clear();
    }
}