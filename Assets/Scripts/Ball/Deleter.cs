using UnityEngine;

public class Deleter : MonoBehaviour
{
    public float deletePosition = 1f;

    // Variables
    bool deleting = false;

    void Start()
    {
        
    }

    void Update()
    {
        if (transform.position.y < deletePosition)
            deleting = true;

        if (deleting)
            Delete();
    }
    void Delete()
    {
        Destroy(gameObject);
    }
}
