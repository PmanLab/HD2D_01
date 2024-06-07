using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //--- インスタンス ---
    private Animator anime;     // アニメーション情報

    //--- 変数宣言 ---
    float moveSpeed = 2.0f;     // 移動速度
    bool isMove = false;

    //=== 初期化処理 ===
    void Start()
    {
        anime = this.GetComponent<Animator>();
        if (anime == null) { Debug.Log("PlayerMove.cs：ぬるだよはげ"); }
    }

    //=== 更新処理 ===
    void Update()
    {
        // 垂直方向と水平方向の入力を取得し、それぞれの移動速度をかける
        float Xvalue = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        float Yvalue = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        // 現在のX,Zベクトルに上の処理で取得した値を渡す
        Vector3 movedir = new Vector3(Xvalue, 0, Yvalue);

        //--- 移動入力が入っている時のアニメーション ---
        if (Xvalue != 0 || Yvalue != 0)
        { isMove = true; }
        else
        { isMove = false; }
        //--- 移動している ---
        if(isMove)
        {
            anime.SetBool("Run", true);                                     // 移動アニメーション
            transform.position += movedir;                                  // 現在値取得をした値を足して移動する
            if (Xvalue < 0) { transform.forward = new Vector3(0, 0, 1); }   // 左向き
            if (Xvalue > 0) { transform.forward = new Vector3(0, 0, -1); }  // 右向き
        }
        //--- 移動してない ---
        else
        { anime.SetBool("Run", false); }
    }
}
