using UnityEditor;
using UnityEngine;
using Zenject;

public class BindInterfacesMonoAsCached : MonoInstaller<BindInterfacesMonoAsCached>
{
    [SerializeField] private MonoScript[] _monoScripts;
    public override void InstallBindings()
    {
        foreach (var mono in _monoScripts)
           Container.BindInterfacesTo(mono.GetClass()).AsCached();                    
    }
}
