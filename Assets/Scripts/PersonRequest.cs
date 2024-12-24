using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PersonRequest : MonoBehaviour
{
	public SpriteRenderer personSprite;
	public SpriteRenderer dialogueSprite;
	public TextMeshPro dialogueText;
	[SerializeField] private Person person;
	[SerializeField] private float typingTime = 1.0f;
	[SerializeField] private Sprite encargadoSprite;

	public AudioClip[] normalSoundClips;
	public AudioClip[] happySoundClips;
	public AudioClip[] angrySoundClips;
	private AudioSource audioSource;


	public List<Sprite> sprites;
	private Request currentRequest;


	private void Awake()
	{
		audioSource = GetComponent<AudioSource>();
		audioSource.loop=false;
	}

	private void Start()
	{
		RequestManager.NewRequest.AddListener(StartPersonRequest);
		RequestManager.RequestResult.AddListener(ShowDialogueResult);
		dialogueSprite.enabled=false;
		dialogueText.enabled=false;

		normalSoundClips = Resources.LoadAll<AudioClip>("ClientSounds/Normal");
		happySoundClips = Resources.LoadAll<AudioClip>("ClientSounds/Feliz");
		angrySoundClips = Resources.LoadAll<AudioClip>("ClientSounds/Desagrado");
	}

	public IEnumerator StartTutorial1()
	{
		Debug.Log("Empieza tutorial");
		GameManager.Instance.OnTutorial=true;
		GameManager.Instance.OnTutorial=false;
		personSprite.sprite = encargadoSprite;
		float speed =0.01f;
		List<string> dialogues = new List<string>
        {
            "Hola pibe como estas",
            "Te vamos a probar tres semanas",
            "La gente va a venir y te va a preguntar por lugares para ir a visitar",
            "Vos fijate los horarios, los dias y el clima para saber cuales son los destinos que le sirven",
			"Una vez que los tengas, arrastralos a la mesa y apreta el boton",
            "Estas a contrareloj, asi que trata de ir lo mas rapido que puedas",
            "Mientras mas destinos correctos les entreges a los clientes, mas va a subir tu reputación",
            "Buena suerte"
        };
		person.MoveToPlace(null);
		//int i=0;
		foreach(string dialogue in dialogues)
		{
			PlayRandomClip(normalSoundClips,7);
			Debug.Log("ShowDialogue");
			StartCoroutine(ShowDialogueRoutine(dialogue,speed));
			yield return new WaitUntil(()=>GameManager.Instance.SkipTutorial ||Input.GetMouseButtonDown(0) );
			if(GameManager.Instance.SkipTutorial)
			{
				GameManager.Instance.OnTutorial=false;
				GameManager.Instance.SkipTutorial=false;
				break;
			}
		}
		GameManager.Instance.OnTutorial=false;
		GameManager.Instance.SkipTutorial=false;
		Debug.Log("No mas tuto");
		person.LeavePlaceNoComplete();
		yield return new WaitForSeconds(1.0f);
		GameManager.StartWeekEvent.Invoke();
	}

	public IEnumerator StartTutorial2()
	{
		personSprite.sprite = encargadoSprite;
		Debug.Log("Empieza tutorial");
		GameManager.Instance.OnTutorial=true;
		GameManager.Instance.SkipTutorial=false;
		float speed =0.01f;
		List<string> dialogues = new List<string>
        {
            "Hola pibe como estas",
            "Como la estas pasando",
            "Esta semana vamos a agregar un par de destinos, que son para gente grande",
            "A partir de ahora vamos a pedir el DNI, vos fijate si son adultos",
            "Buena suerte"
        };
		person.MoveToPlace(null);
		foreach(string dialogue in dialogues)
		{
			PlayRandomClip(normalSoundClips,7);
			yield return StartCoroutine(ShowDialogueRoutine(dialogue,speed));
			yield return new WaitUntil(()=>GameManager.Instance.SkipTutorial ||Input.GetMouseButtonDown(0));
			if(GameManager.Instance.SkipTutorial)
			{
				GameManager.Instance.OnTutorial=false;
				GameManager.Instance.SkipTutorial=false;
				break;
			}
		
		}
		GameManager.Instance.OnTutorial=false;
		GameManager.Instance.SkipTutorial=false;
		person.LeavePlaceNoComplete();
		yield return new WaitForSeconds(typingTime);
		GameManager.StartWeekEvent.Invoke();

	}
	/*{
            "Hola pibe como estas",
            "Esta es tu ultima semana de prueba, como te ves",
            "No se que le pasa a la gente esta semana que esta muy apurada",
            "Te hablan super rapido y no se le entiende lo que dice",
			"Tambien agregamos un par de destinos mas",
            "Buena suerte"
        };*/

	public IEnumerator StartTutorial3()
	{
		personSprite.sprite = encargadoSprite;
		Debug.Log("Empieza tutorial");
		GameManager.Instance.OnTutorial=true;
		GameManager.Instance.SkipTutorial=false;
		float speed =0.01f;
		List<string> dialogues = new List<string>
        {
            "Hola pibe, como estas?",
            "Esta es tu ultima semana de prueba, como te ves",
            "No se que le pasa a la gente esta semana que esta muy apurada",
            "Te hablan super rapido y no se le entiende lo que dice",
			"Tambien agregamos un par de destinos mas",
            "Buena suerte"
        };
		person.MoveToPlace(null);
		foreach(string dialogue in dialogues)
		{
			PlayRandomClip(normalSoundClips,7);
			yield return StartCoroutine(ShowDialogueRoutine(dialogue,speed));
			yield return new WaitUntil(()=>GameManager.Instance.SkipTutorial ||Input.GetMouseButtonDown(0));
			if(GameManager.Instance.SkipTutorial)
			{
				GameManager.Instance.OnTutorial=false;
				GameManager.Instance.SkipTutorial=false;
				break;
			}
		
		}
		GameManager.Instance.OnTutorial=false;
		GameManager.Instance.SkipTutorial=false;
		person.LeavePlaceNoComplete();
		yield return new WaitForSeconds(1.0f);
		GameManager.StartWeekEvent.Invoke();

	}

	public IEnumerator StartCutsceneGood()
	{
		personSprite.sprite = encargadoSprite;
		Debug.Log("Empieza tutorial");
		GameManager.Instance.OnTutorial=true;
		GameManager.Instance.SkipTutorial=false;
		float speed =0.01f;
		List<string> dialogues = new List<string>
        {
			"Hola, como estas",
			"Despues de verte trabajar estas semanas llegue a una decision",
			"Debo decir que...",
			"...",
			"TE QUEDAS CON EL TRABAJO!",
			"Felicitaciones, hiciste un trabajo impecable.",
			"Te espero la semana que viene."
        };
		person.MoveToPlace(null);
		foreach(string dialogue in dialogues)
		{
			PlayRandomClip(normalSoundClips,7);
			yield return StartCoroutine(ShowDialogueRoutine(dialogue,speed));
			yield return new WaitUntil(()=>GameManager.Instance.SkipTutorial ||Input.GetMouseButtonDown(0));
			if(GameManager.Instance.SkipTutorial)
			{
				GameManager.Instance.OnTutorial=false;
				GameManager.Instance.SkipTutorial=false;
				break;
			}
		
		}
		GameManager.Instance.OnTutorial=false;
		GameManager.Instance.SkipTutorial=false;
		person.LeavePlaceNoComplete();
		yield return new WaitForSeconds(1.0f);
		MenuManager.LoadMenu();

	}

	public IEnumerator StartCutsceneBad()
	{
		personSprite.sprite = encargadoSprite;
		Debug.Log("Empieza tutorial");
		GameManager.Instance.OnTutorial=true;
		GameManager.Instance.SkipTutorial=false;
		float speed =0.01f;
		List<string> dialogues = new List<string>
        {
			"Hola, como estas.",
			"Despues de verte trabajar estas semanas llegue a una decision.",
			"Debo decir que...",
			"...",
			"Hiciste un pesimo trabajo.",
			"Tengo a todos los clientes enojados.",
			"No te quiero ver mas por aca.",
			"Nos vemos."
        };
		person.MoveToPlace(null);
		foreach(string dialogue in dialogues)
		{
			PlayRandomClip(normalSoundClips,currentRequest.personType);
			yield return StartCoroutine(ShowDialogueRoutine(dialogue,speed));
			yield return new WaitUntil(()=>GameManager.Instance.SkipTutorial ||Input.GetMouseButtonDown(0));
			if(GameManager.Instance.SkipTutorial)
			{
				GameManager.Instance.OnTutorial=false;
				GameManager.Instance.SkipTutorial=false;
				break;
			}
		
		}
		GameManager.Instance.OnTutorial=false;
		GameManager.Instance.SkipTutorial=false;
		person.LeavePlaceNoComplete();
		yield return new WaitForSeconds(1.0f);
		MenuManager.LoadMenu();

	}
	

	public void StartPersonRequest(Request request)
	{
        float time = 1f;
        float speed = 0.02f;
        string requestDialogue = request.RequestDialogue();
		personSprite.sprite = sprites[request.personType-1];
		currentRequest = request;
		PlayRandomClip(normalSoundClips,request.personType);
		if(WeekManager.currentWeek>=3)
		{
			if(UnityEngine.Random.Range(0,4)==1)
			{
				StartCoroutine(ShowDialogueAndHide(requestDialogue, time, speed));
			} 
			else
			{
				ShowDialogue(requestDialogue,0.02f);
			}
		}
		else
		{
			ShowDialogue(requestDialogue,0.02f);
		}
	}


	private void ShowDialogueResult(bool hasSelected, int score)
	{		
		float speed = 0.02f;
		string text = "";
		if(hasSelected)
		{
			if(score<0)
			{
				PlayRandomClip(angrySoundClips,currentRequest.personType);
                List<string> dialoguesResponse = new List<string>
                {
                    "Ni respeto por los mayores...",
                    "Para atender asi, renuncia!!",
                    "Te dejo el pañal del nene para tirar, chau",
                    "Que perdida de tiempo al pedo!!",
                    "Te voy a mandar a mis abogados, nos vemos en la corte...",
                    "Te voy a dejar una review mala..."
                };
				text = dialoguesResponse[currentRequest.personType - 1];

            }
			if(score==0)
			{
				PlayRandomClip(normalSoundClips,currentRequest.personType);
                List<string> dialoguesResponse = new List<string>
                {
                    "Gracias, al menos me atendiste mejor que en PAMI...",
                    "Dedicate a otra cosa.",
                    "El nene quiere ir con la mama",
                    "Ayy que calor",
                    "Gracias gor...",
                    "Ok"
                };
				text = dialoguesResponse[currentRequest.personType - 1];

            }
			if(score>0)
			{
				PlayRandomClip(happySoundClips,currentRequest.personType);
                List<string> dialoguesResponse = new List<string>
                {
                    "Gracias corazon, te dejo un budin para el mate.",
                    "...",
                    "Gracias y perdon por los gritos del nene",
                    "Muy amable, gracias por la atencion",
                    "Te es espero en La Normandina a la noche.",
                    "De una"
                };
				text = dialoguesResponse[currentRequest.personType - 1];

            }
		}
		else
		{
			PlayRandomClip(angrySoundClips,currentRequest.personType);
            List<string> dialoguesResponse = new List<string>
                {
                    "Bue, gracias por nada",
                    "Todo el dia al pedo",
					"Se viven rascando",
					"Parece que no hay nadie..."
                };
			text = dialoguesResponse[UnityEngine.Random.Range(0, dialoguesResponse.Count)];
		}
		ShowDialogue(text,speed);

	}

	IEnumerator ShowDialogueRoutine(string text,float speed)
	{
		dialogueSprite.enabled=true;
		dialogueText.enabled=true;
		dialogueText.maxVisibleCharacters = 0;
		dialogueText.text = text;
		for(int i=0;i<text.Length;i++)
		{
			yield return new WaitForSeconds(speed);
			dialogueText.maxVisibleCharacters++;
		}
	}

	private IEnumerator ShowDialogueAndHide(string text,float time,float speed)
	{
		yield return StartCoroutine(ShowDialogueRoutine(text,speed));
		yield return new WaitForSeconds(time);
		HideDialogue();
	}


	private void ShowDialogue(string text,float speed)
	{

		StopAllCoroutines();
		StartCoroutine(ShowDialogueRoutine(text,speed));
	}

	private void HideDialogue()
	{
		dialogueSprite.enabled=false;
		dialogueText.enabled=false;
	}

	private void PlayRandomClip(AudioClip[] clips, int PersonType)
	{
		AudioClip clip = clips[UnityEngine.Random.Range(0,clips.Length)];
		audioSource.clip=clip;
		if(PersonType == 1)
		{
			audioSource.pitch = UnityEngine.Random.Range(1.1f,1.3f);
		}
		if(PersonType == 2)
		{
			audioSource.pitch = UnityEngine.Random.Range(0.8f,0.9f);
		}
		if(PersonType == 3)
		{
			audioSource.pitch = UnityEngine.Random.Range(0.8f,1.1f);
		}
		if(PersonType == 4)
		{
			audioSource.pitch = UnityEngine.Random.Range(1.1f,1.3f);
		}
		if(PersonType == 5)
		{
			audioSource.pitch = UnityEngine.Random.Range(1.3f,1.5f);
		}
		if(PersonType == 6)
		{
			audioSource.pitch = UnityEngine.Random.Range(1.2f,1.5f);
		}
		if(PersonType == 7)
		{
			audioSource.pitch = 0.87f;
		}
		audioSource.Play();
	}

	public void OnDestroy()
	{
		StopAllCoroutines();
	}


}
