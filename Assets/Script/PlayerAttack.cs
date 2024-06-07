using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    //--- �C���X�^���X ---
    private Animator anim;      // �A�j���[�V�������

    bool isAttack = false;

    void Start()
    {
        anim = this.GetComponent<Animator>();
        if (anim == null) { Debug.Log("PlayerAttack.cs�F�ʂ邾��͂�"); }
    }

    void Update()
    {
        // �U���t���O(�J�n)
        if (Input.GetKeyDown(KeyCode.K))
        {
            isAttack = true;
            anim.SetBool("Attack", true);
        }

        // �U���t���O(�I��)
        if (!anim.GetBool("Attack"))
        { isAttack = false; }


    }

    void AttackEnd()
    {
        anim.SetBool("Attack", false);     // �U�����Ă��Ȃ�
    }
}
