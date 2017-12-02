using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SweetSpotScript : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnEnable()
    {
      transform.localPosition = new Vector3(Random.Range(-49f, 49f), 0, 0);
    }
}
