using UnityEngine;

public class PlayButton : MonoBehaviour
{
    public void OnItemClick()
    {
        GameManager.Instance.PushState(GameState.InGame);
    }
}
