using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryScript : MonoBehaviour
{

    public Vector2 minimumBoundary;
    public Vector2 maximumBoundary;

    // Use this for initialization
    void Start()
    {

    }

    private void Update()
    {
        transform.position = new Vector3
        (
            Mathf.Clamp(transform.position.x, minimumBoundary.x, maximumBoundary.x),
            Mathf.Clamp(transform.position.y, minimumBoundary.y, maximumBoundary.y),
            transform.position.z
        );
    }
}
