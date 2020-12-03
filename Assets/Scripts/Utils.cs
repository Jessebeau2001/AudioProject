public static class Utils
{
    public static readonly System.Random rnd = new System.Random();

    public static double RandomDouble(double min, double max) {
        return rnd.NextDouble() * (max - min) + min;
    }

    public static T RandomArrayEntry<T>(T[] array) {
        var result = array[rnd.Next(array.Length)];
        return result;
    }
}