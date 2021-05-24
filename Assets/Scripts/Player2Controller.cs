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
    private AM1.Nav.NavController _navControlller;
    Animator player_Animator;
    bool player_walk;
    void Start()
    {
        _rayRange = 1000;
        _targetPos = transform.position;
        _agent = GetComponent<NavMeshAgent>();
        //_agent.SetDegstination(_targetPos);
        _navControlller = GetComponent<AM1.Nav.NavController>();
        player_Animator = gameObject.GetComponent<Animator>();
        player_walk = false;
    }    
        
    void OnTriggerEnter (Collider get)
    {   
        //1つ目のアイテムの花を取得する
        if (get.CompareTag ("flower1"))
        {
            Destroy(get.gameObject);
            item1 = true;
            //効果音再生
            GetComponent<AudioSource>().Play();
        }
        //2つ目のアイテムを取得する
        else if (get.CompareTag("flower2"))
        {
            Destroy(get.gameObject);
            item2 = true;
            GetComponent<AudioSource>().Play();
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
            GetComponent<AudioSource>().Play();
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
                //_agent.SetDestination(_targetPos);
                _navControlller.SetDestination(_targetPos);
                //移動を開始する時、アニメーションをwalkにする
                player_walk = true;
                if (player_walk == true)
                player_Animator.SetBool("move", true);
            }
        }
        //移動場所が指定されてない時はアニメーションをidleにする
        else player_walk = false;
            if (player_walk == false)
            player_Animator.SetBool("move", false);
            
        //クリックしたら非表示にする
            if (Input.GetMouseButtonDown(0))
            {
                letterUI.SetActive(false);
                
            }
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