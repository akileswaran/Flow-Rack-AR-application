using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Opc.Ua;
using Opc.Ua.Client;
using Opc.Ua.Configuration;
using System;
using System.IO;
using UnityEngine.UI;
using UnityEditor;

public class OpcUaCom : MonoBehaviour
{
    
    public string _opcUaEndpointUrl;

    static private List<string> opcUaEndpointList;
    
    private float countdown = 0.5f;
  

    private OpcUaClient _opcUaClient;






    // Start is called before the first frame update
    void Start()
    {
        opcUaEndpointList = new List<string>();
        opcUaEndpointList.Add("ns=4;s=MAIN.rack1");
        opcUaEndpointList.Add("ns=4;s=MAIN.rack2");     
        opcUaEndpointList.Add("ns=4;s=MAIN.rack3");
        opcUaEndpointList.Add("ns=4;s=MAIN.rack4");



        _opcUaClient = new OpcUaClient();
         
        _opcUaClient.SubscripeToOpcUaServer(_opcUaEndpointUrl, opcUaEndpointList);
        
    }

    // Update is called once per frame
    void Update()
    {
           
        if (countdown <= 0)
        {
            _opcUaClient.WriteOpcUaFloatNode("ns=4;s=MAIN.rack2", 50);
            _opcUaClient.WriteOpcUaNode("ns=4;s=MAIN.rack1", true);


            var Num = _opcUaClient.session.ReadValue("ns=4;s=MAIN.rack3");
            var Numb = _opcUaClient.session.ReadValue("ns=4;s=MAIN.rack4");
            TextMesh textObject = GameObject.Find("rack1").GetComponent<TextMesh>();
            textObject.text = "test";
            TextMesh textObject1 = GameObject.Find("rack2").GetComponent<TextMesh>();
            textObject1.text ="iyg";

            TextMesh textObject2 = GameObject.Find("rack3").GetComponent<TextMesh>();
            textObject2.text =Convert.ToString(Num);
            TextMesh textObject3 = GameObject.Find("rack4").GetComponent<TextMesh>();
            textObject3.text = Convert.ToString(Numb);

            countdown = 0.5f;
        }
        countdown -= Time.deltaTime;

    }
}

