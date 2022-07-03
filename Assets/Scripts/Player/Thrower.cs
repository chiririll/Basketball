using System.Threading.Tasks;
using UnityEngine;

public class Thrower : MonoBehaviour
{
    // Settings
    public Vector3 offset;
    public GameObject ballPrefab;

    public float forceSpeed = 1f;
    public float forceBackSpeed = 1.2f;
    public float maxForce = 20f;
    public float minForce = 1f;

    // Variables
    GameObject ball;
    Rigidbody ballRb;
    float force;

    void Start()
    {
        force = minForce;
    }

    void CreateBall()
    {
        ball = Instantiate(ballPrefab);
        ball.transform.position = transform.position + transform.forward + offset;
        ballRb = ball.GetComponent<Rigidbody>();
    }
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            IncreaseForce();

        if (Input.GetMouseButtonUp(0))
        {
            CreateBall();
            ballRb.useGravity = true;
            ballRb.AddForce(transform.forward * force, ForceMode.Impulse);
            force = minForce;
        }
    }

    async void IncreaseForce()
    {
        float delta = maxForce * 0.9f * Time.deltaTime;

        while (!Input.GetMouseButtonUp(0))
        { 
            
            if (force > maxForce && delta > 0)
                delta = -delta * forceBackSpeed;
            
            if (force >= minForce)
                force += delta;
            
            await Task.Yield();
        }
    }
}
