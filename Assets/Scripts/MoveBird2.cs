using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MoveBird2 : MonoBehaviour
{
    public GameObject letterPrefab;
    void Start()
    {
        Debug.Log("test");
        // まずは手紙を落とす位置まで鳥をdotweenで動かす その位置を入れる
        transform.DOScale(new Vector3(0,0,0),0);//小さくしておいて、元の大きさに戻す
        transform.DOScale(new Vector3(0.05f,0.05f,0.05f),0.5f);
        transform.DOLocalMove(new Vector3(-0.5f,8.0f,-2.8f), 1.5f)
                 .SetEase(Ease.Linear)
                 //移動に緩急つけない
        .OnComplete(() => {
            Debug.Log("letter");
           // 手紙を生成する
           GameObject letter = Instantiate(letterPrefab, transform.position, Quaternion.Euler (-90f,0,-90f), transform.parent) as GameObject;
           //鳥が手紙を落とす位置で生成する
           // 上記で作った手紙をDoTweenで指定の場所に動かす
           letter.transform.DOLocalMove(new Vector3(-0.2f,5.4f,-2.8f), 2f);
           
           transform.DOScale(new Vector3(0,0,0),5.5f);
           // 上記の処理と同時に鳥をまたDoTweenで画面外に飛ばす
           transform.DOLocalMove(new Vector3(6.5f,6.0f,-2.8f), 1.5f)
                    .SetEase(Ease.Linear);
        });
         
    }

    void Update()
    {
        
    }
}
