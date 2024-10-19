class Pair<K, V> {
    public K First;
    public V Second;
    public Pair(K first, V second)
    {
        this.first = first;
        this.second = second;
    }
}
class Program {
    public static void Main(string[] args){
        var pair = new Pair<string, string>("Hello", "World");
    }
}
