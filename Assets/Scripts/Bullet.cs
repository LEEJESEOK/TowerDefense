using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //속도
    public float speed = 5;

    //폭발효과공장
    public GameObject exploFactory;

    void Start()
    {
        
    }

    void Update()
    {
        //자신의 앞방향으로 이동하고 싶다
        //p = p0 + vt
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        //1. 폭발효과공장에서 폭발효과를 만든다.
        GameObject explo = Instantiate(exploFactory);
        //2. 만든효과를 나(Bullet)의위치에 놓는다
        explo.transform.position = transform.position;
        //3. 3초뒤에 만든효과를 없앤다
        Destroy(explo, 3);
        //4. 나를 없앤다
        Destroy(gameObject);
    }
}
