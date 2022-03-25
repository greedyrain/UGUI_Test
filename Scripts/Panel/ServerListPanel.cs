using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ServerListPanel : BasePanel
{

    public ScrollView leftSV, rightSV;
    public Transform leftContent, rightContent;
    public override void Init()
    {

    }

    public override void ShowMe()
    {
        base.ShowMe();
        //动态创建左侧的服务器大类列表；
        for (int i = 0; i < LoginManager.Instance.ServersList.Count / 10 + 1; i++)
        {
            ServersObj serversObj = Instantiate(Resources.Load<ServersObj>("Prefabs/ServersObj"), leftContent);
            //serversObj
        }
        //动态创建右侧的服务器列表（默认）；
    }
}
