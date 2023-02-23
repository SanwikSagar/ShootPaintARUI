using JMRSDK.InputModule;
using UnityEngine;
public class basic_movement : MonoBehaviour, ISelectClickHandler
{
    public void Start()
    {
        JMRInputManager.Instance.AddGlobalListener(gameObject);

    }
    public void OnSelectClicked(SelectClickEventData eventData)
    {
        Debug.Log("OnSelectClicked");
    }
}
