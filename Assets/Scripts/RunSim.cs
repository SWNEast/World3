using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Globalization;

public class RunSim : MonoBehaviour
{
    public TabButton graphTab;
    public GameObject simPanel;
    [SerializeField] private Sim sim1;
    [SerializeField] private Sim sim2;
    [SerializeField] private Sim sim3;
    [SerializeField] private Sim sim4;
    [SerializeField] private Sim sim5;
    private Sim[] sims = new Sim[5];
    public int simID = 0;
    private Sim sim;

    //BASE

    public int length;

    public TMP_InputField start;
    public TMP_InputField end;
    public TMP_InputField timestep;
    public TMP_InputField pyear;

    public TMP_InputField P1;
    public TMP_InputField P2;
    public TMP_InputField P3;
    public TMP_InputField P4;

    public TMP_InputField IC;
    public TMP_InputField SC;

    public TMP_InputField AL;
    public TMP_InputField PAL;
    public TMP_InputField UIL;
    public TMP_InputField LFERT;

    public TMP_InputField NR;

    public TMP_InputField PPOL;

    //ADVANCED
    //POP
    public TMP_InputField FCEST;
    public TMP_InputField PET;
    public TMP_InputField RLT;
    public TMP_InputField ZPGT;
    public TMP_InputField DCFSN;
    public TMP_InputField MTFN;
    public TMP_InputField LPD;
    public TMP_InputField IEAT;
    public TMP_InputField SAD;
    public TMP_InputField LEN;
    public TMP_InputField HSID;

    //CAPITAL
    public TMP_InputField ICOR1;
    public TMP_InputField ICOR2;
    public TMP_InputField ALIC1;
    public TMP_InputField ALIC2;
    public TMP_InputField IET;
    public TMP_InputField IOPCD;
    public TMP_InputField FIOAC1;
    public TMP_InputField FIOAC2;
    public TMP_InputField SCOR1;
    public TMP_InputField SCOR2;
    public TMP_InputField ALSC1;
    public TMP_InputField ALSC2;
    public TMP_InputField LUFDT;
    public TMP_InputField LFPF;

    //AGRICULTURE
    public TMP_InputField PALT;
    public TMP_InputField PL;
    public TMP_InputField LFH;
    public TMP_InputField IO70;
    public TMP_InputField LYF1;
    public TMP_InputField LYF2;
    public TMP_InputField ALAI1;
    public TMP_InputField ALAI2;
    public TMP_InputField SD;
    public TMP_InputField UILDT;
    public TMP_InputField ALLN;
    public TMP_InputField ILF;
    public TMP_InputField FSPD;
    public TMP_InputField SFPC;

    //RESOURCE
    public TMP_InputField NRUF1;
    public TMP_InputField NRUF2;

    //POLLUTION
    public TMP_InputField AHL70;
    public TMP_InputField PPOL70;
    public TMP_InputField IMEF;
    public TMP_InputField PPTD;
    public TMP_InputField IMTI;
    public TMP_InputField FIPM;
    public TMP_InputField FRPM;
    public TMP_InputField PPGF1;
    public TMP_InputField PPGF2;
    public TMP_InputField AMTI;




    private float endYear;

    public void Awake()
    {
        LoadDefaults();
        sims[0] = sim1;
        sims[1] = sim2;
        sims[2] = sim3;
        sims[3] = sim4;
        sims[4] = sim5;
    }

    public void Run()
    {
        sim = sims[simID];
        Clear(sim);
        ReadInputs();
        int i = 0;
        sim.Advance(i);
        sim.Levels(i);
        sim.Auxiliries(i);
        sim.Rates(i);
        i++;
        while (sim.TIME[sim.TIME.Count - 1] < endYear)
        {
            sim.Advance(i);
            sim.Levels(i);
            sim.Auxiliries(i);
            sim.Rates(i);
            i++;
        }
        graphTab.Manual();
        simID += 1;
        if (simID == 5) simID = 0;
    }

