using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ServerPanel : BasePanel
{
    public Button changeServerBtn, enterGameBtn,backBtn;
    public TMP_Text serverName;
    public override void Init()
    {
        changeServerBtn.onClick.AddListener(() =>
        {
            //打开服务器列表；
            //隐藏当前界面；
            UIManager.Instance.HidePanel<ServerPanel>();
            UIManager.Instance.ShowPanel<ServerListPanel>();
        });

        enterGameBtn.onClick.AddListener(() =>
        {
            //进入游戏场景；
            LoginManager.Instance.SaveLoginData();
            SceneManager.LoadScene("GameScene");
        });

        backBtn.onClick.AddListener(() =>
        {
            LoginManager.Instance.LoginData.autoLogin = false;
            UIManager.Instance.ShowPanel<LoginPanel>();
            UIManager.Instance.HidePanel<ServerPanel>();
        });
    }

    public override void ShowMe()
    {
        base.ShowMe();
        //显示时将当前选择的区号的文字改为选中的区名；
        int id = LoginManager.Instance.LoginData.lastServerID;
        if (id == 0)
        {
            id = 1;
        }
        string serverName = LoginManager.Instance.ServersList[id-1].serverName;
        ChangeServerName(serverName);
    }

    public void ChangeServerName(string serverName)
    {
        this.serverName.text = serverName;
    }
}
