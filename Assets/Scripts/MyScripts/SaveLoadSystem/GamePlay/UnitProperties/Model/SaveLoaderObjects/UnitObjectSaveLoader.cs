using System.Collections.Generic;
using UnityEngine;

public class UnitObjectSaveLoader : SaveLoader<List<UnitObjectData>, UnitPropertiesStorage>
{
    protected override void SetupData(UnitPropertiesStorage service, List<UnitObjectData> data)
    {
        service.SetObjectsUnitData(data);
        Debug.Log($"<color=green>��������� ������ � ������: {service.GetUnitObjectsData().Count}!</color>");
    }
    protected override List<UnitObjectData> ConvertToData(UnitPropertiesStorage service)
    {
        Debug.Log($"<color=green>��������� ������ � ������: {service.GetUnitObjectsData().Count}!</color>");
        return service.GetUnitObjectsData();
    }
   
}

   


