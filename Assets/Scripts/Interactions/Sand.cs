using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sand : MonoBehaviour {

    float Move = 0.3f;

	void Update () {
		if (Input.GetKey(KeyCode.RightArrow) && transform.position.x <= -17.918) 
        {
            transform.Translate(Move, 0, 0);
        }
        if (Input.GetKey(KeyCode.LeftArrow) && transform.position.x >= -26.75)
        {
            transform.Translate(-Move, 0, 0);
        }
        if (Input.GetKey(KeyCode.UpArrow) && transform.position.z <= 27.66)
        {
            transform.Translate(0, 0, Move);
        }
        if (Input.GetKey(KeyCode.DownArrow) && transform.position.z >= 18.956)
        {
            transform.Translate(0, 0, -Move);
        }
	}
}
