using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    public GameObject player;
    private Vector3 targetPosition;
    float leftBorder = -11.45f;
    float downBorder = -4.26f;
    float upBorder = 4.29f;
    float rightBorder = 11.45f;

    Switch sw;
    public GameObject Handle;
    Meteor me;
    public GameObject Meteor;
    public GameObject MeteorTrance;
    float time=0;
    private void Start()
    {
        sw = Handle.GetComponent<Switch>();
        me = Meteor.GetComponent<Meteor>();
    }

    void LateUpdate()
    {

        if(sw.meteorstart && !me.finish)
        {
            targetPosition = new Vector3(MeteorTrance.transform.position.x, MeteorTrance    .transform.position.x ,- 10);

            // 使用Mathf.Clamp确保摄像机位置不超出边界
            float clampedX = Mathf.Clamp(targetPosition.x, leftBorder, rightBorder);
            float clampedY = Mathf.Clamp(targetPosition.y, downBorder, upBorder);
            time += Time.deltaTime;
            transform.position = Vector3.Lerp(transform.position, new Vector3(clampedX, clampedY, -10),time/10);
        }
        else
        {
            targetPosition = new Vector3(player.transform.position.x, player.transform.position.y, -10);

            // 使用Mathf.Clamp确保摄像机位置不超出边界
            float clampedX = Mathf.Clamp(targetPosition.x, leftBorder, rightBorder);
            float clampedY = Mathf.Clamp(targetPosition.y, downBorder, upBorder);

            transform.position = new Vector3(clampedX, clampedY, -10);
        }
        
    }
}
