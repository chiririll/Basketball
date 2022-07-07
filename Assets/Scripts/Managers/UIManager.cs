using UnityEngine;

public class UIManager : MonoBehaviour
{
    // UI prefabs
    public GameObject MainMenuUI;
    public GameObject GameUI;

    GameObject currentUI;

    private void Awake()
    {
        GameManager.OnGameStateChanged += StateChanged;
    }

    private void OnDestroy()
    {
        GameManager.OnGameStateChanged -= StateChanged;
    }

    void StateChanged(GameState state)
    {
        switch (state)
        {
            case GameState.MainMenu:
                ShowUI(MainMenuUI);
                break;
            case GameState.Options:
                break;
            case GameState.InGame:
                ShowUI(GameUI);
                break;
            case GameState.EndGame:
                break;
        }
    }

    void ShowUI(GameObject ui)
    {
        if (currentUI != null)
        {
            // TODO: disappear animation
            Destroy(currentUI);
        }

        currentUI = Instantiate(ui);
    }
}
