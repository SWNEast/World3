using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sim : MonoBehaviour
{

    //System
    public float DT = 0.5f;
    public List<float> TIME = new List<float>();
    public float TIMEI = 1900;
    public float PYEAR = 1975;

    //Model
    //  Population
    //      TOTAL POPULATION
    public List<float> POP = new List<float>();

    public List<float> P1 = new List<float>(); 
    public List<float> P2 = new List<float>(); 
    public List<float> P3 = new List<float>(); 
    public List<float> P4 = new List<float>(); 

    public float P1I = 650000000;
    public float P2I = 700000000;
    public float P3I = 190000000;
    public float P4I = 60000000;

    public List<float> D1 = new List<float>(); 
    public List<float> D2 = new List<float>(); 
    public List<float> D3 = new List<float>(); 
    public List<float> D4 = new List<float>(); 

    public List<float> MAT1 = new List<float>();
    public List<float> MAT2 = new List<float>();
    public List<float> MAT3 = new List<float>();

    public List<float> M1 = new List<float>(); 
    public List<float> M2 = new List<float>(); 
    public List<float> M3 = new List<float>(); 
    public List<float> M4 = new List<float>(); 

    public float[] M1T = { .0567f, .0366f, .0243f, .0155f, .0082f, .0023f, .001f };
    public float[] M2T = { .0266f, .0171f, .0110f, .0065f, .0040f, .0016f, .0008f };
    public float[] M3T = { .0562f, .0373f, .0252f, .0171f, .0118f, .0083f, .006f };
    public float[] M4T = { .13f, .11f, .09f, .07f, .06f, .05f, .04f };

    //      Birth Rate
    public List<float> CBR = new List<float>();

    public List<float> B = new List<float>();

    public List<float> TF = new List<float>();
    public List<float> FCE = new List<float>();
    public List<float> FCFPC = new List<float>();
    public List<float> MTF = new List<float>();
    public List<float> DTF = new List<float>();
    public List<float> DCFS = new List<float>();
    public List<float> FCAPC = new List<float>();
    public List<float> NFC = new List<float>();
    public List<float> FRSN = new List<float>();
    public List<float> SFSN = new List<float>();
    public List<float> FSAFC = new List<float>();
    public List<float> CMPLE = new List<float>();
    public List<float> FM = new List<float>();
    public List<float> PLE = new List<float>();
    public List<float> FIE = new List<float>();
    public List<float> AIOPC = new List<float>();
    public List<float> DIOPC = new List<float>();

    public float FCEST = 4000;
    public float PET = 4000;
    public float RLT = 30;
    public float ZPGT = 4000;
    public float DCFSN = 4;
    public float MTFN = 12;
    public float LPD = 20;
    public float IEAT = 3;
    public float SAD = 20;

    public float[] FCET = { .75f,  .85f,  .9f,  .95f,  .98f,  .99f,  1 };
    public float[] FSAFCT = { 0f,  .005f,  .015f,  .025f,  .03f,  .035f };
    public float[] CMPLET = { 3f,  2.1f,  1.6f,  1.4f,  1.3f,  1.2f,  1.1f,  1.05f,  1 };
    public float[] FRSNT = { .5f,  .6f,  .7f,  .85f,  1 };
    public float[] SFSNT = { 1.25f,  1f,  .9f,  .8f,  .75f };
    public float[] FMT = { 0f,  .2f,  .4f,  .6f,  .8f,  .9f,  1f,  1.05f,  1.1f };

    //      Death Rate
    public List<float> CDR = new List<float>();

    public List<float> D = new List<float>();
    public List<float> LE = new List<float>();
    public List<float> LMF = new List<float>();
    public List<float> LMHS = new List<float>();
    public List<float> LMC = new List<float>();
    public List<float> LMP = new List<float>();
    public List<float> LMHS1 = new List<float>();
    public List<float> LMHS2 = new List<float>();
    public List<float> CMI = new List<float>();
    public List<float> FPU = new List<float>();
    public List<float> EHSPC = new List<float>();
    public List<float> HSAPC = new List<float>();

    public float LEN = 28;
    public float HSID = 20;

    public float[] LMFT = { 0f,  1f,  1.2f,  1.3f,  1.35f,  1.4f };
    public float[] LMPT = { 1f,  .99f,  .97f,  .95f,  .90f,  .85f,  .75f,  .65f,  .55f,  .40f,  .20f };
    public float[] LMHS1T = { 1f,  1.1f,  1.4f,  1.6f,  1.7f,  1.8f };
    public float[] LMHS2T = { 1f,  1.4f,  1.6f,  1.8f,  1.95f,  2 };
    public float[] CMIT = { .5f,  .05f,  -0.1f,  -0.08f,  -0.02f,  .05f,  .1f,  .15f,  .2f };
    public float[] FPUT = { 0f,  .2f,  .4f,  .5f,  .58f,  .65f,  .72f,  .78f,  .80f };
    public float[] HSAPCT = { 0f,  20f,  50f,  95f,  140f,  175f,  200f,  220f,  230 };

    //  Capital
    //      Industrial
    public List<float> IC = new List<float>();

    public List<float> IOPC = new List<float>();
    public List<float> IO = new List<float>();
    public List<float> ICOR = new List<float>();
    public List<float> FIOAI = new List<float>();
    public List<float> ALIC = new List<float>();
    public List<float> FIOAC = new List<float>();
    public List<float> FIOACV = new List<float>();
    public List<float> FIOACC = new List<float>();

    public List<float> ICIR = new List<float>();
    public List<float> ICDR = new List<float>();

    public float ICOR1 = 3;
    public float ICOR2 = 3;
    public float ICI = 210000000000;
    public float ALIC1 = 14;
    public float ALIC2 = 14;
    public float IET = 4000;
    public float IOPCD = 400;
    public float FIOAC1 = .43f;
    public float FIOAC2 = .43f;

    public float[] FIOACVT = { .3f,  .32f,  .34f,  .36f,  .38f,  .43f,  .73f,  .77f,  .81f,  .82f,  .83f };

    //      Service
    public List<float> SC = new List<float>();

    public List<float> SOPC = new List<float>();
    public List<float> SO = new List<float>();
    public List<float> SCOR = new List<float>();
    public List<float> FIOAS = new List<float>();
    public List<float> FIOAS1 = new List<float>();
    public List<float> FIOAS2 = new List<float>();
    public List<float> ALSC = new List<float>();
    public List<float> ISOPC = new List<float>();
    public List<float> ISOPC1 = new List<float>();
    public List<float> ISOPC2 = new List<float>();

    public List<float> SCIR = new List<float>();
    public List<float> SCDR = new List<float>();

    public float SCOR1 = 1;
    public float SCOR2 = 1;
    public float SCI = 144000000000;
    public float ALSC1 = 20;
    public float ALSC2 = 20;

    public float[] FIOAS1T = { .3f,  .2f,  .1f,  .05f,  0 };
    public float[] FIOAS2T = { .3f,  .2f,  .1f,  .05f,  0 };
    public float[] ISOPC1T = { 40f,  300f,  640f,  1000f,  1220f,  1450f,  1650f,  1800f,  2000 };
    public float[] ISOPC2T = { 40f,  300f,  640f,  1000f,  1220f,  1450f,  1650f,  1800f,  2000 };

    //      JOB
    public List<float> CUF = new List<float>();
    public List<float> LUFD = new List<float>();
    public List<float> J = new List<float>();
    public List<float> LUF = new List<float>();
    public List<float> LF = new List<float>();
    public List<float> PJIS = new List<float>();
    public List<float> PJAS = new List<float>();
    public List<float> PJSS = new List<float>();
    public List<float> JPICU = new List<float>();
    public List<float> JPH = new List<float>();
    public List<float> JPSCU = new List<float>();

    public float LUFDT = 2;
    public float LFPF = .75f;

    public float[] CUFT = { 1f,  .9f,  .7f,  .3f,  .1f,  .1f };
    public float[] JPICUT = { .37f,  .18f,  12f,  .09f,  .07f,  .06f };
    public float[] JPHT = { 2f,  .5f,  .4f,  .3f,  .27f,  .24f,  .2f,  .2f };
    public float[] JPSCUT = { 1.1f,  .6f,  .35f,  .2f,  .15f,  .15f };

    //  Agriculture Sector
    //      Food From Investment In Land Development
    public List<float> PAL = new List<float>();
    public List<float> AL = new List<float>();

    public List<float> TAI = new List<float>();
    public List<float> FIOAA = new List<float>();
    public List<float> DCPH = new List<float>();
    public List<float> FIOAA1 = new List<float>();
    public List<float> FIOAA2 = new List<float>();
    public List<float> LFC = new List<float>();
    public List<float> FPC = new List<float>();
    public List<float> IFPC = new List<float>();
    public List<float> IFPC1 = new List<float>();
    public List<float> IFPC2 = new List<float>();
    public List<float> F = new List<float>();

    public List<float> LDR = new List<float>();

    public float PALI = 2300000000;
    public float PALT = 3200000000;
    public float ALI = 900000000;
    public float PL = 0.1f;
    public float LFH = 0.7f;

    public float[] DCPHT = { 100000f,  7400f,  5200f,  3500f,  2400f,  1500f,  750f,  300f,  150f,  75f,  50 };
    public float[] FIOAA1T = { .4f,  .2f,  .1f,  .025f,  0f,  0 };
    public float[] FIOAA2T = { .4f,  .2f,  .1f,  .025f,  0f,  0 };
    public float[] IFPC1T = { 230f,  480f,  690f,  850f,  970f,  1070f,  1150f,  1210f,  1250 };
    public float[] IFPC2T = { 230f,  480f,  690f,  850f,  970f,  1070f,  1150f,  1210f,  1250 };

    //      Food From Investment In Agricultural Inputs
    public List<float> LYMAP1 = new List<float>();
    public List<float> LYMAP2 = new List<float>();
    public List<float> LYMAP = new List<float>();
    public List<float> LYF = new List<float>();
    public List<float> LY = new List<float>();
    public List<float> LYMC = new List<float>();
    public List<float> AIPH = new List<float>();
    public List<float> AI = new List<float>();
    public List<float> CAI = new List<float>();
    public List<float> ALAI = new List<float>();

    public float IO70 = 790000000000;
    public float LYF1 = 1;
    public float LYF2 = 1;
    public float ALAI1 = 2;
    public float ALAI2 = 2;

    public float[] LYMAP1T = { 1f,  1f,  .7f,  .4f };
    public float[] LYMAP2T = { 1f,  1f,  .7f,  .4f };
    public float[] LYMCT = { 1f,  3f,  3.8f,  4.4f,  4.9f,  5.4f,  5.7f,  6f,  6.3f,  6.6f,  6.9f,  7.2f,  7.4f,  7.6f,  7.8f,  8f,  8.2f,  8.4f,  8.6f,  8.8f,  9.2f,  9.4f,  9.6f,  9.8f,  10 };

    //      The Investment Allocation Decision
    public List<float> FIALD = new List<float>();
    public List<float> MPLD = new List<float>();
    public List<float> MPAI = new List<float>();
    public List<float> MLYMC = new List<float>();

    public float SD = 0.07f;

    public float[] FIALDT = { 0f,  .05f,  .15f,  .30f,  .50f,  .70f,  .85f,  .95f,  1 };
    public float[] MLYMCT = { .075f,  .03f,  .015f,  .011f,  .009f,  .008f,  .007f,  .006f,  .005f,  .005f,  .005f,  .005f,  .005f,  .005f,  .005f,  .005f };

    //      Land Erosion and Urban-Industrial Use
    public List<float> UIL = new List<float>();

    public List<float> ALL = new List<float>();
    public List<float> LLMY = new List<float>();
    public List<float> UILR = new List<float>();
    public List<float> LLMY1 = new List<float>();
    public List<float> LLMY2 = new List<float>();
    public List<float> UILPC = new List<float>();

    public List<float> LER = new List<float>();
    public List<float> LRUI = new List<float>();

    public float UILDT = 10;
    public float UILI = 820000;
    public float ALLN = 6000;

    public float[] LLMY1T = { 1.2f,  1f,  .63f,  .36f,  .16f,  .055f,  .04f,  .025f,  .015f,  .01f };
    public float[] LLMY2T = { 1.2f,  1f,  .63f,  .36f,  .16f,  .055f,  .04f,  .025f,  .015f,  .01f };
    public float[] UILPCT = { .005f,  .008f,  .015f,  .025f,  .04f,  .055f,  .07f,  .08f,  .09f };

    //      Land Fertility Regeneration
    public List<float> LFRT = new List<float>();

    public List<float> LFR = new List<float>();

    public float ILF = 600;

    public float[] LFRTT = { 20f,  13f,  8f,  4f,  2f,  2 };

    //      Land Fertility Degradation
    public List<float> LFERT = new List<float>();

    public List<float> LFDR = new List<float>();

    public List<float> LFD = new List<float>();

    public float LFERTI = 600;

    public float[] LFDRT = { 0f,  .1f,  .3f,  .5f };

    //      Discontinuing Land Maintenance
    public List<float> FALM = new List<float>();
    public List<float> PFR = new List<float>();
    public List<float> FR = new List<float>();

    public float FSPD = 2;
    public float SFPC = 230;

    public float[] FALMT = { 0f,  .04f,  .07f,  .09f,  .1f };

    //  Nonrenewable Resource
    public List<float> NR = new List<float>();

    public List<float> FCAOR = new List<float>();
    public List<float> FCAOR1 = new List<float>();
    public List<float> FCAOR2 = new List<float>();
    public List<float> NRFR = new List<float>();
    public List<float> PCRUM = new List<float>();
    public List<float> NRUF = new List<float>();

    public List<float> NRUR = new List<float>();

    public float NRI = 1000000000000;
    public float NRUF1 = 1;
    public float NRUF2 = 1;

    public float[] FCAOR1T = { 1f,  .9f,  .7f,  .5f,  .2f,  .1f,  .05f,  .05f,  .05f,  .05f,  .05f };
    public float[] FCAOR2T = { 1f,  .9f,  .7f,  .5f,  .2f,  .1f,  .05f,  .05f,  .05f,  .05f,  .05f };
    public float[] PCRUMT = { 0f,  .85f,  2.6f,  4.4f,  5.4f,  6.2f,  6.8f,  7f,  7 };

    //  Persistent Pollution
    public List<float> PPOL = new List<float>();

    public List<float> AHL = new List<float>();
    public List<float> AHLM = new List<float>();
    public List<float> PPOLX = new List<float>();
    public List<float> PPGIO = new List<float>();
    public List<float> PPGAO = new List<float>();
    public List<float> PPGF = new List<float>();

    public List<float> PPASR = new List<float>();
    public List<float> PPAPR = new List<float>();
    public List<float> PPGR = new List<float>();

    public float AHL70 = 1.5f;
    public float PPOL70 = 136000000;
    public float IMEF = 0.1f;
    public float PPTD = 20;
    public float IMTI = 10;
    public float FIPM = 0.001f;
    public float FRPM = 0.02f;
    public float AMTI = 1;
    public float PPGF1 = 1;
    public float PPGF2 = 2;
    public float PPOLI = 25000000;

    public float[] AHLMT = { 1f,  11f,  21f,  31f,  41 };

    public bool Levels(int k)
    {
        if (k == 0)
        {
            //Total Pop
            P1.Add(P1I);
            P2.Add(P2I);
            P3.Add(P3I);
            P4.Add(P4I);
            //Industrial
            IC.Add(ICI);
            //Service
            SC.Add(SCI);
            //Food From Investment In Land Development
            AL.Add(ALI);
            PAL.Add(PALI);
            //Land Erosion and Urban-Industial Use
            UIL.Add(UILI);
            //Land Fertility Degradation
            LFERT.Add(LFERTI);
            //Nonrenewable Resource Sector
            NR.Add(NRI);
            //Persistent Pollution Sector
            PPOL.Add(PPOLI);

        }
        else
        {
            //Total Pop
            P1.Add(P1[k - 1] + DT * (B[k - 1] - D1[k - 1] - MAT1[k - 1]));
            P2.Add(P2[k - 1] + DT * (MAT1[k - 1] - D2[k - 1] - MAT2[k - 1]));
            P3.Add(P3[k - 1] + DT * (MAT2[k - 1] - D3[k - 1] - MAT3[k - 1]));
            P4.Add(P4[k - 1] + DT * (MAT3[k - 1] - D4[k - 1]));
            //Industrial
            IC.Add(IC[k - 1] + DT * (ICIR[k - 1] - ICDR[k - 1]));
            //Service
            SC.Add(SC[k - 1] + DT * (SCIR[k - 1] - SCDR[k - 1]));
            //Food From Investment In Land Development
            AL.Add(AL[k - 1] + DT * (LDR[k - 1] - LER[k - 1] - LRUI[k - 1]));
            PAL.Add(PAL[k - 1] + DT * (-LDR[k - 1]));
            //Land Erosion and Urban-Industial Use
            UIL.Add(UIL[k - 1] + DT * LRUI[k - 1]);
            //Land Fertility Degradation
            LFERT.Add(LFERT[k - 1] + DT * (LFR[k - 1] - LFD[k - 1]));
            //Nonrenewable Resource Sector
            NR.Add(NR[k - 1] + DT * (-NRUR[k - 1]));
            //Persistent Pollution Sector
            PPOL.Add(PPOL[k - 1] + DT * (PPAPR[k - 1] - PPASR[k - 1]));

        }
        //Debug.Log("Levels: " + k);
        return true;
    }

    public bool Auxiliries(int k)
    {
        if (k == 0)
        {
            //Total Pop
            POP.Add(1);
            M1.Add(1);
            M2.Add(1);
            M3.Add(1);
            M4.Add(1);
            //Death
            D.Add(1);
            LE.Add(1);
            LMF.Add(1);
            HSAPC.Add(1);
            EHSPC.Add(1);
            LMHS.Add(1);
            LMHS1.Add(1);
            LMHS2.Add(1);
            FPU.Add(1);
            CMI.Add(1);
            LMC.Add(1);
            LMP.Add(1);
            //Birth
            TF.Add(1);
            MTF.Add(1);
            FM.Add(1);
            DTF.Add(1);
            CMPLE.Add(1);
            PLE.Add(1);
            DCFS.Add(1);
            SFSN.Add(1);
            DIOPC.Add(1);
            FRSN.Add(0.82f);
            FIE.Add(1);
            AIOPC.Add(1);
            NFC.Add(1);
            FCE.Add(1);
            FCFPC.Add(1);
            FCAPC.Add(1);
            FSAFC.Add(1);
            //Industrial
            IOPC.Add(1);
            IO.Add(1);
            ICOR.Add(1);
            ALIC.Add(1);
            FIOAI.Add(1);
            FIOAC.Add(1);
            FIOACC.Add(1);
            FIOACV.Add(1);
            //Service
            ISOPC.Add(1);
            ISOPC1.Add(1);
            ISOPC2.Add(1);
            FIOAS.Add(1);
            FIOAS1.Add(1);
            FIOAS2.Add(1);
            ALSC.Add(1);
            SO.Add(1);
            SOPC.Add(1);
            SCOR.Add(1);
            //Job
            J.Add(1);
            PJIS.Add(1);
            JPICU.Add(1);
            PJSS.Add(1);
            JPSCU.Add(1);
            PJAS.Add(1);
            JPH.Add(1);
            LF.Add(1);
            LUF.Add(1);
            LUFD.Add(1);
            CUF.Add(1);
            //Food From Investment In Land Developement
            LFC.Add(1);
            F.Add(1);
            FPC.Add(1);
            IFPC.Add(1);
            IFPC1.Add(1);
            IFPC2.Add(1);
            TAI.Add(1);
            FIOAA.Add(1);
            FIOAA1.Add(1);
            FIOAA2.Add(1);
            DCPH.Add(1);
            //Food From Investment In Agricultural Inputs
            CAI.Add(1);
            AI.Add(5000000000);
            ALAI.Add(1);
            AIPH.Add(1);
            LYMC.Add(1);
            LY.Add(1);
            LYF.Add(1);
            LYMAP.Add(1);
            LYMAP1.Add(1);
            LYMAP2.Add(1);
            //The Investment Allocation
            FIALD.Add(1);
            MPLD.Add(1);
            MPAI.Add(1);
            MLYMC.Add(1);
            //Land Erosion and Urban-Industrial Use
            ALL.Add(1);
            LLMY.Add(1);
            LLMY1.Add(1);
            LLMY2.Add(1);
            UILPC.Add(1);
            UILR.Add(1);
            //Land Fertility Degradation
            LFDR.Add(1);
            //Land Fertility Regeneration
            LFRT.Add(1);
            //Discontinuing Land Maintenance
            FALM.Add(1);
            FR.Add(1);
            PFR.Add(1);
            //Nonrenewable Resource Sector
            NRUF.Add(1);
            PCRUM.Add(1);
            NRFR.Add(1);
            FCAOR.Add(1);
            FCAOR1.Add(1);
            FCAOR2.Add(1);
            //Persistent Pollution Sector
            PPGF.Add(1);
            PPGIO.Add(1);
            PPGAO.Add(1);
            PPOLX.Add(1);
            AHLM.Add(1);
            AHL.Add(1);
        }
        else
        {
            //Level 1
            PPOLX.Add(PPOL[k] / PPOL70);
            SCOR.Add(CLIP(SCOR2, SCOR1, TIME[k], PYEAR));
            D.Add(D1[k - 1] + D2[k - 1] + D3[k - 1] + D4[k - 1]);
            ALIC.Add(CLIP(ALIC2, ALIC1, TIME[k], PYEAR));
            FIOACC.Add(CLIP(FIOAC2, FIOAC1, TIME[k], PYEAR));
            POP.Add(P1[k] + P2[k] + P3[k] + P4[k]);
            PPGF.Add(CLIP(PPGF2, PPGF1, TIME[k], PYEAR));
            LFC.Add(AL[k] / PALT);
            ALSC.Add(CLIP(ALSC2, ALSC1, TIME[k], PYEAR));
            NRFR.Add(NR[k] / NRI);
            ICOR.Add(CLIP(ICOR2, ICOR1, TIME[k], PYEAR));
            LYF.Add(CLIP(LYF2, LYF1, TIME[k], PYEAR));
            DCPH.Add(TABHL(DCPHT, PAL[k] / PALT, 0, 1, 0.1f));
            ALAI.Add(CLIP(ALAI2, ALAI1, TIME[k], PYEAR));
            FALM.Add(TABHL(FALMT, PFR[k - 1], 0, 4, 1));
            LF.Add((P2[k] + P3[k]) * LFPF);
            
            //Level 2
            LFDR.Add(TABHL(LFDRT, PPOLX[k], 0, 30, 10));
            AHLM.Add(TABHL(AHLMT, PPOLX[k], 1, 1001, 250));
            LMP.Add(TABHL(LMPT, PPOLX[k], 0, 100, 10));
            SO.Add((SC[k] * CUF[k - 1]) / SCOR[k]);
            FPU.Add(TABHL(FPUT, POP[k], 0, 16000000000, 2000000000));
            FCAOR1.Add(TABHL(FCAOR1T, NRFR[k], 0, 1, 0.1f));
            FCAOR2.Add(TABHL(FCAOR2T, NRFR[k], 0, 1, 0.1f));
            LFRT.Add(TABHL(LFRTT, FALM[k], 0, 0.1f, 0.02f));
            AIPH.Add(AI[k - 1] * (1 - FALM[k]) / AL[k]);

            //Level 3
            AHL.Add(AHL70 * AHLM[k]);
            SOPC.Add(SO[k] / POP[k]);
            FCAOR.Add(CLIP(FCAOR2[k], FCAOR1[k], TIME[k], PYEAR));
            LYMC.Add(TABHL(LYMCT, AIPH[k], 0, 1000, 40));
            PPGAO.Add(AIPH[k] * AL[k] * FIPM * AMTI);
            MLYMC.Add(TABHL(MLYMCT, AIPH[k], 0, 600, 40));
            JPH.Add(TABHL(JPHT, AIPH[k], 2, 30, 4));

            //Level 4
            HSAPC.Add(TABHL(HSAPCT, SOPC[k], 0, 2000, 250));
            JPSCU.Add(TABHL(JPSCUT, SOPC[k], 50, 800, 150) * 0.001f);
            IO.Add(IC[k] * (1 - FCAOR[k]) * CUF[k - 1] / ICOR[k]);
            PJAS.Add(JPH[k] * AL[k]);
            
            //Level 5
            EHSPC.Add(SMOOTH(HSAPC[k], HSID));
            PJSS.Add(SC[k] * JPSCU[k]);
            IOPC.Add(IO[k] / POP[k]);
            LYMAP1.Add(TABHL(LYMAP1T, IO[k] / IO70, 0, 30, 10));
            LYMAP2.Add(TABHL(LYMAP2T, IO[k] / IO70, 0, 30, 10));

            //Level 6
            LMHS1.Add(TABHL(LMHS1T, EHSPC[k], 0, 100, 20));
            LMHS2.Add(TABHL(LMHS2T, EHSPC[k], 0, 100, 20));
            CMI.Add(TABHL(CMIT, IOPC[k], 0, 1600, 200));
            DIOPC.Add(DLINF3(IOPC[k], SAD));
            FIOACV.Add(TABHL(FIOACVT, IOPC[k] / IOPCD, 0, 2, 0.2f));
            PCRUM.Add(TABHL(PCRUMT, IOPC[k], 0, 1600, 200));
            JPICU.Add(TABHL(JPICUT, IOPC[k], 50, 800, 150) * 0.001f);
            AIOPC.Add(SMOOTH(IOPC[k], IEAT));
            ISOPC1.Add(TABHL(ISOPC1T, IOPC[k], 0, 1600, 200));
            ISOPC2.Add(TABHL(ISOPC1T, IOPC[k], 0, 1600, 200));
            UILPC.Add(TABHL(UILPCT, IOPC[k], 0, 1600, 200));
            IFPC1.Add(TABHL(IFPC1T, IOPC[k], 0, 1600, 200));
            IFPC2.Add(TABHL(IFPC2T, IOPC[k], 0, 1600, 200));
            LYMAP.Add(CLIP(LYMAP2[k], LYMAP1[k], TIME[k], PYEAR));

            //Level 7
            LMHS.Add(CLIP(LMHS2[k], LMHS1[k], TIME[k], 1940));
            LMC.Add(1 - (CMI[k] * FPU[k]));
            SFSN.Add(TABHL(SFSNT, DIOPC[k], 0, 800, 200));
            FIOAC.Add(CLIP(FIOACV[k], FIOACC[k], TIME[k], IET));
            PPGIO.Add(PCRUM[k] * POP[k] * FRPM * IMEF * IMTI);
            NRUF.Add(CLIP(NRUF2, NRUF1, TIME[k], PYEAR));
            PJIS.Add(IC[k] * JPICU[k]);
            FIE.Add((IOPC[k] - AIOPC[k]) / AIOPC[k]);
            ISOPC.Add(CLIP(ISOPC2[k], ISOPC1[k], TIME[k], PYEAR));
            UILR.Add(UILPC[k] * POP[k]);
            IFPC.Add(CLIP(IFPC2[k], IFPC1[k], TIME[k], PYEAR));
            LY.Add(LYF[k] * LFERT[k] * LYMC[k] * LYMAP[k]);
            
            //Level 8
            FIOAS1.Add(TABHL(FIOAS1T, SOPC[k] / ISOPC[k], 0, 2, 0.5f));
            FIOAS2.Add(TABHL(FIOAS2T, SOPC[k] / ISOPC[k], 0, 2, 0.5f));
            J.Add(PJIS[k] + PJAS[k] + PJSS[k]);
            FRSN.Add(TABHL(FRSNT, FIE[k], -0.2f, 0.2f, 0.1f));
            F.Add(LY[k] * AL[k] * LFH * (1 - PL));
            LLMY1.Add(TABHL(LLMY1T, LY[k] / ILF, 0, 9, 1));
            LLMY2.Add(TABHL(LLMY2T, LY[k] / ILF, 0, 9, 1));
            MPLD.Add(LY[k] / (DCPH[k] * SD));
            MPAI.Add(ALAI[k] * LY[k] * MLYMC[k] / LYMC[k]);

            //Level 9
            FIOAS.Add(CLIP(FIOAS2[k], FIOAS1[k], TIME[k], PYEAR));
            LUF.Add(J[k] / LF[k]);
            DCFS.Add(CLIP(2, DCFSN * FRSN[k] * SFSN[k], TIME[k], ZPGT));
            FPC.Add(F[k] * POP[k]);
            LLMY.Add(CLIP(LLMY2[k], LLMY1[k], TIME[k], PYEAR));
            FIALD.Add(TABHL(FIALDT, MPLD[k] / MPAI[k], 0, 2, 0.25f));

            //Level 10
            LUFD.Add(SMOOTH(LUF[k], LUFDT));
            FIOAA1.Add(TABHL(FIOAA1T, FPC[k] / IFPC[k], 0, 2.5f, 0.5f));
            FIOAA2.Add(TABHL(FIOAA2T, FPC[k] / IFPC[k], 0, 2.5f, 0.5f));
            LMF.Add(TABHL(LMFT, FPC[k] / SFPC, 0, 5, 1));
            FR.Add(FPC[k] / SFPC);
            ALL.Add(ALLN * LLMY[k]);

            //Level 11
            LE.Add(LEN * LMF[k] * LMHS[k] * LMP[k] * LMC[k]);
            CUF.Add(TABHL(CUFT, LUFD[k], 1, 11, 2));
            FIOAA.Add(CLIP(FIOAA2[k], FIOAA1[k], TIME[k], PYEAR));
            PFR.Add(SMOOTH(FR[k], FSPD));

            //Level 12
            M1.Add(TABHL(M1T, LE[k], 20, 80, 10));
            M2.Add(TABHL(M2T, LE[k], 20, 80, 10));
            M3.Add(TABHL(M3T, LE[k], 20, 80, 10));
            M4.Add(TABHL(M3T, LE[k], 20, 80, 10));
            FM.Add(TABHL(FMT, LE[k], 0, 80, 10));
            PLE.Add(DLINF3(LE[k], LPD));
            FIOAI.Add(1 - FIOAA[k] - FIOAS[k] - FIOAC[k]);
            TAI.Add(IO[k] * FIOAA[k]);
            
            //Level 13
            MTF.Add(MTFN * FM[k]);
            CMPLE.Add(TABHL(CMPLET, PLE[k], 0, 80, 10));
            CAI.Add(TAI[k] * (1 - FIALD[k]));

            //Level 14
            DTF.Add(DCFS[k] * CMPLE[k]);
            AI.Add(SMOOTH(CAI[k], ALAI[k]));
            
            //Level 15
            NFC.Add((MTF[k] / DTF[k]) - 1);
            
            //Level 16
            FSAFC.Add(TABHL(FSAFCT, NFC[k], 0, 10, 2));
            
            //Level 17
            FCAPC.Add(FSAFC[k] * SOPC[k]);
            
            //Level 18
            FCFPC.Add(DLINF3(FCAPC[k], HSID));
            
            //Level 19
            FCE.Add(CLIP(1, (TABHL(FCET, FCFPC[k], 0, 3, 0.5F)), TIME[k], FCEST));
            
            //Level 20
            TF.Add(MIN(MTF[k], (MTF[k] * (1 - FCE[k]) + DTF[k] * FCE[k])));
            //TF.Add(MIN(1, 2));
        }
        //Debug.Log("Auxs: " + k);
        return true;
    }

    

    public bool Rates(int k)
    {
        if (k == 0)
        {
            //Total Pop
            D1.Add(1);
            MAT1.Add(1);
            D2.Add(1);
            MAT2.Add(1);
            D3.Add(1);
            MAT3.Add(1);
            D4.Add(1);
            //Birth
            B.Add(1);
            //Industrial
            ICDR.Add(1);
            ICIR.Add(1);
            //Service
            SCIR.Add(1);
            SCDR.Add(1);
            //Food From Investment In Land Development
            LDR.Add(1);
            //Land Erosion and Urban-Industrial Use
            LER.Add(1);
            LRUI.Add(1);
            //Land Fertility Degradation
            LFD.Add(1);
            //Land Fertility Regeneration
            LFR.Add(1);
            //Nonrenewable Resource Sector
            NRUR.Add(1);
            //Persistent Pollution Sector
            PPGR.Add(1);
            PPAPR.Add(1);
            PPASR.Add(1);
        }
        else
        {
            //Total Pop
            D1.Add(P1[k] * M1[k]);
            MAT1.Add(P1[k] * (1 - M1[k]) / 15);
            D2.Add(P2[k] * M2[k]);
            MAT2.Add(P2[k] * (1 - M2[k]) / 30);
            D3.Add(P3[k] * M3[k]);
            MAT3.Add(P3[k] * (1 - M3[k]) / 20);
            D4.Add(P4[k] * M4[k]);
            //Birth
            B.Add(CLIP(D[k], (TF[k] * P2[k] * 0.5f / RLT), TIME[k], PET));
            //Industrial
            ICDR.Add(IC[k] / ALIC[k]);
            ICIR.Add(IO[k] * FIOAI[k]);
            //Service
            SCIR.Add(IO[k] * FIOAS[k]);
            SCDR.Add(SC[k] / ALSC[k]);
            //Food From Investment In Land Development
            LDR.Add(TAI[k] * FIALD[k] / DCPH[k]);
            //Land Erosion and Urban-Industrial Use
            LER.Add(AL[k] / ALL[k]);
            LRUI.Add(MAX(0, (UILR[k] - UIL[k]) / UILDT));
            //Land Fertility Degradation
            LFD.Add(LFERT[k] * LFDR[k]);
            //Land Fertility Regeneration
            LFR.Add((ILF - LFERT[k]) / LFRT[k]);
            //Nonrenewable Resource Sector
            NRUR.Add(POP[k] * PCRUM[k] * NRUF[k]);
            //Persistent Pollution Sector
            PPGR.Add((PPGIO[k] + PPGAO[k]) * PPGF[k]);
            PPAPR.Add(DELAY3(PPGR[k], PPTD));
            PPASR.Add(PPOL[k] / (AHL[k]) * 1.4f);
        }
        //Debug.Log("Rates: " + k);
        return true;
    }

    void Supplementaries(int k)
    {
        //Death
        CDR.Add(1000 * D[k] / POP[k]);
        //Birth
        CBR.Add(1000 * B[k - 1] / POP[k]);
    }

    public void Advance(int k)
    {
        if (k == 0)
        {
            TIME.Add(TIMEI);
        }
        else
        {
            TIME.Add(TIME[k - 1] + DT);
        }
    }
    public float TABHL(float[] tab, float x, float xlow, float xhigh, float xincr)
    {
        if (x <= xlow) return tab[0];
        else if (x >= xhigh) return tab[tab.Length - 1];
        else {
            float search = xlow;
            int count = 0;
            bool found = false;
            while (!found)
            {
                search += xincr;
                count += 1;
                if (search > x) found = true;
            }
            return LinearInterpolation(x, search - xincr, search, tab[count - 1], tab[count]);
        }
    }

    float LinearInterpolation(float x, float x1, float x2, float y1, float y2)
    {
        return y1 + ((x - x1) / (x2 - x1)) * (y2 - y1);
    }
    float SMOOTH(float i, float del)
    {
        //TODO
        return i;
    }

    float DLINF3(float i, float del)
    {
        //TODO
        return i;
    }

    float DELAY3(float i, float del)
    {
        //TODO
        return i;
    }

    public float CLIP(float p, float q, float r, float s)
    {
        if (r >= s)
        {
            return p;
        } else
        {
            return q;
        }
    }

    public float MIN(float p, float q)
    {
        if (p <= q)
        {
            return p;
        } else
        {
            return q;
        }
    }

    public float MAX(float p, float q)
    {
        if (p >= q)
        {
            return p;
        } else
        {
            return q;
        }
    }
}
