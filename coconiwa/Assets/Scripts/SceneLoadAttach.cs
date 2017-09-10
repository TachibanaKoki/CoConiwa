﻿using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadAttach : MonoBehaviour
{

    [SerializeField]
    string LoadSceneName;

    [SerializeField]
    bool isTransition = true;

    public void LoadSceneAsync()
    {
        if (isTransition)
        {
            UnderBerMenu menu = transform.parent.GetComponent<UnderBerMenu>();
            if (menu != null)
            {
                transform.parent.GetComponent<UnderBerMenu>().ChangeScene(LoadSceneName);
            }
            else
            {
                UnderBerMenu.I.ChangeScene(LoadSceneName);
            }
            return;
        }

        try
        {
            SceneManager.LoadSceneAsync(LoadSceneName);
        }
        catch
        {
            Debug.Log("LoadSceneNotFound");
        }
    }

    public void LoadScene()
    {
        try
        {
            SceneManager.LoadScene(LoadSceneName);
        }
        catch
        {
            Debug.Log("LoadSceneNotFound");
        }
    }

    public void MapSceneLoad(string FileID)
    {
        AppData.SelectTargetName = FileID;
        UnderBerMenu.I.ChangeScene("Content");
    }
}
