using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [Header("Basic Movement")]
    public CharacterController controller;
    public float speed;
    public float gravity = -9.81f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    private Vector3 velocity;
    private bool isGrounded;
    public Vector3 startPosition;

    [Header("Lover")]
    public ChemistController chemist;
    public ForestcoreController forestcore;
    public GamerController gamer;
    public GrilldadController grilldad;
    public JojoController jojo;
    public OccultController occult;
    public bool isDateTime;
    public bool isSocialTime;
    public bool isMurderTime;
    public bool isIngredientTime;
    private GameObject loveInterest; // stores the GameObject of the love interest
    private PlayerListUI chosenInterest;
    public string interestName;
    public int dateCount;

    [Header("UI")]
    public GameObject forestcoreDate;
    public GameObject grilldadDate;
    public GameObject chemistDate;
    public GameObject gamerDate;
    public GameObject jojoDate;
    public GameObject occultDate;
    public GameObject forestcoreSprite;
    public GameObject grilldadSprite;
    public GameObject chemistSprite;
    public GameObject gamerSprite;
    public GameObject jojoSprite;
    public GameObject occultSprite;
    public GameObject forestcoreShop;
    public GameObject grilldadShop;
    public GameObject chemistPharmacy;
    public GameObject gamerHouse;
    public GameObject jojoShop;
    public GameObject occultGrandmaHouse;
    public GameObject fcDialogueBox;
    public GameObject gdDialogueBox;
    public GameObject cDialogueBox;
    public GameObject gDialogueBox;
    public GameObject jDialogueBox;
    public GameObject oDialogueBox;
    public GameObject pauseMenu;
    public bool notesOpen;
    public GameObject notesMenu;

    [Header("WinLose")]
    public GameObject armaniWin;
    public GameObject aspenWin;
    public GameObject carmenWin;
    public GameObject daveyWin;
    public GameObject kaiWin;
    public GameObject wesleyWin;

    [Header("Dialogue")]
    public DialogueTriggerFC forestcoreDialogue;
    public DialogueTriggerGD grilldadDialogue;
    public DialogueTriggerC chemistDialogue;
    public DialogueTriggerG gamerDialogue;
    public DialogueTriggerJJ jojoDialogue;
    public DialogueTriggerO occultDialogue;
    public DialogueManager dialogueManager;

    [Header("Murder")]
    private string[] targets = new string[3];
    private string[] murderItems1 = new string[3];
    private string[] murderItems2 = new string[3];
    private string[] murderItems3 = new string[3];
    public GameObject target1;
    public GameObject target2;
    public GameObject target3;

    [Header("Items")]
    public int armaniItemCount;
    public int aspenItemCount;
    public int daveyItemCount;
    public int carmenItemCount;
    public int kaiItemCount;
    public int wesleyItemCount;

    [Header("For Notes Menu")] // yes i know this is redundant but im pressed for time pls be kind
    public bool forestcoreFriendDateOccured;
    public bool grilldadFriendDateOccured;
    public bool chemistFriendDateOccured;
    public bool gamerFriendDateOccured;
    public bool jojoFriendDateOccured;
    public bool occultFriendDateOccured;
    public bool forestcoreIsDead;
    public bool grilldadIsDead;
    public bool chemistIsDead;
    public bool gamerIsDead;
    public bool jojoIsDead;
    public bool occultIsDead;

    [Header("Other")]
    public Material skybox;
    public Material skyboxNight;
    private static readonly int rotation = Shader.PropertyToID("_Rotation");
    private static readonly int exposure = Shader.PropertyToID("_Exposure");
    private float elapsedTime = 0f;
    private float timeScale = 2.5f;
    public Light directionalLight;
    public bool isDateHappening;
    public static PlayerController Instance { get; private set; }

    // regretting not using inheritance but it has been too long to go back

    private void Awake()
    {
        if (Instance != null)
        {
            DestroyImmediate(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        startPosition = transform.position;
        isDateTime = true;
        isSocialTime = false;
        isMurderTime = false;
        isIngredientTime = false;
        dateCount = 0;
        notesOpen = false;
        forestcoreFriendDateOccured = false;
        grilldadFriendDateOccured = false;
        chemistFriendDateOccured = false;
        gamerFriendDateOccured = false;
        jojoFriendDateOccured = false;
        occultFriendDateOccured = false;
        isDateHappening = false;

        if (GameManager.Instance.isFirstInstance)
        {
            interestName = PlayerListUI.loveInterest;
            loveInterest = GameObject.Find(interestName);
            // there will be a bug here if you do not start the test game from the PlayerCards scene
            loveInterest.gameObject.tag = "LoveInterest";

            assignMurders(interestName);

            target1 = GameObject.Find(targets[0]);
            target1.gameObject.tag = "Target";

            target2 = GameObject.Find(targets[1]);
            target2.gameObject.tag = "Target";

            target3 = GameObject.Find(targets[2]);
            target3.gameObject.tag = "Target";

            GameManager.Instance.isFirstInstance = false;
        }

        reactivateNPCS();

        // set active calls
        reassignments();
        setEverythingInactive();
        // StartCoroutine(startingBuffer()); // the game does not allow u to begin dating until 4 minutes of gameplay have passed
    }

    void Update()
    {
        inventoryContainsItems();
        skyboxController();

        if (GameManager.Instance.sceneJustLoaded == true)
        {
            reassignments();
            removeDeadNPCs();
            winScreen();
            setEverythingInactive();
            Cursor.lockState = CursorLockMode.Locked;
            GameManager.Instance.sceneJustLoaded = false;
        }

        // movement mechanics
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 move = transform.right * horizontal + transform.forward * vertical;
        controller.Move(move * speed * Time.deltaTime);
        // controller.SimpleMove(transform.forward * vertical * 10f * speed * Time.deltaTime);

        // key presses
        if (Input.GetKeyDown(KeyCode.Escape) && !notesOpen)
        {
            pauseMenu.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            // freeze screen here
        }

        if (Input.GetKeyDown(KeyCode.Escape) && notesOpen)
        {
            notesMenu.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            notesOpen = false;
        }

        if (Input.GetKeyDown(KeyCode.E) && !notesOpen && !isDateHappening)
        {
            notesOpen = true;
            notesMenu.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
        }

        // character interaction key 
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (isDateTime)
            {
                isMurderTime = false;
                reactivateNPCS();
                RenderSettings.skybox = skybox;
                DynamicGI.UpdateEnvironment();
                directionalLight.color = new Color(1f, 0.95f, 0.83f);
                Collider[] hitColliders = Physics.OverlapSphere(gameObject.transform.position, 20f); // second number is radius

                foreach (var hitCollider in hitColliders)
                {
                    if (hitCollider.gameObject.tag == "LoveInterest")
                    {
                        isDateHappening = true;
                        if (interestName == "forestcore")
                        {
                            forestcoreDate.SetActive(true);
                            forestcoreSprite.SetActive(true);
                            fcDialogueBox.SetActive(true);
                            forestcoreDialogue.dialogueStart();
                        }
                        else if (interestName == "grilldad")
                        {
                            grilldadDate.SetActive(true);
                            grilldadSprite.SetActive(true);
                            gdDialogueBox.SetActive(true);
                            grilldadDialogue.dialogueStart();
                        }
                        else if (interestName == "chemist")
                        {
                            chemistDate.SetActive(true);
                            chemistSprite.SetActive(true);
                            cDialogueBox.SetActive(true);
                            chemistDialogue.dialogueStart();
                        }
                        else if (interestName == "gamer")
                        {
                            gamerDate.SetActive(true);
                            gamerSprite.SetActive(true);
                            gDialogueBox.SetActive(true);
                            gamerDialogue.dialogueStart();
                        }
                        else if (interestName == "jojo")
                        {
                            jojoDate.SetActive(true);
                            jojoSprite.SetActive(true);
                            jDialogueBox.SetActive(true);
                            jojoDialogue.dialogueStart();
                        }
                        else if (interestName == "occult")
                        {
                            occultDate.SetActive(true);
                            occultSprite.SetActive(true);
                            oDialogueBox.SetActive(true);
                            occultDialogue.dialogueStart();
                        }

                        dateCount++;
                        isSocialTime = true;
                        isDateHappening = false;
                    }
                }
            }

            if (isSocialTime)
            {
                isDateTime = false;
                isIngredientTime = false;
                Collider[] hitColliders = Physics.OverlapSphere(gameObject.transform.position, 20f); // second number is radius

                foreach (var hitCollider in hitColliders)
                {
                    if (hitCollider.gameObject.tag == "Target")
                    {
                        isDateHappening = true;

                        if (hitCollider.gameObject.name == "forestcore")
                        {
                            forestcoreShop.SetActive(true);
                            forestcoreSprite.SetActive(true);       // gifts during dates --> have as a dialogue box at the end
                            fcDialogueBox.SetActive(true);
                            aspenItemCount++;
                            forestcoreFriendDateOccured = true;
                            forestcoreDialogue.dialogueStart();
                        }
                        else if (hitCollider.gameObject.name == "grilldad")
                        {
                            grilldadShop.SetActive(true);
                            grilldadSprite.SetActive(true);
                            gdDialogueBox.SetActive(true);
                            daveyItemCount++;
                            grilldadFriendDateOccured = true;
                            grilldadDialogue.dialogueStart();
                        }
                        else if (hitCollider.gameObject.name == "chemist")
                        {
                            chemistPharmacy.SetActive(true);
                            chemistSprite.SetActive(true);
                            cDialogueBox.SetActive(true);
                            wesleyItemCount++;
                            chemistFriendDateOccured = true;
                            chemistDialogue.dialogueStart();
                        }
                        else if (hitCollider.gameObject.name == "gamer")
                        {
                            gamerHouse.SetActive(true);
                            gamerSprite.SetActive(true);
                            gDialogueBox.SetActive(true);
                            carmenItemCount++;
                            gamerFriendDateOccured = true;
                            gamerDialogue.dialogueStart();
                        }
                        else if (hitCollider.gameObject.name == "jojo")
                        {
                            jojoShop.SetActive(true);
                            jojoSprite.SetActive(true);
                            jDialogueBox.SetActive(true);
                            armaniItemCount++;
                            jojoFriendDateOccured = true;
                            jojoDialogue.dialogueStart();
                        }
                        else if (hitCollider.gameObject.name == "occult")
                        {
                            occultGrandmaHouse.SetActive(true);
                            occultSprite.SetActive(true);
                            oDialogueBox.SetActive(true);
                            kaiItemCount++;
                            occultFriendDateOccured = true;
                            occultDialogue.dialogueStart();
                        }

                        isIngredientTime = true;
                        isDateHappening = false;
                    }
                }
            }

            if (isIngredientTime)
            {
                isSocialTime = false;
                RenderSettings.skybox = skyboxNight;
                DynamicGI.UpdateEnvironment();
                directionalLight.color = new Color(1f, 0.58f, 0.51f);
                StartCoroutine(ingredientTimer());          // CHANGE BACK TO 180 SECONDS AFTER DEBUGGING!!!!!!!!!!!!!
            }

            if (isMurderTime)
            {
                deactivateNPCS();

                // guarantees player is within range of love interest AND player has items required
                Collider[] hitColliders = Physics.OverlapSphere(gameObject.transform.position, 20f); // second number is radius
                foreach (var hitCollider in hitColliders)
                {
                    Debug.Log(hitCollider.gameObject.name);
                    if (hitCollider.gameObject.name == "AspenHouse")    // if you lose you won't come back to town
                    {
                        if (aspenItemCount == 3 && forestcore.gameObject.tag == "Target")
                        {
                            SceneManager.LoadScene(9);
                            PlayerPrefs.SetString("currentTarget", "carmen");
                            gamer.isDead = true;
                        }
                    }
                    else if (hitCollider.gameObject.name == "DaveyHouse")
                    {
                        if (daveyItemCount == 3 && grilldad.gameObject.tag == "Target")
                        {
                            SceneManager.LoadScene(9);
                            PlayerPrefs.SetString("currentTarget", "davey");
                            grilldad.isDead = true;
                        }
                    }
                    else if (hitCollider.gameObject.name == "WesleyHouse")
                    {
                        if (wesleyItemCount == 3 && chemist.gameObject.tag == "Target")
                        {
                            SceneManager.LoadScene(9);
                            PlayerPrefs.SetString("currentTarget", "wesley");
                            chemist.isDead = true;
                        }
                    }
                    else if (hitCollider.gameObject.name == "CarmenHouse")
                    {
                        if (carmenItemCount == 3 && gamer.gameObject.tag == "Target")
                        {
                            SceneManager.LoadScene(9);
                            PlayerPrefs.SetString("currentTarget", "carmen");
                            gamer.isDead = true;
                        }
                    }
                    else if (hitCollider.gameObject.name == "ArmaniHouse")
                    {
                        if (armaniItemCount == 3 && jojo.gameObject.tag == "Target")
                        {
                            SceneManager.LoadScene(9);
                            PlayerPrefs.SetString("currentTarget", "armani");
                            jojo.isDead = true;
                        }
                    }
                    else if (hitCollider.gameObject.name == "KaiHouse")
                    {
                        if (kaiItemCount == 3 && occult.gameObject.tag == "Target")
                        {
                            SceneManager.LoadScene(9);
                            PlayerPrefs.SetString("currentTarget", "kai");
                            occult.isDead = true;
                        }
                    }
                }
            }
        }
        // end key presses
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "ArmaniItem")
        {
            armaniItemCount++;
        }
        else if (collider.gameObject.tag == "AspenItem")
        {
            aspenItemCount++;
        }
        else if (collider.gameObject.tag == "CarmenItem")
        {
            carmenItemCount++;
        }
        else if (collider.gameObject.tag == "DaveyItem")
        {
            daveyItemCount++;
        }
        else if (collider.gameObject.tag == "KaiItem")
        {
            kaiItemCount++;
        }
        else if (collider.gameObject.tag == "WesleyItem")
        {
            wesleyItemCount++;
        }

        collider.gameObject.SetActive(false);
    }

    IEnumerator ingredientTimer()
    {
        yield return new WaitForSeconds(5);
        Debug.Log("reached");
        isMurderTime = true;
        isIngredientTime = false;
    }

    public void skyboxController()
    {
        skybox.SetFloat(rotation, elapsedTime * timeScale);
    }

    // do not change unless bugs
    private void inventoryContainsItems()
    {
        int counter1 = 0;
        int counter2 = 0;
        int counter3 = 0;

        // checks if player has required items
        for (int i = 0; i < murderItems1.Length; i++)
            // {
            //     if (inventoryManager.contains(murderItems1[i]))
            //     {
            //         counter1++;
            //     }
            // }

            // for (int i = 0; i < murderItems2.Length; i++)
            // {
            //     if (inventoryManager.contains(murderItems2[i]))
            //     {
            //         counter2++;
            //     }
            // }

            // for (int i = 0; i < murderItems3.Length; i++)
            // {
            //     if (inventoryManager.contains(murderItems3[i]))
            //     {
            //         counter3++;
            //     }
            // }

            // makes sure player has ALL required items
            if (counter1 == 3)
            {
                setToKill(1);
            }
            else if (counter2 == 3)
            {
                setToKill(2);
            }
            else if (counter3 == 3)
            {
                setToKill(3);
            }
    }

    // do not change unless there is bug
    private void setToKill(int index)
    {
        if (targets[index] == "forestcore")
        {
            forestcore.playerHasItems = true;
        }
        else if (targets[index] == "grilldad")
        {
            grilldad.playerHasItems = true;
        }
        else if (targets[index] == "chemist")
        {
            chemist.playerHasItems = true;
        }
        else if (targets[index] == "gamer")
        {
            gamer.playerHasItems = true;
        }
        else if (targets[index] == "jojo")
        {
            jojo.playerHasItems = true;
        }
        else if (targets[index] == "occult")
        {
            occult.playerHasItems = true;
        }
    }

    // assigns the murder targets to the variables - DO NOT CHANGE
    private void assignMurders(string interestName)
    {
        int iteration = 0;

        if (interestName == "forestcore")
        {
            // assigning the names to the variable local to this script
            for (int i = 0; i < 3; i++)
            {
                targets[i] = forestcore.friends[i];
            }

            // assigning the items to the variable local to this script
            foreach (string name in targets)
            {
                iteration++;
                assignMurderItems(name, iteration);
            }
        }
        else if (interestName == "grilldad")
        {
            // assigning the names to the variable local to this script
            for (int i = 0; i < 3; i++)
            {
                targets[i] = grilldad.friends[i];
            }

            // assigning the items to the variable local to this script
            foreach (string name in targets)
            {
                iteration++;
                assignMurderItems(name, iteration);
            }
        }
        else if (interestName == "chemist")
        {
            // assigning the names to the variable local to this script
            for (int i = 0; i < 3; i++)
            {
                targets[i] = chemist.friends[i];
            }

            // assigning the items to the variable local to this script
            foreach (string name in targets)
            {
                iteration++;
                assignMurderItems(name, iteration);
            }
        }
        else if (interestName == "gamer")
        {
            // assigning the names to the variable local to this script
            for (int i = 0; i < 3; i++)
            {
                targets[i] = gamer.friends[i];
            }

            // assigning the items to the variable local to this script
            foreach (string name in targets)
            {
                iteration++;
                assignMurderItems(name, iteration);
            }
        }
        else if (interestName == "occult")
        {
            // assigning the names to the variable local to this script
            for (int i = 0; i < 3; i++)
            {
                targets[i] = occult.friends[i];
            }

            // assigning the items to the variable local to this script
            foreach (string name in targets)
            {
                iteration++;
                assignMurderItems(name, iteration);
            }
        }
        else if (interestName == "jojo")
        {
            // assigning the names to the variable local to this script
            for (int i = 0; i < 3; i++)
            {
                targets[i] = jojo.friends[i];
            }

            // assigning the items to the variable local to this script
            foreach (string name in targets)
            {
                iteration++;
                assignMurderItems(name, iteration);
            }
        }
    }

    // assigns the items required to kill the targets to the variables -- DO NOT CHANGE
    private void assignMurderItems(string name, int iteration)
    {
        if (name == "forestcore")
        {
            if (iteration == 1)
            {
                for (int i = 0; i < 3; i++)
                {
                    murderItems1[i] = forestcore.requiredItems[i];
                }
            }
            else if (iteration == 2)
            {
                for (int i = 0; i < 3; i++)
                {
                    murderItems2[i] = forestcore.requiredItems[i];
                }
            }
            else if (iteration == 3)
            {
                for (int i = 0; i < 3; i++)
                {
                    murderItems3[i] = forestcore.requiredItems[i];
                }
            }
        }
        else if (name == "grilldad")
        {
            if (iteration == 1)
            {
                for (int i = 0; i < 3; i++)
                {
                    murderItems1[i] = grilldad.requiredItems[i];
                }
            }
            else if (iteration == 2)
            {
                for (int i = 0; i < 3; i++)
                {
                    murderItems2[i] = grilldad.requiredItems[i];
                }
            }
            else if (iteration == 3)
            {
                for (int i = 0; i < 3; i++)
                {
                    murderItems3[i] = grilldad.requiredItems[i];
                }
            }
        }
        else if (name == "chemist")
        {
            if (iteration == 1)
            {
                for (int i = 0; i < 3; i++)
                {
                    murderItems1[i] = chemist.requiredItems[i];
                }
            }
            else if (iteration == 2)
            {
                for (int i = 0; i < 3; i++)
                {
                    murderItems2[i] = chemist.requiredItems[i];
                }
            }
            else if (iteration == 3)
            {
                for (int i = 0; i < 3; i++)
                {
                    murderItems3[i] = chemist.requiredItems[i];
                }
            }
        }
        else if (name == "gamer")
        {
            if (iteration == 1)
            {
                for (int i = 0; i < 3; i++)
                {
                    murderItems1[i] = gamer.requiredItems[i];
                }
            }
            else if (iteration == 2)
            {
                for (int i = 0; i < 3; i++)
                {
                    murderItems2[i] = gamer.requiredItems[i];
                }
            }
            else if (iteration == 3)
            {
                for (int i = 0; i < 3; i++)
                {
                    murderItems3[i] = gamer.requiredItems[i];
                }
            }
        }
        else if (name == "occult")
        {
            if (iteration == 1)
            {
                for (int i = 0; i < 3; i++)
                {
                    murderItems1[i] = occult.requiredItems[i];
                }
            }
            else if (iteration == 2)
            {
                for (int i = 0; i < 3; i++)
                {
                    murderItems2[i] = occult.requiredItems[i];
                }
            }
            else if (iteration == 3)
            {
                for (int i = 0; i < 3; i++)
                {
                    murderItems3[i] = occult.requiredItems[i];
                }
            }
        }
        else if (name == "jojo")
        {
            if (iteration == 1)
            {
                for (int i = 0; i < 3; i++)
                {
                    murderItems1[i] = jojo.requiredItems[i];
                }
            }
            else if (iteration == 2)
            {
                for (int i = 0; i < 3; i++)
                {
                    murderItems2[i] = jojo.requiredItems[i];
                }
            }
            else if (iteration == 3)
            {
                for (int i = 0; i < 3; i++)
                {
                    murderItems3[i] = jojo.requiredItems[i];
                }
            }
        }
    }

    private void removeDeadNPCs()
    {
        if (forestcore.isDead == true)
        {
            forestcore.gameObject.SetActive(false);
        }
        else if (grilldad.isDead == true)
        {
            grilldad.gameObject.SetActive(false);
        }
        else if (chemist.isDead == true)
        {
            chemist.gameObject.SetActive(false);
        }
        else if (gamer.isDead == true)
        {
            gamer.gameObject.SetActive(false);
        }
        else if (jojo.isDead == true)
        {
            jojo.gameObject.SetActive(false);
        }
        else if (occult.isDead == true)
        {
            occult.gameObject.SetActive(false);
        }
    }

    private void reassignments()
    {
        chemist = GameObject.Find("chemist").GetComponent<ChemistController>();
        forestcore = GameObject.Find("forestcore").GetComponent<ForestcoreController>();
        grilldad = GameObject.Find("grilldad").GetComponent<GrilldadController>();
        gamer = GameObject.Find("gamer").GetComponent<GamerController>();
        jojo = GameObject.Find("jojo").GetComponent<JojoController>();
        occult = GameObject.Find("occult").GetComponent<OccultController>();
        forestcoreDialogue = GameObject.Find("forestcore").GetComponent<DialogueTriggerFC>();
        grilldadDialogue = GameObject.Find("grilldad").GetComponent<DialogueTriggerGD>();
        chemistDialogue = GameObject.Find("chemist").GetComponent<DialogueTriggerC>();
        gamerDialogue = GameObject.Find("gamer").GetComponent<DialogueTriggerG>();
        jojoDialogue = GameObject.Find("jojo").GetComponent<DialogueTriggerJJ>();
        occultDialogue = GameObject.Find("occult").GetComponent<DialogueTriggerO>();
        dialogueManager = GameObject.Find("DialogueManager").GetComponent<DialogueManager>();
        notesMenu = GameObject.Find("Canvas/NotesMenu");

        forestcoreDate = GameObject.Find("Canvas/DateBackgrounds/ForestcoreBackground");
        grilldadDate = GameObject.Find("Canvas/DateBackgrounds/GrilldadBackground");
        chemistDate = GameObject.Find("Canvas/DateBackgrounds/ChemistBackground");
        gamerDate = GameObject.Find("Canvas/DateBackgrounds/GamerBackground");
        jojoDate = GameObject.Find("Canvas/DateBackgrounds/JojoBackground");
        occultDate = GameObject.Find("Canvas/DateBackgrounds/OccultBackground");
        forestcoreSprite = GameObject.Find("Canvas/CharacterIcons/ForestcoreSprite");
        grilldadSprite = GameObject.Find("Canvas/CharacterIcons/GrilldadSprite");
        chemistSprite = GameObject.Find("Canvas/CharacterIcons/ChemistSprite");
        gamerSprite = GameObject.Find("Canvas/CharacterIcons/GamerSprite");
        jojoSprite = GameObject.Find("Canvas/CharacterIcons/JojoSprite");
        occultSprite = GameObject.Find("Canvas/CharacterIcons/OccultSprite");
        forestcoreShop = GameObject.Find("Canvas/FriendDateBackgrounds/AspenShop");
        grilldadShop = GameObject.Find("Canvas/FriendDateBackgrounds/DaveyShop");
        chemistPharmacy = GameObject.Find("Canvas/FriendDateBackgrounds/WesleyPharmacy");
        gamerHouse = GameObject.Find("Canvas/FriendDateBackgrounds/CarmenHouse");
        jojoShop = GameObject.Find("Canvas/FriendDateBackgrounds/ArmaniShop");
        occultGrandmaHouse = GameObject.Find("Canvas/FriendDateBackgrounds/KaiGrandmaHouse");
        directionalLight = GameObject.Find("Directional Light").GetComponent<Light>();

        armaniWin = GameObject.Find("Canvas/WinScreens/ArmaniWin");
        aspenWin = GameObject.Find("Canvas/WinScreens/AspenWin");
        carmenWin = GameObject.Find("Canvas/WinScreens/CarmenWin");
        daveyWin = GameObject.Find("Canvas/WinScreens/DaveyWin");
        kaiWin = GameObject.Find("Canvas/WinScreens/KaiWin");
        wesleyWin = GameObject.Find("Canvas/WinScreens/WesleyWin");

        fcDialogueBox = FindInactiveObjectByName("AspenDB");
        gdDialogueBox = FindInactiveObjectByName("DaveyDB");
        cDialogueBox = FindInactiveObjectByName("WesleyDB");
        gDialogueBox = FindInactiveObjectByName("CarmenDB");
        jDialogueBox = FindInactiveObjectByName("ArmaniDB");
        oDialogueBox = FindInactiveObjectByName("KaiDB");
        pauseMenu = FindInactiveObjectByName("PauseMenu");
    }

    private GameObject FindInactiveObjectByName(string name)
    {
        Transform[] objs = Resources.FindObjectsOfTypeAll<Transform>() as Transform[];
        for (int i = 0; i < objs.Length; i++)
        {
            if (objs[i].hideFlags == HideFlags.None)
            {
                if (objs[i].name == name)
                {
                    return objs[i].gameObject;
                }
            }
        }
        return null;
    }

    public void setEverythingInactive()
    {
        forestcoreDate.SetActive(false);
        grilldadDate.SetActive(false);
        chemistDate.SetActive(false);
        gamerDate.SetActive(false);
        jojoDate.SetActive(false);
        occultDate.SetActive(false);
        forestcoreSprite.SetActive(false);
        grilldadSprite.SetActive(false);
        chemistSprite.SetActive(false);
        gamerSprite.SetActive(false);
        jojoSprite.SetActive(false);
        occultSprite.SetActive(false);
        forestcoreShop.SetActive(false);
        grilldadShop.SetActive(false);
        chemistPharmacy.SetActive(false);
        gamerHouse.SetActive(false);
        jojoShop.SetActive(false);
        occultGrandmaHouse.SetActive(false);
        fcDialogueBox.SetActive(false);
        gdDialogueBox.SetActive(false);
        cDialogueBox.SetActive(false);
        gDialogueBox.SetActive(false);
        jDialogueBox.SetActive(false);
        oDialogueBox.SetActive(false);
        pauseMenu.SetActive(false);
        armaniWin.SetActive(false);
        aspenWin.SetActive(false);
        carmenWin.SetActive(false);
        daveyWin.SetActive(false);
        kaiWin.SetActive(false);
        wesleyWin.SetActive(false);
        notesMenu.SetActive(false);
    }

    private void deactivateNPCS()
    {
        // forestcore.gameObject.SetActive(false);
        // grilldad.gameObject.SetActive(false);
        // chemist.gameObject.SetActive(false);
        // gamer.gameObject.SetActive(false);
        // jojo.gameObject.SetActive(false);
        // occult.gameObject.SetActive(false);
    }

    private void reactivateNPCS()
    {
        // forestcore.gameObject.SetActive(true);
        // grilldad.gameObject.SetActive(true);
        // chemist.gameObject.SetActive(true);
        // gamer.gameObject.SetActive(true);
        // jojo.gameObject.SetActive(true);
        // occult.gameObject.SetActive(true);
    }

    IEnumerator startingBuffer()
    {
        yield return new WaitForSeconds(240);
        isDateTime = true;
    }

    public void winScreen()
    {
        if (interestName == "forestcore")
        {
            GameManager.Instance.winScreen = aspenWin;
        }
        else if (interestName == "grilldad")
        {
            GameManager.Instance.winScreen = daveyWin;
        }
        else if (interestName == "chemist")
        {
            GameManager.Instance.winScreen = wesleyWin;
        }
        else if (interestName == "gamer")
        {
            GameManager.Instance.winScreen = carmenWin;
        }
        else if (interestName == "jojo")
        {
            GameManager.Instance.winScreen = armaniWin;
        }
        else if (interestName == "occult")
        {
            GameManager.Instance.winScreen = kaiWin;
        }
    }
}
