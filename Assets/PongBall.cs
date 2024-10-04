using System.Collections;
using UnityEngine;

public class PongBall : MonoBehaviour
{
    Vector3 originalPosition;
    public float speed;
    private Rigidbody rb;
    public GameObject Ball;
    private Vector3 direction;

    void Start()
    {
        this.direction = new Vector3(1f, 0f, 1f);
        rb = GetComponent<Rigidbody>();
    }
    private void Awake()
    {
        originalPosition = Ball.transform.position;
    }
    private void Update()
    {
        this.transform.position += direction * speed * Time.deltaTime * 15;
    }
    void LaunchBall()
    {

        Vector3 angle = new Vector3(Random.Range(0f, 360f), 0f, Random.Range(0f, 360f)).normalized;

        rb.velocity = angle * speed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Vector3 normal = collision.contacts[0].normal;
        direction = Vector3.Reflect(direction, normal);

    }

    private void OnTriggerEnter(Collider other)
    {
        Ball.transform.position = originalPosition;
        LaunchBall();
    }

}
