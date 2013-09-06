const int MAX = 100;
const int MAX2 = MAX * (MAX + 1) / 2;

static int[] p = new int[MAX2];         /* Минимална цена за достигане на възел I */
static int[] pred = new int[MAX2];      /* Предшественик на възел I в мин. път */

/* Цени за преминаване през върховете */
static int[] v = {0,1,22,33,5,6,77,8,22,7,225,177,738,737,778,39,28,9,10,11,12,13};
const int n = 6;             /* Брой редове в триъгълника */

static void Compare(int ind1, int ind2)
{ if (p[ind1] > p[ind2] + v[ind1]) {
    p[ind1] = p[ind2] + v[ind1];
    pred[ind1] = ind2;
  }
}

/* Намира минималния път до всеки възел */
static void FindMinPath()
{ p[1] = v[1];
  int sum = 0;
  /* До първия връх се стига непосредствено */
  for (int i = 1; i <= n; i++) {
    for (int j = 1; j <= i; j++) {
      if (j > 1)
		Compare(sum + j + i - 1, sum + j);
      Compare(sum + j + i, sum + j);
      Compare(sum + j + i + 1, sum + j);
    }
    sum += i;
  }
}

/* Извежда триъгълника на минималните пътища на екрана */
static void Print(int[] m)
{ int sum = 0;
  for (int i = 1; i <= n; sum += i++) {
    for (int j = 1; j <= i; j++) 
	  Console.Write("{0,8}", m[sum + j]);
    Console.WriteLine();
  }
}

/* Извежда минималния път до върха x */
static void WritePath(int x)
{ Console.WriteLine("Пътят до връх номер {0} е минимален: {1}", x, p[x]);
  Console.Write("Пътят, изведен в обратен ред (индекси): ");
  while (x != 1) {
    Console.Write("{0} ", x);
    x = pred[x];
  }
  Console.Write("1");
}

/* Намира връх от последния ред с минимален път */
static void FindMinLastRow()
{ int minInd, end = n * (n + 1) / 2;
  for (int i = 1 + (minInd = end-n+1); i <= end; i++)
    if (p[i] < p[minInd])
	  minInd = i;
  WritePath(minInd);
}

static void Main() {
  Array.Resize(ref v, MAX2);
  for (int i = 0; i < (n + 3)*(n + 2)/2; i++)
	p[i] = int.MaxValue;
  Console.WriteLine("Изходен триъгълник:"); Print(v);
  FindMinPath();
  Console.WriteLine("Триъгълник на минималните пътища: "); Print(p);
  FindMinLastRow();
}