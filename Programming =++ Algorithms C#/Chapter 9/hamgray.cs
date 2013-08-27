void Print(int[] a)
{ Console.WriteLine(string.Join(" ", a.Skip(1)));
}

void Backgray(int[] a, int k)
{ if (k == 0) { Print(a); return; }
  a[k] = 1;  Forwgray(a, k - 1);
  a[k] = 0;  Backgray(a, k - 1);
}

void Forwgray(int[] a, int k)
{ if (k == 0) {  Print(a); return; }
  a[k] = 0;  Forwgray(a, k - 1);
  a[k] = 1;  Backgray(a, k - 1);
}

void Main() {
  /* код на Грей, Хамилтонов цикъл в n-мерен двоичен куб (Хиперкуб) */
  const int DIMENSIONS = 3;
  int[] a = new int[DIMENSIONS + 1];
  Forwgray(a, DIMENSIONS);
}
