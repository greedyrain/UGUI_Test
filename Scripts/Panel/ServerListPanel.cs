using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.U2D;

public class ServerListPanel : BasePanel
{
    public ScrollRect leftSV, rightSV;
    public Transform leftContent, rightContent;
    public TMP_Text lastServerName,serversTitle;
    public Image lastServerStatus;

    private List<ServerListObj> objList = new List<ServerListObj>();

    public override void Init()
    {
        
    }

    public override void ShowMe()
    {
        base.ShowMe();
        if (LoginManager.Instance.LoginData.lastServerID>0)
        {
            SetLastServer(LoginManager.Instance.ServersList[LoginManager.Instance.LoginData.lastServerID-1]);
        }
        else
        {
            lastServerName.text = "None";
            lastServerStatus.gameObject.SetActive(false);
        }
        //动态创建左侧的服务器大类列表；
        //计算总共要创建多少个左侧按钮：
        int count = LoginManager.Instance.ServersList.Count;
        if (count % 5 != 0)
            count = LoginManager.Instance.ServersList.Count / 5 + 1;
        else
            count = LoginManager.Instance.ServersList.Count / 5;

        for (int i = 0; i < count; i++)
        {
            //1.生成实例
            ServersObj serversObj = Instantiate(Resources.Load<ServersObj>("Prefabs/ServersObj"), leftContent);
            //2.修改名字
            int begin = 5 * i + 1;
            int end = 5 * i + 5;
            if (end> LoginManager.Instance.ServersList.Count)
                end = LoginManager.Instance.ServersList.Count;
            serversObj.InitInfo(begin,end);
        }
        //动态创建右侧的服务器列表（默认）；
        UpdatePanel(1, 5);
    }

    public void SetLastServer(ServerData data)
    {
        SpriteAtlas atlas = Resources.Load<SpriteAtlas>("Atlas");
        lastServerName.text = data.serverName;
        switch (data.serverStatus)
        {
            case 1:
                lastServerStatus.gameObject.SetActive(false);
                break;
            case 2://流畅
                lastServerStatus.sprite = atlas.GetSprite("ui_DL_liuchang_01");
                break;
            case 3://繁忙
                lastServerStatus.sprite = atlas.GetSprite("ui_DL_fanhua_01");
                break;
            case 4://火爆
                lastServerStatus.sprite = atlas.GetSprite("ui_DL_huobao_01");
                break;
            case 5://维护
                lastServerStatus.sprite = atlas.GetSprite("ui_DL_weihu_01");
                break;
        }
    }

    public void UpdatePanel(int beginIndex,int endIndex)
    {
        //清空list；
        foreach (ServerListObj obj in objList)
        {
            Destroy(obj.gameObject);
        }
        objList.Clear();
        //提供给外部调用的，更新右侧服务器列表的方法；
        for (int i = beginIndex; i <= endIndex; i++)
        {
            //生成一个实例，并通过读取的Json文档的内容给实例赋值；
            //1。生成实例
            ServerListObj serverListObj = Instantiate(Resources.Load<ServerListObj>("Prefabs/ServerListObj"),rightContent);
            serverListObj.InitInfo(LoginManager.Instance.ServersList[i-1]);
            objList.Add(serverListObj);
        }
        serversTitle.text = beginIndex + "~" + endIndex + " Servers";
    }
}
