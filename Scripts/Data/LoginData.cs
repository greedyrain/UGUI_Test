using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//单独的账号信息的数据结构
public class LoginData
{
    public string userName, password;
    public bool rememberPW, autoLogin;

    public int lastServerID = 0;
}
//存储所有账号信息
public class LoginDataBase
{
    public Dictionary<string, string> userLoginDatas = new Dictionary<string, string>();
}