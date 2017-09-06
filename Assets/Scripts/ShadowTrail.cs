using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowTrail : MonoBehaviour {

    public List<float> x;
    public List<float> y;
    public List<int> actions;

    public int t;

	// Use this for initialization
	void Start () {
		
	}

    void FixedUpdate()
    {
        t++;
        x.Add(transform.position.x);
        y.Add(transform.position.y);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
