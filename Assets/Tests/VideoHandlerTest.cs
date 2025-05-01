using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.TestTools;

public class VideoHandlerTests
{
    private GameObject videoObj;
    private VideoHandler handler;
    private VideoPlayer player;
    private Button button;
    private Sprite startSprite;
    private Sprite stopSprite;
    private GameObject previewHud;
    private GameObject UIElements;
    private GameObject interactionHud;
    private GameObject pauseButton;

    [SetUp]
    public void Setup()
    {
        // Crear objeto de prueba con componentes
        videoObj = new GameObject("VideoObject");
        player = videoObj.AddComponent<VideoPlayer>();
        handler = videoObj.AddComponent<VideoHandler>();

        // Crear botón con imagen
        var buttonGO = new GameObject("Button");
        button = buttonGO.AddComponent<Button>();
        button.image = buttonGO.AddComponent<Image>();

        // Sprites ficticios para pruebas
        Texture2D testTexture = new Texture2D(10, 10);
        handler.startSprite = Sprite.Create(testTexture, new Rect(0, 0, 10, 10), Vector2.zero);
        handler.stopSprite = Sprite.Create(testTexture, new Rect(0, 0, 10, 10), Vector2.zero);

        // Mock UI GameObjects
        previewHud = new GameObject("PreviewHUD");
        UIElements = new GameObject("UIElements");
        interactionHud = new GameObject("InteractionHUD");
        pauseButton = new GameObject("PauseButton");

        // Asignar referencias
        handler.button = button;
        handler.startSprite = startSprite;
        handler.stopSprite = stopSprite;
        handler.previewHud = previewHud;
        handler.UIElements = UIElements;
        handler.interactionHud = interactionHud;
        handler.pauseButton = pauseButton;

        // Simular estado inicial
        previewHud.SetActive(true);
        UIElements.SetActive(false);
        interactionHud.SetActive(false);
        pauseButton.SetActive(true);
    }

    [TearDown]
    public void Teardown()
    {
        Object.DestroyImmediate(videoObj);
        Object.DestroyImmediate(button.gameObject);
        Object.DestroyImmediate(previewHud);
        Object.DestroyImmediate(UIElements);
        Object.DestroyImmediate(interactionHud);
        Object.DestroyImmediate(pauseButton);
    }

    [UnityTest]
    public System.Collections.IEnumerator StartVideo_HidesPreviewAndShowsUI()
    {
        handler.StartVideo();
        yield return null;

        Assert.IsFalse(previewHud.activeSelf);
        Assert.IsTrue(UIElements.activeSelf);
    }

    [UnityTest]
    public System.Collections.IEnumerator PausePlayVideo_TogglesPlayPauseState()
    {
        Assert.AreEqual(stopSprite, button.image.sprite);

        handler.PausePlayVideo();
        yield return null;
        
        Assert.AreEqual(startSprite, button.image.sprite);
    }

    [UnityTest]
    public System.Collections.IEnumerator VideoEnded_EnablesInteractionUI()
    {
        handler.SendMessage("VideoEnded", player);
        yield return null;

        Assert.IsTrue(interactionHud.activeSelf);
        Assert.IsFalse(pauseButton.activeSelf);
    }
}
