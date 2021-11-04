using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraneScript : MonoBehaviour
{
	public float frequency;
	public float phase;
	public float altitude;
	
	float xval;
	
    // Start is called before the first frame update
    void Start()
    {
        frequency = 5.00f;
		phase = 0.00f;
		altitude = 3.00f;
    }

    // Update is called once per frame
    void Update()
    {
		phase += frequency * Time.deltaTime;
        xval = altitude * Mathf.Sin(phase);
		this.GetComponent<Transform>().position = new Vector3(xval, 5.00f, 0.00f);
    }
}
