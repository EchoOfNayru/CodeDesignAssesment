using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeCheats : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    void TimeIncrease()
    {
        Time.timeScale += 100;
    }
    void TimeSoFastItsActuallyStopped()
    {
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update () {
		if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            TimeIncrease();
            Debug.Log("good programmer :)");
        }
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            TimeSoFastItsActuallyStopped();
            Debug.Log("dope programmer :)");
        }
    }
}
