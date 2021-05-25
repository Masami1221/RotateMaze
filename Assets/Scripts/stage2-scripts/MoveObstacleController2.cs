using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using System.Threading.Tasks;

public class MoveObstacleController2 : MonoBehaviour
{
    // 最初に移動する始点
    [SerializeField]
    private Vector3 _startPos;
    // 最初に移動する終点
    [SerializeField]
    private Vector3 _endPos;
    // アイテム使用後のポジション
    [SerializeField]
    private Vector3 _useItemPos;
    private NavMeshAgent _agent;
    private AM1.Nav.NavController _navController;
    private NavMeshObstacle _obstacle;
    // 次に移動する場所
    private Vector3 _targetPos;
    // 次に移動する場所がstartPosかendPosかどうかのフラグ
    bool _isToStart = true;
    // アイテム使用されているか
    bool _isUseItem = false;
    public GameObject flower2UI;
    void Start()
    {
        _obstacle = GetComponent<NavMeshObstacle>();
        _agent = GetComponent<NavMeshAgent>();
        _navController = GetComponent<AM1.Nav.NavController>();
        // 初期状態はstartPosに移動するようにする
        _targetPos = _startPos;
        //_agent.SetDestination(_targetPos);
        _navController.SetDestination(_targetPos);
    }    
        
    void OnTriggerEnter (Collider collider)
    {
        if (_isUseItem)
        {
            return;
        }
        //当たったプレイヤーがアイテムを持っていたら移動する
        if (collider.CompareTag ("Player"))
        {
            _agent.enabled = false;
            _obstacle.enabled = true;
            var player = collider.GetComponent<Player2Controller>();
            // プレイヤーにアイテムを持っているかどうかのフラグと取得する関数を用意しておく
             if (player.IsObstacleItem2())
             {
                 _isUseItem = true;
                 _obstacle.enabled = false;
                 _isUseItem = true;
                 //_agent.SetDestination(_useItemPos);
                 _navController.SetDestination(_useItemPos);
                 flower2UI.SetActive(false);
                 GetComponent<AudioSource>().Play();
             }
        }
    }

    void OnTriggerExit (Collider collider)
    {
       Debug.Log("exit");
        if (_isUseItem)
        {
            return;
        }
        if (collider.CompareTag ("Player"))
        {
            _obstacle.enabled = false;
            LateTarget();
        }
    }

    async void LateTarget()
    {
        await Task.Delay(100);
        _agent.enabled = true;
        if (_isToStart)
        {
            _targetPos = _startPos;
        }
        else
        {
            _targetPos = _endPos;
        }
        //_agent.SetDestination(_targetPos);
        _navController.SetDestination(_targetPos);
    }

    void Update()
    {
        // アイテムが使われた後は完了位置まで移動するだけなのでそれ以降の処理はしないようにする
        if (_isUseItem)
        {
            return;
        }
        // ターゲットの位置まで1以内になれば新しい位置に移動する
        if (_navController.IsReached)
        {
            if (_isToStart)
            {
                _isToStart = false;
                _targetPos = _endPos;
            } else {
                _isToStart = true;
                _targetPos = _startPos;
            }
            //_agent.SetDestination(_targetPos);
            _navController.SetDestination(_targetPos);
        }
    }
}