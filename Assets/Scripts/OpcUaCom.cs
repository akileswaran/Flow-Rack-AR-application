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
    
    //public string _opcUaNodeForRobotAxis2;
    //public string _opcUaNodeForRobotAxis3;
    //public string _opcUaNodeForRobotAxis4;
    //public string _opcUaNodeForRobotAxis5;
    //public string _opcUaNodeForRobotAxis6;

    //public GameObject axis1KOS;
    //public GameObject axis2KOS;
    //public GameObject axis3KOS;
    //public GameObject axis4KOS;
    //public GameObject axis5KOS;
    //public GameObject axis6KOS;

    //public float axis1OffsetToRealRobot;
    //public float axis2OffsetToRealRobot;
    //public float axis3OffsetToRealRobot;
    //public float axis4OffsetToRealRobot;
    //public float axis5OffsetToRealRobot;
    //public float axis6OffsetToRealRobot;

    //private Vector3 _axis1Rotation;
    //private Vector3 _axis2Rotation;
    //private Vector3 _axis3Rotation;
    //private Vector3 _axis4Rotation;
    //private Vector3 _axis5Rotation;
    //private Vector3 _axis6Rotation;

    static private List<string> opcUaEndpointList;
    
    private float countdown = 0.5f;
  

    private OpcUaClient _opcUaClient;
  //  public Session session { get; set; }





    // Start is called before the first frame update
    void Start()
    {
        opcUaEndpointList = new List<string>();
        opcUaEndpointList.Add("ns=2;s=Demo.Massfolder_Static.Variable0000");
        opcUaEndpointList.Add("ns=2;s=Demo.Massfolder_Static.Variable0001");
        opcUaEndpointList.Add("ns=2;s=Demo.Massfolder_Static.Variable0002");
        opcUaEndpointList.Add("ns=2;s=Demo.Massfolder_Static.Variable0003");


        _opcUaClient = new OpcUaClient();
         
        _opcUaClient.SubscripeToOpcUaServer(_opcUaEndpointUrl, opcUaEndpointList);
        
    }

    // Update is called once per frame
    void Update()
    {
           
        if (countdown <= 0)
        {




            var Num = _opcUaClient.session.ReadValue("ns=2;s=Demo.Massfolder_Static.Variable0000");
            var Numb = _opcUaClient.session.ReadValue("ns=2;s=Demo.Massfolder_Static.Variable0001");
            var Numbr = _opcUaClient.session.ReadValue("ns=2;s=Demo.Massfolder_Static.Variable0002");
            var Number = _opcUaClient.session.ReadValue("ns=2;s=Demo.Massfolder_Static.Variable0003");

            //var Num1 = _opcUaClient.session.ReadNode("ns = 4; s = MAIN.rack2");
            // session.ReadValue("ns = 4; s = MAIN.rack3");
            //TextMesh textObject = GameObject.Find("rack1").GetComponent<TextMesh>();
            //textObject.text = "test";
            //TextMesh textObject1 = GameObject.Find("rack2").GetComponent<TextMesh>();
            //textObject1.text ="iyg";

            TextMesh textObject2 = GameObject.Find("rack4:").GetComponent<TextMesh>();
            textObject2.text ="Box4:"+Convert.ToString(Num);
            TextMesh textObject3 = GameObject.Find("rack5:").GetComponent<TextMesh>();
            textObject3.text = "Box5:" + Convert.ToString(Numb);
            TextMesh textObject4 = GameObject.Find("rack6:").GetComponent<TextMesh>();
            textObject4.text = "Box6:" + Convert.ToString(Numbr);
            TextMesh textObject5 = GameObject.Find("rack7:").GetComponent<TextMesh>();
            textObject5.text = "Box7:" + Convert.ToString(Number);

            countdown = 0.5f;
        }
        countdown -= Time.deltaTime;

    }
}

