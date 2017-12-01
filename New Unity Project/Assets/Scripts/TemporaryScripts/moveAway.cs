using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveAway : MonoBehaviour {

    public Transform flagPole;

    public float moveSpeed = 10;

    public float range;

    private Rigidbody2D myRigidBody;

    private bool move;

    public float distanceToTarget;


    //private float minDist = 0;

    // Use this for initialization
    void Start()
    {
        myRigidBody = new Rigidbody2D();
    }

    // Update is called once per frame
    void Update()
    {
        //myRigidBody.constraints = RigidbodyConstraints2D.FreezeRotation;
        distanceToTarget = Vector3.Distance(transform.position, flagPole.position);

        if (Input.GetKey("space"))
        {
            move = true;
        }

        if (move == true)
        {
            Vector3 targetDir = flagPole.position - transform.position;
            float angle = Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg - 90f;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.back);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, q, 180);

            transform.Translate(Vector3.up * Time.deltaTime * moveSpeed);
        }
        
    }
}
