using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class MoveObstacleController : MonoBehaviour
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
    // 次に移動する場所
    private Vector3 _targetPos;
    // 次に移動する場所がstartPosかendPosかどうかのフラグ
    bool _isToStart = true;
    // アイテム使用されているか
    bool _isUseItem = false;
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        // 初期状態はstartPosに移動するようにする
        _targetPos = _startPos;
        _agent.SetDestination(_startPos);
    }    
        
    void OnTriggerEnter (Collider collider)
    {
        //当たったプレイヤーがアイテムを持っていたら移動する
        if (collider.CompareTag ("Player"))
        {
            _agent.ResetPath();
            var player = collider.GetComponent<Player2Controller>();
            // プレイヤーにアイテムを持っているかどうかのフラグと取得する関数を用意しておく
            // if (player.IsObstacleItem())
            // {
                // _isUseItem = true;
                // _agent.SetDestination(_useItemPos);
            // }
        }
    }

    void OnTriggerExit (Collider collider)
    {
        Debug.Log("exit");
        if (collider.CompareTag ("Player"))
        {
            if (_isToStart)
            {
                _targetPos = _startPos;
            }
            else
            {
                _targetPos = _endPos;
            }
            _agent.SetDestination(_targetPos);
        }
    }

    void Update()
    {
        // アイテムが使われた後は完了位置まで移動するだけなのでそれ以降の処理はしないようにする
        if (_isUseItem)
        {
            return;
        }
        // ターゲットの位置まで1以内になれば新しい位置に移動する
        if (Vector3.Distance(transform.position, _targetPos) < 0.1f)
        {
            if (_isToStart)
            {
                _isToStart = false;
                _targetPos = _endPos;
            } else {
                _isToStart = true;
                _targetPos = _startPos;
            }
            _agent.SetDestination(_targetPos);
        }
    }
}