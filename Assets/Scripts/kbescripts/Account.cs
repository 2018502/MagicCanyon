using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KBEngine;
public class Account : AccountBase
{

    public override void __init__()
    {//实体被初始化时会调用该函数
		KBEngine.Event.registerIn("Event_EnterGame", this, "EnterGame");
        KBEngine.Event.registerIn("Event_HelloToFirstEntity", this, "HelloToFirstEntity");
		KBEngine.Event.fireOut("Event_OnLoginSuccessfully", KBEngineApp.app.entity_uuid, this);
    }

    public override void onDestroy()
    {//实体被销毁时会调用该函数
    }

    #region 自定义回调

    public override void onEnterGameFailed(sbyte errorCode)
    {
        Dbg.ERROR_MSG("Account::onEnterGameFailed: errorCode=" + errorCode);
		KBEngine.Event.fireOut("Event_OnEnterGameFailed", errorCode);
        
    }
    public override void onEnterGameSuccess()
    {
        Dbg.DEBUG_MSG("Account::onEnterGameSuccess!");
        KBEngine.Event.fireOut("Event_OnEnterGameSuccess");
    }

    public override void onFirstEntityHello(string content)
    {
        Dbg.DEBUG_MSG("Account::onFirstEntityHello:content=\r\n" + content);
		KBEngine.Event.fireOut("Event_OnFirstEntityHello", content);
        
    }

    #endregion

	 public void EnterGame()
    {
        Dbg.DEBUG_MSG("Account::enterGame");
        this.baseEntityCall.enterGame();
    }
    public void HelloToFirstEntity(string content)
    {
        Dbg.DEBUG_MSG("Account::HelloToFirstEntity, content="+content);
        FirstEntityBase firstEntity = null;
        foreach (var pair in KBEngineApp.app.entities)
        {
            Debug.Log("Check--------------"+pair.Key+pair.Value.className);
            if (pair.Value.className == "FirstEntity")
            {
                firstEntity = pair.Value as FirstEntityBase;
            }
        }
        if (firstEntity == null)
        {
            Dbg.ERROR_MSG("Account::HelloToFirstEntity, firstEntity can not find");
            return;
        }
        firstEntity.cellEntityCall.hello(content);
    }

}