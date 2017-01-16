using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sand : MonoBehaviour {

    float Move = 0.7f;

	void Update () {
		if (Input.GetKey(KeyCode.RightArrow) && transform.position.x <= -6.3) 
        {
            transform.Translate(Move, 0, 0);
        }
        if (Input.GetKey(KeyCode.LeftArrow) && transform.position.x >= -15.87)
        {
            transform.Translate(-Move, 0, 0);
        }
        if (Input.GetKey(KeyCode.UpArrow) && transform.position.z <= 28.181)
        {
            transform.Translate(0, 0, Move);
        }
        if (Input.GetKey(KeyCode.DownArrow) && transform.position.z >= 18.474)
        {
            transform.Translate(0, 0, -Move);
        }
	}
}
