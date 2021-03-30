using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bridgeController : MonoBehaviour
{
    public bool item = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {    

    }
    //当たり判定をチェックする
    void OnCollisionEnter(Collision collision)
    {
        //プレイヤーがアイテムを持っているかチェックする
        //1.プレイヤーの情報を取得
        var player = collision.gameObject;
        //2. プレイヤーがアイテムを持っているかを確認
        if (player.GetComponent<PlayerController>().getItem() == true)
        {
            //3.持っていたらオブジェクトを動かす
    
            Debug.Log("Go ahead");
        }
    }
}
