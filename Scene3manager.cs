using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene3manager : MonoBehaviour
{
    public GameObject mesh;
    SpriteRenderer sp;
    float time=0;
    private void Awake()
    {
        sp = mesh.GetComponent<SpriteRenderer>();
        
    }
    private void Update()
    {
        if(sp.color.a>0)
        {
            time += Time.deltaTime/5;
            sp.color = new Color(0, 0, 0, 1 - time);
        }
        if (Input.GetKey(KeyCode.Q))
        {
               OnExitGame();
        }

        
            
        
    }
    public void OnExitGame()//����һ���˳���Ϸ�ķ���
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;//�������unity��������
#else
        Application.Quit();//�����ڴ���ļ���
#endif
    }
}
