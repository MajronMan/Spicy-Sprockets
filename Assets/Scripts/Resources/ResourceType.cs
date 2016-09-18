namespace Assets.Scripts.Resources
{
    public static class ResourceType {

        public enum Type
        {
            Coal
        }

        public class Coal
        {
            public static int MassPerUnit = 2137;
            public static  int VolumePerUnit = 410;
            public static int DefaultCostPerUnit = 911;
            public static string Name = "Coal";
        }
    }
}
