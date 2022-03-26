using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LoginPanel : BasePanel
{
    public Button registerBtn, confirmBtn;
    public TMP_InputField userNameIF, passwordIF;
    public Toggle toggleRememberPW, toggleAutoLogin;
    string userName, password;
    public override void Init()
    {
        userNameIF.onValueChanged.AddListener((userName) =>
        {
            //记录当前输入的账号名和密码，当点击确定时传入判断方法，与数据库中的数据进行比较；
            userName = userNameIF.text;
        });

        passwordIF.onValueChanged.AddListener((password) =>
        {
            //记录当前输入的账号名和密码，当点击确定时传入判断方法，与数据库中的数据进行比较；
            password = passwordIF.text;
        });

        confirmBtn.onClick.AddListener(()=>
        {
            if (LoginManager.Instance.CheckLogin(userNameIF.text, passwordIF.text))
            {
                LoginManager.Instance.LoginData.rememberPW = toggleRememberPW.isOn;
                LoginManager.Instance.LoginData.autoLogin = toggleAutoLogin.isOn;
                LoginManager.Instance.LoginData.userName = userNameIF.text;
                LoginManager.Instance.LoginData.password = passwordIF.text;
                //打开服务器选择面板；
                if (LoginManager.Instance.LoginData.lastServerID == 0)
                    UIManager.Instance.ShowPanel<ServerListPanel>();
                else
                    UIManager.Instance.ShowPanel<ServerPanel>();
                UIManager.Instance.HidePanel<LoginPanel>();
            }
        });

        registerBtn.onClick.AddListener(() =>
        {
            //打开注册面板
            UIManager.Instance.ShowPanel<RegisterPanel>();
            //隐藏登陆面板
            UIManager.Instance.HidePanel<LoginPanel>();
        });

        toggleRememberPW.onValueChanged.AddListener((isOn) =>
        {
            //打开时，自动填充password
            //关闭时，不填充password
            if (!isOn)
            {
                toggleAutoLogin.isOn = false;
            }
        });

        toggleAutoLogin.onValueChanged.AddListener((isOn) =>
        {
            //打开时，自动勾选记住密码，并会直接进入服务器选择界面；
            //关闭时，没有任何操作；
            //记住密码取消勾选时，变为关闭状态；
            if (isOn)
            {
                toggleRememberPW.isOn = true;
            }
        });
    }

    public override void ShowMe()
    {
        base.ShowMe();
        //获取登陆数据；
        LoginData loginData = LoginManager.Instance.LoginData;
        toggleRememberPW.isOn = loginData.rememberPW;
        toggleAutoLogin.isOn = loginData.autoLogin;
        userNameIF.text = loginData.userName;
        passwordIF.text = toggleRememberPW.isOn ? loginData.password : "";
        if (toggleAutoLogin.isOn)
        {
            //验证账号密码相关；
            if (LoginManager.Instance.CheckLogin(userNameIF.text, passwordIF.text))
            {
                if (LoginManager.Instance.LoginData.lastServerID == 0)
                    UIManager.Instance.ShowPanel<ServerListPanel>();
                else
                    UIManager.Instance.ShowPanel<ServerPanel>();
                UIManager.Instance.HidePanel<LoginPanel>();
            }
        }
    }
}
