using UnityEngine;

    public sealed class ResourceObject : MonoBehaviour
    {
        [SerializeField]
        public ResourceType resourceType;
        
        [SerializeField]
        public int remainingCount;
    }