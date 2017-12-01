using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DistanceText : MonoBehaviour {

    public Text distanceText;
    public GameObject textObject;
    private float count;
    public Transform flagPole;
    public GameObject arrow;
    public GameObject text;

    private bool show;

    // Use this for initialization
    void Start ()
    {
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKey("space"))
        {
            show = true;
            text.SetActive(true);
            arrow.SetActive(true);
        }

        count = Vector3.Distance(transform.position, flagPole.position);

        SetCountTest();
    }

    void SetCountTest()
    {
        if (show == true)
        {
            distanceText.text = Mathf.RoundToInt(count).ToString() + " m";
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ArrowInvisi")
        {
            arrow.SetActive(false);
            text.SetActive(false);

            show = false;
        }
    }
}
