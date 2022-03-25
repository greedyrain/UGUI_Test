using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginData
{
    public string userName, password;
    public bool rememberPW, autoLogin;

    public int lastServerID = 0;
}

public class LoginDataBase
{
    public Dictionary<string, string> userLoginDatas = new Dictionary<string, string>();
}