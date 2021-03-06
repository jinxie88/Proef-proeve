﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostC : Card
{  
	public override void ActivateSelf(Player player = null, Node node = null)
    {
        PlayerRotation rot = GameObject.FindWithTag(Tags.GAMECONTROLLER).GetComponent<PlayerRotation>();
        rot.Players[rot.CurrentPlayer].BoostActive = true;
        Destroy(this.gameObject);
	}
}
