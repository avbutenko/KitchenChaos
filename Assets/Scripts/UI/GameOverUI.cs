using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Netcode;
using Unity.Services.Lobbies.Models;
using UnityEngine;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{


    //[SerializeField] private TextMeshProUGUI recipesDeliveredText;
    [SerializeField] private Button playAgainButton;
    [SerializeField] private Transform resultContainer;
    [SerializeField] private Transform resultTemplate;


    private void Awake()
    {
        playAgainButton.onClick.AddListener(() =>
        {
            NetworkManager.Singleton.Shutdown();
            Loader.Load(Loader.Scene.MainMenuScene);
        });
    }

    private void Start()
    {
        KitchenGameManager.Instance.OnStateChanged += KitchenGameManager_OnStateChanged;

        Hide();
    }

    private void KitchenGameManager_OnStateChanged(object sender, System.EventArgs e)
    {
        if (KitchenGameManager.Instance.IsGameOver())
        {
            Show();
            UpdateResults();
            //recipesDeliveredText.text = DeliveryManager.Instance.GetSuccessfulRecipesAmount().ToString();
        }
        else
        {
            Hide();
        }
    }

    private void UpdateResults()
    {
        foreach (Transform child in resultContainer)
        {
            if (child == resultTemplate) continue;
            Destroy(child.gameObject);
        }

        foreach (PlayerData playerData in KitchenGameMultiplayer.Instance.GetPlayersList())
        {
            Transform resultTransform = Instantiate(resultTemplate, resultContainer);
            resultTransform.gameObject.SetActive(true);
            resultTransform.GetComponent<ResultSingleUI>().SetResults(playerData.playerName.ToString(), playerData.playerScore);
        }
    }

    private void Show()
    {
        gameObject.SetActive(true);
        playAgainButton.Select();
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }


}