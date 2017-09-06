using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleableBlockLever : MonoBehaviour {
    public float Value = -1;
    public float Direction = 0;
    public float MaxValue = 1;

    public GameObject Destination;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Use()
    {
        if (Value > 0) Value = -1; else Value = 1;
        if (Destination != null)
        {
            if(Destination.GetComponent<SignalSplitter>() != null)
            {
                Destination.GetComponent<SignalSplitter>().UpdateFlow(Value);
            }
        }
    }
}
