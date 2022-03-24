using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LoginPanel : BasePanel
{
    public Button registerBtn, confirmBtn;
    public TMP_InputField userNameIF, passwordIF;
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

        confirmBtn.onClick.AddListener(CheckLoginData);
    }

    public void CheckLoginData()
    {
        if (DataManager.Instance.loginDataBase.userLoginDatas.ContainsKey(userName))
        {
            if (DataManager.Instance.loginDataBase.userLoginDatas[userName] == password)
            {
                //登陆成功
            }
        }
    }
}
