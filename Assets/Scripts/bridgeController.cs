using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.AI;

public class bridgeController : MonoBehaviour
{
    public bool item = false;
    GameObject part1;
    GameObject part2;
    GameObject part3;
    GameObject part4;
    GameObject part5;
    [SerializeField]
    private NavMeshSurface _surface;
    
    // Start is called before the first frame update
    void Start()
    {
        //GameObject BridgeParts = GameObject.Find("BridgeParts");
        this.part1 = GameObject.Find("bridge1");
        this.part2 = GameObject.Find("bridge2");
        this.part3 = GameObject.Find("bridge3");
        this.part4 = GameObject.Find("bridge4");
        this.part5 = GameObject.Find("bridge5");
        //this.part1.transform.DOScalse(new Vector3(0,0,0),0); 
        //小さくしておいて橋を動かすときに大きくする。ここで0にしておくとエラーになります。
    }

    // Update is called once per frame
    void Update()
    {    
        
    }
    //当たり判定をチェックする
    void OnTriggerEnter(Collider other)
    {
        //プレイヤーがアイテムを持っているかチェックする
        //1.プレイヤーの情報を取得
        var player = other.gameObject;
        var playerController = player.GetComponent<PlayerController>();
        if (playerController == null)
        {
            return;
        }
        //2. プレイヤーがアイテムを持っているかを確認
        if (playerController.getItem() == true)
        {
            //3.持っていたらオブジェクトを動かす
            Debug.Log("Go ahead");
            this.part1.transform.DOLocalMove(new Vector3(20.27f,-8.88f, -18.94f), 1f);
            //this.part1.transform.DOScalse(new Vector3(200f,120f,20f),1f); 元の大きさにする。
            this.part2.transform.DOLocalMove(new Vector3(24.27f,-8.88f, -18.94f), 1.5f);
            this.part3.transform.DOLocalMove(new Vector3(28.27f,-8.88f, -18.94f), 2f);
            this.part4.transform.DOLocalMove(new Vector3(32.27f,-8.88f, -18.94f), 2.5f);
            this.part5.transform.DOLocalMove(new Vector3(36.27f,-8.88f, -18.94f), 3f);
            //GetComponent<NavMeshSurface> ().Bake ();
             //_surface.BuildNavMesh();
        }
    }
}
