namespace Assets.Scripts.Utils {
    [System.Serializable]
    public struct IntVector2 {
        //not even sure if we'll use it anyway
        public int X, Y;

        public IntVector2(int x, int y) {
            this.X = x;
            this.Y = y;
        }

        public static IntVector2 operator +(IntVector2 a, IntVector2 b) {
            {
                a.X += b.X;
                a.Y += b.Y;
                return a;
            }
        }

        public static IntVector2 operator /(IntVector2 a, int b) {
            a.X /= b;
            a.Y /= b;
            return a;
        }
    }
}