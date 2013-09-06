const int NOT_SOLVED = -1;
const int n = 9;         /* Брой матрици */
long m[n,n];    /* Таблица - целева функция */
static long r[n+1] = {12,13,35,3,34,2,21,10,21,6}; /* Размерности на матриците */

static long SolveMemo(int i, int j)
{ if (NOT_SOLVED != m[i,j]) /* Стойността вече е била пресметната */
    return m[i,j];
  if (i == j)                /* В този интервал няма матрица */
    m[i,j] = 0;
  else {                     /* Пресмятаме рекурсивно */
    for (int k = i; k <= j - 1; k++)
      long q = solveMemo(i, k) + solveMemo(k + 1, j) + r[i-1] * r[k] * r[j];
      if (q < m[i,j])
		m[i,j] = q;
  }
  return m[i,j];
}

static long SolveMemoization()
{ for (int i = 1; i <= n; i++)
    for (int j = i; j <= n; j++)
	  m[i,j] = NOT_SOLVED;
  return SolveMemo(1, n);
}

static void PrintMatrix() /* Извежда матрицата на минимумите на екрана */
{ Console.Write("Матрица на минимумите:");
  for (int i = 1; i <= n; i++) {
    for (int j = 1; j <= n; j++)
      Console.Write("{0,8}", m[i,j]);
    Console.WriteLine();
  }
}

static void Main() {
  Console.Write("Минималният брой умножения е: {0}", SolveMemoization());
  PrintMatrix();
}
