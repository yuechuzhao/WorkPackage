using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace HardGames.UniqueController {

	// only one monobehaviour in game 
	public class UniqueGameController : MonoBehaviour {

		private static UniqueGameController instance_;
		public static UniqueGameController Instance{
			get {
				return instance_;
			}
		}

		private List<IGameBehaviour> allBehaviours;

		// manually do this action
		public void AddGameBehaviour(IGameBehaviour g){
			if (!allBehaviours.Contains(g)){
				g.Start();
				allBehaviours.Add(g);
			}
		}

		// manually do this action
		public void RemoveGameBehaviour(IGameBehaviour g){
			if (allBehaviours.Contains(g)){
				g.DestroySelf();
				allBehaviours.Remove(g);
			}
		}

		public void Pause(){
		}

		public void Resume(){
		}

		void Awake(){
			allBehaviours = new List<IGameBehaviour>();
			if (instance_ != null){
				Destroy(instance_.gameObject);
			}
			instance_ = this;
			DontDestroyOnLoad(gameObject);
		}
		
		protected virtual void Start(){
		}
		
		protected virtual void OnEnable(){
		}
		
		protected virtual void OnDisable(){
		}

		protected virtual void OnGUI(){
			for (int i = 0; i < allBehaviours.Count; i++) {
				allBehaviours[i].OnGUI();
			}
		}
		
		protected virtual void Update(){
			for (int i = 0; i < allBehaviours.Count; i++) {
				allBehaviours[i].Update();
			}
		}
		
		protected virtual void LateUpdate(){
			for (int i = 0; i < allBehaviours.Count; i++) {
				allBehaviours[i].LateUpdate();
			}
		}
		
		protected virtual void FixedUpdate(){
			for (int i = 0; i < allBehaviours.Count; i++) {
				allBehaviours[i].FixedUpdate();
			}
		}
		
		protected virtual void OnDestroy(){
			for (int i = 0; i < allBehaviours.Count; i++) {
				allBehaviours[i].DestroySelf();
			}
		}
		
		protected virtual void OnLevelWasLoaded(int level){
		}

		protected virtual void OnLevelWasLoaded(string levelName){
		}
		
		protected virtual void OnApplicationFocus(bool flag){
		}
	}

}

