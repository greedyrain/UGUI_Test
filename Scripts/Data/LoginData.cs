using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginData
{
    string userName, password;
}

public class LoginDataBase
{
    public Dictionary<string, string> userLoginDatas = new Dictionary<string, string>();
}
