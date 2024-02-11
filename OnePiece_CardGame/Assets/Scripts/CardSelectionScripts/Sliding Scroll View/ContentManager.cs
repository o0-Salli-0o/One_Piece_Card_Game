using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Unity.VisualScripting;
using UnityEngine.Android;

public class ContentManager : MonoBehaviour
{

    [Header("Content Viewport")]
    public Image contentDisplay;
    public List<GameObject> contentPanels;

    [Header("Navigation Dots")]
    public GameObject dotsContainer;
    public GameObject dotPrefab;

    [Header("Pagination Buttons")]
    public Button nextButton;
    public Button prevButton;

    [Header("Page Settings")]
    public bool useTimer = false;
    public bool isLimitedSwipe = false;
    public float autoMoveTime = 5f;
    private float timer;
    public int currentIndex = 0;
    public float swipeThreshold = 50f;
    private Vector2 touchStartPos;

    public GameObject cardSelectionPanel;
    public GameObject cardContainer;

    private const string ALL_CARDS = "All";
    private const string RED_CARDS = "Red";
    private const string GREEN_CARDS = "Green";
    private const string BLUE_CARDS = "Blue";
    private const string PURPLE_CARDS = "Purple";
    private const string BLACK_CARDS = "Black";
    private const string YELLOW_CARDS = "Yellow";

    private const string LEADER_CARDS = "Leader";
    private const string CHARACTER_CARDS = "Character";
    private const string STAGE_CARDS = "Stage";
    private const string EVENT_CARDS = "Event";

    void Start()
    {
        nextButton.onClick.AddListener(NextContent);
        prevButton.onClick.AddListener(PreviousContent);

        // Initialize dots
        //InitializeDots();

        //InitContentPages();
        InitContentPagesTest(CardDatabaseBehaviour.cards);

        // Display initial content
        //ShowContent();

        // Start auto-move timer if enabled
        /*if (useTimer)
        {
            timer = autoMoveTime;
            InvokeRepeating("AutoMoveContent", 1f, 1f); // Invoke every second to update the timer
        }*/
    }

    void InitializeDots()
    {
        //InitializeContentPanelList();

        // Create dots based on the number of content panels
        for (int i = 0; i <= GetPageCountOf(CardDatabaseBehaviour.cards) /*contentPanels.Count*/; i++)
        {
            GameObject dot = Instantiate(dotPrefab, dotsContainer.transform);
            Image dotImage = dot.GetComponent<Image>();
            dotImage.color = (i == currentIndex) ? Color.white : Color.gray;
            dotImage.fillAmount = 0f; // Initial fill amount
            // You may want to customize the dot appearance and layout here
        }
    }

    /*private void InitializeContentPanelList()
    {
        for(int i = 0; i <= GetLeadersPageCount(); i++)
        {
            contentPanels.Add(pagePrefab);
        }
    }*/

    private int GetPageCountOf(List<CardData> cards)
    {

        int cardCount = 0;
        int pageCount = 0;

        foreach (CardData card in cards)
        {
            //if (card.IsLeader)
            //{
                cardCount++;
            //}

            if (cardCount == 10 /*10=cards/page*/)
            {
                pageCount++;
                cardCount = 0;
            }
        }
        return pageCount;
    }

    void UpdateDots()
    {
        // Update the appearance of dots based on the current index
        for (int i = 0; i < dotsContainer.transform.childCount; i++)
        {
            Image dotImage = dotsContainer.transform.GetChild(i).GetComponent<Image>();
            dotImage.color = (i == currentIndex) ? Color.white : Color.gray;

            float targetFillAmount = timer / autoMoveTime;
            StartCoroutine(SmoothFill(dotImage, targetFillAmount, 0.5f));
        }
    }

