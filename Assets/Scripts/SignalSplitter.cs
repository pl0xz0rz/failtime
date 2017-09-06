using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignalSplitter : MonoBehaviour {

    public GameObject MainSource;
    public GameObject Destination;
    public GameObject SecondDest;

    float Value;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void UpdateFlow(float newValue, int source = 0)
    {
        Value = newValue;
        if(source == 0)
        {
            if(Destination != null)
            {
                if(Destination.GetComponent<ToggleableBlock>() != null)
                {
                    Destination.GetComponent<ToggleableBlock>().Use(Value);
                }
                if (Destination.GetComponent<SignalSplitter>() != null)
                {
                    Destination.GetComponent<SignalSplitter>().UpdateFlow(Value);
                }

            }
            if(SecondDest != null)
            {
                if (SecondDest.GetComponent<SignalSplitter>() != null)
                {
                    SecondDest.GetComponent<SignalSplitter>().UpdateFlow(Value);
                }
                if (SecondDest.GetComponent<ToggleableBlock>() != null)
                {
                    SecondDest.GetComponent<ToggleableBlock>().Use(Value);
                }
            }
        }
    }
}
