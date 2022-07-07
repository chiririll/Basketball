using UnityEngine;

public class PlayerData
{
    private float m_force = 0f;
    public float Force
    {
        get { return m_force; }
        set { m_force = Mathf.Clamp(value, 0f, 1f); }
    }

    public float Cooldown = 0f;

    public int Score = 0;
}
