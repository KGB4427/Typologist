using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class TutorialManager : MonoBehaviour
{
    [System.Serializable]
    public class TutorialStep
    {
        [TextArea]
        public string message;
        public GameObject[] activateObjects;
        public GameObject[] deactivateObjects;
        public MonoBehaviour[] enableComponents;
        public MonoBehaviour[] disableComponents;
    }

    public List<TutorialStep> steps = new List<TutorialStep>();
    public Text tutorialText; // UI Text element
    public GameObject tutorialPanel; // Panel to show/hide tutorial
    private int currentStep = 0;

    void Start()
    {
        if (steps.Count > 0)
        {
            ShowStep(0);
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            NextStep();
        }
    }

    public void NextStep()
    {
        currentStep++;

        if (currentStep >= steps.Count)
        {
            tutorialPanel.SetActive(false);
            return;
        }

        ShowStep(currentStep);
    }

    void ShowStep(int index)
    {
        TutorialStep step = steps[index];
        tutorialText.text = step.message;

        foreach (GameObject go in step.activateObjects)
            if (go) go.SetActive(true);

        foreach (GameObject go in step.deactivateObjects)
            if (go) go.SetActive(false);

        foreach (MonoBehaviour comp in step.enableComponents)
            if (comp) comp.enabled = true;

        foreach (MonoBehaviour comp in step.disableComponents)
            if (comp) comp.enabled = false;
    }
}
