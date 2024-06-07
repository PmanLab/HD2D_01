using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //--- �C���X�^���X ---
    private Animator anime;     // �A�j���[�V�������

    //--- �ϐ��錾 ---
    float moveSpeed = 2.0f;     // �ړ����x
    bool isMove = false;

    //=== ���������� ===
    void Start()
    {
        anime = this.GetComponent<Animator>();
        if (anime == null) { Debug.Log("PlayerMove.cs�F�ʂ邾��͂�"); }
    }

    //=== �X�V���� ===
    void Update()
    {
        // ���������Ɛ��������̓��͂��擾���A���ꂼ��̈ړ����x��������
        float Xvalue = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        float Yvalue = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        // ���݂�X,Z�x�N�g���ɏ�̏����Ŏ擾�����l��n��
        Vector3 movedir = new Vector3(Xvalue, 0, Yvalue);

        //--- �ړ����͂������Ă��鎞�̃A�j���[�V���� ---
        if (Xvalue != 0 || Yvalue != 0)
        { isMove = true; }
        else
        { isMove = false; }
        //--- �ړ����Ă��� ---
        if(isMove)
        {
            anime.SetBool("Run", true);                                     // �ړ��A�j���[�V����
            transform.position += movedir;                                  // ���ݒl�擾�������l�𑫂��Ĉړ�����
            if (Xvalue < 0) { transform.forward = new Vector3(0, 0, 1); }   // ������
            if (Xvalue > 0) { transform.forward = new Vector3(0, 0, -1); }  // �E����
        }
        //--- �ړ����ĂȂ� ---
        else
        { anime.SetBool("Run", false); }
    }
}
