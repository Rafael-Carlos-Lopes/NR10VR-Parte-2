using UnityEngine;
using System.Collections;

public class ControladorCones : MonoBehaviour {

	int conesPosicionadosCorretamente;//contador de cones posicionados corretamente
	int cordasColocadas;
	int bandeirasColocadas;
	[SerializeField]
	GameObject[] cones;

	[SerializeField]
	GameObject conferirPontuacao;

	public void AumentarContadorConesColocados()
	{
		conesPosicionadosCorretamente ++;
	}
	
	public void DiminuirContadorConesColocados()
	{
		conesPosicionadosCorretamente --;
	}

	public void AumentarContadorCordasColocadas()
	{
		cordasColocadas ++;
	}

	public void AumentarContadorBandeirasColocadas()
	{
		bandeirasColocadas ++;
	}
	
	void Update()
	{
		if (conesPosicionadosCorretamente == 8)
		{
			for (int i = 0; i < cones.Length; i++)
			{
				cones[i].tag = "Corda";
			}

			PlayerPrefs.SetInt ("PontosConesColocados", 10);

			//amigo.GetComponent<NPCFalas> ().SetBomTrab ();
			GameObject.FindGameObjectWithTag("Amigo").GetComponent<NPCFalas> ().SetBomTrab();
			conesPosicionadosCorretamente = 0;
		}

		if (cordasColocadas == 7) 
		{
			for (int i = 0; i < cones.Length; i++)
			{
				cones[i].tag = "Bandeira";
			}

			PlayerPrefs.SetInt ("PontosCordasColocadas", 10);

			//amigo.GetComponent<NPCFalas> ().SetBomTrab ();
			GameObject.FindGameObjectWithTag("Amigo").GetComponent<NPCFalas> ().SetBomTrab();
			cordasColocadas = 0;
		}

		if (bandeirasColocadas == 8) 
		{
			for (int i = 0; i < cones.Length; i++)
			{
				cones[i].tag = "BandeiraColocada";
			}

			PlayerPrefs.SetInt ("PontosBandeirasColocadas", 10);

			bandeirasColocadas = 0;
			//amigo.GetComponent<NPCFalas> ().SetBoaSina ();
			GameObject.FindGameObjectWithTag("Amigo").GetComponent<NPCFalas> ().SetBoaSina();

			gameObject.GetComponent<ControladorCones> ().enabled = false;
		}
	}
}