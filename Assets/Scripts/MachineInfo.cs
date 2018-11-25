using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
public class MachineInfo : MonoBehaviour {


    public Text timeStampText;
    public string TimeStamp { get { return timestamp; } set { timestamp = value; timeStampText.text = value; } }


    public Text IDText;
    public string ID { get { return iD; } set { iD = value; IDText.text = value; } }

    public Text jobNameText;
    public string JobName { get { return jobName; } set { jobName = value; jobNameText.text = value; } }

    public Text machineStateText;
    public string MachineState { get { return machineState; } set { machineState = value; machineStateText.text = value; } }

    public Text machineSpeedText;
    public string MachineSpeed { get { return machineSpeed; } set { machineSpeed = value; machineSpeedText.text = value; } }

    public Text machineSpeedMaxText;
    public string MachineSpeedMax { get { return machineSpeedMax; } set { machineSpeedMax = value; machineSpeedMaxText.text = value; } }

    public Text inputCounterText;
    public string InputCounter { get { return inputCounter; } set { inputCounter = value; inputCounterText.text = value; } }

    public Text outputCounterText;
    public string OutputCounter { get { return outputCounter; } set { outputCounter = value; outputCounterText.text = value; } }

    public Text cuttingForceText;
    public string CuttingForce { get { return cuttingForce; } set { cuttingForce = value; cuttingForceText.text = value; } }

    public Text cuttingForceMaxText;
    public string CuttingForceMax { get { return cuttingForceMax; } set { cuttingForceMax = value; cuttingForceMaxText.text = value; } }

    public Text normalStopText;
    public string NormalStop { get { return normalStop; } set { normalStop = value; normalStopText.text = value; } }

    public Text urgentStopText;
    public string UrgentStop { get { return urgentStop; } set { urgentStop = value; urgentStopText.text = value; } }

    public Text openProtectionText;
    public string OpenProtection { get { return openProtection; } set { openProtection = value; openProtectionText.text = value; } }

    public Text technicalDefectText;
    public string TechnicalDefect { get { return technicalDefect; } set { technicalDefect = value; technicalDefectText.text = value; } }


    string timestamp, iD, jobName, machineState, machineSpeed, machineSpeedMax, inputCounter, outputCounter, 
        cuttingForce, cuttingForceMax, normalStop, urgentStop, openProtection, technicalDefect;


    void Start()
    {
        StartCoroutine(GetText());
    }

    IEnumerator GetText()
    {
        while (true)
        {
            UnityWebRequest www = UnityWebRequest.Get("http://www.duggan.ch/~akv_lauzhack/mastercut.php");
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                // Show results as text
                Debug.Log(www.downloadHandler.text);

                string data = www.downloadHandler.text;
                data.Replace('{', ' ');
                data.Replace('}', ' ');
                data.Replace('[', ' ');
                data.Replace(']', ' ');
                string[] parts = data.Split(',');

                for (int i=0; i<parts.Length; i++)
                {
                    parts[i] = parts[i].Replace('"', ' ');
                }
                TimeStamp = parts[0];
                ID = parts[1];
                JobName = parts[2];
                MachineState = parts[3];
                MachineSpeed = parts[4];
                MachineSpeedMax = parts[5];
                InputCounter = parts[6];
                OutputCounter = parts[7];
                CuttingForce = parts[8];
                CuttingForceMax = parts[9];
                NormalStop = parts[10];
                UrgentStop = parts[11];
                OpenProtection = parts[12];
                TechnicalDefect = parts[13];

            }
            yield return new WaitForSecondsRealtime(3f);
        }
    }
}
