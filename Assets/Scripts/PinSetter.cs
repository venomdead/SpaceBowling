using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PinSetter : MonoBehaviour {

    public GameObject pinSet;

    private PinCounter pinCounter;
	private BowlingPin pin;
	private Animator animator;


	// Use this for initialization
	void Start () {
        
        pin = GameObject.FindObjectOfType<BowlingPin>();
        animator = GameObject.FindObjectOfType<Animator>();
        pinCounter = GameObject.FindObjectOfType<PinCounter>();

	}
	
	// Update is called once per frame
	void Update () {

       
	}

   

    public void RaisePins (){

        foreach (BowlingPin bowlingPin in GameObject.FindObjectsOfType<BowlingPin>())
        {
			bowlingPin.RaiseIfStanding();
		}
    }

    public void LowerPins () {

		foreach (BowlingPin bowlingPin in GameObject.FindObjectsOfType<BowlingPin>())
		{
			bowlingPin.LowerIfStanding();
		}
    }


    public void RenewPins (){

        Debug.Log("renewing pins");
        Instantiate(pinSet, new Vector3(0, 40, 1829), Quaternion.identity);
    }

    public void PerformAction(ActionMaster.Action action){
        
		if (action == ActionMaster.Action.Tidy)
		{
			animator.SetTrigger("tidyTrigger");
		}
		else if (action == ActionMaster.Action.EndTurn)
		{
			animator.SetTrigger("resetTrigger");
            pinCounter.Reset();
		}
		else if (action == ActionMaster.Action.Reset)
		{
			animator.SetTrigger("resetTrigger");
            pinCounter.Reset();
        }
		else if (action == ActionMaster.Action.EndGame)
		{
			throw new UnityException("Don't know how to trigger end Game yet");
		}


	}
}

