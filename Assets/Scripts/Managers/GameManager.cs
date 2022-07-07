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
    // Events
    public static event Action<GameState> OnGameStateChanged;
    public static event Action<int> OnPlayerScore;

    // Singleton instance
    public static GameManager Instance;

    // Current state
    private GameState _state;

    // Data
    public static PlayerData playerData;

    private void Awake()
    { 
        Instance = this;
    }

    private void Start()
    {
        PushState(GameState.MainMenu);
    }

    GameState CurrentState()
    {
        return _state;
    }

    public void PushState(GameState new_state)
    {
        // Executing logic
        switch (new_state)
        {
            case GameState.MainMenu:
                SwitchToMainMenu();
                break;
            case GameState.Options:
                
                break;
            case GameState.InGame:
                SwitchToGame();
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

    void SwitchToMainMenu()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    void SwitchToGame()
    {
        playerData = new PlayerData();

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void Score()
    {
        OnPlayerScore.Invoke(++playerData.Score);
    }
}