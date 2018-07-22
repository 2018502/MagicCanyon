using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class UIEnterGame : MonoBehaviour {
	void Awake() {
		DontDestroyOnLoad(this.gameObject);
	}
	// Use this for initialization
	void Start () {
		InstallEvents();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void InstallEvents(){
		KBEngine.Event.registerOut("Event_OnEnterGameSuccess",this,"OnEnterGameSuccess");
		KBEngine.Event.registerOut("Event_OnEnterGameFailed",this,"OnEnterGameFailed");
	}

	public void OnEnterGameClick(){
		KBEngine.Event.fireIn("Event_EnterGame");
		Debug.Log("点击EnterGame， 等待中....");
	}

	public void OnLoginGameClick(){
		KBEngine.Event.fireIn("login","111111","111111",System.Text.Encoding.UTF8.GetBytes("KBEngine_u3d_KBEText"));
		Debug.Log("点击登录进行认证，等待中....");
	}
	public void OnEnterGameFailed(sbyte errorCode){
		Debug.LogErrorFormat("EnterGame 失败,errorCode={0}",errorCode);

	}

	public void OnEnterGameSuccess(){
		Debug.Log("EnterGame 成功,开始进入世界，等待...");
		SceneManager.LoadScene("TWorld");
	}
}