    IEnumerator SmoothFill(Image image, float targetFillAmount, float duration)
    {
        float startFillAmount = image.fillAmount;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            image.fillAmount = Mathf.Lerp(startFillAmount, targetFillAmount, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        image.fillAmount = targetFillAmount; // Ensure it reaches the exact target
    }

    void Update()
    {
        // Detect swipe input only within the content area
        //DetectSwipe();
    }

    void DetectSwipe()
    {
        if (Input.GetMouseButtonDown(0))
        {
            touchStartPos = Input.mousePosition;
        }

        if (Input.GetMouseButtonUp(0))
        {
            Vector2 touchEndPos = Input.mousePosition;
            float swipeDistance = touchEndPos.x - touchStartPos.x;

            // Check if the swipe is within the content area bounds
            if (Mathf.Abs(swipeDistance) > swipeThreshold && IsTouchInContentArea(touchStartPos))
            {
                if (isLimitedSwipe && ((currentIndex == 0 && swipeDistance > 0) || (currentIndex == contentPanels.Count - 1 && swipeDistance < 0)))
                {
                    // Limited swipe is enabled, and at the edge of content
                    return;
                }

                if (swipeDistance > 0)
                {
                    PreviousContent();
                }
                else
                {
                    NextContent();
                }
            }
        }
    }

    // Check if the touch position is within the content area bounds
    bool IsTouchInContentArea(Vector2 touchPosition)
    {
        //return RectTransformUtility.RectangleContainsScreenPoint(contentArea, touchPosition);
        return false;
    }

    void AutoMoveContent()
    {
        timer -= 1f; // Decrease timer every second

        if (timer <= 0)
        {
            timer = autoMoveTime;
            NextContent();
        }

        UpdateDots(); // Update dots on every timer tick
    }

    void NextContent()
    {
        currentIndex = (currentIndex + 1) % contentPanels.Count;
        ShowContent();
        UpdateDots();
    }

    void PreviousContent()
    {
        currentIndex = (currentIndex - 1 + contentPanels.Count) % contentPanels.Count;
        ShowContent();
        UpdateDots();
    }

    public void ShowContent()
    {
        /*for(int a = 0; a <= GetPageCount(); a++)
        {
            contentPanels[a].SetActive(true);
            contentPanels[a].GetComponent<CardToPanelTest>().CardsToPanel();
        }*/

            // Activate the current panel and deactivate others
        for (int i = 0; i < contentPanels.Count /*contentPanels.Count*/; i++)
        {
            /*if (contentPanels[i].transform.childCount == 0)
            {
                AddCardsToPage(contentPanels[i]);
            }*/

            bool isActive = i == currentIndex;
            contentPanels[i].SetActive(isActive);
            //Debug.Log(contentPanels.Count/*contentPanels[0].transform.childCount*/);

            // Update dot visibility and color based on the current active content

            //Image dotImage = dotsContainer.transform.GetChild(i).GetComponent<Image>();
            //dotImage.color = isActive ? Color.white : Color.gray;

            if (isActive)
            {
                // Reset timer and fill amount when the content is swiped
                timer = autoMoveTime;
                //dotImage.fillAmount = 1f;
            }
            else
            {
                // Set the fill amount to 0 for non-active content

                //dotImage.fillAmount = 0f;
            }
        }
    }

    public void SetCurrentIndex(int newIndex)
    {
        if (newIndex >= 0 && newIndex < contentPanels.Count)
        {
            currentIndex = newIndex;
            ShowContent();
            UpdateDots();
        }
    }

    public void FilterBy(Text filterCriteria)
    {
        MoveContentCardsToContainer();
        DestroyPages();
        MoveContainerCardsToContent(filterCriteria.text.ToString());
    }

    private void MoveContainerCardsToContent(string filterCriteria)
    {
        List<GameObject> cards = cardContainer.GetComponent<CardContainer>().GetCardsBy(filterCriteria);

        int nrOfPages = GetNumberOfPages(cards);
        cardSelectionPanel.GetComponent<PageToPanelTest>().PagesToSelectionPanel(nrOfPages);
        InitContentPagesTest(TransformList(cards));
    }

    private int GetNumberOfPages(List<GameObject> cards)
    {
        int CARDS_PER_PAGE = 10;
        int cardCount = 0;
        int pageCount = 0;

        foreach(GameObject card in cards)
        {
            cardCount++;

            if (cardCount == CARDS_PER_PAGE)
            {
                pageCount++;
                cardCount = 0;
            }
        }
        return pageCount;
    }

    private void MoveContentCardsToContainer()
    {
        List<GameObject> contentCards = GetContentCards();

        foreach(GameObject card in contentCards)
        {
            cardContainer.GetComponent<CardContainer>().Add(card);
        }

        cardContainer.GetComponent<CardContainer>().Sort();
    }

    private List<GameObject> GetContentCards()
    {
        List<GameObject> resultList = new();

        for(int i = 0; i < contentPanels.Count /*cardSelectionPanel.transform.childCount*/; i++)
        {
            //GameObject cardSelectionPage = cardSelectionPanel.transform.GetChild(i).gameObject;

            GameObject cardSelectionPage = contentPanels[i];

            for(int j = 0; j < cardSelectionPage.transform.childCount; j++)
            {
                resultList.Add(cardSelectionPage.transform.GetChild(j).gameObject);
            }
        }
        return resultList;
    }

    private void DestroyPages()
    {
        for(int i = 0; i < cardSelectionPanel.transform.childCount; i++)
        {
            GameObject cardSelectionPage = cardSelectionPanel.transform.GetChild(i).gameObject;
            contentPanels.Clear();
            Destroy(cardSelectionPage);
        }
    }

    private void InitContentPages()
    {
        for(int i = 0; i < contentPanels.Count; i++)
        {

            GameObject cardSelectionPage = contentPanels[i];
            AddCardsToPage(cardSelectionPage);
        }
    }

    private void InitContentPagesTest(List<CardData> cards)
    {
        int pageIndex = 0;

        List<CardData> cardsOfPage = new();

        CardData lastCard = cards[cards.Count - 1];

        foreach (CardData card in cards)
        {

            cardsOfPage.Add(card);

            if(cardsOfPage.Count == 10 || card.CardID == lastCard.CardID)
            {
                GameObject cardSelectionPage = contentPanels[pageIndex++];
                cardSelectionPage.GetComponent<CardToPanelTest>().CardsToPanel(cardsOfPage);
                cardsOfPage.Clear();
            }
        }

        SetCurrentIndex(0);
    }

    private List<CardData> TransformList(List<GameObject> transformList)
    {
        List<CardData> resultList = new List<CardData>();

        foreach(GameObject card in transformList)
        {
            resultList.Add(card.GetComponent<CardDisplayTest>().CardData);
        }
        return resultList;
    }

    private void AddCardsToPage(GameObject cardSelectionPage)
    {
        cardSelectionPage.GetComponent<CardToPanelTest>().CardsToPanel();
    }
}