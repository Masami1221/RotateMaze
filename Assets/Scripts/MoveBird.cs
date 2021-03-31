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
        transform.DOLocalMove(new Vector3(10.9f,-9.3f,34.8f), 5f)
        .OnComplete(() => {
            Debug.Log("letter");
           // 手紙を生成する
           // prefabで作ってInstatiate(xxxx)
           GameObject letter = Instantiate(letterPrefab) as GameObject;
           letter.transform.position = transform.position;
           // 上記で作った手紙をDoTweenで指定の場所に動かす
           letter.transform.DOLocalMove(new Vector3(12.3f,-21.7f,38.8f), 5f);
           
           // 上記の処理と同時に鳥をまたDoTweenで画面外に飛ばす
           transform.DOLocalMove(new Vector3(48f,32f,-18f), 5f);
        });
         
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
