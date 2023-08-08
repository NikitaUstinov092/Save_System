using System.Collections.Generic;
using UnityEngine;

public class UnitSaveLoader : SaveLoader<List<UnitBaseData>, UnitBaseDataStorage>
{
    /// <summary>
    /// �������� Unitov
    /// </summary>
    /// <param name="service"></param>
    /// <param name="data"></param>
    protected override void SetupData(UnitBaseDataStorage service, List<UnitBaseData> data)
    {
        service.SetUpUnits(data);
        Debug.Log($"<color=green>��������� ������: {service.GetCurrentUnits().Count}!</color>");
    }

    /// <summary>
    /// ����� ����������� ��� ����������
    /// </summary>
    /// <param name="service"></param>
    /// <returns></returns>
    protected override List<UnitBaseData> ConvertToData(UnitBaseDataStorage service)
    {
        Debug.Log($"<color=green>������ ���������: {service.GetCurrentUnits().Count}!</color>");
        return service.GetCurrentUnits();        
    }

    
}
