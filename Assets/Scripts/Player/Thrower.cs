using System.Threading.Tasks;
using UnityEngine;

public class Thrower : MonoBehaviour
{
    // Settings
    public GameObject cam;
    public GameObject ballPrefab;

    public Vector3 SpawnPosition;
    public float CoolDown = 1f;

    public float forceSpeed = 1f;
    public float forceBackSpeed = 1.2f;
    public float maxForce = 20f;
    public float minForce = 1f;

    // Created ball
    GameObject ball;
    Rigidbody ballRb;

    // Variables
    float force;
    float currentCD = 0f;

    void Start()
    {
        currentCD = CoolDown;

        ResetForce();
        CreateBall();
    }

    void Update()
    {
        UpdateCooldown();
        Animate();

        if (Input.GetMouseButtonDown(0) && currentCD == 0)
            IncreaseForce();

        if (Input.GetMouseButtonUp(0))
            Throw();
    }

    void UpdateCooldown()
    {
        if (currentCD == 0)
            return;

        if (currentCD > 0)
            currentCD -= Time.deltaTime;
        else
        {
            currentCD = 0;
            GameManager.playerData.Force = 0f;
        }

        GameManager.playerData.Cooldown = currentCD;
    }

    void Animate()
    {
        if (currentCD == 0f)
            return;

        ball.transform.localPosition = Vector3.Lerp(SpawnPosition, Vector3.zero, 1 - currentCD / CoolDown);
    }

    void CreateBall()
    {
        ball = Instantiate(ballPrefab);
        ballRb = ball.GetComponent<Rigidbody>();

        ball.transform.SetParent(transform);

        ball.transform.localPosition = SpawnPosition;
    }

    async void IncreaseForce()
    {
        force = minForce;
        float delta = maxForce * 0.9f * Time.deltaTime;
        bool reset = true;

        while (!Input.GetMouseButtonUp(0))
        {
            GameManager.playerData.Force = GetNormalizedForceValue();

            if (force > maxForce && delta > 0)
                delta = -delta * forceBackSpeed;

            if (force >= minForce)
                force += delta;
            else
            {
                force = minForce;
                reset = false;
                break;
            }

            await Task.Yield();
        }

        if (reset)
            ResetForce();
    }

    void ResetForce()
    {
        force = 0f;
        GameManager.playerData.Force = GetNormalizedForceValue();
    }

    void Throw()
    {
        // Checking cooldown and force
        if (currentCD > 0 || force == 0)
            return;

        // Throwing ball
        ball.transform.SetParent(null);
        ballRb.isKinematic = false;
        ball.GetComponent<SphereCollider>().enabled = true;
        ball.GetComponent<Deleter>().enabled = true;
        ballRb.AddForce(cam.transform.forward * force, ForceMode.Impulse);

        // Reseting force and creating ball
        force = minForce;
        currentCD = CoolDown;
        CreateBall();
    }

    public float GetNormalizedForceValue()
    {
        return force != 0f ? Mathf.InverseLerp(minForce, maxForce, force) : minForce;
    }
}
