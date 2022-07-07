using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class ScoreData : MonoBehaviour
{
    TextMeshProUGUI m_TextMesh;

    private void Awake()
    {
        GameManager.OnPlayerScore += UpdateText;
    }

    private void OnDestroy()
    {
        GameManager.OnPlayerScore -= UpdateText;
    }

    private void Start()
    {
        m_TextMesh = GetComponent<TextMeshProUGUI>();
    }

    void UpdateText(int score)
    {
        m_TextMesh.text = score.ToString();
    }
}
