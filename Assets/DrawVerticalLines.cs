using UnityEngine;

public class DrawVerticalLines : MonoBehaviour
{
    public int lineCount = 10;  // ����Ҫ�����ߵ�����
    public float lineWidth = 2; // �ߵĿ��
    public Color lineColor = Color.white; // �ߵ���ɫ

    private void OnGUI()
    {
        // ��ȡ��Ļ�Ŀ�Ȳ������ߵ��������Եõ�ÿ����֮��ļ��
        float gap = Screen.width / (float)lineCount;

        for (int i = 0; i < lineCount; i++)
        {
            // ����ÿ���ߵ������յ��λ��
            float x = gap * i;

            // �����ߵ���ɫ
            GUI.color = lineColor;

            // ������
            GUI.DrawTexture(new Rect(x, 0, lineWidth, Screen.height), Texture2D.whiteTexture);
        }
    }
}