    public void Clear(Sim sim)
    {
        //graphSelection.Clear();

        sim.TIME.Clear();

        sim.POP.Clear();

        sim.P1.Clear();
        sim.P2.Clear();
        sim.P3.Clear();
        sim.P4.Clear();

        sim.D1.Clear();
        sim.D2.Clear();
        sim.D3.Clear();
        sim.D4.Clear();

        sim.MAT1.Clear();
        sim.MAT2.Clear();
        sim.MAT3.Clear();

        sim.M1.Clear();
        sim.M2.Clear();
        sim.M3.Clear();
        sim.M4.Clear();

        sim.CBR.Clear();

        sim.B.Clear();

        sim.TF.Clear();
        sim.FCE.Clear();
        sim.FCFPC.Clear();
        sim.MTF.Clear();
        sim.DTF.Clear();
        sim.DCFS.Clear();
        sim.FCAPC.Clear();
        sim.NFC.Clear();
        sim.FRSN.Clear();
        sim.SFSN.Clear();
        sim.FSAFC.Clear();
        sim.CMPLE.Clear();
        sim.FM.Clear();
        sim.PLE.Clear();
        sim.FIE.Clear();
        sim.AIOPC.Clear();
        sim.DIOPC.Clear();

        sim.CDR.Clear();
        
        sim.D.Clear();
        sim.LE.Clear();
        sim.LMF.Clear();
        sim.LMHS.Clear();
        sim.LMC.Clear();
        sim.LMP.Clear();
        sim.LMHS1.Clear();
        sim.LMHS2.Clear();
        sim.CMI.Clear();
        sim.FPU.Clear();
        sim.EHSPC.Clear();
        sim.HSAPC.Clear();

        sim.IC.Clear();
        
        sim.IOPC.Clear();
        sim.IO.Clear();
        sim.ICOR.Clear();
        sim.FIOAI.Clear();
        sim.ALIC.Clear();
        sim.FIOAC.Clear();
        sim.FIOACV.Clear();
        sim.FIOACC.Clear();

        sim.ICIR.Clear();
        sim.ICDR.Clear();

        sim.SC.Clear();

        sim.SOPC.Clear();
        sim.SO.Clear();
        sim.SCOR.Clear();
        sim.FIOAS.Clear();
        sim.FIOAS1.Clear();
        sim.FIOAS2.Clear();
        sim.ALSC.Clear();
        sim.ISOPC.Clear();
        sim.ISOPC1.Clear();
        sim.ISOPC2.Clear();

        sim.SCIR.Clear();
        sim.SCDR.Clear();

        sim.CUF.Clear();
        sim.LUFD.Clear();
        sim.J.Clear();
        sim.LUF.Clear();
        sim.LF.Clear();
        sim.PJIS.Clear();
        sim.PJAS.Clear();
        sim.PJSS.Clear();
        sim.JPICU.Clear();
        sim.JPH.Clear();
        sim.JPSCU.Clear();

        sim.PAL.Clear();
        sim.AL.Clear();

        sim.TAI.Clear();
        sim.FIOAA.Clear();
        sim.DCPH.Clear();
        sim.FIOAA1.Clear();
        sim.FIOAA2.Clear();
        sim.LFC.Clear();
        sim.FPC.Clear();
        sim.IFPC.Clear();
        sim.IFPC1.Clear();
        sim.IFPC2.Clear();
        sim.F.Clear();

        sim.LDR.Clear();

        sim.LYMAP1.Clear();
        sim.LYMAP2.Clear();
        sim.LYMAP.Clear();
        sim.LYF.Clear();
        sim.LY.Clear();
        sim.LYMC.Clear();
        sim.AIPH.Clear();
        sim.AI.Clear();
        sim.CAI.Clear();
        sim.ALAI.Clear();

        sim.FIALD.Clear();
        sim.MPLD.Clear();
        sim.MPAI.Clear();
        sim.MLYMC.Clear();

        sim.UIL.Clear();

        sim.ALL.Clear();
        sim.LLMY.Clear();
        sim.UILR.Clear();
        sim.LLMY1.Clear();
        sim.LLMY2.Clear();
        sim.UILPC.Clear();

        sim.LER.Clear();
        sim.LRUI.Clear();

        sim.LFRT.Clear();
        
        sim.LFR.Clear();

        sim.LFERT.Clear();

        sim.LFDR.Clear();

        sim.LFD.Clear();

        sim.FALM.Clear();
        sim.PFR.Clear();
        sim.FR.Clear();

        sim.NR.Clear();

        sim.FCAOR.Clear();
        sim.FCAOR1.Clear();
        sim.FCAOR2.Clear();
        sim.NRFR.Clear();
        sim.PCRUM.Clear();
        sim.NRUF.Clear();

        sim.NRUR.Clear();

        sim.PPOL.Clear();

        sim.AHL.Clear();
        sim.AHLM.Clear();
        sim.PPOLX.Clear();
        sim.PPGIO.Clear();
        sim.PPGAO.Clear();
        sim.PPGF.Clear();

        sim.PPASR.Clear();
        sim.PPAPR.Clear();
        sim.PPGR.Clear();



    }

