using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolfSlider : MonoBehaviour
{
    RectTransform slider;
    public Transform sweetSpot;
    Vector3 newPos = new Vector3(50, 0, 0);
    private Vector3 buttonVelocity = Vector3.zero;
    public float movementSpeed = 75f;
    public float distFromSweetSpot;
    Vector3 heading;
    bool rightSide;

    void Start()
    {
        rightSide = false;
        slider = GetComponent<RectTransform>();
    }

    void Update()
    {
        if (rightSide == false)
        {
            StartCoroutine(MoveRight());

        }
        if (rightSide == true)
        {
            StartCoroutine(MoveLeft());
        }
        heading = slider.localPosition - sweetSpot.transform.localPosition;
        distFromSweetSpot = heading.magnitude;
    }
    IEnumerator MoveRight()
    {

        Vector3 newPos = new Vector3(49, 0, 0);
        slider.localPosition = Vector3.MoveTowards(slider.localPosition, newPos, Time.deltaTime * movementSpeed);

        if(slider.localPosition == new Vector3(49,0,0))
        {
            rightSide = true;
            yield return null;
        }
    }
    IEnumerator MoveLeft()
    {
        Vector3 newPos = new Vector3(-49, 0, 0);
        slider.localPosition = Vector3.MoveTowards(slider.localPosition, newPos, Time.deltaTime * movementSpeed);

        if (slider.localPosition == new Vector3(-49, 0, 0))
        {
            rightSide = false;
            yield return null;
        }
    }
    private void OnEnable()
    {
        transform.localPosition = new Vector3(-49, 0, 0);
    }

}
