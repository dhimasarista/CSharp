namespace Algorithms;

class Hashing
{
    public int GetHash(string key, int tableSize)
    {
        int hash = 0;
        foreach (char c in key)
        {
            hash = (hash * 31 + c) % tableSize;  // Menghasilkan hash sederhana
        }
        return hash;
    }
}