﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour {

	private int _currentPlayer = 3;

	private SmoothCameraFollow _cameraFollow;
	private List<Player> _players = new List<Player>();
    private CardManager _cardManager;

	void Awake()
	{
		_cameraFollow = Camera.main.GetComponent<SmoothCameraFollow>();
	}

	void Start()
	{
		_cameraFollow.SetTarget = _players[0].PlayerObject.transform;
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
			StartCoroutine(EndTurn(0.25f));
		if (Input.GetKeyDown(KeyCode.A))
			_players[_currentPlayer].BoostActive = true;
	}

	public IEnumerator EndTurn(float waitTime)
	{
		_players[_currentPlayer].EndTurn();
		yield return new WaitForSeconds(waitTime);

		_currentPlayer ++;

		if (_currentPlayer >= _players.Count)
			_currentPlayer = 0;
		
		_cameraFollow.SetTarget = _players[_currentPlayer].PlayerObject.transform;
        _cardManager.DrawCard();
		_players[_currentPlayer].EnableTurn();

		yield return new WaitForEndOfFrame();
	}

	public List<Player> Players
	{
		get
		{
			return _players;
		}
		set 
		{
			_players = value;
		}
	}

    public int CurrentPlayer
    {
        get
        {
            return _currentPlayer;
        }
        set
        {
            _currentPlayer = value;
        }
    }
}
