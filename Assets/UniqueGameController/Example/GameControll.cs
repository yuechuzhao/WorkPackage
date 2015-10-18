using UnityEngine;
using System.Collections;
using HardGames.UniqueController;

public class Ground : GameBehaviour
{
	public override void Awake ()
	{
		base.Awake ();
		GameObject go = GameObject.Instantiate(Resources.Load("Ground", typeof(GameObject))) as GameObject;
		Target = go;
	}

	public override void Update ()
	{
		base.Update ();
		if (Time.frameCount % 5 == 0){
			Debug.Log("Ground....in...update");
		}
	}

}


public class Player : GameBehaviour {
	public override void Awake()
	{
		base.Awake ();
		Target = GameObject.Instantiate(Resources.Load("Player", typeof(GameObject))) as GameObject;
	}
	
	public override void Update ()
	{
		base.Update ();
		if (Time.frameCount % 10 == 0){
			Debug.Log("Player....in...update " + Target.name);
		}
	}
}

public class PlayController: GameBehaviour {
	Ground ground_;
	Player player_;
	int playerID_ = 0;

	public void Build(){
		ground_ = new Ground();
		UniqueGameController.Instance.AddGameBehaviour(ground_);

		player_ = new Player();
		UniqueGameController.Instance.AddGameBehaviour(player_);
	}

	public override void OnGUI(){
		if (GUI.Button(new Rect(0, 0, 120, 30), "destory one")){
			if (player_ != null){
				UniqueGameController.Instance.RemoveGameBehaviour(player_);
				player_ = null;
			}
		}

		if (GUI.Button(new Rect(0, 40, 120, 30), "new one")){
			if (player_ == null){
				player_ = new Player();
				playerID_ += 1;
				player_.Target.name = "player" + playerID_;
				UniqueGameController.Instance.AddGameBehaviour(player_);
			}
		}
	}
}