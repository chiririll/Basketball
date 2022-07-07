using UnityEngine;

public class CamRotation : MonoBehaviour
{
    // Settings 
    public float mouseSens = 1000f;
    public bool inverse = false;

    public float minAngle = -90f;
    public float maxAngle = 90f;

    // Variables
    float xRotation = 0f;

    void Start()
    {
        xRotation = transform.rotation.x;
    }

    void Update()
    {
        float MouseX = Input.GetAxis("Mouse X") * mouseSens * Time.deltaTime;
        float MouseY = Input.GetAxis("Mouse Y") * mouseSens * Time.deltaTime;

        xRotation += MouseY * (inverse ? 1 : -1);
        xRotation = Mathf.Clamp(xRotation, minAngle, maxAngle);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.parent.Rotate(Vector3.up * MouseX);
    }
}
