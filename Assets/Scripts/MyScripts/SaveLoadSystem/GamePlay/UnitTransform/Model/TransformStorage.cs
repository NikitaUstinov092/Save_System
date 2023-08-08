using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;

public class TransformStorage 
{
    public event Action<List<UnitTransform>> OntransformLoaded;
    public List<UnitTransform> GetCurrentListTransform() => _currentListTransform;

    [ReadOnly]
    [ShowInInspector]
    private List<UnitTransform> _currentListTransform = new();

    [Button]
    public void SetUpUnits(List<UnitTransform> units)
    {    
        _currentListTransform = units;
        OntransformLoaded?.Invoke(_currentListTransform);
    }

    [Button]
    public void AddTransform(UnitTransform UnitData)
    {
        if (!_currentListTransform.Contains(UnitData))
        {
            _currentListTransform.Add(UnitData);
        }     
             
    }
    public void ClearList()
    {
        _currentListTransform.Clear();
    }
}
