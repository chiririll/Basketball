using UnityEngine;

public class HitDetector : MonoBehaviour
{
    void OnTriggerEnter(Collider col)
    {
        if (!col.gameObject.CompareTag("Ball"))
            return;

        transform.parent.GetComponent<ParticleSystem>().Play();

        GameManager.Instance.Score();
    }
}
