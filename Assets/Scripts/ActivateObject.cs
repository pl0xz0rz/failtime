using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class ActivateObject : MonoBehaviour {
    
    GameObject m_target;
    Transform m_usecheck;
    bool m_busy;

    public float Radius;

	// Use this for initialization
	void Start () {
        m_usecheck = transform.Find("UseCheck");
	}
	
	// Update is called once per frame
	void Update () {
		if(m_target == null)
        {
            if (!m_busy)
            {
                m_busy = CrossPlatformInputManager.GetButtonDown("Action");
                if (m_busy)
                {
                    Debug.Log("Trying to use");
                    Collider2D t = Physics2D.OverlapCircle(m_usecheck.position, Radius, 1 << 9);
                    if (t != null)
                    {
                        if (t.GetComponent<ToggleableBlockLever>() != null)
                        {
                            Debug.Log("Pulling lever");
                            t.GetComponent<ToggleableBlockLever>().Use();
                        }
                        if (t.GetComponent<ActivateGhost>() != null && GetComponent<ShadowTrail>() != null)
                        {
                            Debug.Log("Good luck");
                            GameObject f = Instantiate(GetComponent<ShadowEnemySpawner>().prefab);
                            f.GetComponent<ShadowEnemy>().f = GetComponent<ShadowTrail>();
                        }
                        if (GetComponent<ShadowTrail>() != null)
                        {
                            GetComponent<ShadowTrail>().actions.Add(GetComponent<ShadowTrail>().t);
                        }
                    };
                }
            } else
            {
                m_busy = false;
            }
        }
	}

}
