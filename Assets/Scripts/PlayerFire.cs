using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerFire : MonoBehaviour
{
    //�Ѿ˰���
    public GameObject bulletFactory;
    //�ѱ�
    public Transform trFirePos;
    //����ȿ������
    public GameObject fragmentFactory;

    public Transform trLeft, trRight;

    void Start()
    {
        trFirePos = Camera.main.transform;
    }

    void Update()
    {
        Vector2 stickpos = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick, 
            OVRInput.Controller.LTouch);

            
        //1. ���࿡ ���콺 ���� ��ư�� ������
        if(Input.GetButtonDown("Fire1") || (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch)))
        {
            FireBullet();
        }

        //1. ���࿡ ���콺 ������ ��ư�� ������
        if(Input.GetButtonDown("Fire2") || (OVRInput.GetDown(OVRInput.Button.Two, OVRInput.Controller.RTouch)))
        {
            FireRay();
        }
    }

    void FireRay()
    {
        //2. ī�޶���ġ, ī�޶�չ��� ���� ������ Ray�� �����
        // Ray ray = new Ray(trFirePos.position, trFirePos.forward);
        Ray ray = new Ray(trRight.position, trRight.forward);

        //3. ���࿡ Ray�� �߻��ؼ� ��򰡿� �ε����ٸ�
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit))
        {
            //4. ����ȿ�����忡�� ����ȿ���� �����
            GameObject fragment = Instantiate(fragmentFactory);
            //5. ����ȿ���� �ε��� ��ġ�� ���´�
            fragment.transform.position = hit.point;
            //6. ����ȿ���� �չ����� �ε��� ��ġ�� normal ���ͷ� ����
            fragment.transform.forward = hit.normal;
            //7. 2�ʵڿ� �ı�����
            Destroy(fragment, 2);
            //8. 만약에 맞은 오브젝트가 Drone이면 파괴
            if(hit.transform.name.Contains("Drone"))
            {
                Destroy(hit.transform.gameObject);
            }
        }
    }


    void FireBullet()
    {
        //2. �Ѿ˰��忡�� �Ѿ��� �����.
        GameObject bullet = Instantiate(bulletFactory);
        //3. ������� �Ѿ��� �ѱ��� ���´�.
        bullet.transform.position = trRight.position;
        //4. ������� �Ѿ��� �չ����� �ѱ��� �չ������� �Ѵ�.
        bullet.transform.forward = trRight.forward;
    }
}
