using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Player1Controller : MonoBehaviour
{
    private float _rayRange;
    private Vector3 _targetPos;
    private NavMeshAgent _agent;
    public bool item;
    public GameObject letterUI;
    public GameObject hint2UI;
    bool isCalledDestroy = false;
    
    void Start()
    {
        _rayRange = 1000;
        _targetPos = transform.position;
        _agent = GetComponent<NavMeshAgent>();
        //_agent.SetDegstination(_targetPos);
    }    
        
    void OnTriggerEnter (Collider get)
    {
        //拾ったアイテムを一度だけ消す処理
        if (!isCalledDestroy){
            if (get.CompareTag ("Item"))
            {
                Destroy(get.gameObject);
                item = true;
                isCalledDestroy = true;
                //効果音再生
                GetComponent<AudioSource>().Play();
            }
        }
        
        //手紙を拾う処理
        //当たったのがletterだったら
        if (get.CompareTag ("letter"))
        {
            //letterを消して、UIを表示する
            Debug.Log("pick up the letter");
            Destroy(get.gameObject);
            GetComponent<AudioSource>().Play();
            letterUI.SetActive(true);
            
        }
    }
    

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
        //クリックしたら非表示にする
            if (Input.GetMouseButtonDown(0))
            {
                letterUI.SetActive(false);
                hint2UI.SetActive(false);
                
            }
    }
    public bool getItem()
    {
        return item;
    }
}