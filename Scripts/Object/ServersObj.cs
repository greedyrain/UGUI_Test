using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ServersObj : MonoBehaviour
{
    public Button button;
    public TMP_Text text;
    public int beginIndex, endIndex;
    // Start is called before the first frame update
    void Start()
    {
        button.onClick.AddListener(() =>
        {
            //通知ServersList面板更新右侧SV内容；
        });
    }

    public void InitInfo(int beginIndex,int endIndex)
    {
        this.beginIndex = beginIndex;
        this.endIndex = endIndex;

        text.text = "No."+this.beginIndex + "-" + "No."+this.endIndex + "Server";
    }
}
