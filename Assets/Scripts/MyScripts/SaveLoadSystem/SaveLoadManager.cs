using Sirenix.OdinInspector;
using System;
using UnityEngine;
using Zenject;

    public sealed class SaveLoadManager : MonoBehaviour
    {
        public event Action OnStartSaving;
        public event Action OnLoaded;

        private ISaveLoader[] _saveLoaders;
        private GameRepository _repository;
        private DiContainer _diContainer;

        [Inject]
        public void Construct(DiContainer diContainer)
        {
            _diContainer = diContainer;
            _saveLoaders = diContainer.ResolveAll<ISaveLoader>().ToArray();
            _repository = diContainer.Resolve<GameRepository>();
        }
 
        [Button]
        public void Load() 
        {
            _repository.LoadState();
            
            foreach (var saveLoader in _saveLoaders)
            {
                saveLoader.LoadGame(_repository, _diContainer);
            }
            OnLoaded?.Invoke();
        }

        [Button]
        public void Save()
        {
            OnStartSaving?.Invoke();
            Debug.Log("Количество сохраннённых данных " +_saveLoaders.Length);
            foreach (var saveLoader in _saveLoaders)
            {
                saveLoader.SaveGame(_repository, _diContainer);
            }           
            _repository.SaveState();
        }
    }
