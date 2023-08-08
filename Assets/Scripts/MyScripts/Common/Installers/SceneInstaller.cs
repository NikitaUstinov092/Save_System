using UnityEngine;
using Zenject;

public class SceneInstaller : MonoInstaller<SceneInstaller>
{
   public override void InstallBindings()
    {
       Container.Bind<SaveLoadManager>().FromComponentInHierarchy().AsSingle();
       Container.BindInterfacesAndSelfTo<UnitContainer>().FromComponentInHierarchy().AsSingle();           
       Container.Bind(typeof(IFindTypeInUnit<>)).To(typeof(TypeFinder<>)).AsSingle();
       Container.Bind<GameRepository>().AsSingle();

       UnitSpawnSaveLoadSystem();
       UnitPropertiesSaveLoadSystem();
       PlayerResourseSaveLoadSystem();
       ObjectsResourcesSaveLoadSystem();
       UnitTransformSaveLoadSystem();
    }
    private void UnitSpawnSaveLoadSystem()
    {
        Container.Bind<UnitSpawDataConfig>().AsSingle();
        Container.BindInterfacesTo<UnitSpawnAdapter>().AsSingle();
        Container.Bind<UnitBaseDataStorage>().AsSingle();
        Container.Bind<UnitSpawner>().FromComponentInHierarchy().AsSingle();
    }
    private void UnitPropertiesSaveLoadSystem()
    {
        Container.Bind<UnitPropertiesConfig>().AsSingle();
        Container.Bind<UnitPropertiesStorage>().AsSingle();
        Container.BindInterfacesTo<UnitPropertiesAdapter>().AsSingle();     
    }  
    private void PlayerResourseSaveLoadSystem()
    {
        Container.Bind<PlayerResources>().FromComponentInHierarchy().AsSingle();
    }
    private void ObjectsResourcesSaveLoadSystem()
    {     
        Container.Bind<ObjectResourcesDataConfig>().AsSingle();
        Container.Bind<ObjectResourcesStorage>().AsSingle();
        Container.BindInterfacesTo<ObjectResourseAdapter>().AsSingle();
    }
    private void UnitTransformSaveLoadSystem()
    {
        Container.Bind<TransformStorage>().AsSingle();
        Container.Bind<TransformDataConfig>().AsSingle();
        Container.BindInterfacesTo<UnitTransformAdapter>().AsSingle();       
    }
}