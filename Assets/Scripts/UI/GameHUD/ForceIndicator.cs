using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class ForceIndicator : MonoBehaviour
{
    private Image _img;

    void Start()
    {
        _img = GetComponent<Image>();
    }

    void Update()
    {
        if (GameManager.playerData.Force != 0 && GameManager.playerData.Cooldown == 0)
            _img.fillAmount = GameManager.playerData.Force;
        else if (_img.fillAmount != 0 )
            _img.fillAmount = 0;
    }
}
