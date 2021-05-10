using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class LoadGraphs : MonoBehaviour
{
    public GameObject panel;
    [SerializeField] private WindowGraph windowGraph;
    [SerializeField] private RunSim runSim;
    private List<float> graph;
    public List<Sim> sims = new List<Sim>();

    [SerializeField] private Button selectBtn;
    [SerializeField] private Button sim1Btn;
    [SerializeField] private Button sim2Btn;
    [SerializeField] private Button sim3Btn;
    [SerializeField] private Button sim4Btn;
    [SerializeField] private Button sim5Btn;

    [SerializeField] private TMP_Text x1;
    [SerializeField] private TMP_Text x2;
    [SerializeField] private TMP_Text x3;
    [SerializeField] private TMP_Text x4;
    [SerializeField] private TMP_Text x5;
    [SerializeField] private TMP_Text x6;
    [SerializeField] private TMP_Text x7;
    [SerializeField] private TMP_Text x8;
    [SerializeField] private TMP_Text x9;
    [SerializeField] private TMP_Text x10;
    [SerializeField] private TMP_Text x11;
    [SerializeField] private TMP_Text y1;
    [SerializeField] private TMP_Text y2;
    [SerializeField] private TMP_Text y3;
    [SerializeField] private TMP_Text y4;
    [SerializeField] private TMP_Text y5;
    [SerializeField] private TMP_Text xHeader;
    [SerializeField] private TMP_Text yHeader;

    [SerializeField] private Image graphBlock;
    [SerializeField] private GameObject graphContainer;
    [SerializeField] private GameObject graphSelect;

    private void Update()
    {
        if (graphSelect.activeInHierarchy  || (windowGraph.graph1Line.Count == 0 && !graphBlock.gameObject.activeInHierarchy))
        {
            graphBlock.gameObject.SetActive(true);
            graphContainer.SetActive(false);
        } else if (windowGraph.graph1Line.Count != 0 && graphBlock.gameObject.activeInHierarchy) {
            graphBlock.gameObject.SetActive(false);
            graphContainer.SetActive(true);
        }
    }
    public void Open()
    {
        if (panel != null)
        {
            panel.SetActive(true);
        }
    }

    public void Close()
    {
        if (panel != null)
        {
            panel.SetActive(false);
            
        }
    }

    public void DrawGraph(string graphName)
    {
        windowGraph.ClearAll();
        int id = 0;
        List<float> maxes = new List<float>();
        
        float yMax = 0;
        float pow = 0;
        string yUnit = "";
        switch (graphName)
        {
            case "Total Pop":
                yUnit = "People";
                foreach (Sim sim in sims)
                {
                    maxes.Add(FindMax(sim.POP));
                }
                yMax = FindMax(maxes);
                (yMax, pow) = RoundMax(yMax);
                foreach (Sim sim in sims) 
                { 
                    windowGraph.CreateGraph(sim.POP, id, yMax * (float)Math.Pow(10, pow)); 
                    id++; 
                }
                break;
            case "Death":
                yUnit = "People Per Year";
                foreach (Sim sim in sims)
                {
                    maxes.Add(FindMax(sim.D));
                }
                yMax = FindMax(maxes);
                (yMax, pow) = RoundMax(yMax);
                foreach (Sim sim in sims)
                {
                    windowGraph.CreateGraph(sim.D, id, yMax * (float)Math.Pow(10, pow));
                    id++;
                }
                break;
            case "Birth":
                yUnit = "People Per Year";
                foreach (Sim sim in sims)
                {
                    maxes.Add(FindMax(sim.B));
                }
                yMax = FindMax(maxes);
                (yMax, pow) = RoundMax(yMax);
                foreach (Sim sim in sims)
                {
                    windowGraph.CreateGraph(sim.B, id, yMax * (float) Math.Pow(10,pow));
                    id++;
                }
                break;
            case "Family Size":
                yUnit = "People";
                foreach (Sim sim in sims)
                {
                    maxes.Add(FindMax(sim.SFSN));
                }
                yMax = FindMax(maxes);
                (yMax, pow) = RoundMax(yMax);
                foreach (Sim sim in sims)
                {
                    windowGraph.CreateGraph(sim.SFSN, id, yMax * (float) Math.Pow(10,pow));
                    id++;
                }
                break;
            case "Life Expectancy":
                yUnit = "Years";
                foreach (Sim sim in sims)
                {
                    maxes.Add(FindMax(sim.LE));
                }
                yMax = FindMax(maxes);
                (yMax, pow) = RoundMax(yMax);
                foreach (Sim sim in sims)
                {
                    windowGraph.CreateGraph(sim.LE, id, yMax * (float) Math.Pow(10,pow));
                    id++;
                }
                break;
            case "Urban":
                yUnit = "Fraction of Population";
                foreach (Sim sim in sims)
                {
                    maxes.Add(FindMax(sim.FPU));
                }
                yMax = FindMax(maxes);
                (yMax, pow) = RoundMax(yMax);
                foreach (Sim sim in sims)
                {
                    windowGraph.CreateGraph(sim.FPU, id, yMax * (float) Math.Pow(10,pow));
                    id++;
                }
                break;
            case "Health":
                yUnit = "Dollars Per Person Per Year";
                foreach (Sim sim in sims)
                {
                    maxes.Add(FindMax(sim.EHSPC));
                }
                yMax = FindMax(maxes);
                (yMax, pow) = RoundMax(yMax);
                foreach (Sim sim in sims)
                {
                    windowGraph.CreateGraph(sim.EHSPC, id, yMax * (float) Math.Pow(10,pow));
                    id++;
                }
                break;
            case "Ind. Cap.":
                yUnit = "Dollars";
                foreach (Sim sim in sims)
                {
                    maxes.Add(FindMax(sim.IC));
                }
                yMax = FindMax(maxes);
                (yMax, pow) = RoundMax(yMax);
                foreach (Sim sim in sims)
                {
                    windowGraph.CreateGraph(sim.IC, id, yMax * (float) Math.Pow(10,pow));
                    id++;
                }
                break;
            case "Ind. Out.":
                yUnit = "Dollars Per Year";
                foreach (Sim sim in sims)
                {
                    maxes.Add(FindMax(sim.IO));
                }
                yMax = FindMax(maxes);
                (yMax, pow) = RoundMax(yMax);
                foreach (Sim sim in sims)
                {
                    windowGraph.CreateGraph(sim.IO, id, yMax * (float) Math.Pow(10,pow));
                    id++;
                }
                break;
            case "Ser. Cap.":
                yUnit = "Dollars";
                foreach (Sim sim in sims)
                {
                    maxes.Add(FindMax(sim.SC));
                }
                yMax = FindMax(maxes);
                (yMax, pow) = RoundMax(yMax);
                foreach (Sim sim in sims)
                {
                    windowGraph.CreateGraph(sim.SC, id, yMax * (float) Math.Pow(10,pow));
                    id++;
                }
                break;
            case "Ser. Out.":
                yUnit = "Dollars Per Year";
                foreach (Sim sim in sims)
                {
                    maxes.Add(FindMax(sim.SO));
                }
                yMax = FindMax(maxes);
                (yMax, pow) = RoundMax(yMax);
                foreach (Sim sim in sims)
                {
                    windowGraph.CreateGraph(sim.SO, id, yMax * (float) Math.Pow(10,pow));
                    id++;
                }
                break;
            case "Jobs":
                yUnit = "People";
                foreach (Sim sim in sims)
                {
                    maxes.Add(FindMax(sim.J));
                }
                yMax = FindMax(maxes);
                (yMax, pow) = RoundMax(yMax);
                foreach (Sim sim in sims)
                {
                    windowGraph.CreateGraph(sim.J, id, yMax * (float) Math.Pow(10,pow));
                    id++;
                }
                break;
            case "Labour":
                yUnit = "People";
                foreach (Sim sim in sims)
                {
                    maxes.Add(FindMax(sim.LF));
                }
                yMax = FindMax(maxes);
                (yMax, pow) = RoundMax(yMax);
                foreach (Sim sim in sims)
                {
                    windowGraph.CreateGraph(sim.LF, id, yMax * (float) Math.Pow(10,pow));
                    id++;
                }
                break;
            case "Jobs/Hect":
                yUnit = "People Per Hectare";
                foreach (Sim sim in sims)
                {
                    maxes.Add(FindMax(sim.JPH));
                }
                yMax = FindMax(maxes);
                (yMax, pow) = RoundMax(yMax);
                foreach (Sim sim in sims)
                {
                    windowGraph.CreateGraph(sim.JPH, id, yMax * (float) Math.Pow(10,pow));
                    id++;
                }
                break;
            case "Land":
                yUnit = "Hectares";
                foreach (Sim sim in sims)
                {
                    maxes.Add(FindMax(sim.AL));
                }
                yMax = FindMax(maxes);
                (yMax, pow) = RoundMax(yMax);
                foreach (Sim sim in sims)
                {
                    windowGraph.CreateGraph(sim.AL, id, yMax * (float) Math.Pow(10,pow));
                    id++;
                }
                break;
            case "Food":
                yUnit = "Vegetable-Equivalent Kilograms Per Year";
                foreach (Sim sim in sims)
                {
                    maxes.Add(FindMax(sim.F));
                }
                yMax = FindMax(maxes);
                (yMax, pow) = RoundMax(yMax);
                foreach (Sim sim in sims)
                {
                    windowGraph.CreateGraph(sim.F, id, yMax * (float) Math.Pow(10,pow));
                    id++;
                }
                break;
            case "Yield":
                yUnit = "Vegetable-Equivalent Kilograms Per Hectare Per Year";
                foreach (Sim sim in sims)
                {
                    maxes.Add(FindMax(sim.LY));
                }
                yMax = FindMax(maxes);
                (yMax, pow) = RoundMax(yMax);
                foreach (Sim sim in sims)
                {
                    windowGraph.CreateGraph(sim.LY, id, yMax * (float) Math.Pow(10,pow));
                    id++;
                }
                break;
            case "U-I Land":
                yUnit = "Hectares";
                foreach (Sim sim in sims)
                {
                    maxes.Add(FindMax(sim.UIL));
                }
                yMax = FindMax(maxes);
                (yMax, pow) = RoundMax(yMax);
                foreach (Sim sim in sims)
                {
                    windowGraph.CreateGraph(sim.UIL, id, yMax * (float) Math.Pow(10,pow));
                    id++;
                }
                break;
            case "Land Fert.":
                yUnit = "Vegetable-Equivalent Kilograms Per Hectare Per Year";
                foreach (Sim sim in sims)
                {
                    maxes.Add(FindMax(sim.LFERT));
                }
                yMax = FindMax(maxes);
                (yMax, pow) = RoundMax(yMax);
                foreach (Sim sim in sims)
                {
                    windowGraph.CreateGraph(sim.LFERT, id, yMax * (float) Math.Pow(10,pow));
                    id++;
                }
                break;
            case "Land Regen.":
                yUnit = "Vegetable-Equivalent Kilograms Per Hectare Per Year Per Year";
                foreach (Sim sim in sims)
                {
                    maxes.Add(FindMax(sim.LFR));
                }
                yMax = FindMax(maxes);
                (yMax, pow) = RoundMax(yMax);
                foreach (Sim sim in sims)
                {
                    windowGraph.CreateGraph(sim.LFR, id, yMax * (float) Math.Pow(10,pow));
                    id++;
                }
                break;
            case "Land Degra.":
                yUnit = "Vegetable-Equivalent Kilograms Per Hectare Per Year Per Year";
                foreach (Sim sim in sims)
                {
                    maxes.Add(FindMax(sim.LFD));
                }
                yMax = FindMax(maxes);
                (yMax, pow) = RoundMax(yMax);
                foreach (Sim sim in sims)
                {
                    windowGraph.CreateGraph(sim.LFD, id, yMax * (float) Math.Pow(10,pow));
                    id++;
                }
                break;
            case "Resources":
                yUnit = "Resource Units";
                foreach (Sim sim in sims)
                {
                    maxes.Add(FindMax(sim.NR));
                }
                yMax = FindMax(maxes);
                (yMax, pow) = RoundMax(yMax);
                foreach (Sim sim in sims)
                {
                    windowGraph.CreateGraph(sim.NR, id, yMax * (float) Math.Pow(10,pow));
                    id++;
                }
                break;
            case "Res. Cap.":
                yUnit = "Fraction of Capital";
                foreach (Sim sim in sims)
                {
                    maxes.Add(FindMax(sim.FCAOR));
                }
                yMax = FindMax(maxes);
                (yMax, pow) = RoundMax(yMax);
                foreach (Sim sim in sims)
                {
                    windowGraph.CreateGraph(sim.FCAOR, id, yMax * (float) Math.Pow(10,pow));
                    id++;
                }
                break;
            case "Res. Left":
                yUnit = "Fraction of Resources Remaining";
                foreach (Sim sim in sims)
                {
                    maxes.Add(FindMax(sim.NRFR));
                }
                yMax = FindMax(maxes);
                (yMax, pow) = RoundMax(yMax);
                foreach (Sim sim in sims)
                {
                    windowGraph.CreateGraph(sim.NRFR, id, yMax * (float) Math.Pow(10,pow));
                    id++;
                }
                break;
            case "Res./Capita":
                yUnit = "Resource Units Per Person Per Year";
                foreach (Sim sim in sims)
                {
                    maxes.Add(FindMax(sim.PCRUM));
                }
                yMax = FindMax(maxes);
                (yMax, pow) = RoundMax(yMax);
                foreach (Sim sim in sims)
                {
                    windowGraph.CreateGraph(sim.PCRUM, id, yMax * (float) Math.Pow(10,pow));
                    id++;
                }
                break;
            case "Usage":
                yUnit = "Resource Units Per Year";
                foreach (Sim sim in sims)
                {
                    maxes.Add(FindMax(sim.NRUR));
                }
                yMax = FindMax(maxes);
                (yMax, pow) = RoundMax(yMax);
                foreach (Sim sim in sims)
                {
                    windowGraph.CreateGraph(sim.NRUR, id, yMax * (float) Math.Pow(10,pow));
                    id++;
                }
                break;
            case "Pollution":
                yUnit = "Pollution Units";
                foreach (Sim sim in sims)
                {
                    maxes.Add(FindMax(sim.PPOL));
                }
                yMax = FindMax(maxes);
                (yMax, pow) = RoundMax(yMax);
                foreach (Sim sim in sims)
                {
                    windowGraph.CreateGraph(sim.PPOL, id, yMax * (float) Math.Pow(10,pow));
                    id++;
                }
                break;
            case "Half Life":
                yUnit = "Years";
                foreach (Sim sim in sims)
                {
                    maxes.Add(FindMax(sim.AHL));
                }
                yMax = FindMax(maxes);
                (yMax, pow) = RoundMax(yMax);
                foreach (Sim sim in sims)
                {
                    windowGraph.CreateGraph(sim.AHL, id, yMax * (float) Math.Pow(10,pow));
                    id++;
                }
                break;
            case "Pol. Index":
                yUnit = "Index";
                foreach (Sim sim in sims)
                {
                    maxes.Add(FindMax(sim.PPOLX));
                }
                yMax = FindMax(maxes);
                (yMax, pow) = RoundMax(yMax);
                foreach (Sim sim in sims)
                {
                    windowGraph.CreateGraph(sim.PPOLX, id, yMax * (float) Math.Pow(10,pow));
                    id++;
                }
                break;
            case "Ind. Pol.":
                yUnit = "Pollution Units Per Year";
                foreach (Sim sim in sims)
                {
                    maxes.Add(FindMax(sim.PPGIO));
                }
                yMax = FindMax(maxes);
                (yMax, pow) = RoundMax(yMax);
                foreach (Sim sim in sims)
                {
                    windowGraph.CreateGraph(sim.PPGIO, id, yMax * (float) Math.Pow(10,pow));
                    id++;
                }
                break;
            case "Agr. Pol.":
                yUnit = "Pollution Units Per Year";
                foreach (Sim sim in sims)
                {
                    maxes.Add(FindMax(sim.PPGAO));
                }
                yMax = FindMax(maxes);
                (yMax, pow) = RoundMax(yMax);
                foreach (Sim sim in sims)
                {
                    windowGraph.CreateGraph(sim.PPGAO, id, yMax * (float) Math.Pow(10,pow));
                    id++;
                }
                break;

        }
        UpdateButtons(graphName);
        UpdateAxis(yMax, yUnit, pow);
        Close();
    }

    public float FindMax(List<float> valueList)
    {
        float max = 0;
        foreach (float val in valueList)
        {
            if (val > max) max = val;
        }
        return max;
    }

    private void UpdateButtons(string graphName)
    {
        selectBtn.GetComponentInChildren<Text>().text = graphName;
        if (sims[0].TIME.Count > 0) sim1Btn.gameObject.SetActive(true);
        else sim1Btn.gameObject.SetActive(false);

        if (sims[1].TIME.Count > 0) sim2Btn.gameObject.SetActive(true);
        else sim2Btn.gameObject.SetActive(false);

        if (sims[2].TIME.Count > 0) sim3Btn.gameObject.SetActive(true);
        else sim3Btn.gameObject.SetActive(false);

        if (sims[3].TIME.Count > 0) sim4Btn.gameObject.SetActive(true);
        else sim4Btn.gameObject.SetActive(false);

        if (sims[4].TIME.Count > 0) sim5Btn.gameObject.SetActive(true);
        else sim5Btn.gameObject.SetActive(false);
    }

    private void UpdateAxis(float yMax, string yUnit, float power)
    {
        float startYear = sims[0].TIME[0];
        float endYear = sims[0].TIME[sims[0].TIME.Count - 1];
        x1.gameObject.SetActive(true);
        x1.text = startYear.ToString();
        x2.gameObject.SetActive(true);
        x2.text = (startYear + (endYear - startYear) * 0.1).ToString();
        x3.gameObject.SetActive(true);
        x3.text = (startYear + (endYear - startYear) * 0.2).ToString();
        x4.gameObject.SetActive(true);
        x4.text = (startYear + (endYear - startYear) * 0.3).ToString();
        x5.gameObject.SetActive(true);
        x5.text = (startYear + (endYear - startYear) * 0.4).ToString();
        x6.gameObject.SetActive(true);
        x6.text = (startYear + (endYear - startYear) * 0.5).ToString();
        x7.gameObject.SetActive(true);
        x7.text = (startYear + (endYear - startYear) * 0.6).ToString();
        x8.gameObject.SetActive(true);
        x8.text = (startYear + (endYear - startYear) * 0.7).ToString();
        x9.gameObject.SetActive(true);
        x9.text = (startYear + (endYear - startYear) * 0.8).ToString();
        x10.gameObject.SetActive(true);
        x10.text = (startYear + (endYear - startYear) * 0.9).ToString();
        x11.gameObject.SetActive(true);
        x11.text = endYear.ToString();
        y1.gameObject.SetActive(true);
        y1.text = "0";
        y2.gameObject.SetActive(true);
        y2.text = (yMax*0.25).ToString();
        y3.gameObject.SetActive(true);
        y3.text = (yMax*0.5).ToString();
        y4.gameObject.SetActive(true);
        y4.text = (yMax*0.75).ToString();
        y5.gameObject.SetActive(true);
        y5.text = yMax.ToString();

        xHeader.gameObject.SetActive(true);
        if (power == 3) yUnit = "Thousands of " + yUnit;
        else if (power == 6) yUnit = "Millions of " + yUnit;
        else if (power == 9) yUnit = "Billions of " + yUnit;
        else if (power == 12) yUnit = "Trillions of " + yUnit;
        yHeader.text = yUnit;
        yHeader.gameObject.SetActive(true);


    }

    public void ClearGraph()
    {
        selectBtn.GetComponentInChildren<Text>().text = "Select";
        sim1Btn.gameObject.SetActive(false);
        sim2Btn.gameObject.SetActive(false);
        sim3Btn.gameObject.SetActive(false);
        sim4Btn.gameObject.SetActive(false);
        sim5Btn.gameObject.SetActive(false);
        windowGraph.ClearAll();
    }

    public void ClearHistory()
    {
        foreach (Sim sim in sims)
        {
            runSim.Clear(sim);
        }
        runSim.simID = 0;
        ClearGraph();
    }

    public (float, float) RoundMax(float num)
    {
        int digits = (Math.Ceiling(num)).ToString().Length;
        int power;
        if (digits > 3 && digits <= 6) power = 3;
        else if (digits > 6 && digits <= 9) power = 6;
        else if (digits > 9 && digits <= 12) power = 9;
        else if (digits > 12) power = 12;
        else power = 0;
        num = (float)Math.Ceiling(num / Math.Pow(10, power));
        return (num, power);
    }
}
