using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoalScript : MonoBehaviour
{
    public GameObject player;
    public GameObject levelClear;
   
   void OnTriggerEnter(Collider other)
   {
       if (other.name == player.name)
       {
           levelClear.GetComponent<Text>();
           levelClear.SetActive(true);
           player.SetActive(false);
       }
   }
}
