using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlingPin : MonoBehaviour {

    public float standingThreshold;
	public float distanceToRaise = 40f;


	// Use this for initialization
	void Start () {
	}

	
	// Update is called once per frame
	void Update () {

	}

    public bool IsStanding (){

        Vector3 rotationInEuler = transform.rotation.eulerAngles;
        //mathf.abs returns absolute value
        float tiltInX = Mathf.Abs(rotationInEuler.x);
        float tiltInZ = Mathf.Abs(rotationInEuler.z);

        if (standingThreshold > tiltInX && standingThreshold > tiltInZ){

            return true;

        } else {
            return false;
        }

    }

	public void RaiseIfStanding()
	{
		Debug.Log("raising pins");
			if (IsStanding())
			{
				transform.Translate(new Vector3(0, distanceToRaise, 0), Space.World);
				GetComponent<Rigidbody>().useGravity = false;
                transform.rotation = Quaternion.Euler(0, 0, 0);

		}
	}

	public void LowerIfStanding()
	{
		Debug.Log("lowering pins");
		if (IsStanding())
		{
			transform.Translate(new Vector3(0, -distanceToRaise, 0), Space.World);
		}

		GetComponent<Rigidbody>().useGravity = true;
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
	}


	public void RenewPins()
	{
		Debug.Log("renewing pins");
	}
}
