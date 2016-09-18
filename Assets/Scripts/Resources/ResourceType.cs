using UnityEngine;
using System.Collections;

public static class ResourceType {

    public enum Type
    {
        Coal
    }

    public class Coal
    {
        public static int massPerUnit = 2137;
        public static  int volumePerUnit = 410;
        public static int defaultCostPerUnit = 911;
        public static string name = "Coal";
    }
}
