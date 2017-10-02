﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinCounter : MonoBehaviour {


	public Text standingText;



	private bool ballOutOfPlay = false;
	private int lastStandingCount = -1;
	private float lastChangeTime;
	private int lastSettledCount = 10;

	private Animator animator;
	private ActionMaster actionMaster = new ActionMaster();
	private Ball ball;
    private GameManager gameManager;



	// Use this for initialization
	void Start () {
		animator = GameObject.FindObjectOfType<Animator>();
        ball = GameObject.FindObjectOfType<Ball>();
        gameManager = FindObjectOfType<GameManager>();

	}
	
	// Update is called once per frame
	void Update () {

		standingText.text = CountStanding().ToString();

		if (ballOutOfPlay)
		{
			UpdateStandingCount();

		}

	}

    public void Reset()
    {

	lastSettledCount = 10;

    }

	private void OnTriggerExit(Collider collider)
	{
		if (collider.gameObject.name == "Ball")
		{
            ballOutOfPlay = true;
			standingText.color = Color.red;
		}
	}

    public void SetBallOutOfPlay()
	{

		ballOutOfPlay = true;
	}

	void UpdateStandingCount()
	{
		int currentStanding = CountStanding();

		if (currentStanding != lastStandingCount)
		{
			lastChangeTime = Time.time;
			lastStandingCount = currentStanding;
			return;
		}

		float settleTime = 3f;

		if ((Time.time - lastChangeTime) > settleTime)
		{
			PinsHaveSettled();
		}

	}

	void PinsHaveSettled()
	{
		int standing = CountStanding();
		int pinFall = lastSettledCount - standing;
		lastSettledCount = standing;

        gameManager.Bowl(pinFall);

		lastStandingCount = -1;
		ballOutOfPlay = false;
		standingText.color = Color.green;

	}


	int CountStanding()
	{
		int standing = 0;

		foreach (BowlingPin bowlingPin in GameObject.FindObjectsOfType<BowlingPin>())
		{
			if (bowlingPin && bowlingPin.IsStanding())
			{
				standing++;
			}
		}
		return standing;


	}


}
