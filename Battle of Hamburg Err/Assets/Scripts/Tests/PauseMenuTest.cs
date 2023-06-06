using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class PauseMenuTest
{

    private PauseMenu pauseMenu;

    [SetUp]
    public void SetUp()
    {
        pauseMenu = new PauseMenu
        {
            pauseMenuUI = new GameObject(),
            settingsMenuUI = new GameObject(),
            currentMenuUI = new GameObject()

        };
        PauseMenu.gameIsPaused = false;
        PauseMenu.inOtherMenu = false;
        PauseMenu.gameSpeed = 1;
    }

    // A Test behaves as an ordinary method
    [Test]
    public void Pause_Test()
    {
        pauseMenu.Pause();
        Assert.AreEqual(true, PauseMenu.gameIsPaused);
    }

    [Test]
    public void OtherMenu_Test()
    {
        pauseMenu.SettingsButton();
        Assert.AreEqual(pauseMenu.settingsMenuUI, pauseMenu.currentMenuUI);
    }

    [Test]
    public void Back_Test()
    {
        pauseMenu.SettingsButton();
        pauseMenu.Back(pauseMenu.settingsMenuUI);
        Assert.AreEqual(pauseMenu.pauseMenuUI, pauseMenu.currentMenuUI);
    }

}
