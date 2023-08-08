using System.Collections.Generic;
using UnityEngine;

public class PlayerSaveLoader : SaveLoader<Dictionary<ResourceType, int>, PlayerResources>
{
    protected override void SetupData(PlayerResources service, Dictionary<ResourceType, int> data)
    {
        service.LoadResources(data);
        Debug.Log($"<color=green>Ресурсов игрока загружено: {service.GetAllResources().Count}!</color>");
    }

    protected override Dictionary<ResourceType, int> ConvertToData(PlayerResources service)
    {
        Debug.Log($"<color=green>Ресурсов игрока сохранено: {service.GetAllResources().Count}!</color>");
        return service.GetAllResources();
    } 
}
