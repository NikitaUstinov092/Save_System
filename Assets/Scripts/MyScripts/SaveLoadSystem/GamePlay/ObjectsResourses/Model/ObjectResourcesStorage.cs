using System;
using System.Collections.Generic;
public class ObjectResourcesStorage 
{
    public event Action<List<ResourceObjectData>> OnResorceObjectsLoaded;
    public List<ResourceObjectData> GetCurrentObjectsResources() => _currentObjectResources;

    private List<ResourceObjectData> _currentObjectResources = new();
    public void SetUpObjectResourses(List<ResourceObjectData> resource)
    {
        _currentObjectResources = resource;
        OnResorceObjectsLoaded?.Invoke(_currentObjectResources);
    }
    public void AddObjectResourse(ResourceObjectData resource)
    {
        if (!_currentObjectResources.Contains(resource))
            _currentObjectResources.Add(resource);
    }

    public void ClearList()
    {
        _currentObjectResources.Clear();
    }
}
