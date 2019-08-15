using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
/**
 *按钮功能的实现
 *修改时间：2019-08-13
 */
public class ButtonListener : MonoBehaviour
{
      private void Start()
      {
            
            GetComponent<Button>().onClick.AddListener(OnClick);
      }

      void OnClick()
      {
            if (this.name.Equals("开始游戏"))
            {
                  SceneManager.LoadScene("Scenes/SampleScene");
            }

            if (this.name.Equals("选项"))
            {
                  print("选项");
            }
            if (this.name.Equals("历史最高"))
            {
                  print("历史最高");
            }
            if (this.name.Equals("退出"))
            {
                  /*
                   * 程序退出
                   */
                  Application.Quit();
            }

            if (this.name.Equals("返回游戏"))
            {

                  GameObject canvas = GameObject.Find("Canvas");
                  canvas.SetActive(false);
                  Time.timeScale = 1;
            }

            if (this.name.Equals("重新开始"))
            {
                  Time.timeScale = 1;
                   SceneManager.LoadScene("Scenes/SampleScene");
                   //print("重新开始了");
            }

            if (this.name.Equals("退出游戏"))
            {
                  Application.Quit();
            }
      }


}
