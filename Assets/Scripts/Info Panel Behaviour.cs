using UnityEngine;

public class InfoPanelBehaviour : MonoBehaviour
{
    const float speed = 6f;

    [SerializeField] Transform sectionInfo;

    Vector3 desiredScale = Vector3.zero;

    private void Update()
    {
        sectionInfo.localScale = Vector3.Lerp(sectionInfo.position, desiredScale, Time.deltaTime * speed);
    }
    
    public void OpenInfo()
    {
        desiredScale = Vector3.one;
    }

    public void CloseInfo()
    {
        desiredScale = Vector3.zero;
    }
}
