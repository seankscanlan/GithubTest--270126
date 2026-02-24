using UnityEngine;
using System.Collections;

public class MenuController: MonoBehaviour
{
    public CanvasGroup mainMenu;
    public CanvasGroup optionsMenu;
    public float transitionDuration = .25f;

    void Start()
    {
        ShowMainMenuInstant();
    }

    public void OpenOptionsMenu()
    {
        StartCoroutine(TransitionMenu(mainMenu,optionsMenu)); //Coroutines work with human time
    }

    public void BackToMainMenu()
    {
        StartCoroutine(TransitionMenu(optionsMenu,mainMenu));
    }

    void ShowMainMenuInstant()
    {
        mainMenu.alpha = 1;
        mainMenu.interactable = true;
        mainMenu.blocksRaycasts = true; //raycasts are straight lines and instant

        optionsMenu.alpha = 0;
        optionsMenu.interactable = false;
        optionsMenu.blocksRaycasts = false;
        optionsMenu.gameObject.SetActive(false); //gameObject is specific game object, GameObject is the component game object
    }

    IEnumerator TransitionMenu(CanvasGroup currentMenu, CanvasGroup nextMenu)
    {
        float timer = 0f;

        nextMenu.gameObject.SetActive(true);

        while(timer < transitionDuration)
        {
            timer += Time.deltaTime;
            float progress = timer/transitionDuration;
            currentMenu.alpha = 1- progress;
            nextMenu.alpha = progress;
            yield return null;
        }
        currentMenu.interactable = false;
        currentMenu.blocksRaycasts = false;
        currentMenu.gameObject.SetActive(false);

        nextMenu.interactable = true;
        nextMenu.blocksRaycasts = true;
    }
}