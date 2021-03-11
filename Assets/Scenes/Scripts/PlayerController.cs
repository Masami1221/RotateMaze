using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    private float _rayRange;
    private Vector3 _targetPos;
    private NavMeshAgent _agent;
    // Start is called before the first frame update
    void Start()
    {
        _rayRange = 100;
        _targetPos = transform.position;
        _agent = GetComponent<NavMeshAgent>();
        _agent.SetDestination(_targetPos);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, _rayRange))
            {
                _targetPos= hit.point;
                _agent.SetDestination(_targetPos);
            }
        }
    }
}
