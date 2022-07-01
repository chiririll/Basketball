using System;
using UnityEngine;


public enum GameState
{
    MainMenu,
    Options,
    InGame,
    EndGame
}


public class GameManager : MonoBehaviour
{
    // Singleton instance
    public static GameManager Instance;
    public static event Action<GameState> OnGameStateChanged;

    // Current state
    private GameState _state;
    

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        _state = GameState.MainMenu;
    }

    GameState CurrentState()
    {
        return _state;
    }

    void PushState(GameState new_state)
    {
        // Executing logic
        switch (new_state)
        {
            case GameState.MainMenu:

                break;
            case GameState.Options:

                break;
            case GameState.InGame:

                break;
            case GameState.EndGame:

                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(new_state), new_state, null);
        }

        // Changing state
        _state = new_state;

        // Creating event
        OnGameStateChanged.Invoke(new_state);
    }
}