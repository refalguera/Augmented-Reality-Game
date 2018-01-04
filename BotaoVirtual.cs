using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class BotaoVirtual : MonoBehaviour, IVirtualButtonEventHandler {

    void Start(){

        VirtualButtonBehaviour[] vbs = GetComponentsInChildren<VirtualButtonBehaviour>();

        for (int i = 0; i < vbs.Length; i++) {

            vbs[i].RegisterEventHandler(this);
        }

    }

    public void OnButtonPressed(VirtualButtonAbstractBehaviour vb) {

        Debug.Log("Botao: " + vb.VirtualButtonName + " pressionado");
    }

    public void OnButtonReleased(VirtualButtonAbstractBehaviour vb)
    {

        Debug.Log("Botao: " + vb.VirtualButtonName + " solto");
    }


}
