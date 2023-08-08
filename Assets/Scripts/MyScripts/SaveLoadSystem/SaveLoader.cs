using UnityEngine;
using Zenject;


    public abstract class SaveLoader<TData, TService> : ISaveLoader
    {
        void ISaveLoader.LoadGame(IGameRepository repository, DiContainer container)
        {         
            var service = container.Resolve<TService>();

            if (repository.TryGetData(out TData data))              
                SetupData(service, data);        
            else          
                SetupByDefault(service);          
        }

        void ISaveLoader.SaveGame(IGameRepository repository, DiContainer container)
        {
            var service = container.Resolve<TService>();

            var data = ConvertToData(service);
            repository.SetData(data);           
        }

        protected abstract void SetupData(TService service, TData data);

        protected abstract TData ConvertToData(TService service);

        protected virtual void SetupByDefault(TService service)
        {
        }

    }
