using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MIRAS : MonoBehaviour
{
    GameObject itemAtual, cordaPega;
    [SerializeField]
    GameObject cordaOBJ;
    [SerializeField]
    Transform mao, amigo;
    RaycastHit hit;
    [SerializeField]
    Sprite[]maosImages;//maoAberta = indice 0, indice 1 mao fechada,indice 2 mira normal
    [SerializeField]
    Image[] maoIMG;
    [SerializeField]
    Text[] textoDeDicas;
    int conesComCorda, contadorDeConesUsados = 0;
    Rigidbody rb;
    bool segurandoEscada = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        maoIMG[0].sprite = maosImages[2];
        maoIMG[1].sprite = maosImages[2];
    }

    void Update()
    {
        PegarItem();
        SoltarObjetos();
        ManipularEscada();
        Debug.DrawRay(transform.position, transform.forward * 1.06f);
    }

    void SoltarObjetos()
    {
        if (Input.GetButtonUp("Fire1") && itemAtual != null && (itemAtual.tag.Equals("Item") || itemAtual.tag.Equals("Escada")))
        {
            if (itemAtual.tag.Equals("Item") && itemAtual.GetComponent<VerificadorObjetos>().getJaManipulou() == false)
            {
                float distancia = Vector3.Distance(itemAtual.GetComponent<VerificadorObjetos>().getPosicaoInicial(), itemAtual.transform.position);
                if (distancia > 3)
                {//esse 3 e a distancia minima que considera que manipulou o cone
                    itemAtual.GetComponent<VerificadorObjetos>().SetJaManipulou(true);
                    contadorDeConesUsados += 1;
                }
                itemAtual.GetComponent<Rigidbody>().useGravity = true;
                itemAtual.GetComponent<Rigidbody>().isKinematic = false;
                itemAtual.transform.rotation = Quaternion.identity;//zerando rotacao
                itemAtual = null;//Garantir que agr ele nao tem itens
            }
            else if (itemAtual.tag.Equals("Escada"))
            {
                itemAtual.GetComponent<Rigidbody>().useGravity = true;
                itemAtual.GetComponent<Rigidbody>().isKinematic = false;
                itemAtual = null;//Garantir que agr ele nao tem itens
            }
        }
    }

    void ManipularEscada()
    {
        if (itemAtual != null && itemAtual.tag.Equals("Escada"))
        {
            itemAtual.transform.eulerAngles = new Vector3(itemAtual.transform.eulerAngles.x, mao.eulerAngles.y, itemAtual.transform.eulerAngles.z);
            if (segurandoEscada == false)
            {
                amigo.SetParent(GameObject.Find("EscadaBPivot").transform);
                amigo.localPosition = Vector3.zero;
                amigo.LookAt(transform.position);
                segurandoEscada = true;
            }
        }
        else if (GameObject.FindGameObjectWithTag("Escada").GetComponent<VerificadorObjetos>().getColisor() != null && itemAtual == null)
        {
            if (GameObject.FindGameObjectWithTag("Escada").GetComponent<VerificadorObjetos>().getColisor().tag.Equals("Poste") && segurandoEscada == true)
            {
                amigo.SetParent(null);
                segurandoEscada = false;
            }
            else if (GameObject.FindGameObjectWithTag("Escada").GetComponent<VerificadorObjetos>().getColisor().tag.Equals("Poste") && amigo.position != new Vector3(GameObject.Find("LugarPisar").transform.position.x, 1, GameObject.Find("LugarPisar").transform.position.z) && segurandoEscada == false)
            {
                Debug.Log("Lendo");
                amigo.position = Vector3.MoveTowards(amigo.position, new Vector3(GameObject.Find("LugarPisar").transform.position.x, 1, GameObject.Find("LugarPisar").transform.position.z), 0.1f);
                amigo.LookAt(GameObject.Find("EscadaBPivot").transform.position);
            }
        }
    }

    void PegarItem()
    {
        maoIMG[0].sprite = maosImages[2];
        maoIMG[1].sprite = maosImages[2];
        if (Physics.Raycast(transform.position, transform.forward, out hit, 1.06f))
        {
            if (hit.collider.tag.Equals("Item") && itemAtual == null)
            {
                maoIMG[0].sprite = maosImages[0];
                maoIMG[1].sprite = maosImages[0];
                if (Input.GetButtonDown("Fire1"))
                {
                    itemAtual = hit.collider.gameObject;
                    itemAtual.transform.position = mao.position;
                    itemAtual.GetComponent<Rigidbody>().useGravity = false;
                    itemAtual.GetComponent<Rigidbody>().isKinematic = true;
                }
            }
            else if (hit.collider.tag.Equals("Escada") && Input.GetButton("Fire2"))
            {
                //aqui coloca animacao do personagem abaixando
                maoIMG[0].sprite = maosImages[0];
                maoIMG[1].sprite = maosImages[0];
                if (Input.GetButtonDown("Fire1"))
                {
                    itemAtual = hit.collider.gameObject;
                    itemAtual.transform.position = mao.position;
                    itemAtual.GetComponent<Rigidbody>().useGravity = false;
                    itemAtual.GetComponent<Rigidbody>().isKinematic = true;
                }
            }
			/*
            else if (hit.collider.tag.Equals("Corda"))
            {
                Debug.Log("Colidindo com corda!");
                if (Input.GetButtonDown("Fire1"))
                {
                    if (cordaPega != null)
                    {
                        cordaPega.GetComponent<Corda>().SetDestino(hit.transform);
                    }

                    if (conesComCorda <= 7)
                    {
                        GameObject g = Instantiate(cordaOBJ, hit.transform.position, Quaternion.identity) as GameObject;
                        cordaPega = g;
                        conesComCorda++;
                    }

                }
            }
            */
        }
        if (itemAtual != null)
        {
            maoIMG[0].sprite = maosImages[1];
            maoIMG[1].sprite = maosImages[1];
            itemAtual.transform.position = mao.position;
        }
    }

    void OnTriggerEnter(Collider outro)
    {
        if (outro.tag.Equals("Area de Ferramentas"))
        {
            textoDeDicas[0].text = "Aperte o Botão X para chamar o amigo!";
            textoDeDicas[1].text = "Aperte o Botão X para chamar o amigo!";
        }
    }

    void OnTriggerStay(Collider outro)
    {
        if (outro.tag.Equals("Area de Ferramentas") && Vector3.Distance(transform.position, amigo.position) > 2)
        {
            amigo.position = Vector3.MoveTowards(amigo.position, transform.position, 0.2f);
        }
    }
}
