using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GamePlay : UICanvas
{
    public EventTrigger trigger;
    public Button buttonPause;

    void OnEnable()
    {
        EventTrigger.Entry downEntry = new EventTrigger.Entry();
        downEntry.eventID = EventTriggerType.PointerDown;
        downEntry.callback.AddListener((data) => { OnPointerDown((PointerEventData)data); });

        EventTrigger.Entry upEntry = new EventTrigger.Entry();
        upEntry.eventID = EventTriggerType.PointerUp;
        upEntry.callback.AddListener((data) => { OnPointerUp((PointerEventData)data); });

        trigger.triggers.Add(downEntry);
        trigger.triggers.Add(upEntry);

        buttonPause.onClick.AddListener(ButtonPause);
    }

    public void OnPointerDown(PointerEventData data)
    {
    }
    public void ButtonPause()
    {
        Time.timeScale = 0f;
        UIManager.Ins.OpenUI<Pause>();
    }
    public void OnPointerUp(PointerEventData data)
    {
    }
}
