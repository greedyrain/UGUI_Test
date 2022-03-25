using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginManager
{
    private static LoginManager instance = new LoginManager();
    public static LoginManager Instance
    {
        get { return instance; }
    }

    private LoginManager()
    {
        loginData = JsonManager.Instance.LoadData<LoginData>("LoginData");
        loginDataBase = JsonManager.Instance.LoadData<LoginDataBase>("LoginDataBase");
        serversList = JsonManager.Instance.LoadData<List<ServerData>>("ServersList");
    }

    private LoginData loginData;
    public LoginData LoginData
    {
        get { return loginData; }
    }

    private LoginDataBase loginDataBase;
    public LoginDataBase LoginDataBase
    {
        get { return loginDataBase; }
    }

    private List<ServerData> serversList;
    public List<ServerData> ServersList
    {
        get { return serversList; }
    }

    public void SaveLoginData()
    {
        JsonManager.Instance.SaveData(loginData, "LoginData");
    }

    public void SaveLoginDataBase()
    {
        JsonManager.Instance.SaveData(LoginDataBase, "LoginDataBase");
    }

    public bool CheckLogin(string userName,string password)
    {
        if (loginDataBase.userLoginDatas.ContainsKey(userName))
        {
            if (loginDataBase.userLoginDatas[userName] == password)
            {
                return true;
            }
            else
            {
                TipPanel tipPanel = UIManager.Instance.ShowPanel<TipPanel>();
                tipPanel.ChangeText("You've entered a wrong password.");
                return false;
            }
        }
        else
        {
            TipPanel tipPanel = UIManager.Instance.ShowPanel<TipPanel>();
            tipPanel.ChangeText("The user name doesn't exists.");
            return false;
        }
    }

    public bool RegisterUser(string userName,string password)
    {
        if (LoginDataBase.userLoginDatas.ContainsKey(userName))
        {
            TipPanel tipPanel = UIManager.Instance.ShowPanel<TipPanel>();
            tipPanel.ChangeText("The user name already exists.");
            return false;
        }
        else
        {
            if (userName.Length < 8)
            {
                TipPanel tipPanel = UIManager.Instance.ShowPanel<TipPanel>();
                tipPanel.ChangeText("Please enter a user name larger than 8 characters.");
                return false;
            }
            else if(password.Length < 8)
            {
                TipPanel tipPanel = UIManager.Instance.ShowPanel<TipPanel>();
                tipPanel.ChangeText("Please enter a password larger than 8 characters.");
                return false;
            }
        }
        loginDataBase.userLoginDatas.Add(userName, password);
        SaveLoginDataBase();
        return true;

    }
}
