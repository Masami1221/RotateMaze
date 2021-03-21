using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MoveBird : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.DOLocalMove(new Vector3(48f,32f,-18f), 5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
