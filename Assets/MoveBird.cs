using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MoveBird : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // まずは手紙を落とす位置まで鳥をdotweenで動かす その位置を入れる
        transform.DOLocalMove(new Vector3(48f,32f,-18f), 7f)
        .OnComplete(() => {
           // 手紙を生成する
           // prefabで作ってInstatiate(xxxx)
           
           // 上記で作った手紙をDoTweenで指定の場所に動かす
           
           // 上記の処理と同時に鳥をまたDoTweenで画面外に飛ばす
        });
        
        // transform.DOLocalMove(new Vector3(48f,32f,-18f), 7f);
        // 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
