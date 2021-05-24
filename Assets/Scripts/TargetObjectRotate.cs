using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Threading.Tasks;

public class TargetObjectRotate : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject targetObject;
    public GameObject cameraRig;
    public GameObject player;
    private NavMeshAgent _agent;
    public GameObject controller;

    private bool isDraggable = false;
    private Quaternion _startRot;
    private Quaternion _startTargetRot;

    public GameObject laserPointerObject;
    void Start()
    {
        _agent = player.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        // if (OVRInput.GetDown(OVRInput.RawButton.X))
        // {
        //     _agent.enabled = false;
        //     LateTarget();

        //     var rotation = targetObject.transform.rotation.eulerAngles.y;
        //     targetObject.transform.rotation = Quaternion.Euler(0, rotation+90, 0);
        // }

        if (OVRInput.GetDown(OVRInput.RawButton.Y))
        {
            var transform = cameraRig.transform.position;
            cameraRig.transform.position = new Vector3(transform.x, transform.y + 10, transform.z);
        }

        if (OVRInput.GetDown(OVRInput.RawButton.A))
        {
            var player1 = player.GetComponent<Player1Controller>();
            var laserScript = laserPointerObject.GetComponent<LaserPointer>();
            Ray ray = new Ray(laserScript.GetStartPoint(), laserScript.GetForward());
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 1000))
            {
                Debug.Log("hit");
                player1.SetTargetPos(hit.point);
            }
        }


        if (OVRInput.GetDown(OVRInput.RawButton.B))
        {
            isDraggable = true;
            _startTargetRot = targetObject.transform.rotation;
            _startRot = controller.transform.rotation;
            _agent.enabled = false;
        }
        if (OVRInput.GetUp(OVRInput.RawButton.B))
        {
            isDraggable = false;
            _agent.enabled = true;
            // targetObject.transform.rotation = Quaternion.Euler(0, _startRot.y - controller.transform.rotation.y, 0);
        }

        if (OVRInput.Get(OVRInput.RawButton.B) && isDraggable)
        {
            targetObject.transform.rotation = Quaternion.Euler(0, _startTargetRot.eulerAngles.y + (_startRot.eulerAngles.y - controller.transform.rotation.eulerAngles.y), 0);
        }
    }

    async void LateTarget()
    {
        await Task.Delay(100);
        _agent.enabled = true;
    }
}
