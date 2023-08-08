using System.Collections.Generic;
using UnityEngine;

public class UnitSaveLoader : SaveLoader<List<UnitBaseData>, UnitBaseDataStorage>
{
    /// <summary>
    /// Загрузка Unitov
    /// </summary>
    /// <param name="service"></param>
    /// <param name="data"></param>
    protected override void SetupData(UnitBaseDataStorage service, List<UnitBaseData> data)
    {
        service.SetUpUnits(data);
        Debug.Log($"<color=green>Загружено юнитов: {service.GetCurrentUnits().Count}!</color>");
    }

    /// <summary>
    /// Метод срабатывает при сохранении
    /// </summary>
    /// <param name="service"></param>
    /// <returns></returns>
    protected override List<UnitBaseData> ConvertToData(UnitBaseDataStorage service)
    {
        Debug.Log($"<color=green>Юнитов сохранено: {service.GetCurrentUnits().Count}!</color>");
        return service.GetCurrentUnits();        
    }

    
}
