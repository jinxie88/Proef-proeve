﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour {

	[SerializeField] private SmoothCameraFollow cameraFollow;
	[SerializeField] private CameraTargetter cameraTargetter;
	[SerializeField] private int currentPlayer = 0;
	[SerializeField] private List<Player> players = new List<Player>();
	[SerializeField] private CardManager cardManager;

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
			EndTurn();
	}

	public void EndTurn()
	{
		players[currentPlayer].CanWalk = false;	
		currentPlayer ++;
		if (currentPlayer >= players.Count)
			currentPlayer = 0;
		
		cameraFollow.SetTarget = players[currentPlayer].PlayerObject.transform;
		players[currentPlayer].CanWalk = true;
		NextPlayer();
	}

	private void NextPlayer()
	{
		cardManager.HideAllCards();
		cardManager.ShowCards(currentPlayer);

	}
	public List<Player> Players
	{
		set 
		{
			players = value;
		}
	}

}