    public void ReadInputs()
    {
        sim.TIMEI = Parse(start);
        endYear = Parse(end);
        sim.DT = Parse(timestep);
        sim.PYEAR = Parse(pyear);

        sim.P1I = Parse(P1) * 1000000;
        sim.P2I = Parse(P2) * 1000000;
        sim.P3I = Parse(P3) * 1000000;
        sim.P4I = Parse(P4) * 1000000;

        sim.ICI = Parse(IC) * 1000000000;
        sim.SCI = Parse(SC) * 1000000000;

        sim.ALI = Parse(AL) * 1000000;
        sim.PALI = Parse(PAL) * 1000000;
        sim.UILI = Parse(UIL) * 1000000;
        sim.LFERTI = Parse(LFERT);

        sim.NRI = Parse(NR) * 1000000000000;

        sim.PPOLI = Parse(PPOL) * 1000000;

        //ADVANCED
        //POP
        sim.FCEST = Parse(FCEST);
        sim.PET = Parse(PET);
        sim.ZPGT = Parse(ZPGT);
        sim.DCFSN = Parse(DCFSN);
        sim.MTFN = Parse(MTFN);
        sim.LPD = Parse(LPD);
        sim.IEAT = Parse(IEAT);
        sim.SAD = Parse(SAD);
        sim.LEN = Parse(LEN);
        sim.HSID = Parse(HSID);

        //CAPITAL
        sim.ICOR1 = Parse(ICOR1);
        sim.ICOR2 = Parse(ICOR2);
        sim.ALIC1 = Parse(ALIC1);
        sim.ALIC2 = Parse(ALIC2);
        sim.IET = Parse(IET);
        sim.IOPCD = Parse(IOPCD);
        sim.FIOAC1 = Parse(FIOAC1);
        sim.FIOAC2 = Parse(FIOAC2);
        sim.SCOR1 = Parse(SCOR1);
        sim.SCOR2 = Parse(SCOR2);
        sim.LUFDT = Parse(LUFDT);
        sim.LFPF = Parse(LFPF);

        //AGRICULTURE
        sim.PALT = Parse(PALT) * 1000000;
        sim.PL = Parse(PL);
        sim.LFH = Parse(LFH);
        sim.IO70 = Parse(IO70) * 1000000000;
        sim.LYF1 = Parse(LYF1);
        sim.LYF2 = Parse(LYF2);
        sim.ALAI1 = Parse(ALAI1);
        sim.ALAI2 = Parse(ALAI2);
        sim.SD = Parse(SD);
        sim.UILDT = Parse(UILDT);
        sim.ALLN = Parse(ALLN);
        sim.ILF = Parse(ILF);
        sim.FSPD = Parse(FSPD);
        sim.SFPC = Parse(SFPC);

        //RESOURCE
        sim.NRUF1 = Parse(NRUF1);
        sim.NRUF2 = Parse(NRUF2);

        //POLLUTION
        sim.AHL70 = Parse(AHL70);
        sim.PPOL70 = Parse(PPOL70) * 1000000;
        sim.IMEF = Parse(IMEF);
        sim.PPTD = Parse(PPTD);
        sim.IMTI = Parse(IMTI);
        sim.FIPM = Parse(FIPM);
        sim.FRPM = Parse(FRPM);
        sim.PPGF1 = Parse(PPGF1);
        sim.PPGF2 = Parse(PPGF2);
        sim.AMTI = Parse(AMTI);

    }

    public void LoadDefaults()
    {
        start.text = "1900";
        end.text = "2400";
        timestep.text = "0.5";
        pyear.text = "1975";

        P1.text = "650";
        P2.text = "700";
        P3.text = "190";
        P4.text = "60";

        IC.text = "210";
        SC.text = "144";

        AL.text = "900";
        PAL.text = "2300";
        UIL.text = "0.82";
        LFERT.text = "600";

        NR.text = "1";

        PPOL.text = "25";

        //ADVANCED
        //POP
        FCEST.text = "4000";
        PET.text = "4000";
        RLT.text = "30";
        ZPGT.text = "4000";
        DCFSN.text = "4";
        MTFN.text = "12";
        LPD.text = "20";
        IEAT.text = "3";
        SAD.text = "20";
        LEN.text = "28";
        HSID.text = "20";

        //Capital
        ICOR1.text = "3";
        ICOR2.text = "3";
        ALIC1.text = "14";
        ALIC2.text = "14";
        IET.text = "4000";
        IOPCD.text = "400";
        FIOAC1.text = "0.43";
        FIOAC2.text = "0.43";
        SCOR1.text = "1";
        SCOR2.text = "1";
        ALSC1.text = "20";
        ALSC2.text = "20";
        LUFDT.text = "2";
        LFPF.text = "0.75";

        //Agriculture
        PALT.text = "3200";
        PL.text = "0.1";
        LFH.text = "0.7";
        IO70.text = "790";
        LYF1.text = "1";
        LYF2.text = "1";
        ALAI1.text = "2";
        ALAI2.text = "2";
        SD.text = "0.07";
        UILDT.text = "10";
        ALLN.text = "6000";
        ILF.text = "600";
        FSPD.text = "2";
        SFPC.text = "230";

        //Resource
        NRUF1.text = "1";
        NRUF2.text = "1";

        //Pollution
        AHL70.text = "1.5";
        PPOL70.text = "136";
        IMEF.text = "0.1";
        PPTD.text = "20";
        IMTI.text = "10";
        FIPM.text = "0.001";
        FRPM.text = "0.02";
        PPGF1.text = "1";
        PPGF2.text = "1";
        AMTI.text = "1";
    }

    public float Parse(TMP_InputField field)
    {
        float value = float.Parse(field.text, CultureInfo.InvariantCulture.NumberFormat);
        if (field == end && Parse(start) + 1000 < value)
        {
            field.text = (Parse(start) + 1000).ToString();
            return Parse(start) + 1000;
        } else if (field == end && Parse(start) + 100 > value)
        {
            field.text = (Parse(start) + 100).ToString();
            return Parse(start) + 100;
        }
        else if (value <= 0)
        {
            field.text = "1";
            return 1;
        } else
        {
            return value;
        }
    }

    public Sim GetCurrent()
    {
        return sims[simID];
    }
}
