using UnityEngine;

public class DrawVerticalLines : MonoBehaviour
{
    public int lineCount = 10;  // 你想要画的线的数量
    public float lineWidth = 2; // 线的宽度
    public Color lineColor = Color.white; // 线的颜色

    private void OnGUI()
    {
        // 获取屏幕的宽度并除以线的数量，以得到每条线之间的间隔
        float gap = Screen.width / (float)lineCount;

        for (int i = 0; i < lineCount; i++)
        {
            // 计算每条线的起点和终点的位置
            float x = gap * i;

            // 设置线的颜色
            GUI.color = lineColor;

            // 绘制线
            GUI.DrawTexture(new Rect(x, 0, lineWidth, Screen.height), Texture2D.whiteTexture);
        }
    }
}