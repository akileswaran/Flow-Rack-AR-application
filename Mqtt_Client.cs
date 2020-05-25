using UnityEngine;
using System.Collections;

using uPLibrary.Networking.M2Mqtt;
using System;
using System.Runtime.InteropServices;
using System.Text;
using uPLibrary.Networking.M2Mqtt.Messages;

public class mqtt : MonoBehaviour
{
    //http://tdoc.info/blog/2014/11/10/mqtt_csharp.html
    private MqttClient4Unity client;

    public string brokerHostname = null;
    public int brokerPort = 1883;
    public string userName = null;
    public string password = null;
    public string topic = null;

    private Queue msgq = new Queue();

   string lastMessage = null;

    // Use this for initialization
    void Start()
    {
        if (brokerHostname != null && userName != null && password != null)
        {
            Connect();
            client.Subscribe(topic);
        }
    }

    // Update is called once per frame
    void Update()
    {
        while (client.Count() > 0)
        {
            //for(int i =0;i<100;i++)
            //{
                string s = client.Receive();
                msgq.Enqueue(s);
                // Debug.Log("received :" + s);
                Console.WriteLine(s);
            if (s.Contains("rack1:"))
            {
                TextMesh textObject = GameObject.Find("rack1:").GetComponent<TextMesh>();
                textObject.text = s;
            }
            if (s.Contains("rack2:"))
            {
                TextMesh textObject = GameObject.Find("rack2:").GetComponent<TextMesh>();
                textObject.text = s;
            }
            if (s.Contains("rack3:"))
            {
                TextMesh textObject = GameObject.Find("rack3:").GetComponent<TextMesh>();
                textObject.text = s;
            }

            // }


        }

    }



    public void Connect()
    {
        client = new MqttClient4Unity(brokerHostname, brokerPort, false, null);
        string clientId = Guid.NewGuid().ToString();
        client.Connect(clientId, userName, password);
    }

    public void Publish(string _topic, string msg)
    {
        client.Publish(
            _topic, Encoding.UTF8.GetBytes(msg),
            MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE, false);
    }
}


