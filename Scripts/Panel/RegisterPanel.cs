using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class RegisterPanel : BasePanel
{
    public TMP_InputField userNameIF, passwordIF;
    public Button confirmBtn, cancelBtn;
    public override void Init()
    {
        confirmBtn.onClick.AddListener(() =>
        {
            //关闭当前界面，将当前的UserName和Password存储到LoginManager中；
            if (LoginManager.Instance.RegisterUser(userNameIF.text,passwordIF.text))
            {
                LoginManager.Instance.LoginData.userName = userNameIF.text;
                LoginManager.Instance.LoginData.password = LoginManager.Instance.LoginData.rememberPW ? LoginManager.Instance.LoginData.password : "";
                UIManager.Instance.ShowPanel<LoginPanel>();
                UIManager.Instance.HidePanel<RegisterPanel>();
            }
        });

        cancelBtn.onClick.AddListener(() =>
        {
            //关闭当前界面，打开登陆界面；

            UIManager.Instance.ShowPanel<LoginPanel>();
            UIManager.Instance.HidePanel<RegisterPanel>();
        });
    }
}
