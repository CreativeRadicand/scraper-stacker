using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPosition : MonoBehaviour
{
	//This script deals with the position of the camera. Generally speaking, we'll want to record the actual stable position of the camera.
	//The focus here is the shaking part, but we want to make sure that each shake will always be centered towards 0 relatively speaking.
	
    // Start is called before the first frame update
	
	public Vector3 base_pos;
	public Vector3 offset_vec;
	public float shake_angle;
	public float shake_magnitude;
	public float shake_reduction;
	
	public float base_shake_magnitude;
	
    void Start()
    {
        
		base_pos = this.GetComponent<Transform>().position;
		
		offset_vec = new Vector3 (0.0f, 0.0f, 0.0f);
		
		shake_angle = 0.0f;
		
		base_shake_magnitude = 0.75f;
		
		shake_magnitude = base_shake_magnitude;
		
		shake_reduction = 0.01f;
    }

    // Update is called once per frame
    void Update()
    {
        //We change the shake magnitude by 1, or set it to 0.
		shake_magnitude = Mathf.Max(shake_magnitude - shake_reduction, 0.0f);
		
		//We then make the offset for the shaking effect:
		shake_angle = Random.Range(-Mathf.PI, Mathf.PI);
		offset_vec = new Vector3(Mathf.Cos(shake_angle), Mathf.Sin(shake_angle), 0.0f);
		
		//We then set the position we want for the camera:
		this.GetComponent<Transform>().position = base_pos + shake_magnitude * offset_vec;
    }
}
