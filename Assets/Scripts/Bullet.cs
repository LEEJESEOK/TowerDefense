using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //�ӵ�
    public float speed = 5;

    //����ȿ������
    public GameObject exploFactory;

    void Start()
    {
        
    }

    void Update()
    {
        //�ڽ��� �չ������� �̵��ϰ� �ʹ�
        //p = p0 + vt
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        //1. ����ȿ�����忡�� ����ȿ���� �����.
        GameObject explo = Instantiate(exploFactory);
        //2. ����ȿ���� ��(Bullet)����ġ�� ���´�
        explo.transform.position = transform.position;
        //3. 3�ʵڿ� ����ȿ���� ���ش�
        Destroy(explo, 3);
        //4. ���� ���ش�
        Destroy(gameObject);
    }
}
