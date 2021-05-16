using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class langageButtonScript : MonoBehaviour
{
    public GameObject enButton;
    public GameObject jpButton;
   public void OnClick()
   {
       enButton.SetActive(true);
       jpButton.SetActive(true); 
   }
}
