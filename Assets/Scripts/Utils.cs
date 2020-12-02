public static class Utils
{
    public static double RandomDouble(double min, double max) {
        System.Random rnd = new System.Random();
        return rnd.NextDouble() * (max - min) + min;
    }

    public static T RandomArrayEntry<T>(T[] array) {
        System.Random rnd = new System.Random();
        var result = array[rnd.Next(array.Length)];
        return result;
    }
}