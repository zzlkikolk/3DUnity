using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCon : MonoBehaviour
{
    // Start is called before the first frame update
    //碰撞检测销毁方法
    private void OnCollisionEnter(Collision other)
    {
        //Debug.LogFormat("碰撞啦！！"+other.gameObject.tag);
        if (other.gameObject.tag.Equals("plane"))
        {
            Destroy(other.gameObject);
        }
    }
}
