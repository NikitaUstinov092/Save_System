using System.Collections.Generic;
using UnityEngine;

public class TransformSaveLoader : SaveLoader<List<UnitTransform>, TransformStorage>
{
    protected override void SetupData(TransformStorage service, List<UnitTransform> data)
    {
        service.SetUpUnits(data);
        Debug.Log($"<color=green>������� ���������: {service.GetCurrentListTransform().Count}!</color>");
    }

    protected override List<UnitTransform> ConvertToData(TransformStorage service)
    {
        Debug.Log($"<color=green>������� ���������: {service.GetCurrentListTransform().Count}!</color>");
        return service.GetCurrentListTransform();
    }
}
