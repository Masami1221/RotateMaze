using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hint2Script : MonoBehaviour
{
    public string hint2;
    public GameObject item1Prefab;
    //private GameObject canvas;
    
    public GameObject hint2UI;
    bool isInstatiateItem = false;
    void Start()
    {
        //canvas = GameObject.Find("Canvas");
    }
    public void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.tag == "Player") {
                hint2UI.SetActive(true);
                Debug.Log("item appear");
                if (isInstatiateItem == false)
                {
                    isInstatiateItem = true;
                    GameObject coin = Instantiate(item1Prefab, new Vector3(-16.2f,1.5f,36.8f), Quaternion.Euler (-90f,0,0), transform.parent) as GameObject;
                    coin.transform.localPosition = new Vector3(-16.2f,1.5f,36.8f);
                    GetComponent<AudioSource>().Play();
                }
                
        }
    }        

    //void OnTriggerExit(Collider other) {
        //if (other.gameObject.tag == "Player") {
            //if (hint2UI) {
               // hint2UI.SetActive(false);
            //}
        //}
    //}        
}