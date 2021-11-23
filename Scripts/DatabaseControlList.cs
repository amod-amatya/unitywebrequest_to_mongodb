using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UnityWebGL.Editor
{
public class DatabaseControlList: MonoBehaviour
{
    [SerializeField]
    private Text dbRowText;
    public void SetText(string db)
    {
        dbRowText.text= db;
    }
}
}
