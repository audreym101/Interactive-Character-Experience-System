using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class UIManager : MonoBehaviour
{
    [Header("Screens")]
    public CanvasGroup mainMenuScreen;
    public CanvasGroup fighterSelectScreen;
    public CanvasGroup battleScreen;

    [Header("Battle UI")]
    public TMP_Text activeFighterText;
    public Slider fighter1Health;
    public Slider fighter2Health;
    public Slider fighter3Health;
    public TMP_Text winnerText;

    public float fadeDuration = 0.5f;

    void Start()
    {
        InitScreen(mainMenuScreen, true);
        InitScreen(fighterSelectScreen, false);
        InitScreen(battleScreen, false);
        Debug.Log("UIManager Start - MainMenu visible");
    }

    void InitScreen(CanvasGroup cg, bool visible)
    {
        cg.alpha = visible ? 1f : 0f;
        cg.interactable = visible;
        cg.blocksRaycasts = visible;
    }

    public void ShowMainMenu()
    {
        Debug.Log("ShowMainMenu called");
        StartCoroutine(TransitionTo(mainMenuScreen));
    }
    public void ShowFighterSelect()
    {
        Debug.Log("ShowFighterSelect called");
        StartCoroutine(TransitionTo(fighterSelectScreen));
    }
    public void ShowBattle()
    {
        winnerText.gameObject.SetActive(false);
        StartCoroutine(TransitionTo(battleScreen));
    }

    IEnumerator TransitionTo(CanvasGroup target)
    {
        CanvasGroup[] screens = { mainMenuScreen, fighterSelectScreen, battleScreen };

        foreach (CanvasGroup screen in screens)
            if (screen != target)
                StartCoroutine(Fade(screen, 0f));

        yield return new WaitForSeconds(fadeDuration);

        StartCoroutine(Fade(target, 1f));
        target.interactable = true;
        target.blocksRaycasts = true;
    }

    IEnumerator Fade(CanvasGroup cg, float targetAlpha)
    {
        cg.interactable = false;
        cg.blocksRaycasts = false;

        float startAlpha = cg.alpha;
        float time = 0f;

        while (time < fadeDuration)
        {
            time += Time.deltaTime;
            cg.alpha = Mathf.Lerp(startAlpha, targetAlpha, time / fadeDuration);
            yield return null;
        }

        cg.alpha = targetAlpha;
    }

    public void UpdateActiveFighterText(string name)
    {
        activeFighterText.text = name;
    }

    public void SetHealth(int fighterIndex, float value)
    {
        if (fighterIndex == 1) fighter1Health.value = value;
        else if (fighterIndex == 2) fighter2Health.value = value;
        else if (fighterIndex == 3) fighter3Health.value = value;
    }

    public void ShowWinner(string name)
    {
        winnerText.gameObject.SetActive(true);
        winnerText.text = name + " Wins!";
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
