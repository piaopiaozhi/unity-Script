using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TraceManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject lineRenderpre;
    public Transform player;
    public float cd = 0.1f;

    private List<List<Vector3>> tracePointsList = new List<List<Vector3>>();
    private List<LineRenderer> lineRenderers = new List<LineRenderer>();
    private int clRenderIndex = 0;
    private float lastTraceTime=0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.J))
        {
            CreateNewLineRenderer();
            clRenderIndex = lineRenderers.Count - 1;
        }
        if(Input.GetKey(KeyCode.J))
        {
            if(Time.time - lastTraceTime > cd)
            {
                tracePointsList[clRenderIndex].Add(player.transform.position);
                lineRenderers[clRenderIndex].positionCount = tracePointsList[clRenderIndex].Count;
                lineRenderers[clRenderIndex].SetPositions(tracePointsList[clRenderIndex].ToArray());
                lastTraceTime = Time.time;
            }
        }
    }

    void CreateNewLineRenderer()
    {
        GameObject newLineRenderer = Instantiate(lineRenderpre, Vector3.zero, Quaternion.identity);
        LineRenderer lineRenderer = newLineRenderer.GetComponent<LineRenderer>();
        lineRenderers.Add(lineRenderer);
        tracePointsList.Add(new List<Vector3>());
    }
}
