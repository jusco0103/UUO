using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float speed = 4f; //歩くスピード
    private Rigidbody2D rigidbdy2D;
    private Animator anim;

	// Use this for initialization
	void Start () {
        //各コンポーネントをキャッシュしておく
        anim = GetComponent<Animator>();
        rigidbdy2D = GetComponent<Rigidbody2D>();
	}
	
    void FixedUpdate()
    {
        //左キー: -1、右キー: 1
        float x = Input.GetAxisRaw("Horizontal");
        //左か右を入力したら
        if (x != 0)
        {
            //入力方向へ移動
            rigidbdy2D.velocity = new Vector2(x * speed, rigidbdy2D.velocity.y);
            //localScale.xを-1にすると画像が反転する
            Vector2 temp = transform.localScale;
            temp.x = x;
            transform.localScale = temp;
            //Wait→Dash
            anim.SetBool("Dash", true);
            //左も右も入力していなかったら
        }
        else
        {
            //横移動の速度を0にしてピタッと止まるようにする
            rigidbdy2D.velocity = new Vector2(0, rigidbdy2D.velocity.y);
            //Dash→Wait
            anim.SetBool("Dash", false);
        }
    }
}