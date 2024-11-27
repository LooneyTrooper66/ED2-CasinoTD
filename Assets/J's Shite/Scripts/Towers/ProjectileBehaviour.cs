using System;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class ProjectileBehaviour : MonoBehaviour
{
    private Vector3 startPos;


    private void Start()
    {
        startPos = transform.position;
    }

    private void Update()
    {
        float dist = Vector2.Distance(transform.position, startPos);

        if (dist <= 3)
        {
            transform.Translate(Vector3.up * 10 * Time.deltaTime);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
