using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ServerPanel : BasePanel
{
    public Button changeServerBtn, enterGameBtn;
    public TMP_Text serverName;
    public override void Init()
    {
        changeServerBtn.onClick.AddListener(() =>
        {
            //打开服务器列表；
            //隐藏当前界面；
            UIManager.Instance.HidePanel<ServerPanel>();
        });

        enterGameBtn.onClick.AddListener(() =>
        {
            //进入游戏场景；
            SceneManager.LoadScene("GameScene");
        });
    }

    public override void ShowMe()
    {
        base.ShowMe();
        //显示时将当前选择的区号的文字改为选中的区名；
    }

    public void ChangeServerName(string serverName)
    {
        this.serverName.text = serverName;
    }
}
