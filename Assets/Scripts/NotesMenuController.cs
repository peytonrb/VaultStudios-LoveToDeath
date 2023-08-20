using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotesMenuController : MonoBehaviour
{
    // public static NotesMenuController Instance { get; private set; }

    [Header("Pages")]
    public GameObject armaniPage;
    public GameObject aspenPage;
    public GameObject carmenPage;
    public GameObject daveyPage;
    public GameObject kaiPage;
    public GameObject wesleyPage;

    [Header("LoveProgress")]
    public GameObject loveMeter;
    public GameObject oneHeart;
    public GameObject twoHeart;
    public GameObject threeHeart;
    public GameObject fourHeart;

    [Header("ItemsBase")]
    public GameObject armaniBase;
    public GameObject aspenBase;
    public GameObject carmenBase;
    public GameObject daveyBase;
    public GameObject kaiBase;
    public GameObject wesleyBase;

    [Header("Tabs")]
    public GameObject armaniTabs;
    public GameObject aspenTabs;
    public GameObject carmenTabs;
    public GameObject daveyTabs;
    public GameObject kaiTabs;
    public GameObject wesleyTabs;

    [Header("Doodles Love")]
    public GameObject armaniDoodlesLove;
    public GameObject aspenDoodlesLove;
    public GameObject carmenDoodlesLove;
    public GameObject daveyDoodlesLove;
    public GameObject kaiDoodlesLove;
    public GameObject wesleyDoodlesLove;

    [Header("Doodles Dead")]
    public GameObject armaniDoodles;
    public GameObject aspenDoodles;
    public GameObject carmenDoodles;
    public GameObject daveyDoodles;
    public GameObject kaiDoodles;
    public GameObject wesleyDoodles;

    [Header("Items")]
    public GameObject bat;
    public GameObject tripwire;
    public GameObject toolbox;
    public GameObject berries;
    public GameObject mortar;
    public GameObject tea;
    public GameObject wireCutters;
    public GameObject gardenGloves;
    public GameObject screwdriver;
    public GameObject gas;
    public GameObject keys;
    public GameObject saw;
    public GameObject necronomicon;
    public GameObject ouija;
    public GameObject candles;
    public GameObject bunsenBurner;
    public GameObject chemical;
    public GameObject gloves;

    public PlayerController player;
    public List<string> collectedItems;

    // private void Awake()
    // {
    //     if (Instance != null)
    //     {
    //         DestroyImmediate(gameObject);
    //     }
    //     else
    //     {
    //         Instance = this;
    //         DontDestroyOnLoad(gameObject);
    //     }
    // }

    void Start()
    {
        collectedItems.Clear();
        reassign();
        armaniTab();
    }

    void Update()
    {
        if (GameManager.Instance.sceneJustLoaded == true)
        {
            reassign();
        }
    }

    public void armaniTab()
    {
        setEverythingInactive();
        armaniPage.SetActive(true);

        if (player.interestName == "jojo")
        {
            loveMeter.SetActive(true);
            armaniDoodlesLove.SetActive(true);

            if (player.dateCount == 1)
            {
                oneHeart.SetActive(true);
            }
            else if (player.dateCount == 2)
            {
                twoHeart.SetActive(true);
            }
            else if (player.dateCount == 3)
            {
                threeHeart.SetActive(true);
                fourHeart.SetActive(true);
            }
        }
        else if (player.target1.gameObject.name == "jojo"
                || player.target2.gameObject.name == "jojo"
                || player.target3.gameObject.name == "jojo")
        {
            armaniBase.SetActive(true);

            if (player.jojoIsDead == true)
            {
                armaniDoodles.SetActive(true);
            }

            if (player.jojoFriendDateOccured == true)
            {
                bat.SetActive(true);
            }

            foreach (string item in collectedItems)
            {
                if (item == "ARMANI_toolbox")
                {
                    toolbox.SetActive(true);
                }

                if (item == "ARMANI_fishing line")
                {
                    tripwire.SetActive(true);
                }
            }
        }
    }

    public void aspenTab()
    {
        setEverythingInactive();
        aspenPage.SetActive(true);

        if (player.interestName == "forestcore")
        {
            loveMeter.SetActive(true);
            aspenDoodlesLove.SetActive(true);

            if (player.dateCount == 1)
            {
                oneHeart.SetActive(true);
            }
            else if (player.dateCount == 2)
            {
                twoHeart.SetActive(true);
            }
            else if (player.dateCount == 3)
            {
                threeHeart.SetActive(true);
                fourHeart.SetActive(true);
            }
        }
        else if (player.target1.gameObject.name == "forestcore"
                || player.target2.gameObject.name == "forestcore"
                || player.target3.gameObject.name == "forestcore")
        {
            aspenBase.SetActive(true);

            if (player.forestcoreIsDead == true)
            {
                aspenDoodles.SetActive(true);
            }

            if (player.forestcoreFriendDateOccured == true)
            {
                mortar.SetActive(true);
            }

            foreach (string item in collectedItems)
            {
                if (item == "ASPEN_poison berries")
                {
                    berries.SetActive(true);
                }

                if (item == "ASPEN_sweet tea")
                {
                    tea.SetActive(true);
                }
            }
        }
    }

    public void carmenTab()
    {
        setEverythingInactive();
        carmenPage.SetActive(true);

        if (player.interestName == "gamer")
        {
            loveMeter.SetActive(true);
            carmenDoodlesLove.SetActive(true);

            if (player.dateCount == 1)
            {
                oneHeart.SetActive(true);
            }
            else if (player.dateCount == 2)
            {
                twoHeart.SetActive(true);
            }
            else if (player.dateCount == 3)
            {
                threeHeart.SetActive(true);
                fourHeart.SetActive(true);
            }
        }
        else if (player.target1.gameObject.name == "gamer"
                || player.target2.gameObject.name == "gamer"
                || player.target3.gameObject.name == "gamer")
        {
            carmenBase.SetActive(true);

            if (player.gamerIsDead == true)
            {
                carmenDoodles.SetActive(true);
            }

            if (player.gamerFriendDateOccured == true)
            {
                screwdriver.SetActive(true);
            }

            foreach (string item in collectedItems)
            {
                if (item == "CARMEN_garden gloves")
                {
                    gardenGloves.SetActive(true);
                }

                if (item == "CARMEN_pliers")
                {
                    wireCutters.SetActive(true);
                }
            }
        }
    }

    public void daveyTab()
    {
        setEverythingInactive();
        daveyPage.SetActive(true);

        if (player.interestName == "grilldad")
        {
            loveMeter.SetActive(true);
            daveyDoodlesLove.SetActive(true);

            if (player.dateCount == 1)
            {
                oneHeart.SetActive(true);
            }
            else if (player.dateCount == 2)
            {
                twoHeart.SetActive(true);
            }
            else if (player.dateCount == 3)
            {
                threeHeart.SetActive(true);
                fourHeart.SetActive(true);
            }
        }
        else if (player.target1.gameObject.name == "grilldad"
                || player.target2.gameObject.name == "grilldad"
                || player.target3.gameObject.name == "grilldad")
        {
            daveyBase.SetActive(true);

            if (player.grilldadIsDead == true)
            {
                daveyDoodles.SetActive(true);
            }

            if (player.grilldadFriendDateOccured == true)
            {
                gas.SetActive(true);
            }

            foreach (string item in collectedItems)
            {
                if (item == "DAVEY_car keys")
                {
                    keys.SetActive(true);
                }

                if (item == "DAVEY_handsaw")
                {
                    saw.SetActive(true);
                }
            }
        }
    }

    public void kaiTab()
    {
        setEverythingInactive();
        kaiPage.SetActive(true);

        if (player.interestName == "occult")
        {
            loveMeter.SetActive(true);
            kaiDoodlesLove.SetActive(true);

            if (player.dateCount == 1)
            {
                oneHeart.SetActive(true);
            }
            else if (player.dateCount == 2)
            {
                twoHeart.SetActive(true);
            }
            else if (player.dateCount == 3)
            {
                threeHeart.SetActive(true);
                fourHeart.SetActive(true);
            }
        }
        else if (player.target1.gameObject.name == "occult"
                || player.target2.gameObject.name == "occult"
                || player.target3.gameObject.name == "occult")
        {
            kaiBase.SetActive(true);

            if (player.occultIsDead == true)
            {
                kaiDoodles.SetActive(true);
            }

            if (player.occultFriendDateOccured == true)
            {
                necronomicon.SetActive(true);
            }

            foreach (string item in collectedItems)
            {
                if (item == "KAI_candles")
                {
                    candles.SetActive(true);
                }

                if (item == "KAI_ouija")
                {
                    ouija.SetActive(true);
                }
            }
        }
    }

    public void wesleyTab()
    {
        setEverythingInactive();
        wesleyPage.SetActive(true);

        if (player.interestName == "chemist")
        {
            loveMeter.SetActive(true);
            wesleyDoodlesLove.SetActive(true);

            if (player.dateCount == 1)
            {
                oneHeart.SetActive(true);
            }
            else if (player.dateCount == 2)
            {
                twoHeart.SetActive(true);
            }
            else if (player.dateCount == 3)
            {
                threeHeart.SetActive(true);
                fourHeart.SetActive(true);
            }
        }
        else if (player.target1.gameObject.name == "chemist"
                || player.target2.gameObject.name == "chemist"
                || player.target3.gameObject.name == "chemist")
        {
            wesleyBase.SetActive(true);

            if (player.chemistIsDead == true)
            {
                wesleyDoodles.SetActive(true);
            }

            if (player.chemistFriendDateOccured == true)
            {
                gloves.SetActive(true);
            }

            foreach (string item in collectedItems)
            {
                if (item == "WESLEY_bunsen burner")
                {
                    bunsenBurner.SetActive(true);
                }

                if (item == "WESLEY_chemical")
                {
                    chemical.SetActive(true);
                }
            }
        }
    }

    public void addItems(string itemName)
    {
        collectedItems.Add(itemName);
    }

    private void setEverythingInactive()
    {
        armaniPage.SetActive(false);
        aspenPage.SetActive(false);
        carmenPage.SetActive(false);
        daveyPage.SetActive(false);
        kaiPage.SetActive(false);
        wesleyPage.SetActive(false);
        loveMeter.SetActive(false);
        oneHeart.SetActive(false);
        twoHeart.SetActive(false);
        threeHeart.SetActive(false);
        fourHeart.SetActive(false);
        armaniBase.SetActive(false);
        aspenBase.SetActive(false);
        carmenBase.SetActive(false);
        daveyBase.SetActive(false);
        kaiBase.SetActive(false);
        wesleyBase.SetActive(false);
        armaniDoodlesLove.SetActive(false);
        aspenDoodlesLove.SetActive(false);
        carmenDoodlesLove.SetActive(false);
        daveyDoodlesLove.SetActive(false);
        kaiDoodlesLove.SetActive(false);
        wesleyDoodlesLove.SetActive(false);
        armaniDoodles.SetActive(false);
        aspenDoodles.SetActive(false);
        carmenDoodles.SetActive(false);
        daveyDoodles.SetActive(false);
        kaiDoodles.SetActive(false);
        wesleyDoodles.SetActive(false);
        bat.SetActive(false);
        tripwire.SetActive(false);
        toolbox.SetActive(false);
        berries.SetActive(false);
        mortar.SetActive(false);
        tea.SetActive(false);
        wireCutters.SetActive(false);
        gardenGloves.SetActive(false);
        screwdriver.SetActive(false);
        gas.SetActive(false);
        keys.SetActive(false);
        saw.SetActive(false);
        necronomicon.SetActive(false);
        ouija.SetActive(false);
        candles.SetActive(false);
        bunsenBurner.SetActive(false);
        chemical.SetActive(false);
        gloves.SetActive(false);
    }

    private void reassign()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();
        armaniPage = GameObject.Find("Canvas/NotesMenu/Pages/ArmaniPage");
        aspenPage = GameObject.Find("Canvas/NotesMenu/Pages/AspenPage");
        carmenPage = GameObject.Find("Canvas/NotesMenu/Pages/CarmenPage");
        daveyPage = GameObject.Find("Canvas/NotesMenu/Pages/DaveyPage");
        kaiPage = GameObject.Find("Canvas/NotesMenu/Pages/KaiPage");
        wesleyPage = GameObject.Find("Canvas/NotesMenu/Pages/WesleyPage");
        loveMeter = GameObject.Find("Canvas/NotesMenu/LoveProgress/Meter");
        oneHeart = GameObject.Find("Canvas/NotesMenu/LoveProgress/FirstHeart");
        twoHeart = GameObject.Find("Canvas/NotesMenu/LoveProgress/SecondHeart");
        threeHeart = GameObject.Find("Canvas/NotesMenu/LoveProgress/ThirdHeart");
        fourHeart = GameObject.Find("Canvas/NotesMenu/LoveProgress/FinalHeart");
        armaniBase = GameObject.Find("Canvas/NotesMenu/ItemsBase/ArmaniBase");
        aspenBase = GameObject.Find("Canvas/NotesMenu/ItemsBase/AspenBase");
        carmenBase = GameObject.Find("Canvas/NotesMenu/ItemsBase/CarmenBase");
        daveyBase = GameObject.Find("Canvas/NotesMenu/ItemsBase/DaveyBase");
        kaiBase = GameObject.Find("Canvas/NotesMenu/ItemsBase/KaiBase");
        wesleyBase = GameObject.Find("Canvas/NotesMenu/ItemsBase/WesleyBase");
        armaniTabs = GameObject.Find("Canvas/NotesMenu/Tabs/ArmaniTab");
        aspenTabs = GameObject.Find("Canvas/NotesMenu/Tabs/AspenTab");
        carmenTabs = GameObject.Find("Canvas/NotesMenu/Tabs/CarmenTab");
        daveyTabs = GameObject.Find("Canvas/NotesMenu/Tabs/DaveyTab");
        kaiTabs = GameObject.Find("Canvas/NotesMenu/Tabs/KaiTab");
        wesleyTabs = GameObject.Find("Canvas/NotesMenu/Tabs/WesleyTab");
        armaniDoodlesLove = GameObject.Find("Canvas/NotesMenu/DoodlesLove/ArmaniDoodlesLove");
        aspenDoodlesLove = GameObject.Find("Canvas/NotesMenu/DoodlesLove/AspenDoodlesLove");
        carmenDoodlesLove = GameObject.Find("Canvas/NotesMenu/DoodlesLove/CarmenDoodlesLove");
        daveyDoodlesLove = GameObject.Find("Canvas/NotesMenu/DoodlesLove/DaveyDoodlesLove");
        kaiDoodlesLove = GameObject.Find("Canvas/NotesMenu/DoodlesLove/KaiDoodlesLove");
        wesleyDoodlesLove = GameObject.Find("Canvas/NotesMenu/DoodlesLove/WesleyDoodlesLove");
        armaniDoodles = GameObject.Find("Canvas/NotesMenu/DoodlesDead/ArmaniDoodles");
        aspenDoodles = GameObject.Find("Canvas/NotesMenu/DoodlesDead/AspenDoodles");
        carmenDoodles = GameObject.Find("Canvas/NotesMenu/DoodlesDead/CarmenDoodles");
        daveyDoodles = GameObject.Find("Canvas/NotesMenu/DoodlesDead/DaveyDoodles");
        kaiDoodles = GameObject.Find("Canvas/NotesMenu/DoodlesDead/KaiDoodles");
        wesleyDoodles = GameObject.Find("Canvas/NotesMenu/DoodlesDead/WesleyDoodles");
        bat = GameObject.Find("Canvas/NotesMenu/ItemsCollected/ArmaniBat");
        tripwire = GameObject.Find("Canvas/NotesMenu/ItemsCollected/ArmaniTripwire");
        toolbox = GameObject.Find("Canvas/NotesMenu/ItemsCollected/ArmaniToolbox");
        berries = GameObject.Find("Canvas/NotesMenu/ItemsCollected/AspenBerries");
        mortar = GameObject.Find("Canvas/NotesMenu/ItemsCollected/AspenMortar");
        tea = GameObject.Find("Canvas/NotesMenu/ItemsCollected/AspenTea");
        wireCutters = GameObject.Find("Canvas/NotesMenu/ItemsCollected/CarmenWireCutters");
        gardenGloves = GameObject.Find("Canvas/NotesMenu/ItemsCollected/CarmenGloves");
        screwdriver = GameObject.Find("Canvas/NotesMenu/ItemsCollected/CarmenScrewdriver");
        gas = GameObject.Find("Canvas/NotesMenu/ItemsCollected/DaveyGasoline");
        keys = GameObject.Find("Canvas/NotesMenu/ItemsCollected/DaveyKeys");
        saw = GameObject.Find("Canvas/NotesMenu/ItemsCollected/DaveySaw");
        necronomicon = GameObject.Find("Canvas/NotesMenu/ItemsCollected/KaiNecronomicon");
        ouija = GameObject.Find("Canvas/NotesMenu/ItemsCollected/KaiOuija");
        candles = GameObject.Find("Canvas/NotesMenu/ItemsCollected/KaiCandles");
        bunsenBurner = GameObject.Find("Canvas/NotesMenu/ItemsCollected/WesleyBunsenBurner");
        chemical = GameObject.Find("Canvas/NotesMenu/ItemsCollected/WesleyChemicals");
        gloves = GameObject.Find("Canvas/NotesMenu/ItemsCollected/WesleyGloves");
    }
}
