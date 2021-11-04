using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputScript : MonoBehaviour
{
	public string keyboard_input;
	
	public enum input_state {
		key_down,
		key_up
	};
	
	public input_state key_input;
	public GameObject main_camera;
	public CameraPosition camera_position_script;
	
	public float timeleft;
	
    // Start is called before the first frame update
    void Start()
    {
		keyboard_input = "space";
        key_input = input_state.key_up;
		
		main_camera = GameObject.Find("Main Camera");
		camera_position_script = main_camera.GetComponent<CameraPosition>();
		Debug.Log(camera_position_script);
		
		timeleft = 30.0f;
    }

    // Update is called once per frame
    void Update()
    {
		//This is ticking down the time left.
		timeleft = Mathf.Max(timeleft - Time.deltaTime, 0);
		Debug.Log(timeleft);
		
        if (key_input == input_state.key_up)
		{
			if (Input.GetKeyDown(keyboard_input))
			{
				key_input = input_state.key_down;
				
				camera_position_script.shake_magnitude = camera_position_script.base_shake_magnitude;
			}
		}
		else if (key_input == input_state.key_down)
		{
			if (Input.GetKeyUp(keyboard_input))
			{
				key_input = input_state.key_up;
			}
		}
    }
}
