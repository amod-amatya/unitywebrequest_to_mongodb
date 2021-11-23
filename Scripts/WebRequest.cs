using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;
using System.Configuration;
using System.Collections.Specialized;
using UnityEngine.Networking;
using SimpleJSON;

namespace UnityWebGL.Editor
{
public class WebRequest : MonoBehaviour
{
    // public string[] listComponents;
    private List<string> listComponents = new List<string>();
    private string timeStamp = "0";
    public GameObject textTemplate;
    void Start()
    {}

    public void FetchMongodbData()
    {
        StartCoroutine(GetQuestion(result => {
            Debug.Log("Time stamp: " + result.time_stamp);
            

            foreach(var x in result.components) {
                 Debug.Log(x);
                 listComponents.Add(x);
            }
            if (!timeStamp.Equals(result.time_stamp)) {
                Debug.Log("inside");
                timeStamp = result.time_stamp;
                foreach(var x in listComponents)
                    PopulateList(x);
                
            }
        }));  
    }
    IEnumerator GetQuestion(System.Action<DatabaseModel> callback = null)
    {
        using (UnityWebRequest request = UnityWebRequest.Get(Config.webhook_url))
        {
            yield return request.SendWebRequest();
            if (request.isNetworkError || request.isHttpError) {
                Debug.Log(request.error);
                if(callback != null) {
                    callback.Invoke(null);
                }
            }
            else {
                if(callback != null) {
                    Debug.Log("Retrieved json data " + request.downloadHandler.text);
                    if (request.downloadHandler.text != null) {
                        callback.Invoke(DatabaseModel.Parse(request.downloadHandler.text));
                    }
                }
            }
        }
    }
    public void PopulateList(string data)
    {
        GameObject txt;
        txt = Instantiate(textTemplate) as GameObject;

        txt.GetComponent<DatabaseControlList>().SetText(data);
        txt.transform.SetParent(textTemplate.transform.parent, true);
    }
}
}