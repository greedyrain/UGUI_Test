using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager
{
    private static DataManager instance;
    public static DataManager Instance => instance;
    public LoginDataBase loginDataBase = new LoginDataBase();
    private DataManager()
    {

    }

    public void AddLoginData(string userName,string password)
    {
        if (!loginDataBase.userLoginDatas.ContainsKey(userName))
        {
            loginDataBase.userLoginDatas.Add(userName, password);
        }
        else
        {
            //弹出提示窗口，显示已经存在用户；
        }
    }
}
