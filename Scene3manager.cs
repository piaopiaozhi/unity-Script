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
    public void OnExitGame()//定义一个退出游戏的方法
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;//如果是在unity编译器中
#else
        Application.Quit();//否则在打包文件中
#endif
    }
}
