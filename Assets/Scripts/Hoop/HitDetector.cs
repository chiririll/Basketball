using UnityEngine;

public class HitDetector : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col)
    {
        if (!col.gameObject.CompareTag("Ball"))
            return;

        transform.parent.GetComponent<ParticleSystem>().Play();
    }
}
