using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour
{
    void Start()
    {
        
    }
    void OnTriggerEnter (Collider hit)
    {
        if (hit.CompareTag ("Player"))
        {
            Destroy(gameObject);
        }
    }
    void Update()
    {
        
    }
}
