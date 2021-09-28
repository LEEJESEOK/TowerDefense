using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandController : MonoBehaviour
{
    public Transform trRight;

    Transform trCatchObject;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        CatchObject();

        DropObject();

    }

    void CatchObject()
    {
        // 1. 오른쪽 컨트롤러의 그랩버튼을 누르면
        if (OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger))
        {
            // 2. 오른손위치, 오른손 앞방향으로 나가는 Ray를 만든다
            Ray ray = new Ray(trRight.position, trRight.forward);
            RaycastHit hit;
            LayerMask layer = LayerMask.GetMask("Catchable");
            // 3. Ray가 어딘가에 부딪힌다면
            if (Physics.Raycast(ray, out hit, 100, layer))
            {
                // 4. 부딪힌 물체를 잡는다(setparent)
                hit.transform.SetParent(trRight.transform);
                // 5. 잡은 물체를 저장
                trCatchObject = hit.transform;
                // 잡은 물체의 rigidbody, isKinematic : true
                SetKinematic(true);
            }
        }
    }

    void DropObject()
    {
        // 1. 오른쪽 그랩버튼을 떼면
        if (OVRInput.GetUp(OVRInput.Button.PrimaryHandTrigger))
        {
            if (trCatchObject == null)
                return;

            // 잡은 물체의 rigidbody, isKinematic : false
            SetKinematic(false);
            // 2. 잡은 물체를 놓는다
            trCatchObject.parent = null;
            // 3. 잡은 물체 null로 변경
            trCatchObject = null;
        }
    }

    void SetKinematic(bool enable)
    {
        trCatchObject.GetComponent<Rigidbody>().isKinematic = enable;
    }
}
