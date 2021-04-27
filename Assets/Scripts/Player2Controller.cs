using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Player2Controller : MonoBehaviour
{
    private float _rayRange;
    private Vector3 _targetPos;
    private NavMeshAgent _agent;
    public bool item1;
    public bool item2;
    public GameObject letterUI;
    
    void Start()
    {
        _rayRange = 1000;
        _targetPos = transform.position;
        _agent = GetComponent<NavMeshAgent>();
        //_agent.SetDegstination(_targetPos);
    }    
        
    void OnTriggerEnter (Collider get)
    {   
        //1つ目のアイテムの花を取得する
        if (get.CompareTag ("flower1"))
        {
            Destroy(get.gameObject);
            item1 = true;
        }
        //2つ目のアイテムを取得する
        else if (get.CompareTag("flower2"))
        {
            Destroy(get.gameObject);
            item2 = true;
        }
        //ダミーの花を取得する
        else if (get.CompareTag("dummy"))
        {
            Destroy(get.gameObject);
            Debug.Log("dummy flower");
        }

        else if (get.CompareTag("MoveObstacle"))
        {
            Debug.Log("playerDetact");
            _agent.ResetPath();
        }
        //手紙を拾う処理
        //当たったのがletterだったら
        else if (get.CompareTag ("letter"))
        {
            //letterを消して、UIを表示する
            Debug.Log("pick up the letter");
            Destroy(get.gameObject);
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
        //    if (Input.GetMouseButtonDown(0))
        //    {
        //        letterUI.SetActive(false);
                
        //    }
    }
    public bool IsObstacleItem1()
    {
        return item1;
    }
    public bool IsObstacleItem2()
    {
        return item2;
    }
}