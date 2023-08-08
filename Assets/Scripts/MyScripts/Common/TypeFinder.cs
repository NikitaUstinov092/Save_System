using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class TypeFinder<Type> : IFindTypeInUnit<Type>
{
    [Inject]
    private UnitContainer _unitContainer;
    public Type[] GetTypeData()
    {
        List<Type> searchCompList = new List<Type>();

        foreach (GameObject obj in _unitContainer.GetAllUnitsObjects)
        {
            if (obj.TryGetComponent(out Type unitObject))
                searchCompList.Add(unitObject);
        }
        return searchCompList.ToArray();
    }

    public Type GetTypeById(int id)
    {
        foreach (var obj in _unitContainer.GetAllUnitsObjects)
        {
            if (obj.TryGetComponent(out Type unitObject) && obj.GetComponent<UnitId>().Id == id)
            {
                return unitObject;
            }
        }
        Debug.LogError("Компонент с таким ID не найден");
        return default(Type);
    }

    public int GetidByType(Type unitObject)
    {
        foreach (GameObject obj in _unitContainer.GetAllUnitsObjects)
        {
            if (obj.TryGetComponent(out Type unitData))
            {
                if (unitData.GetHashCode() == unitObject.GetHashCode())
                {
                    return obj.GetComponent<UnitId>().Id;
                }
            }
        }
        return -1;
    }
}
