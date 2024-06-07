using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    //--- インスタンス ---
    private Animator anim;      // アニメーション情報

    bool isAttack = false;

    void Start()
    {
        anim = this.GetComponent<Animator>();
        if (anim == null) { Debug.Log("PlayerAttack.cs：ぬるだよはげ"); }
    }

    void Update()
    {
        // 攻撃フラグ(開始)
        if (Input.GetKeyDown(KeyCode.K))
        {
            isAttack = true;
            anim.SetBool("Attack", true);
        }

        // 攻撃フラグ(終了)
        if (!anim.GetBool("Attack"))
        { isAttack = false; }


    }

    void AttackEnd()
    {
        anim.SetBool("Attack", false);     // 攻撃していない
    }
}
