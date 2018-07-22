using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KBEngine;

public class World : MonoBehaviour {

	// Use this for initialization
	void Start () {
		InstallEvents();
		Debug.Log("World Started!");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void InstallEvents(){
		KBEngine.Event.registerOut("onEnterWorld",this,"onEnterWorld");
		KBEngine.Event.registerOut("onLeaveWorld",this,"onLeaveWorld");
		KBEngine.Event.registerOut("Event_OnFirstEntityHello",this,"sayFirstEntityHello");

	}

	public void OnHelloBtnClick(){
		KBEngine.Event.fireIn("Event_HelloToFirstEntity","Hi, I'm your master");
	}

	public void onEnterWorld(Entity entity){
		Debug.Log("Entity enter the world"+entity.className);
	}

	public void onLeaveWorld(Entity entity){
		Debug.Log("Entity leave the world"+entity.className);
	}
	public void sayFirstEntityHello(string content){
		Debug.Log("I，m firstEtntity Receive your message"+content);
	}
}
