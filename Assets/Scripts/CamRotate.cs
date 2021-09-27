using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CamRotate : MonoBehaviour
{
    //ȸ����
    float rotX;
    float rotY;
    //ȸ���ӷ�
    public float rotSpeed = 200;

    void Start()
    {
        //ȸ���� �ʱ�ȭ
        rotX = -transform.localEulerAngles.x;
        rotY = transform.localEulerAngles.y;
    }

    void Update()
    {
        //���콺 �����ӿ� ���� ī�޶� ȸ����Ű�� �ʹ�.
        //1. ���콺�� �Է��� ����
        float mx = Input.GetAxis("Mouse X");
        float my = Input.GetAxis("Mouse Y");

        //2. ���콺�� �Է°��� ���� (ȸ����)
        rotX += my * rotSpeed * Time.deltaTime;
        rotY += mx * rotSpeed * Time.deltaTime;

        //���� ȸ���� -60 ~ 60 ����
        rotX = Mathf.Clamp(rotX, -60, 60);

        //3. ī�޶��� ȸ������ ���������� ����
        transform.localEulerAngles = new Vector3(-rotX, rotY, 0);
    }
}
 