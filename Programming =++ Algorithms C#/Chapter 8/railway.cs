using System;
class Program
{ long minPrice[n];  /* Минимална цена на билета от началната до текущата гара */
  
  static long[] dist = {0,3,7,8,13,15,23}; /* Разстояние от началната гара */
  const long l1 = 3,  l2 = 6,  l3 = 8,
                      c1 = 20, c2 = 30, c3 = 40;
  const int n = 7;
  const int end = 6;
  int start = 2;
  
  static long Calc(int cur)
  { int i;
    long price;
    if (minPrice[cur] == NOT_CALCULATED ) {
      /* Търсим най-лявата гара и пресмятаме евентуалната цена, ако вземем билет тип 1 */
      for (int i = cur - 1; i >= start && (dist[cur] - dist[i]) <= l1; i--);
      if (++i < cur)
        if ((price = calc(i) + c1) < minPrice[cur])
  		 minPrice[cur] = price;
      /* Търсим най-лявата гара и пресмятаме евентуалната цена, ако вземем билет тип 2 */
      for (; i >= start && (dist[cur] - dist[i]) <= l2; i--);
      if (++i < cur)
        if ((price = calc(i) + c2) < minPrice[cur]) minPrice[cur] = price;
      /* Търсим най-лявата гара и пресмятаме евентуалната цена, ако вземем билет тип 3 */
      for (; i >= start && (dist[cur] - dist[i]) <= l3; i--);
      if (++i < cur)
        if ((price = calc(i) + c3) < minPrice[cur]) minPrice[cur] = price;
    }
    return minPrice[cur];
  }
  
  static void Main() {
    /* Иницализация */
    for (int i = 0; i < start; i++)
  	minPrice[i] = 0;
    for (; i < n; i++)
  	minPrice[i] = NOT_CALCULATED;
    /* Решаване на задачата */
    start--;
    Console.WriteLine("Минимална цена: {0}", calc(end-1));
  }
}
