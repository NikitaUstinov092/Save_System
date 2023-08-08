using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;


    public sealed class PlayerResources : MonoBehaviour
    {
        [ShowInInspector, ReadOnly]
        private Dictionary<ResourceType, int> resources = new();

        [Button]
        public void SetResource(ResourceType resourceType, int resource)
        {
            this.resources[resourceType] = resource;
        }
        
        public int GetResource(ResourceType resourceType)
        {
            return this.resources[resourceType];
        }

        public void LoadResources(Dictionary<ResourceType, int> resources)
        {
           this.resources = resources;
        }

        public Dictionary<ResourceType, int> GetAllResources()
        {
           return resources;
        }
}
