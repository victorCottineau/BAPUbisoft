using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sand : MonoBehaviour {

    float Move = 0.7f;

	void Update () {
		if (Input.GetKey(KeyCode.RightArrow) && transform.position.x <= -1)
        {
            transform.Translate(Move, 0, 0);
        }
        if (Input.GetKey(KeyCode.LeftArrow) && transform.position.x >= -10.40)
        {
            transform.Translate(-Move, 0, 0);
        }
        if (Input.GetKey(KeyCode.UpArrow) && transform.position.z <= 46.45)
        {
            transform.Translate(0, 0, Move);
        }
        if (Input.GetKey(KeyCode.DownArrow) && transform.position.z >= 36.9)
        {
            transform.Translate(0, 0, -Move);
        }
	}
}
