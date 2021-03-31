using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class dropdown : MonoBehaviour
{
    public Material Material1;
    public Material Material2;
    //in the editor this is what you would set as the object you wan't to change
    public GameObject Rack1;
    public GameObject Rack2;
    public GameObject Rack3;
    public GameObject Rack4;

    //public TextMeshProUGUI Output;

    public void HandleIInputData(int val)
   {
        if (val == 1 )
        {
            Rack2.GetComponent<MeshRenderer>().material = Material2;
            Rack3.GetComponent<MeshRenderer>().material = Material2;
            Rack1.GetComponent<MeshRenderer>().material = Material1;
            Rack4.GetComponent<MeshRenderer>().material = Material2;
        }
        if (val == 2)
        {
            Rack1.GetComponent<MeshRenderer>().material = Material2;
            Rack3.GetComponent<MeshRenderer>().material = Material2;
            Rack2.GetComponent<MeshRenderer>().material = Material1;
            Rack4.GetComponent<MeshRenderer>().material = Material2;
        }
        if (val == 3)
        {
            Rack1.GetComponent<MeshRenderer>().material = Material2;
            Rack2.GetComponent<MeshRenderer>().material = Material2;
            Rack3.GetComponent<MeshRenderer>().material = Material1;
            Rack4.GetComponent<MeshRenderer>().material = Material2;
        }
        if (val == 4)
        {
            Rack1.GetComponent<MeshRenderer>().material = Material2;
            Rack2.GetComponent<MeshRenderer>().material = Material2;
            Rack3.GetComponent<MeshRenderer>().material = Material2;
            Rack4.GetComponent<MeshRenderer>().material = Material1;
        }
    }
}
