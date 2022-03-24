using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TipPanel : BasePanel
{
    public Button confirmBtn;
    public TMP_Text tipsText;
    public override void Init()
    {
        confirmBtn.onClick.AddListener(() =>
        {
            UIManager.Instance.HidePanel<TipPanel>();
        });
    }

    public void ChangeText(string text)
    {
        tipsText.text = text;
    }
}
