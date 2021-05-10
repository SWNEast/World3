using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InputAdvanced : MonoBehaviour
{
    [SerializeField] GameObject panel;
    [SerializeField] TMP_Text header;
    [SerializeField] GameObject popPanel;
    [SerializeField] GameObject capPanel;
    [SerializeField] GameObject agrPanel;
    [SerializeField] GameObject resPanel;
    [SerializeField] GameObject polPanel;
    public int speed;
    public void Expand(string sector)
    {
        switch (sector)
        {
            case "Pop": header.text = "Advanced Population Settings"; popPanel.SetActive(true); break;
            case "Cap": header.text = "Advanced Capital Settings"; capPanel.SetActive(true); break;
            case "Agr": header.text = "Advanced Agriculture Settings"; agrPanel.SetActive(true); break;
            case "Res": header.text = "Advanced Nonrenewable Resource Settings"; resPanel.SetActive(true); break;
            case "Pol": header.text = "Advanced Persistent Pollution Settings"; polPanel.SetActive(true); break;
        }
        StartCoroutine(Wipe(true));
    }

    public void Close()
    {
        StartCoroutine(Wipe(false));
    }
    public IEnumerator Wipe(bool dir)
    {
        if (dir)
        {
            panel.SetActive(true);
            for (int i = 0; i * speed * 2 < 1445; i++)
            {
                panel.GetComponent<RectTransform>().sizeDelta = new Vector2(panel.GetComponent<RectTransform>().sizeDelta.x + 2 * speed, panel.GetComponent<RectTransform>().sizeDelta.y);
                panel.transform.localPosition = new Vector2(panel.transform.localPosition.x - speed, panel.transform.localPosition.y);
                yield return null;
            }
            panel.GetComponent<RectTransform>().sizeDelta = new Vector2(1645, panel.GetComponent<RectTransform>().sizeDelta.y);
            panel.transform.localPosition = new Vector2(0, panel.transform.localPosition.y);
        } else
        {
            
            for (int i = 0; i * speed * 2 < 1445; i++)
            {
                panel.GetComponent<RectTransform>().sizeDelta = new Vector2(panel.GetComponent<RectTransform>().sizeDelta.x - 2 * speed, panel.GetComponent<RectTransform>().sizeDelta.y);
                panel.transform.localPosition = new Vector2(panel.transform.localPosition.x + speed, panel.transform.localPosition.y);
                yield return null;
            }
            panel.GetComponent<RectTransform>().sizeDelta = new Vector2(200, panel.GetComponent<RectTransform>().sizeDelta.y);
            panel.transform.localPosition = new Vector2(722.5f, panel.transform.localPosition.y);
            panel.SetActive(false);
            HideAll();
        }

    }

    private void HideAll()
    {
        popPanel.SetActive(false);
        capPanel.SetActive(false);
        agrPanel.SetActive(false);
        resPanel.SetActive(false);
        polPanel.SetActive(false);
    }
}
