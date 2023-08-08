using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
public class UnitSpawDataConfig
{
    public event Action <int, int> OnUnitFoundInSaveList;
    public event Action<GameObject> OnUnitFoundExtra;
    public event Action OnUnitInitializeDataFinished;

    private IFindTypeInUnit<UnitId> _unitIdData;
    private IFindTypeInUnit<UnitType> _unitTypeData;

    private UnitBaseDataStorage _unitStorage;
      
    [Inject]
    public void Construct(UnitBaseDataStorage unitStorage, IFindTypeInUnit<UnitId> unitIdData, IFindTypeInUnit<UnitType> unitTypeData)
    {
        _unitIdData = unitIdData;
        _unitTypeData = unitTypeData;
        _unitStorage = unitStorage;
    }

    public void InitializeData(List<UnitBaseData> SavedUnits)
    {
        FindSavedUnits(SavedUnits);
        FindExtraUnits(SavedUnits);
        OnUnitInitializeDataFinished?.Invoke();
    }

    private void FindSavedUnits(List<UnitBaseData> SavedUnits)
    {
        var unitsId = _unitIdData.GetTypeData();

        foreach (UnitBaseData savedUnit in SavedUnits)
        {
            bool unitExists = false;

            foreach (UnitId unitObject in unitsId)
            {
                if (unitObject.Id == savedUnit.UnitId)
                {
                    unitExists = true;
                    break;
                }
            }
            if (!unitExists)
                OnUnitFoundInSaveList?.Invoke(savedUnit.PrefabNumber, savedUnit.UnitId);
        }
    }


    private void FindExtraUnits(List<UnitBaseData> SavedUnits)
    {
        var unitsId = _unitIdData.GetTypeData();

        foreach (UnitId unitObject in unitsId)
        {
            bool unitExistsInSaveList = false;

            foreach (UnitBaseData savedUnit in SavedUnits)
            {
                if (unitObject.Id == savedUnit.UnitId)
                {
                    unitExistsInSaveList = true;
                    break;
                }
            }
            if (!unitExistsInSaveList)
                OnUnitFoundExtra?.Invoke(unitObject.gameObject);
        }
    }
    public void SendUnitsToStorage()
    {
        var unitsId = _unitIdData.GetTypeData();
        var unitsType = _unitTypeData.GetTypeData();

        for (var i = 0; i < unitsId.Length; i++)
        {
            var createdData = new UnitBaseData();

            createdData.UnitId = unitsId[i].Id;
            createdData.PrefabNumber = unitsType[i].GetUnitType;
            _unitStorage.AddUnit(createdData);
        }
    }

}
