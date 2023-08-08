using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourseSaveLoader : SaveLoader<List<ResourceObjectData>, ObjectResourcesStorage>
{
    protected override void SetupData(ObjectResourcesStorage service, List<ResourceObjectData> data)
    {
        service.SetUpObjectResourses(data);
        Debug.Log($"<color=green>��������� �������� ��������: {service.GetCurrentObjectsResources().Count}!</color>");
    }

    protected override List<ResourceObjectData> ConvertToData(ObjectResourcesStorage service)
    {
        Debug.Log($"<color=green> C�������� �������� ��������: {service.GetCurrentObjectsResources().Count}!</color>");
        return service.GetCurrentObjectsResources();
    }    
}
