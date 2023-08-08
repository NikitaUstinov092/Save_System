using System.Collections.Generic;
using Zenject;

public class ObjectResourcesDataConfig 
{
    private IFindTypeInUnit<UnitId> _unitIdData;
    private IFindTypeInUnit<ResourceObject> _unitResourceData;
    private ObjectResourcesStorage _resourcesStorage;

    [Inject]
    private void Construct(IFindTypeInUnit<UnitId> unitIdData, IFindTypeInUnit<ResourceObject> unitResourceData, ObjectResourcesStorage resourcesStorage)
    {
        _unitIdData = unitIdData;
        _unitResourceData = unitResourceData;
        _resourcesStorage = resourcesStorage;
    }

    public void InitializeData(List<ResourceObjectData> SavedResources)
    {
        var unitsId = _unitIdData.GetTypeData();

        Dictionary<int, ResourceObjectData> resourceDictionary = new Dictionary<int, ResourceObjectData>();

        foreach (ResourceObjectData resourse in SavedResources)
            resourceDictionary[resourse.ID] = resourse;

        for (var i = 0; i < unitsId.Length; i++)
        {
            var id = unitsId[i].Id;

            if (resourceDictionary.ContainsKey(id))
            {
                var unitResourceComp = _unitResourceData.GetTypeById(id);
                unitResourceComp.resourceType = resourceDictionary[id].ResourceType;
                unitResourceComp.remainingCount = resourceDictionary[id].RemainingCount;
            }             
        }
    }

    public void SendDataToStorage()
    {
        var resourceObjects = _unitResourceData.GetTypeData();

        for (var i = 0; i < resourceObjects.Length; i++)
        {
            var currentUnitid = _unitResourceData.GetidByType(resourceObjects[i]);
            if (currentUnitid == -1)
                continue;
            
            var currentUnitData = resourceObjects[i];
            var resourseData = new ResourceObjectData();

            resourseData.ResourceType = currentUnitData.resourceType;
            resourseData.RemainingCount = currentUnitData.remainingCount;
            resourseData.ID = currentUnitid;

            _resourcesStorage.AddObjectResourse(resourseData);           
        }

    }
}
