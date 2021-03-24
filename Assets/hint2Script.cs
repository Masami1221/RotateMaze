using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hint2Script : MonoBehaviour
{
    public string hint2;
    //public GameObject speakballoonPref;
    //private GameObject canvas;
    
    public GameObject hint2UI;
    void Start()
    {
        //canvas = GameObject.Find("Canvas");
    }
    public void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.tag == "Player") {
            //if (!hint2UI.activeSelf) {
                //hint2UI = Instantiate(speakballoonPref) as GameObject;
                //hint2UI.transform.SetParent(canvas.transform, false);
                hint2UI.SetActive(true);
                //Text hint2UIText = hint2UI.transform.Find("hint2").GetComponent<Text>();
                //hint2UIText.text = hint2;
            //}
        }
    }        

    void OnTriggerExit(Collider other) {
        if (other.gameObject.tag == "Player") {
            if (hint2UI) {
                //Destroy(hint2UI);
                hint2UI.SetActive(false);
            }
        }
    }        
}