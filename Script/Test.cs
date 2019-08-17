using System;
using System.Collections;
using System.Collections.Generic;
using Script;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Test : MonoBehaviour
{
    public Texture texture;
    // Start is called before the first frame update
    //暂停菜单
    public GameObject canvas;

    //Shift键按下时长
    private float ShiftKeyTime = 0f;

    //空格键按下时长
    private float SpaceKeyTime = 0f;

    //转向速度
    private float Steering_speed = 1;

    //游戏对象
    private GameObject test;

    //刚体组件
    private Rigidbody rigidbody_Fj;

    //飞机机翼动画
    private Animator airfoil;

    //每一帧前进的距离
    private float TranslateSpeed = 10f;

    
    //飞机声音
    private AudioSource Audio;

    //飞机控制器
    private AirController ac;

    void Start()
    {
        canvas=GameObject.Find("Canvas");
        //如果游戏在运行，暂停菜单不显示
        if (Time.timeScale == 1)
        {
            canvas.SetActive(false);
        }
    
        Audio = GetComponent<AudioSource>();
        Audio.Pause();
        //音频从第1秒开始
        //double startTime = AudioSettings.dspTime + 1.0;       
        //Audio.PlayScheduled(startTime);

      
        test = GameObject.Find("FJ");
        ac = new AirController(test, Steering_speed);
        ac.TranslateSpeed1 = TranslateSpeed;
        //GameObject.Find("TestAir").SetActive(true);//设置游戏对象的是否激活(显示)
        airfoil = GameObject.Find("cacac").GetComponent<Animator>();
        airfoil.speed = 0f;
        //获取组件
        rigidbody_Fj = test.GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
        //前进
        if (Input.GetKey(KeyCode.W))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                ShiftKeyTime += Time.deltaTime;
                //test.transform.Rotate(Vector3.right*1);
            }

            ac.ForWard(TranslateSpeed * ShiftKeyTime);
        }
        
        
        //暂停
        
        if (Input.GetKey(KeyCode.Escape))
        {
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
               // Audio.Pause();
                canvas.SetActive(true);
            }

        }
        
        
        
        //后退
        if (Input.GetKey(KeyCode.S))
        {
            if (ShiftKeyTime > 0)
                ShiftKeyTime -= Time.deltaTime;
            ac.GoBack(TranslateSpeed * ShiftKeyTime);
        }

        //左转
        if (Input.GetKey(KeyCode.A))
        {
            ac.GoLeft();
        }

        //右转
        if (Input.GetKey(KeyCode.D))
        {
            ac.GoRight();
        }

        //上升(起飞)
        if (Input.GetKey(KeyCode.Space))
        {
            SpaceKeyTime += Time.deltaTime;
            rigidbody_Fj.drag = SpaceKeyTime * 1;
            airfoil.speed = SpaceKeyTime / 5;//机翼动画
            if (airfoil.speed <0.01&&airfoil.speed>0)
            {
                Audio.Play();
            }
            ac.Rise();
        }

        //下降
        if (Input.GetKey(KeyCode.LeftControl))
        {
            ac.Decline();
        }
    }

    #region 准心
     /*  
    //准心功能
    private void OnGUI()
    {
        
        //Rect rect = new Rect(Input.mousePosition.x-(texture.width>>1),Screen.height-Input.mousePosition.y-(texture.height>>1),texture.width,texture.height);
        GUI.DrawTexture(new Rect(510,200,50,50 ),texture);
    }
    */
    #endregion
    //前进代码

}
