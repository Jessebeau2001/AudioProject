public static class Utils
{
    public static double RandomDouble(double min, double max) {
        System.Random rnd = new System.Random();
        return rnd.NextDouble() * (max - min) + min;
    }
}