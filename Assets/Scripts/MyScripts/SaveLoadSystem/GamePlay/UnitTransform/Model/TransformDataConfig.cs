using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class TransformDataConfig 
{
    private IFindTypeInUnit<Transform> _unitTransformData;
    private IFindTypeInUnit<UnitId> _unitIdData;

    private TransformStorage _transformStorage;
    private TransformConvector _transformConvector = new();

    [Inject]
    private void Construct(TransformStorage transformStorage, IFindTypeInUnit<Transform> unitTransformData, IFindTypeInUnit<UnitId> unitIdData)
    {
        _transformStorage = transformStorage;
        _unitTransformData = unitTransformData;
        _unitIdData = unitIdData;
    }

    public void InitializeData(List<UnitTransform> SavedTransforms)
    {
        var unitsId = _unitIdData.GetTypeData();

        Dictionary<int, UnitTransform> transformDictionary = new();

        foreach (UnitTransform unitTransform in SavedTransforms)
            transformDictionary[unitTransform.UserId] = unitTransform;

        for (var i = 0; i < unitsId.Length; i++)
        {
            var id = unitsId[i].Id;

            if (transformDictionary.ContainsKey(id))
            {
                var transformComp = _unitTransformData.GetTypeById(id);
                SetTransform(transformDictionary[id], transformComp);
            }
               
        }
    }
    private void SetTransform(UnitTransform savedTransform, Transform curentTransform)
    {
        _transformConvector.ConvertTransformFrom(savedTransform, curentTransform);
    }

    public void SendDataToStorage()
    {
        var unitTransform = _unitTransformData.GetTypeData();

        for (var i = 0; i < unitTransform.Length; i++)
        {
            var currentUnitid = _unitTransformData.GetidByType(unitTransform[i]);
            if (currentUnitid == -1)
                continue;

            var transform = _transformConvector.ConvertTransformTo(unitTransform[i].transform, currentUnitid);
            _transformStorage.AddTransform(transform);
        }

    }
}
