using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class Deleter : MonoBehaviour
{
    public float deletePosition = 1f;

    // Variables
    bool _destroying = false;
    ParticleSystem _ps;

    void Start()
    {
        _ps = GetComponent<ParticleSystem>();
    }

    void Update()
    {
        if (transform.position.y < deletePosition && !_destroying)
            Destroy();

        if (_destroying && !_ps.isPlaying)
            Destroy(gameObject);
    }
    void Destroy()
    {
        _destroying = true;
        GetComponent<MeshRenderer>().enabled = false;
        gameObject.isStatic = true;

        _ps.Play();
    }
}
