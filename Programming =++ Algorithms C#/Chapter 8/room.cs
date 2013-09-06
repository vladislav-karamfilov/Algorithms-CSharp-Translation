using System;
class Program
{ const int MAXN = 5000;  /* Максимален брой заявки */
  const int MAXD = 365;  /* Максимален брой дни */
  
  struct TZ 
  { 
      public int b;
      public int e; 
  }
  
  struct BlueRed
  { 
      public int CntBlue { get; set; }
      public int CntRed { get; set; }
  } 
  
  static BlueRed[] B = new BlueRed[MAXD+1];
  static BlueRed[] R = new BlueRed[MAXD+1];
  
  const int n = 2; /* Брой сини заявки */
  const int m = 4; /* Брой червени заявки */
  static TZ[] blueOrders = new TZ[] { new TZ { b = 1, e = 5 }, new TZ { b = 12, e = 20} };
  static TZ[] redOrders = new TZ[] { new TZ { b = 2, e = 10}, new TZ { b = 6, e = 11}, 
                            new TZ { b = 15, e = 25}, new TZ { b = 26, e = 30} };
  
  /* Решава задачата с динамично оптимиране */
  static void SolveDynamic()
  { int d, bb, be, blueIndex, redIndex;
    /* Инициализация */
    B[0].CntBlue = B[0].CntRed = R[0].CntBlue = R[0].CntRed = 0; 
    blueIndex = redIndex = 1;
    /* Пресмятане на B[1..MAXD], R[1..MAXD] */
    for (d = 1; d <= MAXD; d++) {
      /* Пресмятане на B[d] */
      B[d] = B[d - 1];
      for (blueIndex = 0; blueIndex < n; blueIndex++) {
        if (blueOrders[blueIndex].e > d)
          break;
        else {
          bb = blueOrders[blueIndex].b;
          be = blueOrders[blueIndex].e;
          if (R[bb-1].CntBlue + R[bb-1].CntRed + (be-bb+1) > B[d].CntBlue + B[d].CntRed) {
            B[d].CntBlue = R[bb - 1].CntBlue + (be - bb + 1);
            B[d].CntRed = R[bb - 1].CntRed + 0;
          }
        }
      }
      /* Пресмятане на R[d]: аналогично на B[d] */
      R[d] = R[d - 1];
      for (redIndex = 0; redIndex < m; redIndex++) {
        if (redOrders[redIndex].e > d)
          break;
        else {
          bb = redOrders[redIndex].b;
          be = redOrders[redIndex].e;
          if (B[bb-1].CntBlue + B[bb-1].CntRed + (be-bb+1) > R[d].CntBlue + R[d].CntRed) {
            R[d].CntBlue = B[bb - 1].CntBlue;
            R[d].CntRed = B[bb - 1].CntRed + (be - bb + 1);
          }
        }
      }
    }
  }
  
  /* Извежда резултата на екрана */
  static void PrintResult()
  { if (B[MAXD].CntBlue + B[MAXD].CntRed > R[MAXD].CntBlue + R[MAXD].CntRed) {
      Console.WriteLine("Заетост на залата (дни): {0}", B[MAXD].CntBlue + B[MAXD].CntRed);
      Console.WriteLine("Брой дни за червените: {0}", B[MAXD].CntRed);
      Console.WriteLine("Брой дни за сините: {0}", B[MAXD].CntBlue);
    }
    else {
      Console.WriteLine("Заетост на залата (дни): {0}", R[MAXD].CntBlue + R[MAXD].CntRed);
      Console.WriteLine("Брой дни за червените: {0}", R[MAXD].CntRed);
      Console.WriteLine("Брой дни за сините: {0}", R[MAXD].CntBlue);
    }
  }
  
  static void Main() {
    Array.Sort(blueOrders, (rb1, rb2) => rb1.e.CompareTo(rb2.e));
    Array.Sort(redOrders, (rb1, rb2) => rb1.e.CompareTo(rb2.e));
    SolveDynamic();
    PrintResult();
  }
}
