using UnityEngine;
using UnityEngine.UI;

public class ButtonTooltip : MonoBehaviour
{
    public Image tooltipImage; // 將提示標語 Image 拖拽到這個變數中

    private bool isHovering = false;

    void Update()
    {
        // 射線檢測，檢查鼠標是否懸停在按鈕上
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            // 如果檢測到的物件是按鈕，顯示提示標語
            if (hit.collider.gameObject == gameObject)
            {
                tooltipImage.enabled = true;
                isHovering = true;
            }
            else
            {
                // 如果鼠標沒有懸停在按鈕上，隱藏提示標語
                if (isHovering)
                {
                    tooltipImage.enabled = false;
                    isHovering = false;
                }
            }
        }
        else
        {
            // 如果鼠標沒有懸停在按鈕上，隱藏提示標語
            if (isHovering)
            {
                tooltipImage.enabled = false;
                isHovering = false;
            }
        }
    }
}