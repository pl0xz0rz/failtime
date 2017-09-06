using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleableBlock : MonoBehaviour {

    public bool IsOpen;

    float DefaultState = 1;

    float Value;

    public GameObject Source;

	// Use this for initialization
	void Start () {
        if (IsOpen)
        {
            DefaultState = -1;
            Open();
        }
	}
	
	// Update is called once per frame
	void Update () {
		if(Source != null)
        {
            if(Source.GetComponent<ToggleableBlockLever>() != null)
            {
                Value = Source.GetComponent<ToggleableBlockLever>().Value;
                if (Source.GetComponent<ToggleableBlockLever>().Value * DefaultState >= .5)
                {
                    Open();
                } else if(Source.GetComponent<ToggleableBlockLever>().Value * DefaultState <= -.5)
                {
                    Close();
                }
            }
        }
	}

    public void Toggle()
    {
        if (!IsOpen)
        {
            Open();
        } else
        {
            IsOpen = false;
            Close();
        }
    }

    public void Use(float value)
    {
        Value = value;
        Debug.Log(value);
        if (!IsOpen && Value * DefaultState > .5)
        {
            Open();
        }
        else if(IsOpen && Value * DefaultState < -.5)
        {
            IsOpen = false;
            Close();
        }
    }

    public void Open()
    {
        IsOpen = true;
        if (GetComponent<SpriteRenderer>() != null) GetComponent<SpriteRenderer>().enabled = false;
        Collider2D[] t = GetComponentsInChildren<Collider2D>();
        if (t != null)
        {
            foreach (Collider2D i in t)
            {
                i.enabled = false;
            }
        }
    }

    public void Close()
    {
        IsOpen = false;
        if (GetComponent<SpriteRenderer>() != null) GetComponent<SpriteRenderer>().enabled = true;
        Collider2D[] t = GetComponentsInChildren<Collider2D>();
        if (t != null)
        {
            foreach (Collider2D i in t)
            {
                i.enabled = true;
            }
        }
    }
}
