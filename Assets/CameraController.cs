using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public GameObject mainCamera;
    public float rotate_speed;

    void Start()
    {
        mainCamera = Camera.main.gameObject;
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void rotateCmaeraAngle() {
    Vector3 angle = new Vector3(
        Input.GetAxis("Mouse X") * rotate_speed,
        Input.GetAxis("Mouse Y") * rotate_speed,
        0
    );
 
    transform.eulerAngles += new Vector3(angle.y, angle.x);
}
    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position;
    }
}
