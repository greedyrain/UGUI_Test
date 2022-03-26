using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.U2D;

public class ServerListObj : MonoBehaviour
{
    public Button button;
    public TMP_Text serverName;
    public Image imageNew;
    public Image status;
    public ServerData serverData;

    // Start is called before the first frame update
    void Start()
    {
        button.onClick.AddListener(()=>
        {
            //关闭选服面板
            LoginManager.Instance.LoginData.lastServerID = serverData.ID;
            UIManager.Instance.HidePanel<ServerListPanel>();
            UIManager.Instance.ShowPanel<ServerPanel>();
        });
    }

    public void InitInfo(ServerData data)
    {
        serverData = data;
        serverName.text = data.serverName;
        imageNew.gameObject.SetActive(data.isNew);
        status.gameObject.SetActive(true);
        SpriteAtlas atlas = Resources.Load<SpriteAtlas>("Atlas");
        switch (data.serverStatus)
        {
            case 1:
                status.gameObject.SetActive(false);
                break;
            case 2://流畅
                status.sprite = atlas.GetSprite("ui_DL_liuchang_01");
                break;
            case 3://繁忙
                status.sprite = atlas.GetSprite("ui_DL_fanhua_01");
                break;
            case 4://火爆
                status.sprite = atlas.GetSprite("ui_DL_huobao_01");
                break;
            case 5://维护
                status.sprite = atlas.GetSprite("ui_DL_weihu_01");
                break;
        }
    }
}
