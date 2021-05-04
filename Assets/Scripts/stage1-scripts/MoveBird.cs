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
        transform.DOScale(new Vector3(0,0,0),0);//小さくしておいて、元の大きさに戻す
        transform.DOScale(new Vector3(0.3f,0.3f,0.3f),0.8f);
        transform.DOLocalMove(new Vector3(12f,0f,33f), 3f)
                 .SetEase(Ease.Linear)
                 //移動に緩急つけない
        .OnComplete(() => {
            Debug.Log("letter");
           // 手紙を生成する
           GameObject letter = Instantiate(letterPrefab, transform.position, Quaternion.Euler (-90f,0,0), transform.parent) as GameObject;
           //letter.transform.position = new Vector3(12f,0f,33f);//鳥が手紙を落とす位置で生成する
           // 上記で作った手紙をDoTweenで指定の場所に動かす
           letter.transform.DOLocalMove(new Vector3(12.6f,-21.9f,36.5f), 4f);
           
           transform.DOScale(new Vector3(0,0,0),5.5f);
           // 上記の処理と同時に鳥をまたDoTweenで画面外に飛ばす
           transform.DOLocalMove(new Vector3(72f,-24f,33f), 5.5f)
                    .SetEase(Ease.Linear);
        });
         
    }

    void Update()
    {
        
    }
}
