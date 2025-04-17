using System.Collections.Generic;
using UnityEngine;

public class BookPageFlipper : MonoBehaviour
{
    [SerializeField] private List<GameObject> pages = new List<GameObject>();
    private int currentPageIndex = 0;

    void Update()
    {
        // Arrow keys
        if (Input.GetKeyDown(KeyCode.RightArrow))
            ShowNextPage();

        if (Input.GetKeyDown(KeyCode.LeftArrow))
            ShowPreviousPage();

        // Scroll wheel (mouse)
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll > 0f)
            ShowPreviousPage();  // scrolling up goes back
        else if (scroll < 0f)
            ShowNextPage();      // scrolling down goes forward
    }

    public void ShowNextPage()
    {
        if (pages.Count == 0) return;

        // Hide current page
        pages[currentPageIndex].SetActive(false);

        // Move to next page (loop to start if at end)
        currentPageIndex = (currentPageIndex + 1) % pages.Count;

        // Show next page
        pages[currentPageIndex].SetActive(true);
    }

    public void ShowPreviousPage()
    {
        if (pages.Count == 0) return;

        pages[currentPageIndex].SetActive(false);
        currentPageIndex = (currentPageIndex - 1 + pages.Count) % pages.Count;
        pages[currentPageIndex].SetActive(true);
    }

    // Optional: Add a method to add new pages dynamically
    public void AddPage(GameObject newPage)
    {
        newPage.SetActive(false); // Hide the new page until it's time to show it
        pages.Add(newPage);
    }

    // Optional: Call this at start to show the first page
    void Start()
    {
        if (pages.Count > 0)
        {
            foreach (var page in pages)
                page.SetActive(false);

            pages[0].SetActive(true);
        }
    }
}
