using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPaddleAI : MonoBehaviour
{
    public Transform ball;
    public float speed = 10.0f;
    public float boundaryZ = 9f;

    void Update()
    {
        Vector3 targetPosition = new Vector3(transform.position.x, transform.position.y, ball.position.z);

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        transform.position = new Vector3(transform.position.x,transform.position.y, Mathf.Clamp(transform.position.z, -boundaryZ, boundaryZ)
        );
    }
}
