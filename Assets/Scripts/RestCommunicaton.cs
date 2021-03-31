using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Proyecto26;
using UnityEditor;
using System;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

[Serializable]
public class postInformation
{
    public string variableData;
    public string Info1;
}


public class RestCommunicaton : MonoBehaviour
{
    private string getResponse1;
    private string getResponse2;
    //private object updatedPost = 4;
    void Update()
    {

        var box6 = RestClient.Get("http://localhost:8080/api/v1/server/opcuatestserver/namespace/2/identifier/Demo.Massfolder_Static.Variable0002").Then(res => getResponse1 = res.Text);
        Debug.Log(getResponse1);



        if (getResponse1!=null)
        {
            TextMesh textObject = GameObject.Find("rack6:").GetComponent<TextMesh>();
            textObject.text = "Box6:" + Convert.ToString(getResponse1);
        }


        var box7 = RestClient.Get("http://localhost:8080/api/v1/server/opcuatestserver/namespace/2/identifier/Demo.Massfolder_Static.Variable0003").Then(res => getResponse2 = res.Text);
        Debug.Log(getResponse2);

        if (getResponse2!=null)
        {
            TextMesh textObject2 = GameObject.Find("rack7:").GetComponent<TextMesh>();
            textObject2.text = "Box7:" + Convert.ToString(getResponse2);

        }


        //RestClient.Put("http://localhost:8080/api/v1/server/opcuatestserver/namespace/2/identifier/Demo.Static.Scalar.String", new postInformation { variableData="appa" }).Then(res => {return "Ok"; });

    }
}
