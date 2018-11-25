using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputController : MonoBehaviour {

    public GameObject CompleteMachine;
    public GameObject TopPartMachine;
    public GameObject BottomPartMachine;

    public Animator MachineAnimator;

    public GameObject PartCanvas;
    public GameObject MachineCover;
    public GameObject EngineModel;
    public GameObject SawModel;
    public GameObject LabeledModel;
    public GameObject PressModel;
    public bool EngineShown;

	// Use this for initialization
	void Start () {

        PartCanvas.SetActive(false);
        EngineModel.SetActive(false);
        SawModel.SetActive(false);
        LabeledModel.SetActive(false);
        PressModel.SetActive(false);
        
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Explode()
    {
        PartCanvas.SetActive(true);
        MachineCover.SetActive(false);
        CompleteMachine.SetActive(false);
        TopPartMachine.SetActive(false);
        BottomPartMachine.SetActive(false);
        if (EngineShown == true)
        {
            EngineShown = false;
            EngineModel.SetActive(false);
        }
          
    }

    public void Together()
    {
        PartCanvas.SetActive(false);
        MachineCover.SetActive(true);
    }

    public void ShowEngineModel()
    {
        EngineModel.SetActive(true);
        PartCanvas.SetActive(false);
        EngineShown = true;
    }

    public void separate()
    {
        if (!MachineAnimator.GetBool("Open")){
            CompleteMachine.SetActive(false);
            TopPartMachine.SetActive(true);
            BottomPartMachine.SetActive(true);

            MachineAnimator.SetBool("Open", true);
        }
        else {
            StartCoroutine(goCompleteModel());
            MachineAnimator.SetBool("Open", false);
        }
    }

    public IEnumerator goCompleteModel() {
        yield return new WaitForSecondsRealtime(2f);
        CompleteMachine.SetActive(true);
        TopPartMachine.SetActive(false);
        BottomPartMachine.SetActive(false);

    }
}
