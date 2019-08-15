using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Z : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject A, B;
    private Vector3 c;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 a = A.transform.position;
        Vector3 b = B.transform.position;
        c = (b-a).normalized;
        Quaternion quaternion=Quaternion.LookRotation(c);
        A.transform.rotation=Quaternion.RotateTowards(A.transform.rotation,quaternion,1f);
        if (Input.GetKey(KeyCode.W))
        {
            A.transform.Translate(Vector3.forward*Time.deltaTime*1f);
        }
    }
}
