using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouletteController : MonoBehaviour
{
    public float rotSpeed = 0;   //回転速度
    public bool rotStop = false;//ボタンのON・OFFを示すブール型の変数

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //マウスが押されたら回転速度を設定する
        if (Input.GetMouseButtonDown(0) && this.rotSpeed == 0)
        {
            this.rotSpeed = 5;
            this.rotStop = false;// ストップ指令を解除(追加)
        }
        if (this.rotStop == true)//回転指令が入ったときに回転を止める(追加)
        {
            this.rotSpeed *= 0.96f;
            if (this.rotSpeed < 1.0e-6)
            {
                this.rotSpeed = 0;
            }
        }
        //回転速度分、ルーレットを回転させる
        transform.Rotate(0, 0, this.rotSpeed);
        

    }
    /*ボタンが押された際のルーレットを止めるメソッド
      ボタンと紐づける為、public型の宣言を使用*/
    public void Stop()
    {
        this.rotStop = true;
    }

    public void Speedup() //回転速度Up(追加)
    {
        this.rotSpeed += 1;

        if (this.rotSpeed > 10)
        {
            this.rotSpeed = 10;
        }
    }

    public void Speeddown()// 回転速度Down(追加)
    {
        this.rotSpeed -= 1;
        if (this.rotSpeed < 1)
        {
            this.rotSpeed = 1;
        }
    }
}
