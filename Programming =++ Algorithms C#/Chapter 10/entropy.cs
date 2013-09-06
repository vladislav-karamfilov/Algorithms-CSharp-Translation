using System;
class Program
{ /* Пресмята ентропията на източника */
  static double CalcEntropy(double[] probs) 
  { double sum = 0;
    for (int i = 0; i < probs.Length; i++)
      sum -= probs[i]*Math.Log(probs[i], 2);
    return sum;
  }
  
  /* Пресмята цената на кода */
  static double CalcValue(double[] probs, int[] lengths)
  { // probs.Zip((lengths p,l) => p*l).Sum()
    double sum = 0;
    for (int i = 0; i < probs.Length; i++)
      sum += probs[i]*lengths[i];
    return sum;
  }
  
  /* Пресмята дължините на кодовете на отделните букви */
  static int[] CalcLengths(double[] probs)
  { // probs.Select(p => Math.Ceiling(Math.Log(1.0 / p, 2))).ToArray()
    int[] lengths = new int[probs.Length];
    for (int i = 0; i < probs.Length; i++)
      lengths[i] =(int) Math.Ceiling(Math.Log(1.0 / probs[i], 2));
    return lengths;
  }
  
  static void Main() {
    double[] probs = new[]{0.2, 0.2, 0.15, 0.15, 0.10, 0.10, 0.05, 0.05};
    
    Console.WriteLine("Източник, зададен с честоти на срещане: ");
    foreach (double prob in probs)
      Console.Write("{0:2} ", prob);
    Console.WriteLine();
  
    double entr = CalcEntropy(probs);
    Console.WriteLine("Ентропия на източника: {0:F8}", entr);
    Console.WriteLine("Теоретична цена на кода: {0:F8}", entr + 1);
    
    int[] lengths = CalcLengths(probs);
    Console.WriteLine("Дължини на кодовете: ");
    for (int i = 0; i < lengths.Length; i++)
      Console.WriteLine("{0} ", lengths[i]);
  
    Console.WriteLine("Цена на кода при горните дължини: {0:F2}", CalcValue(probs, lengths));
  }
}
