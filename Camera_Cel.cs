using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Camera_Cel : MonoBehaviour {

	private bool cameraDisponivel;
	private WebCamTexture cameraDeTras;
	private Texture fundoPadrao;

	public RawImage fundo;
	public AspectRatioFitter encaixa;

	private void Start () {
		
		fundoPadrao = fundo.texture;
		WebCamDevice[] dispositivos = 	WebCamTexture.devices;

		if (dispositivos.Length == 0) {

			Debug.Log("Nenhuma câmera detectada");
			cameraDisponivel = false;
			return;
		}

		for (int i=0; i< dispositivos.Length; i++) {

			if (!dispositivos[i].isFrontFacing) {

				cameraDeTras = new WebCamTexture(dispositivos[i].name, Screen.width, Screen.height);
			}
		}

		if (cameraDeTras == null) {

			Debug.Log("Não foi possível encontrar a câmera de trás");
			return;
		}

		cameraDeTras.Play();
		fundo.texture = cameraDeTras;

		cameraDisponivel=true;
	}

	private void Update () {
		
		if (!cameraDisponivel) {

			return;
		}

		float proporcao = (float)cameraDeTras.width / (float)cameraDeTras.height;
		encaixa.aspectRatio = proporcao;

		float escalaY = cameraDeTras.videoVerticallyMirrored ? -1f:1f;
		fundo.rectTransform.localScale = new Vector3(1f, escalaY, 1f);

		int orientacao = -cameraDeTras.videoRotationAngle;
		fundo.rectTransform.localEulerAngles = new Vector3(0, 0, orientacao);
	}
}
