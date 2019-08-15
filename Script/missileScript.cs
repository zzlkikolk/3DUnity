using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class missileScript : MonoBehaviour
{
    //private int Speed = 20;

    //被发射的
    public GameObject Bullet;
    //复制的导弹
    private GameObject b;
    
    public GameObject B;
    //发射速度
    public float Bullet_Speed = 80;
    //发射的地方
    //public Transform FPomit;
    private Rigidbody clone;
    // Start is called before the first frame update
    void Start()
    {
        //Debug.LogFormat("导弹大小"+Bullet.transform.localScale);
    }

    // Update is called once per frame
    void Update()
    {
            J();
    }

    //发射
    private void J()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            b = GameObject.Instantiate(Bullet,new Vector3(transform.position.x,transform.position.y,transform.position.z),transform.rotation);
            Rigidbody rgd = b.GetComponent<Rigidbody>();//获得游戏刚体组件
           // Transform tra = b.GetComponent<Transform>();
            rgd.velocity = transform.forward * Bullet_Speed;//设置速度velocity
            rgd.isKinematic = false;

        }
    }
    //设置导弹跟踪
    private  void chaseafter(GameObject B)
    {
        Vector3 a = Bullet.transform.position;
        Vector3 b = B.transform.position;
        Vector3 c = (b-a).normalized;
        Quaternion quaternion=Quaternion.LookRotation(c);
        Bullet.transform.rotation=Quaternion.RotateTowards(Bullet.transform.rotation,quaternion,1f);
        if (Input.GetKey(KeyCode.W))
        {
            Bullet.transform.Translate(Vector3.forward*Time.deltaTime*1f);
        }
    }
    //碰撞检测销毁方法
    private void OnCollisionEnter(Collision other)
    {
        //Debug.LogFormat("调用了销毁方法");
        //Debug.LogFormat("Tag是"+other.gameObject.tag);
        if (other.gameObject.tag .Equals("plane") )
        {
            
            Destroy(b);
        }
    }

}
