using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginData
{
    public string userName, password;
    public bool rememberPW, autoLogin;
}

public class LoginDataBase
{
    public Dictionary<string, string> userLoginDatas = new Dictionary<string, string>();
}