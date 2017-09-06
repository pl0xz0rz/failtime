using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowEnemy : MonoBehaviour {

    public ShadowTrail f;
    int i = 0;
    int nextaction = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void FixedUpdate()
    {
        transform.SetPositionAndRotation(new Vector3(f.x[i], f.y[i], 0), Quaternion.identity);
        if(f.actions.Count > nextaction && f.actions[nextaction] == i)
        {
            nextaction++;
            Collider2D t = Physics2D.OverlapCircle(transform.position, .5f, 1 << 9);
            if (t != null)
            {
                if (t.GetComponent<ToggleableBlockLever>() != null)
                {
                    Debug.Log("Pulling lever");
                    t.GetComponent<ToggleableBlockLever>().Use();
                }
            };
        }
        i++;
    }


}
