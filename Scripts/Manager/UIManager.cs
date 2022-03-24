using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager
{
    private static UIManager instance = new UIManager();
    public static UIManager Instance
    {
        get { return instance; }
    }
    public Dictionary<string, BasePanel> panelDic = new Dictionary<string, BasePanel>();
    private Transform canvas;

    private UIManager()
    {
        canvas = GameObject.Find("Canvas").transform;
    }

    //得到面板
    public T GetPanel<T>() where T:BasePanel
    {
        string panelName = typeof(T).Name;
        if (panelDic.ContainsKey(panelName))
            return panelDic[panelName] as T;
        
        return null;
    }

    //显示面板
    public T ShowPanel<T>() where T:BasePanel
    {
        string panelName = typeof(T).Name;//获得面板的名字，在字典中寻找是否有同样的key的面板；
        if (panelDic.ContainsKey(panelName))
            return panelDic[panelName] as T;

        GameObject panelObj = GameObject.Instantiate(Resources.Load<GameObject>("UI/" + panelName));//如果没有，则去创建一个这样的面板；
        panelObj.transform.SetParent(canvas, false);//放在Canvas下，作为子物体；

        T panel = panelObj.GetComponent<T>();//获得这个物体身上的脚本，方便调用该物体身上的方法；
        panelDic.Add(panelName, panel);//存入字典；
        panel.ShowMe();//调用物体身上的方法；

        return panel;
    }

    //隐藏面板
    public void HidePanel<T>(bool isFade = true) where T:BasePanel
    {
        string panelName = typeof(T).Name;
        if (panelDic.ContainsKey(panelName))
        {
            if (isFade)
            {
                panelDic[panelName].HideMe(() =>
                {
                    //淡入淡出结束后会调用的方法：在这里淡出后需要从场景中销毁物体并从字典中移除；
                    GameObject.Destroy(panelDic[panelName].gameObject);
                    panelDic.Remove(panelName);
                });
            }
            else
            {
                GameObject.Destroy(panelDic[panelName].gameObject);
                panelDic.Remove(panelName);
            }
        }
    }
}
