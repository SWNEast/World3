using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WindowGraph : MonoBehaviour
{
    [SerializeField] private Sprite circleSprite;
    [SerializeField] private GameObject block;
    [SerializeField] private GameObject window;
    private RectTransform graphContainer;
    [SerializeField] private GameObject graphPane;
    [SerializeField] private Sim sim;
    public int dotsSkipped;
    public float lineWidth;
    public Material lineMat;


    public List<GameObject> graph1Line = new List<GameObject>();
    private List<GameObject> graph2Line = new List<GameObject>();
    private List<GameObject> graph3Line = new List<GameObject>();
    private List<GameObject> graph4Line = new List<GameObject>();
    private List<GameObject> graph5Line = new List<GameObject>();

    private LoadGraphs graphs;
    private float yMax;


    private void Awake()
    {
        graphContainer = window.transform.Find("GraphContainer").GetComponent<RectTransform>();
    }

    public void Update()
    {
        if (sim.TIME.Count > 0 && block.activeInHierarchy)
        {
            block.SetActive(false);
        }
        else if (sim.TIME.Count == 0 && !block.activeInHierarchy)
        {
            block.SetActive(true);
        }
    }

    public void CreateGraph(List<float> graph, int graphID, float yMax)
    {
        Color color;
        List<GameObject> lineList;
        switch (graphID)
        {
            case 0: color = new Color(1, 0, 0); lineList = graph1Line; break;
            case 1: color = new Color(0, 1, 0); lineList = graph2Line; break;
            case 2: color = new Color(0, 0, 1); lineList = graph3Line; break;
            case 3: color = new Color(1, 1, 0); lineList = graph4Line; break;
            case 4: color = new Color(1, 0, 1); lineList = graph5Line; break;
            default: color = new Color(0, 0, 0); lineList = null; break;
        }
        StartCoroutine(ShowGraph(graph, yMax, color, lineList));
    }

    public void ClearGraph(int graphID)
    {
        List<GameObject> line;
        switch (graphID)
        {
            case 0: line = graph1Line; break;
            case 1: line = graph2Line; break;
            case 2: line = graph3Line; break;
            case 3: line = graph4Line; break;
            case 4: line = graph5Line; break;
            default: line = new List<GameObject>(); break;
        }
        foreach (GameObject go in line)
        {
            Destroy(go);
        }
        line.Clear();
    }

    public void ClearAll()
    {
        ClearGraph(0);
        ClearGraph(1);
        ClearGraph(2);
        ClearGraph(3);
        ClearGraph(4);
    }

    private GameObject CreateCircle(Vector2 anchoredPosition, Color color) 
    {
        GameObject gameObject = new GameObject("circle", typeof(Image));
        gameObject.transform.SetParent(graphContainer, false);
        gameObject.GetComponent<Image>().sprite = circleSprite;
        gameObject.GetComponent<Image>().color = color;
        RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
        rectTransform.anchoredPosition = anchoredPosition;
        rectTransform.sizeDelta = new Vector2(0, 0);
        rectTransform.anchorMin = new Vector2(0, 0);
        rectTransform.anchorMax = new Vector2(0, 0);
        return gameObject;
    }

    private IEnumerator ShowGraph(List<float> valueList, float yMax, Color color, List<GameObject> objectList)
    {
        float graphHeight = graphContainer.sizeDelta.y;
        float yMaximum = yMax;
        float xSize = graphContainer.sizeDelta.x / valueList.Count;

        GameObject lastCircleGameObject = null;
        if (dotsSkipped == 0) dotsSkipped = 1;
        for (int i = 1; i < valueList.Count; i += dotsSkipped)
        {
            float xPosition = xSize + i * xSize;
            float yPosition = (valueList[i] / yMaximum) * graphHeight;
            GameObject circleGameObject = CreateCircle(new Vector2(xPosition, yPosition), color);
            objectList.Add(circleGameObject);
            if (lastCircleGameObject != null)
            {
                GameObject connection = CreateDotConnection(lastCircleGameObject, circleGameObject, color);
                objectList.Add(connection);
            }
            lastCircleGameObject = circleGameObject;
            yield return null;
            
        }
    }

    private GameObject CreateDotConnection(GameObject dotPositionA, GameObject dotPositionB, Color color)
    {
        GameObject gameObject = new GameObject("dotConnection");
        gameObject.transform.SetParent(graphContainer, false);
        gameObject.AddComponent<LineRenderer>();
        LineRenderer lr = gameObject.GetComponent<LineRenderer>();
        lr.material = lineMat;
        lr.startColor = color;
        lr.endColor = color;
        lr.SetPosition(0, dotPositionA.transform.position);
        lr.SetPosition(1, dotPositionB.transform.position);
        lr.widthMultiplier = lineWidth;
        lr.sortingOrder = 1;
        return gameObject;
    }

    public void Fade(int ID)
    {
        List<GameObject> line;
        switch (ID)
        {
            case 1: line = graph1Line; break;
            case 2: line = graph2Line; break;
            case 3: line = graph3Line; break;
            case 4: line = graph4Line; break;
            case 5: line = graph5Line; break;
            default: line = new List<GameObject>(); break;
        }

        foreach (GameObject ob in line)
        {
           if(ob.GetComponent<Image>() != null)
           {
                Color color = ob.GetComponent<Image>().color;
                if (color.a == 1)
                {
                    ob.GetComponent<Image>().color = new Color(color.r, color.g, color.b, 0.5f);
                } else
                {
                    ob.GetComponent<Image>().color = new Color(color.r, color.g, color.b, 1);
                }
           } else if (ob.GetComponent<LineRenderer>() != null)
            {
                LineRenderer lr = ob.GetComponent<LineRenderer>();
                Color color = lr.startColor;
                if (color.a == 1)
                {
                    lr.startColor = new Color(color.r, color.g, color.b, 0.5f);
                    lr.endColor = new Color(color.r, color.g, color.b, 0.5f);
                } else
                {
                    lr.startColor = new Color(color.r, color.g, color.b, 1);
                    lr.endColor = new Color(color.r, color.g, color.b, 1);
                }
            }
        }
    }
}
