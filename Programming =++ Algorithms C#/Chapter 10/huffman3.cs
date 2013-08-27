class Tree
{
    public char Char { get; set; }  /* Символ (буква) */
    public int Weight { get; set; }/* Общо тегло на дървото */
    public Tree Left { get; set; } /* Ляв и десен наследници */
    public Tree Right { get; set; }
}
 
class HeapForest
{
    readonly List<Tree> list = new List<Tree>();
    
    public T GetMin() {
        var first = list[0];
        list[0] = list[list.Length - 1];
        list.RemoveAt(list.Length - 1)
        SiftDown(0);
        return first;
    }
    
    public void Add(T elem) {
        list.Add(elem);
        SiftUp(list.Length - 1);
    }
    
    void SiftUp(int index) {
        int parent = index / 2 - 1 + (index % 2);
        if (parent < 0) return;
        if (list[parent].Weight < list[index].Weight) return;
        T temp = list[index];
        list[index] = list[parent];
        list[parent] = temp;
        SiftUp(parent);
    }
    
    void SiftDown(int index) {
        int minChild = MinChild(index);
        if (minChild == -1) return;
        T temp = list[index];
        list[index] = list[minChild];
        list[minChild] = temp;
        SiftDown(minChild);
    }
    
    int MinChild(int index) {
        int left = index * 2 + 1;
        if (left >= list.Length) return -1;
        if (left == list.Length - 1 ||
            list[left].Weight <= list[left + 1].Weight) 
            return left;
        return left + 1;
    }
    
} 
 
Tree Huffman(string msg)
{ /* Построяване на таблица на честотите на срещане */
  Dictionary<char,int> freqs = msg.GroupBy(ch => ch)
                                  .ToDictionary(g => g.Key, g => g.Count());
  
  var forest = new HeapForest();                                           /* <-- */
  /* За всеки символ с ненулева честота на срещане се създава тривиално дърво */
  foreach(var ch in freqs.Keys.OrderBy(ch => ch)) {                        
      forest.Add(new Tree { Char = ch, Weight = freqs[ch] });
  }

  while (forest.Count > 1) {
    Tree minTree1 = forest.ChopMin(); /* Намиране на двата най-редки върха */
    Tree minTree2 = forest.ChopMin();

    /* Създаване на нов възел - обединение на двата най-редки */           
    var tree = new Tree { Left = minTree1, Right = minTree2,
                          Weight = forest[i].Weight + forest[j].Weight };  /* <-- */
    forest.Add(tree);
  }
  return forest.GetMin();
}

void PrintTree(Tree tree, int h = 0) /* Извежда дървото на екрана */
{ if (tree != null) {
    PrintTree(tree.Left,h+1);
    Console.Write(new string(' ', 4*h));
    Console.Write(" -- ");
    if (tree.Left == null)
      Console.Write(" {0}",tree.Char);
    Console.WriteLine();
    PrintTree(tree.Right,h+1); }
}

void WriteCodes(Tree tree, StringBuilder code) /* Извежда кодовете */
{ if (tree != null) {
    code.Append('0'); 
    WriteCodes(tree.Left, code);
    code.Remove(code.Length-1, 1);
    if (tree.Left == null) {/* Всеки връх на Хъфм. дърво има 0 или 2 наследника */
      Console.WriteLine("{0} = {1}", tree.Char, code);
    }
    code.Append('1');
    WriteCodes(tree.Right, code);
    code.Remove(code.Length-1, 1);
  }
}

void Main() {
  const string msg = "afbabcdefacbabcdecde";
  var tree = Huffman(msg);
  Console.WriteLine("Дърво на Хъфман за {0}:", msg);
  PrintTree(tree);
  WriteCodes(tree, new StringBuilder());
}