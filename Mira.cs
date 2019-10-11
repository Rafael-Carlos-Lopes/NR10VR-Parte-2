using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Mira : MonoBehaviour {
	//Declarando variaveis
	public GameObject itemAtual;
    [SerializeField]
    GameObject personagem, aterramento, aterramento2, characterController, dialogos1, dialogos2, barraDeSeguranca1, barraDeSeguranca2, placa1, placa2,
               posTampa1, posTampa2, tampa, botaoPainel, botoes, posBotoes1, posBotoes2, cadeado1, cadeado2,
               multimetro, fio1, fio2, fio3 ,barraCarregamento1, barraCarregamento2, localDescabear, localCadeado, 
               localAterra, localCabear, AvisoLigado, AvisoDesligado, areaAterramento,
        
               animBarra1, animBarra2, ligaPainel;

	[SerializeField] Transform mao, amigo, posReset, posOrigAterra;
	RaycastHit hit;
	[SerializeField] Sprite[] maosImages;//maoAberta = indice 0, indice 1 mao fechada,indice 2 mira normal
	[SerializeField] Image[] maoIMG;
	bool segurandoEscada = false, podeTerminar = false;
	Rigidbody rb;
    [SerializeField]
    Transform posOrigMulti;

    [SerializeField]
	GameObject playerSubir;

	bool segurar = false;
	bool pausado = false;

	string objetoParaInteragir = "painel";

	[SerializeField]
	GameObject[] areasVerdes, animacoesBrasao, animacoes5Pontos;//pega a lista com as areas
	[SerializeField]
	GameObject amigoAnim; 

	[SerializeField]
	bool errouAbrirChaves, errouFecharChaves, ativarBarra, podeInteragir;

	bool dialogoAparecendo, menuAtivado, placaSegurada, aterraSegurado, cadeadoSegurado, multiSegurado, gameOverAterra;

	[SerializeField]
	Sprite[] sprites;

    //booleanas para identificar se o jogador acertou de primeira ou nao
    bool errouPainel, errouPlaca, errouDesligar, errouCadeado, errouMulti, errouCabeamento,
        errouDesaterrar, errouDesbloquear, errouLigar, errouPainelLigar;

    [SerializeField]
    Text textoAcao1, textoAcao2;

	void Start () {
		rb = GetComponent<Rigidbody>();
		Cursor.lockState = CursorLockMode.Locked;//ocultando cursor
		maoIMG[0].sprite = maosImages[2];
		maoIMG[1].sprite = maosImages[2];

        SetarImagem(0);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(pausado == false)
		{
			if (Input.GetKeyDown (KeyCode.R)) 
			{
				SceneManager.LoadScene(SceneManager.GetActiveScene().name);
			}

			if (podeTerminar == true) 
			{
				if (Input.GetButtonDown ("Fire1")) 
				{
					Invoke ("TerminarJogo", 2f);
					dialogos1.SetActive (false);
					dialogos2.SetActive (false);
				}
			}

			if (dialogoAparecendo == true) 
			{
				if (Input.GetButtonDown ("Fire1")) {
					dialogos1.SetActive (false);
					dialogos2.SetActive (false);
                    maoIMG[0].enabled = true;
                    maoIMG[1].enabled = true;
                    Invoke("DesativarBoolDialogo", 0.2f);
                    Invoke("SetPodeInteragir", 0.1f);
                    characterController.GetComponent<CharacterController>().enabled = true;

                    if(gameOverAterra == true)
                    {
                        aterramento.GetComponent<Transform>().position = posOrigAterra.position;
                        personagem.GetComponent<Transform>().position = posReset.position;
                        itemAtual = null;
                        aterramento.GetComponent<BoxCollider>().enabled = true;
                        aterramento.GetComponent<Transform>().eulerAngles = new Vector3(0, 90, 0);
                        aterraSegurado = false;
                        gameOverAterra = false;
                    }
                }
		}

        if (ativarBarra == true)
            {
                if(Input.GetButtonDown("Fire1"))
                {
                    animBarra1.SetActive(true);
                    animBarra2.SetActive(true);
                    Invoke("ChamarImagem17", 2f);
                }
            }
        //chamando funcoes a serem atualizadas
		PegarItem();
		Debug.DrawRay(transform.position, transform.forward * 3f);//isso pode ser removido
		}
	}

	void PegarItem()
    {
		maoIMG[0].sprite = maosImages[2];
		maoIMG[1].sprite = maosImages[2];
        DesativarTexto();
        if (podeInteragir == true)
        {
            if (Physics.Raycast(transform.position, transform.forward, out hit, 2))
            {

                //=======================================================================================================
                if (hit.collider.tag.Equals("PainelComando") && objetoParaInteragir == "painel")
                {
                    maoIMG[0].sprite = maosImages[0];
                    maoIMG[1].sprite = maosImages[0];
                    AtivarTexto("Desligar Painel");
                    if (Input.GetButtonDown("Fire1"))
                    {

                        AvisoLigado.SetActive(false);
                        AvisoDesligado.SetActive(true);

                        if (errouPainel == false)
                        {
                            Invoke("AumentarBarras10", 2f);
                            animacoesBrasao[0].SetActive(true);
                            animacoesBrasao[1].SetActive(true);
                        }

                        if (errouPainel == true)
                        {
                            Invoke("AumentarBarras5", 2f);
                            animacoes5Pontos[0].SetActive(true);
                            animacoes5Pontos[1].SetActive(true);
                        }
                        objetoParaInteragir = "placa";
                    }
                }

                //====================================================================================================
                if (hit.collider.tag.Equals("PainelComando") && objetoParaInteragir == "placa"
                    && placaSegurada == true)
                {
                    maoIMG[0].sprite = maosImages[0];
                    maoIMG[1].sprite = maosImages[0];
                    AtivarTexto("Colocar Placa");
                    if (Input.GetButtonDown("Fire1"))
                    {
                        placa1.SetActive(false);
                        placa2.SetActive(true);
                        itemAtual = null;
                        objetoParaInteragir = "botaodesligar";
                        tampa.GetComponent<Transform>().eulerAngles = posTampa2.GetComponent<Transform>().eulerAngles;
                        botaoPainel.GetComponent<BoxCollider>().enabled = true;
                        if (errouPlaca == false)
                        {
                            Invoke("AumentarBarras10", 2f);
                            animacoesBrasao[0].SetActive(true);
                            animacoesBrasao[1].SetActive(true);
                        }

                        else
                        {
                            Invoke("AumentarBarras5", 2f);
                            animacoes5Pontos[0].SetActive(true);
                            animacoes5Pontos[1].SetActive(true);
                        }

                        placaSegurada = false;
                    }
                    
                }
               
                //===================================================================================================
                else if (hit.collider.tag.Equals("PainelLigar") && objetoParaInteragir == "PainelLigar")
                {
                    maoIMG[0].sprite = maosImages[0];
                    maoIMG[1].sprite = maosImages[0];
                    AtivarTexto("LigarPainel");
                    if (Input.GetButtonDown("Fire1"))
                    {
                        AvisoLigado.SetActive(true);
                        AvisoDesligado.SetActive(false);

                        if (errouPainelLigar == false)
                        {
                            Invoke("AumentarBarras10", 2f);
                            animacoesBrasao[0].SetActive(true);
                            animacoesBrasao[1].SetActive(true);
                        }

                        else if (errouPainelLigar == true)
                        {
                            Invoke("AumentarBarras5", 2f);
                            animacoes5Pontos[0].SetActive(true);
                            animacoes5Pontos[1].SetActive(true);
                        }
                        objetoParaInteragir = "placa2";
                    }
                }

                //=================================================================================================================
                else if (hit.collider.tag.Equals("Placa2"))
                {
                    maoIMG[0].sprite = maosImages[0];
                    maoIMG[1].sprite = maosImages[0];
                    AtivarTexto("Retirar Placa");
                    if (Input.GetButtonDown("Fire1"))
                    {
                        if (objetoParaInteragir == "placa2")
                        {
                            Invoke("AumentarBarras10", 2f);
                            animacoesBrasao[0].SetActive(true);
                            animacoesBrasao[1].SetActive(true);
                            placa2.SetActive(false);
                            SetarImagem(23);
                            Invoke("TerminarJogo", 4f);
                        }

                        else if (objetoParaInteragir == "PainelLigar")
                        {
                            if (dialogoAparecendo == false)
                            {
                                SetarImagem(22);
                                errouPainelLigar = true;
                                PlayerPrefs.SetInt("Errou4", 1);
                            }
                        }

                    }
                }
                //=============================================================================================
                else if (hit.collider.tag.Equals("Placa") && itemAtual == null)
                {
                    maoIMG[0].sprite = maosImages[0];
                    maoIMG[1].sprite = maosImages[0];
                    AtivarTexto("Pegar Placa");
                    if (Input.GetButtonDown("Fire1"))
                    {
                        if (objetoParaInteragir == "placa")
                        {
                            itemAtual = hit.collider.gameObject;
                            itemAtual.transform.position = mao.position;
                            itemAtual.GetComponent<BoxCollider>().enabled = false;
                            itemAtual.GetComponent<Transform>().eulerAngles = new Vector3(90, -90, 0);
                            placaSegurada = true;
                        }

                        else if (objetoParaInteragir == "painel")
                        {
                            if (dialogoAparecendo == false)
                            {
                                SetarImagem(4);
                                errouPainel = true;
                                PlayerPrefs.SetInt("Errou3", 1);
                            }
                        }

                    }
                }

                //===============================================================================================================
                else if (hit.collider.tag.Equals("AreaAterramento") && aterraSegurado == true)
                {
                    maoIMG[0].sprite = maosImages[0];
                    maoIMG[1].sprite = maosImages[0];
                    AtivarTexto("Soltar Aterramento Temporário");

                    if (Input.GetButtonDown("Fire1"))
                    {
                        aterramento.GetComponent<Transform>().position = posOrigAterra.position;
                        itemAtual = null;
                        aterramento.GetComponent<BoxCollider>().enabled = true;
                        aterramento.GetComponent<Transform>().eulerAngles = new Vector3(0, 90, 0);
                        aterraSegurado = false;
                        areaAterramento.SetActive(true);
                    }
                }
                //=================================================================================================================

                else if (hit.collider.tag.Equals("BotaoDesliga") && objetoParaInteragir == "botaodesligar")
                {
                    maoIMG[0].sprite = maosImages[0];
                    maoIMG[1].sprite = maosImages[0];
                    AtivarTexto("Desligar Disjuntor");
                    if (Input.GetButtonDown("Fire1"))
                    {

                        if (aterraSegurado == true)
                        {
                            SetarImagem(8);
                            errouDesligar = true;
                            gameOverAterra = true;
                            PlayerPrefs.SetInt("Errou4", 1);
                        }

                        else
                        {
                            botoes.GetComponent<Transform>().position = posBotoes2.GetComponent<Transform>().position;
                            botoes.GetComponent<Transform>().eulerAngles = posBotoes2.GetComponent<Transform>().eulerAngles;
                            objetoParaInteragir = "LocalCadeado";
                            botaoPainel.GetComponent<BoxCollider>().enabled = false;

                            if (errouDesligar == false)
                            {
                                Invoke("AumentarBarras10", 2f);
                                animacoesBrasao[0].SetActive(true);
                                animacoesBrasao[1].SetActive(true);
                            }

                            else
                            {
                                Invoke("AumentarBarras5", 2f);
                                animacoes5Pontos[0].SetActive(true);
                                animacoes5Pontos[1].SetActive(true);
                            }
                        }
                    }
                }

                //==============================================================================================

                else if (hit.collider.tag.Equals("BotaoDesliga") && objetoParaInteragir == "BotaoLiga")
                {
                    maoIMG[0].sprite = maosImages[0];
                    maoIMG[1].sprite = maosImages[0];
                    AtivarTexto("Ligar Disjuntor");
                    if (Input.GetButtonDown("Fire1"))
                    {
                        botoes.GetComponent<Transform>().position = posBotoes1.GetComponent<Transform>().position;
                        botoes.GetComponent<Transform>().eulerAngles = posBotoes1.GetComponent<Transform>().eulerAngles;
                        botaoPainel.GetComponent<BoxCollider>().enabled = false;
                        objetoParaInteragir = "LocalMultimetro2";

                        if (errouLigar == false)
                        {
                            Invoke("AumentarBarras10", 2f);
                            animacoesBrasao[0].SetActive(true);
                            animacoesBrasao[1].SetActive(true);
                        }

                        else
                        {
                            Invoke("AumentarBarras5", 2f);
                            animacoes5Pontos[0].SetActive(true);
                            animacoes5Pontos[1].SetActive(true);
                        }

                    }
                }



                //====================================================================================================

                else if (hit.collider.tag.Equals("LocalCadeado") && objetoParaInteragir == "LocalCadeado"
                    && cadeadoSegurado == true)
                {
                    maoIMG[0].sprite = maosImages[0];
                    maoIMG[1].sprite = maosImages[0];
                    AtivarTexto("Colocar Kit Bloqueio");

                    if (Input.GetButtonDown("Fire1"))
                    {
                        if (cadeadoSegurado == true)
                        {
                            if (errouCadeado == false)
                            {
                                Invoke("AumentarBarras10", 2f);
                                animacoesBrasao[0].SetActive(true);
                                animacoesBrasao[1].SetActive(true);
                            }

                            else
                            {
                                Invoke("AumentarBarras5", 2f);
                                animacoes5Pontos[0].SetActive(true);
                                animacoes5Pontos[1].SetActive(true);
                            }

                            cadeado1.SetActive(false);
                            cadeado2.SetActive(true);
                            itemAtual = null;
                            objetoParaInteragir = "LocalMulti";
                            localCadeado.GetComponent<BoxCollider>().enabled = false;
                        }

                        else if (aterraSegurado == true)
                        {
                            SetarImagem(12);
                            errouCadeado = true;
                            gameOverAterra = true;
                            PlayerPrefs.SetInt("Errou3", 1);
                        }
                    }
                }

                //==================================================================================================

                else if (hit.collider.tag.Equals("LocalMultimetro") && objetoParaInteragir == "LocalMulti"
                    && multiSegurado == true)
                {
                    maoIMG[0].sprite = maosImages[0];
                    maoIMG[1].sprite = maosImages[0];
                    AtivarTexto("Usar Multímetro");

                    if (Input.GetButtonDown("Fire1"))
                    {
                        
                        if (errouMulti == false)
                        {
                            Invoke("AumentarBarras10", 2f);
                            animacoesBrasao[0].SetActive(true);
                            animacoesBrasao[1].SetActive(true);
                        }

                        else
                        {
                            Invoke("AumentarBarras5", 2f);
                            animacoes5Pontos[0].SetActive(true);
                            animacoes5Pontos[1].SetActive(true);
                        }

                        SetarImagem(16);
                        multimetro.SetActive(false);
                        itemAtual = null;
                        objetoParaInteragir = "LocalAterra";
                        localAterra.SetActive(true);
                        multiSegurado = false;
                        
                    }
                }
                //====================================================================================================
                else if (hit.collider.tag.Equals("LocalMultimetro") && objetoParaInteragir == "LocalMultimetro2"
                    && multiSegurado == true)
                {
                    AtivarTexto("Usar Multímetro");
                    maoIMG[0].sprite = maosImages[0];
                    maoIMG[1].sprite = maosImages[0];

                    if (Input.GetButtonDown("Fire1"))
                    {

                        Invoke("AumentarBarras10", 2f);
                        animacoesBrasao[0].SetActive(true);
                        animacoesBrasao[1].SetActive(true);

                        SetarImagem(24);
                        multimetro.SetActive(false);
                        itemAtual = null;
                        objetoParaInteragir = "PainelLigar";
                        ligaPainel.SetActive(true);
                        tampa.GetComponent<BoxCollider>().enabled = false;
                        tampa.GetComponent<Transform>().eulerAngles = posTampa1.GetComponent<Transform>().eulerAngles;

                        
                    }
                }
                //=====================================================================================================

                else if (hit.collider.tag.Equals("LocalDescabear") && objetoParaInteragir == "LocalDescabear"
                         && dialogoAparecendo == false)
                {
                    maoIMG[0].sprite = maosImages[0];
                    maoIMG[1].sprite = maosImages[0];
                    if (aterraSegurado == true)
                        AtivarTexto("Colocar Aterramento Temporário");

                    else
                        AtivarTexto("Retirar Cabos");

                    if (Input.GetButtonDown("Fire1"))
                    {
                        if (aterraSegurado == true)
                        {
                            SetarImagem(14);
                            errouCabeamento = true;
                            gameOverAterra = true;
                            PlayerPrefs.SetInt("Errou3", 1);
                        }

                        else
                        {
                            if (errouCabeamento == false)
                            {
                                Invoke("AumentarBarras10", 2f);
                                animacoesBrasao[0].SetActive(true);
                                animacoesBrasao[1].SetActive(true);
                            }

                            else
                            {
                                Invoke("AumentarBarras5", 2f);
                                animacoes5Pontos[0].SetActive(true);
                                animacoes5Pontos[1].SetActive(true);
                            }

                            fio1.SetActive(false);
                            fio2.SetActive(false);
                            fio3.SetActive(false);
                            objetoParaInteragir = "LocalAterra";
                            localAterra.SetActive(true);
                            localDescabear.SetActive(false);
                        }
                    }
                }
                //=======================================================================================================

                else if (hit.collider.tag.Equals("LocalAterra") && objetoParaInteragir == "LocalAterra"
                         && dialogoAparecendo == false)
                {
                    if (aterraSegurado == true)
                    {
                        maoIMG[0].sprite = maosImages[0];
                        maoIMG[1].sprite = maosImages[0];
                        AtivarTexto("Colocar Aterramento Temporário");

                        if (Input.GetButtonDown("Fire1"))
                        {
                            ativarBarra = true;
                            SetarImagem(15);
                            aterramento.SetActive(false);
                            aterramento2.SetActive(true);
                            objetoParaInteragir = "Desaterrar";
                            multimetro.SetActive(true);
                            multimetro.GetComponent<Transform>().position = posOrigMulti.position;
                            multimetro.GetComponent<BoxCollider>().enabled = true;
                            multimetro.GetComponent<Transform>().eulerAngles = posOrigMulti.eulerAngles;
                            multimetro.GetComponent<Transform>().eulerAngles = posOrigMulti.eulerAngles;
                            localCabear.SetActive(true);
                            cadeado2.GetComponent<BoxCollider>().enabled = true;
                            aterraSegurado = false;
                            itemAtual = null;
                        }
                    }
                }

                //=======================================================================================================
                else if (hit.collider.tag.Equals("Desaterrar") && objetoParaInteragir == "Desaterrar"
                    && dialogoAparecendo == false)
                {
                    maoIMG[0].sprite = maosImages[0];
                    maoIMG[1].sprite = maosImages[0];
                    AtivarTexto("Retirar Aterramento Temporário");
                    if (Input.GetButtonDown("Fire1"))
                    {
                        objetoParaInteragir = "Desbloquear";
                        fio1.SetActive(true);
                        fio2.SetActive(true);
                        fio3.SetActive(true);
                        aterramento2.SetActive(false);
                        localCabear.SetActive(false);

                        if (errouDesaterrar == false)
                        {
                            Invoke("AumentarBarras10", 2f);
                            animacoesBrasao[0].SetActive(true);
                            animacoesBrasao[1].SetActive(true);
                        }

                        else
                        {
                            Invoke("AumentarBarras5", 2f);
                            animacoes5Pontos[0].SetActive(true);
                            animacoes5Pontos[1].SetActive(true);
                        }
                    }

                }

                //======================================================================================================

                else if (hit.collider.tag.Equals("Desbloquear") && objetoParaInteragir == "Desbloquear"
                  && dialogoAparecendo == false)
                {
                    maoIMG[0].sprite = maosImages[0];
                    maoIMG[1].sprite = maosImages[0];
                    AtivarTexto("Retirar Kit Bloqueio");
                    if (Input.GetButtonDown("Fire1"))
                    {
                        objetoParaInteragir = "BotaoLiga";
                        cadeado2.SetActive(false);
                        botaoPainel.GetComponent<BoxCollider>().enabled = true;
                        if (errouDesbloquear == false)
                        {
                            Invoke("AumentarBarras10", 2f);
                            animacoesBrasao[0].SetActive(true);
                            animacoesBrasao[1].SetActive(true);
                        }

                        else
                        {
                            Invoke("AumentarBarras5", 2f);
                            animacoes5Pontos[0].SetActive(true);
                            animacoes5Pontos[1].SetActive(true);
                        }
                    }

                }

                //==================================================================================================
                else if (hit.collider.tag.Equals("Desbloquear") && objetoParaInteragir == "Desaterrar"
                 && dialogoAparecendo == false)
                {
                    maoIMG[0].sprite = maosImages[0];
                    maoIMG[1].sprite = maosImages[0];
                    AtivarTexto("Retirar Kit Bloqueio");
                    if (Input.GetButtonDown("Fire1"))
                    {
                        if (dialogoAparecendo == false)
                        {
                            SetarImagem(20);
                            errouDesaterrar = true;
                            PlayerPrefs.SetInt("Errou4", 1);
                        }
                    }

                }
                //==================================================================================================
                else if (hit.collider.tag.Equals("Multimetro") && itemAtual == null)
                {
                    maoIMG[0].sprite = maosImages[0];
                    maoIMG[1].sprite = maosImages[0];
                    AtivarTexto("Pegar Multímetro");
                    if (Input.GetButtonDown("Fire1"))
                    {
                        if (objetoParaInteragir == "painel")
                        {
                            if (dialogoAparecendo == false)
                            {
                                SetarImagem(1);
                                errouPainel = true;
                                PlayerPrefs.SetInt("Errou3", 1);
                            }
                        }

                        else if (objetoParaInteragir == "placa")
                        {
                            if (dialogoAparecendo == false)
                            {
                                SetarImagem(5);
                                errouPlaca = true;
                                PlayerPrefs.SetInt("Errou3", 1);
                            }
                        }

                        else if (objetoParaInteragir == "botaodesligar")
                        {
                            if (dialogoAparecendo == false)
                            {
                                SetarImagem(10);
                                errouDesligar = true;
                                PlayerPrefs.SetInt("Errou3", 1);
                            }
                        }

                        else if (objetoParaInteragir == "LocalCadeado")
                        {
                            if (dialogoAparecendo == false)
                            {
                                SetarImagem(11);
                                errouCadeado = true;
                                PlayerPrefs.SetInt("Errou3", 1);
                            }
                        }

                        else if (objetoParaInteragir == "LocalMulti")
                        {
                            if (dialogoAparecendo == false)
                            {
                                itemAtual = hit.collider.gameObject;
                                itemAtual.transform.position = mao.position;
                                itemAtual.GetComponent<BoxCollider>().enabled = false;
                                itemAtual.GetComponent<Transform>().eulerAngles = new Vector3(90, -90, 0);
                                multiSegurado = true;
                            }
                        }

                        else if (objetoParaInteragir == "LocalMultimetro2")
                        {
                            if (dialogoAparecendo == false)
                            {
                                itemAtual = hit.collider.gameObject;
                                itemAtual.transform.position = mao.position;
                                itemAtual.GetComponent<BoxCollider>().enabled = false;
                                itemAtual.GetComponent<Transform>().eulerAngles = new Vector3(90, -90, 0);
                                multiSegurado = true;
                            }
                        }

                        else if (objetoParaInteragir == "Desaterrar")
                        {
                            if (dialogoAparecendo == false)
                            {
                                SetarImagem(21);
                                errouDesaterrar = true;
                                PlayerPrefs.SetInt("Errou4", 1);
                            }
                        }

                        else if (objetoParaInteragir == "Desbloquear")
                        {
                            if (dialogoAparecendo == false)
                            {
                                SetarImagem(21);
                                errouDesbloquear = true;
                                PlayerPrefs.SetInt("Errou4", 1);
                            }
                        }

                        else if (objetoParaInteragir == "BotaoLigar")
                        {
                            if (dialogoAparecendo == false)
                            {
                                SetarImagem(21);
                                errouLigar = true;
                                PlayerPrefs.SetInt("Errou4", 1);
                            }
                        }
                    }
                }

                //=========================================================================================

                else if (hit.collider.tag.Equals("Cadeado") && itemAtual == null)
                {
                    maoIMG[0].sprite = maosImages[0];
                    maoIMG[1].sprite = maosImages[0];
                    AtivarTexto("Pegar Kit Bloqueio");
                    if (Input.GetButtonDown("Fire1"))
                    {
                        if (objetoParaInteragir == "painel")
                        {
                            if (dialogoAparecendo == false)
                            {
                                SetarImagem(3);
                                errouPainel = true;
                                PlayerPrefs.SetInt("Errou3", 1);
                            }
                        }

                        else if (objetoParaInteragir == "placa")
                        {
                            if (dialogoAparecendo == false)
                            {
                                SetarImagem(7);
                                errouPlaca = true;
                                PlayerPrefs.SetInt("Errou3", 1);
                            }
                        }

                        else if (objetoParaInteragir == "botaodesligar")
                        {
                            if (dialogoAparecendo == false)
                            {
                                SetarImagem(9);
                                errouDesligar = true;
                                PlayerPrefs.SetInt("Errou3", 1);

                            }
                        }

                        else if (objetoParaInteragir == "LocalCadeado")
                        {
                            itemAtual = hit.collider.gameObject;
                            itemAtual.transform.position = mao.position;
                            itemAtual.GetComponent<BoxCollider>().enabled = false;
                            itemAtual.GetComponent<Transform>().eulerAngles = new Vector3(90, -90, 0);
                            cadeadoSegurado = true;
                        }
                    }
                }

                //==================================================================

                else if (hit.collider.tag.Equals("Aterramento"))
                {
                    maoIMG[0].sprite = maosImages[0];
                    maoIMG[1].sprite = maosImages[0];
                    AtivarTexto("Pegar Aterramento Temporário");
                    if (Input.GetButtonDown("Fire1"))
                    {
                        if (objetoParaInteragir == "painel")
                        {
                            if (dialogoAparecendo == false)
                            {
                                SetarImagem(2);
                                errouPainel = true;
                                PlayerPrefs.SetInt("Errou3", 1);
                            }
                        }

                        else if (objetoParaInteragir == "placa")
                        {
                            if (dialogoAparecendo == false)
                            {
                                SetarImagem(6);
                                errouPlaca = true;
                                PlayerPrefs.SetInt("Errou3", 1);
                            }
                        }

                        else if (objetoParaInteragir == "botaodesligar" || objetoParaInteragir == "LocalCadeado"
                            || objetoParaInteragir == "LocalDescabear" || objetoParaInteragir == "LocalAterra")
                        {
                            if (dialogoAparecendo == false)
                            {
                                itemAtual = hit.collider.gameObject;
                                itemAtual.transform.position = mao.position;
                                itemAtual.GetComponent<BoxCollider>().enabled = false;
                                itemAtual.GetComponent<Transform>().eulerAngles = new Vector3(-180, 90, 0);
                                aterraSegurado = true;
                            }
                        }

                        else if (objetoParaInteragir == "LocalCadeado")
                        {
                            if (dialogoAparecendo == false)
                            {
                                itemAtual = hit.collider.gameObject;
                                itemAtual.transform.position = mao.position;
                                itemAtual.GetComponent<BoxCollider>().enabled = false;
                                itemAtual.GetComponent<Transform>().eulerAngles = new Vector3(-180, 90, 0);
                                aterraSegurado = true;
                            }
                        }

                        else if (objetoParaInteragir == "LocalMulti")
                        {
                            if (dialogoAparecendo == false)
                            {
                                SetarImagem(13);
                                errouMulti = true;
                                PlayerPrefs.SetInt("Errou3", 1);
                            }
                        }
                    }
                }

                //=============================================================================================================

            }
            if (itemAtual != null)
            {
                if (segurar == true)
                {
                    maoIMG[0].sprite = maosImages[1];
                    maoIMG[1].sprite = maosImages[1];
                }
                itemAtual.transform.position = mao.position;

            }
        }
	}

    //====================================================
    //====================================================
    //====================================================


	/*valores:
	 * 0 - Texto inicial;
	 * 1 - errou painel pegou multimetro;
	 * 2 - errou painel pegou aterramento;
	 * 3 - errou painel pegou cadeado;
	 * 4 - errou painel pegou placa;
	 * 5 - errou placa pegou multi;
	 * 6 - errou placa pegou aterra;
	 * 7 - errou placa pegou cadeado;
	 * 8 - errou desl pegou aterra - Gameover1;
	 * 9 - errou desl pegou cadeado;
	 * 10 - errou desl pegou multi;
	 * 11 - errou cadeado pegou mult;
	 * 12 - errou cadeado pegou aterramento - Gameover2;
	 * 13 - errou mult pegou aterra;
	 * 14- errou aterramento - Gameover3;
	 * 15 - completou parte1;
     * 16 - multimetro;
     * 17 - Fez manutencao
     * 18 - Segunda parte
     * 19 - acao7 errou cabeamento
     * 20 - acao7 errou cadeado
     * 21 - acao7 errou multimetro, 8 e 9 tambem
     * 22 - acao11 errou placa
     * 23 - concluiu parte 2
     * 24 - Multi zero
	 */

	public void SetarImagem(int valor)
	{
		characterController.GetComponent<CharacterController> ().enabled = false;
		dialogoAparecendo = true;
		dialogos1.SetActive (true);
		dialogos2.SetActive (true);
		maoIMG [0].enabled = false;
		maoIMG [1].enabled = false;
        podeInteragir = false;
        dialogos1.GetComponent<Image>().sprite = sprites[valor];
        dialogos2.GetComponent<Image>().sprite = sprites[valor];
       
	}

	void SetarDialogoAparecendo()
	{
		dialogoAparecendo = false;
	}

	public void SetMenuAtivado(bool valor)
	{
		menuAtivado = valor;
	}

	public void SetobjetoParaInteragir(string valor)
	{
		objetoParaInteragir = valor;
	}

	public void SetErrouAbrirChaves()
	{
		if (errouAbrirChaves == false) {
			barraDeSeguranca1.GetComponent<BarraDeSeguranca> ().AumentarBarra (10);
			barraDeSeguranca2.GetComponent<BarraDeSeguranca> ().AumentarBarra (10);
			barraDeSeguranca1.GetComponent<BarraDeSeguranca> ().AumentarEscudos ();
			barraDeSeguranca2.GetComponent<BarraDeSeguranca> ().AumentarEscudos ();
			animacoesBrasao [0].SetActive (true);
			animacoesBrasao [1].SetActive (true);
		} else if (errouAbrirChaves == true) {
			barraDeSeguranca1.GetComponent<BarraDeSeguranca> ().AumentarBarra (5);
			barraDeSeguranca2.GetComponent<BarraDeSeguranca> ().AumentarBarra (5);
			PlayerPrefs.SetInt ("Errou3", 1);
			animacoes5Pontos [0].SetActive (true);
			animacoes5Pontos [1].SetActive (true);
		}
	}

	public void SetErrouFecharChaves()
	{
		if (errouFecharChaves == false) {
			barraDeSeguranca1.GetComponent<BarraDeSeguranca> ().AumentarBarra (10);
			barraDeSeguranca2.GetComponent<BarraDeSeguranca> ().AumentarBarra (10);
			barraDeSeguranca1.GetComponent<BarraDeSeguranca> ().AumentarEscudos ();
			barraDeSeguranca2.GetComponent<BarraDeSeguranca> ().AumentarEscudos ();
			animacoesBrasao [0].SetActive (true);
			animacoesBrasao [1].SetActive (true);
		} else if (errouFecharChaves == true) {
			barraDeSeguranca1.GetComponent<BarraDeSeguranca> ().AumentarBarra (5);
			barraDeSeguranca2.GetComponent<BarraDeSeguranca> ().AumentarBarra (5);
			PlayerPrefs.SetInt ("Errou3", 1);
			animacoes5Pontos [0].SetActive (true);
			animacoes5Pontos [1].SetActive (true);
		}
	}
		
	void AtivarDialogoTrocarLuvas()
	{
		dialogos1.SetActive (true);
		dialogos2.SetActive (true);
		SetarImagem (15);
		dialogoAparecendo = true;
	}

	public void ChamarTerminarJogo()
	{
		Invoke ("PodeTerminarJogo", 0.5f);
	}

	public void PodeTerminarJogo()
	{
		podeTerminar = true;
	}

	void TerminarJogo()
	{
		barraDeSeguranca1.GetComponent<BarraDeSeguranca> ().SetarPontuacao ();
		SceneManager.LoadScene ("Feedback");
	}

	void ChamarImagem21()
	{
		SetarImagem (21);
	}

    void ChamarImagem17()
    {
        animBarra1.SetActive(false);
        animBarra2.SetActive(false);
        SetarImagem(17);
        ativarBarra = false;
    }

    public void SetPausado(bool valor)
	{
		pausado = valor;
	}

    void DesativarBoolDialogo()
    {
        dialogoAparecendo = false;
    }
		
    void AumentarBarras10()
    {
        barraDeSeguranca1.GetComponent<BarraDeSeguranca>().AumentarBarra(10);
        barraDeSeguranca2.GetComponent<BarraDeSeguranca>().AumentarBarra(10);
        barraDeSeguranca1.GetComponent<BarraDeSeguranca>().AumentarEscudos();
        barraDeSeguranca2.GetComponent<BarraDeSeguranca>().AumentarEscudos();
    }

    void AumentarBarras5()
    {
        barraDeSeguranca1.GetComponent<BarraDeSeguranca>().AumentarBarra(5);
        barraDeSeguranca2.GetComponent<BarraDeSeguranca>().AumentarBarra(5);
    }

    /*Textos:
     * 1-Desligar Painel
     * 2-Colocar Placa de Aviso
     * 3-Desligar Disjuntor
     * 4-Colocar Kit Bloqueio
     * 5-Usar Multimetro
     * 6-Soltar Cabeamento;
     * 7-Colocar Aterramento;
     * 8-Retirar Aterramento;
     * 9-Colocar Cabeamento;
     * 10-Retirar Kit Bloqueio;
     * 11-Ligar Disjuntor
     * 12-Usar Multimetro;
     * 13-Ligar Painel;
     * 14-Retirar Placa de Aviso;
     */
    void AtivarTexto(string texto)
    {
        textoAcao1.text = texto;
        textoAcao2.text = texto;
    }

    void DesativarTexto()
    {
        textoAcao1.text = "";
        textoAcao2.text = "";
    }

    void SetPodeInteragir()
    {
        podeInteragir = true;
    }
}