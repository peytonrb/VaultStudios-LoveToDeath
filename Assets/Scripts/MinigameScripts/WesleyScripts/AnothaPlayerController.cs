using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class AnothaPlayerController : MonoBehaviour
{
    public float speed = 40f;
    public UnityEvent generator;
    private float xInput;
    private float yInput;
    public Rigidbody2D rb;
    public Vector2 movement;
    public GameObject item;
    public ItemValue itemValue;
    public int points;
    public List<string> itemsCollected;
    public bool winLose;
    public Timer timer;
    public bool coroutineFinished;
    public bool hasReplayed;
    private Animator anim;
    public WinLoseUIControllerWesley uiController;

    [Header("Item Count")]
    private int sodium = 0;
    private int chlorine = 0;
    private int lithium = 0;
    private int potassium = 0;
    private int helium = 0;
    private int nitrogen = 0;
    private int argon = 0;
    private int lead = 0;
    private int oxygen = 0;
    // public RoomFirstGenerator generator;

    [Header("UI")]
    public GameObject finisherScreen;
    public TextMeshProUGUI sodiumText;
    public TextMeshProUGUI chlorineText;
    public TextMeshProUGUI argonText;
    public TextMeshProUGUI lithiumText;
    public TextMeshProUGUI potassiumText;
    public TextMeshProUGUI oxygenText;
    public TextMeshProUGUI nitrogenText;
    public TextMeshProUGUI heliumText;
    public TextMeshProUGUI leadText;
    public GameObject winScreen;
    public GameObject loseScreen;
    public GameObject loseScreenDoNotTryAgain;

    void Start()
    {
        finisherScreen.SetActive(false);
        winScreen.SetActive(false);
        loseScreen.SetActive(false);
        loseScreenDoNotTryAgain.SetActive(false);
        coroutineFinished = false;
        itemsCollected = new List<string>();
        generator.Invoke();
        rb.GetComponent<Rigidbody2D>();
        timer = GameObject.Find("EventSystem").GetComponent<Timer>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (timer.levelFinished) // AND timer is finished 
        {
            finisherScreen.SetActive(true);
            sodiumText.text = "" + sodium;
            chlorineText.text = "" + chlorine;
            argonText.text = "" + argon;
            lithiumText.text = "" + lithium;
            potassiumText.text = "" + potassium;
            oxygenText.text = "" + oxygen;
            nitrogenText.text = "" + nitrogen;
            heliumText.text = "" + helium;
            leadText.text = "" + lead;

            if (points >= 45)
                winLose = true;
            else
                winLose = false;

            StartCoroutine(observe());
        }

        if (timer.levelFinished && coroutineFinished)
        {
            if (winLose)
            {
                winScreen.SetActive(true);
            }
            else if (!winLose && !uiController.tryAgainPressed)
            {
                loseScreen.SetActive(true);
            }
            else
            {
                loseScreenDoNotTryAgain.SetActive(true);
            }
        }
    }

    void FixedUpdate()
    {
        movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        rb.velocity = movement * speed * Time.fixedDeltaTime;

        if (movement.Equals(Vector2.zero))
        {
            anim.SetFloat("Speed", 0);
        }
        else
        {
            anim.SetFloat("Speed", 1);
        }
        // transform.Translate(xInput * speed, yInput * speed, 0f);
    }

    IEnumerator observe()
    {
        yield return new WaitForSeconds(5);
        coroutineFinished = true;
    }

    public void addPoints(int value, string name)
    {
        points += value;
        itemsCollected.Add(name);

        if (name == "Sodium")
        {
            sodium++;
        }
        else if (name == "Chlorine")
        {
            chlorine++;
        }
        else if (name == "Argon")
        {
            argon++;
        }
        else if (name == "Lithium")
        {
            lithium++;
        }
        else if (name == "Potassium")
        {
            potassium++;
        }
        else if (name == "Oxygen")
        {
            oxygen++;
        }
        else if (name == "Nitrogen")
        {
            nitrogen++;
        }
        else if (name == "Helium")
        {
            helium++;
        }
        else if (name == "Lead")
        {
            lead++;
        }
    }
}

