using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LocalizationText : MonoBehaviour
{
    public string enText;
    public string jpText;
    public bool isJp = false;
    // Start is called before the first frame update
    void Start()
    {
        var text = GetComponent<Text>();

        if (isJp)
        {
            text.text = jpText;
        }
        else
        {
            text.text = enText;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
