using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MoveBird : MonoBehaviour
{
    public GameObject letterPrefab;
    void Start()
    {
        Debug.Log("test");
        // まずは手紙を落とす位置まで鳥をdotweenで動かす その位置を入れる
        transform.DOLocalMove(new Vector3(10.5f,12f,68f), 3f)
                 .SetEase(Ease.Linear)
                 //移動に緩急つけない
        .OnComplete(() => {
            Debug.Log("letter");
           // 手紙を生成する
           GameObject letter = Instantiate(letterPrefab) as GameObject;
           letter.transform.position = transform.position;
           // 上記で作った手紙をDoTweenで指定の場所に動かす
           letter.transform.DOLocalMove(new Vector3(0f,22.5f,-8.67f), 4f);
           
           // 上記の処理と同時に鳥をまたDoTweenで画面外に飛ばす
           transform.DOLocalMove(new Vector3(50f,-10f,68f), 4f)
                    .SetEase(Ease.Linear);
        });
         
    }

    void Update()
    {
        
    }
}
