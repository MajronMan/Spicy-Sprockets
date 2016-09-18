using UnityEngine;

[System.Serializable]
public struct IntVector2
{
    public int x, y;

    public IntVector2(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public static IntVector2 operator + (IntVector2 a, IntVector2 b) {
        {
            a.x += b.x;
            a.y += b.y;
            return a;
        } }

    public static IntVector2 operator / (IntVector2 a, int b)
    {
        a.x /= b;
        a.y /= b;
        return a;
    }
}