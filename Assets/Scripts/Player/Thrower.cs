using UnityEngine;

public class Thrower : MonoBehaviour
{
    // Settings
    public Vector3 offset;
    public GameObject ballPrefab;

    // Variables
    GameObject ball;
    Rigidbody ballRb;
    float force = 10f;

    void Start()
    {
    }

    void CreateBall()
    {
        ball = Instantiate(ballPrefab);
        ball.transform.position = transform.position + transform.forward + offset;
        ballRb = ball.GetComponent<Rigidbody>();
    }
    
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            CreateBall();
            ballRb.useGravity = true;
            ballRb.AddForce(transform.forward * force, ForceMode.Impulse);
        }
    }
}
