using UnityEngine;

namespace Script
{
    public class AirController:Cotroller
    {
        //游戏对象
        private GameObject test;
        
        //转向速度
        private float Steering_speed;

        private float TranslateSpeed;

        public float TranslateSpeed1
        {
            get => TranslateSpeed;
            set => TranslateSpeed = value;
        }

        public AirController(GameObject test, float steeringSpeed)
        {
            this.test = test;
            this.Steering_speed = steeringSpeed;
        }
        public void ForWard(float TranslateSpeed)
        {
        
            /* 加速时调用  加速时 机头向下低*/
            //test.transform.Rotate(Vector3.right*Steering_speed,Space.Self);
            test.transform.Translate(Vector3.forward*Time.deltaTime*TranslateSpeed);
        }

        //左转向
        public void GoLeft()
        {
            test.transform.Rotate(Vector3.down*Steering_speed,Space.Self);
        }
    
        //右转向
        public void GoRight()
        {
            test.transform.Rotate(Vector3.up*Steering_speed,Space.Self);
        }

        public void GoBack(float TranslateSpeed)
        {
            test.transform.Translate(Vector3.back*Time.deltaTime*TranslateSpeed);
        }

        public void Rise()
        {
            test.transform.Translate(Vector3.up*Time.deltaTime*TranslateSpeed);
        }

        public void Decline()
        {
            test.transform.Translate(Vector3.down*Time.deltaTime*TranslateSpeed);
        }

        //发射导弹
        public void launch()
        {
            
        }
    }
}