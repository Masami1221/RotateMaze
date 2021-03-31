using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    private float _rayRange;
    private Vector3 _targetPos;
    private NavMeshAgent _agent;
    public bool item;
    
    void Start()
    {
        _rayRange = 1000;
        _targetPos = transform.position;
        _agent = GetComponent<NavMeshAgent>();
        //_agent.SetDestination(_targetPos);
    }
    void OnTriggerEnter (Collider get)
    {
        if (get.CompareTag ("Item"))
        {
            Destroy(get.gameObject);
            item = true;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("mouse down");
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, _rayRange))
            {
                Debug.Log("hit");
                _targetPos= hit.point;
                _agent.SetDestination(_targetPos);
            }
        }
    }
    public bool getItem()
    {
        return item;
    }
}
