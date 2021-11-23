using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using UnityEngine.Networking;
using System;

namespace UnityWebGL.Editor
{
[Serializable]
public class DatabaseModel {
    public string _id;
    public List<string> components = new List<string>();
    public string time_stamp;
    public static DatabaseModel Parse(string json) {
        return JsonUtility.FromJson<DatabaseModel>(json);
    }
}
}
