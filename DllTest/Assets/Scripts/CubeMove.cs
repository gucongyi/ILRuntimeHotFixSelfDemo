using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMove : MonoBehaviour
{
    private float speed = 5f;

    private float boundLeftX=-9f;
    private float boundRightX = 9f;

    private bool isRight = true;

    public static Action<float> CallBackX;
    // Use this for initialization
    void Start ()
    {
        speed = 5f;
        boundLeftX = -9f;
        boundRightX = 9f;
        isRight = true;
    }
	
	// Update is called once per frame
	void Update () {
	    if (transform.localPosition.x > boundRightX)
	    {
	        isRight = false;
	    }
	    if (transform.localPosition.x < boundLeftX)
	    {
	        isRight = true;
	    }
        if (isRight==false)
	    {//向左
	        transform.Translate(Vector3.left* speed*Time.deltaTime);
        }
	    else
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
	    if (CallBackX!=null)
	    {
	        CallBackX(transform.localPosition.x);
	    }
	}

    void OnDestroy()
    {
        Debug.Log("========Destroy");
        if (CallBackX != null)
        {
            CallBackX = null;
        }
    }
    
}
