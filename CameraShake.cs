using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour
{
    bool tremendo, movendo = false, morreu;
    float forcaTremedeira;
    float intensidadeTremedeira;
	float delay;
    Vector3 OriginalPos;
    Quaternion OriginalRot;
    [SerializeField]
    Transform pivot;//transform para onde a camera vai
	[SerializeField]
	GameObject cameraObj, verSubiuEscada;
    
    void Update()
    {
        if (intensidadeTremedeira > 0)
        {
			cameraObj.transform.position = OriginalPos + Random.insideUnitSphere * intensidadeTremedeira;
			cameraObj.transform.rotation = new Quaternion(OriginalRot.x + Random.Range(-intensidadeTremedeira, intensidadeTremedeira) * .2f, 
                OriginalRot.y + Random.Range(-intensidadeTremedeira, intensidadeTremedeira) * .2f, 
                OriginalRot.z + Random.Range(-intensidadeTremedeira, intensidadeTremedeira) * .2f, 
                OriginalRot.w + Random.Range(-intensidadeTremedeira, intensidadeTremedeira) * .2f);
            intensidadeTremedeira -= forcaTremedeira;
        }
        else if (tremendo)
        {
            tremendo = false;
            FazTremer();
        }
        if (movendo)
            Movendo();
    }

    public void Movendo()
    {
        //Debug.Log("Movendo!");
        if (movendo)
        {
			cameraObj.transform.position = Vector3.Lerp(cameraObj.transform.position, pivot.position, 0.2f);
			cameraObj.transform.rotation = Quaternion.Lerp(cameraObj.transform.rotation, pivot.rotation, 0.2f);
			Debug.Log (delay);

		} 
			
		if (cameraObj.transform.position == pivot.position && cameraObj.transform.rotation == pivot.rotation && movendo) {
			movendo = false;
		}
    }

    public void FazTremer()
    {
		OriginalPos = cameraObj.transform.position;
		OriginalRot = cameraObj.transform.rotation;
        intensidadeTremedeira = 0.01f;
        forcaTremedeira = 0.01f;
        tremendo = true;
    }

	public void SetMovendo(bool valor){
		movendo = valor;
	}

	void ChamarSubirEscada()
	{
		verSubiuEscada.GetComponent<VerificaSobirEscada> ().SubirEscada ();
	}

	public void SetMorreu(bool valor)
	{
		morreu = valor;
	}
}