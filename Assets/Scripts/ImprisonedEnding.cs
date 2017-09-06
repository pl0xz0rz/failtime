using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImprisonedEnding : MonoBehaviour {

    public ToggleableBlock door;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerStay2D(Collider2D col)
    {
        if (!door.IsOpen)
        {
            if(col.tag == "Player")
            {
                Debug.Log("YOU WIN");
            }
        }
    }
}
