using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform target;
    public float speed;
    public float proportionalFollowDistance = 5.0f;

    Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - target.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 distance = (target.position + offset) - transform.position;
        Vector3 displacement = distance.normalized * speed * Time.deltaTime * distance.magnitude / proportionalFollowDistance; ;

        if (displacement.magnitude > distance.magnitude)
            displacement = distance;

        transform.position = transform.position + displacement;
    }
}
