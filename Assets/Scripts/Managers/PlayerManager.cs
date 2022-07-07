using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    // MainMenu
    public Vector3 MenuPosition;
    public Vector3 MenuRotation;

    // Objects
    public GameObject thrower;
    public GameObject cam;

    private void Awake()
    {
        // Subscribing to events
        GameManager.OnGameStateChanged += StateChanged;
    }

    private void OnDestroy()
    {
        // Unsubscribing
        GameManager.OnGameStateChanged -= StateChanged;
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void StateChanged(GameState state)
    {
        switch (state)
        {
            case GameState.MainMenu:
                ToMainMenu();
                break;
            case GameState.InGame:
                ToGame();
                break;
        }
        
    }

    void ToMainMenu()
    {
        transform.position = MenuPosition;
        SetRotation(MenuRotation);

        cam.GetComponent<CamRotation>().enabled = false;
        thrower.GetComponent<Thrower>().enabled = false;
    }

    void ToGame()
    {
        cam.GetComponent<CamRotation>().enabled = true;
        thrower.GetComponent<Thrower>().enabled = true;
    }

    // Utils
    void SetRotation(Vector3 rotation)
    {
        transform.rotation = Quaternion.Euler(new Vector3(0f, rotation.y, 0f));
        cam.transform.localRotation = Quaternion.Euler(new Vector3(rotation.x, 0f, rotation.z));
    }
}
