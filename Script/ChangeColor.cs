using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnGUI()
    {
        if (GUILayout.Button("ChangeColor"))
        {
            this.GetComponent<MeshRenderer>().material.color=Color.green;
        }

        if (GUILayout.Button("GetAllComponent"))
        {
            //获取所有组件是GetCompoonents
            var allComponent = this.GetComponents<Component>();
            foreach (var item in allComponent)
            {
                print(item.GetType());
            }
        }

        if (GUILayout.Button("GetCompoentsChilder"))
        {
            var ChildComponent = this.GetComponentsInChildren<MeshRenderer>();
            foreach (var item in ChildComponent)
            {
                item.material.color=Color.cyan;
            }
        }

        if (GUILayout.Button("LookGameObjectPosittion"))
        {
            Debug.Log("这是方块B在世界中的坐标"+this.transform.position);
        }
    }
}
