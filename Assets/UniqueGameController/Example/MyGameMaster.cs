using UnityEngine;
using System.Collections;
using HardGames.UniqueController;

public class MyGameMaster : UniqueGameController {

	PlayController playController_;

	protected override void Start ()
	{
		base.Start ();
		Build();
	}

	void Build(){
		playController_ = new PlayController();
		playController_.Build();
		UniqueGameController.Instance.AddGameBehaviour(playController_);
	}
}
