using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace HardGames.UniqueController {

	// only one monobehaviour in game 
	public class UniqueGameController : MonoBehaviour {

		static List<IGameBehaviour> allBehaviours;

		// manually do this action
		public static void AddGameBehaviour(IGameBehaviour g){
			if (!allBehaviours.Contains(g)){
				g.Start();
				allBehaviours.Add(g);
			}
		}
		// manually do this action
		public static void RemoveGameBehaviour(IGameBehaviour g){
			if (allBehaviours.Contains(g)){
				g.DestroySelf();
				allBehaviours.Remove(g);
			}
		}

		void Awake(){
			allBehaviours.Clear();
			allBehaviours = new List<IGameBehaviour>();
		}
		
		protected virtual void Start(){
		}
		
		void OnEnable(){
		}
		
		void OnDisable(){
		}

		void OnGUI(){
			for (int i = 0; i < allBehaviours.Count; i++) {
				allBehaviours[i].OnGUI();
			}
		}
		
		void Update(){
			for (int i = 0; i < allBehaviours.Count; i++) {
				allBehaviours[i].Update();
			}
		}
		
		void LateUpdate(){
			for (int i = 0; i < allBehaviours.Count; i++) {
				allBehaviours[i].LateUpdate();
			}
		}
		
		void FixedUpdate(){
			for (int i = 0; i < allBehaviours.Count; i++) {
				allBehaviours[i].FixedUpdate();
			}
		}
		
		void OnDestroy(){
			for (int i = 0; i < allBehaviours.Count; i++) {
				allBehaviours[i].DestroySelf();
			}
			allBehaviours.Clear();
		}
		
		void OnLevelWasLoaded(int level){
		}

		void OnLevelWasLoaded(string levelName){
		}
		
		void OnApplicationFocus(bool flag){
		}
	}

}

