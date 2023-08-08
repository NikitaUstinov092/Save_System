using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

public enum StateGame
{
    OFF = 0,
    PLAYING = 1,
}

public class GameStateMachine : MonoBehaviour
{
    [ShowInInspector, ReadOnly]
    public StateGame State
    {
      get { return state; }
    }

    private StateGame state;

    [Inject]
    private readonly DiContainer _container;

    private void Start()
    {
        StartGame();
    }

    private void OnDisable()
    {
        Disable();
    }
 
    public void StartGame()
    {
        foreach (var listner in _container.Resolve<IEnumerable<IStartListner>>())
        {
            listner.StartGame();
        }
        state = StateGame.PLAYING;
    }

    public void Disable()
    {
        foreach (var listner in _container.Resolve<IEnumerable<IDisableListner>>())
        {
            listner.Disable();
        }
        state = StateGame.OFF;
    }

}