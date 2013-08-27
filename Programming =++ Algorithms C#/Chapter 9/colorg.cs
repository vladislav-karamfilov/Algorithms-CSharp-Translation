/* върховете се разглеждат в произволен, а не сортиран по степента им ред */
int[] Solve1(int[,] A)
{ int[] colors = new int[A.GetLength(0)];
  for (int i = 0; i < A.GetLength(0); i++) { /* оцветява i-тия връх с най-малкият възможен цвят */
    
    int c = 0;
    bool flag;
    do {
      c++;
      flag = true;
      for (int j = 0; j < i; j++)
        if (A[i,j] == 1 && colors[j] == c) {
          flag = false;
          break;
        }
    } while (!flag);
    colors[i] = c;
  }
  return colors;
}

int[] Solve2(int[,] A)
{ int c = 0, cn = 0;
  int[] colors = new int[A.GetLength(0)];
  /* оцветява върхове само с първия цвят, докато е възможно, след това само с
   * втория и т.н., докато всички върхове бъдат оцветени
   */
  while (cn < A.GetLength(0)) {
    c++;
    for (int i = 0; i < A.GetLength(0); i++) {
      if (colors[i] == 0) {
        bool flag = true;
        for (int j = 0; j < A.GetLength(0); j++)
          if (A[i,j] == 1 && colors[j] == c) {
            flag = false;
            break;
          }
        if (flag) {
          colors[i] = c;
          cn++;
        }
      }
    }
  }
  return colors;
}


void ShowColor(int[] colors)
{ for (int i = 0; i < colors.Length; i++) Console.Write("{0}-{1}; ", i + 1, colors[i]);
  Console.WriteLine();
}

void Main() {
  int[,] A = {
    { 0, 1, 0, 0, 0, 0 },
    { 1, 0, 1, 0, 0, 1 },
    { 0, 1, 0, 0, 1, 0 },
    { 0, 0, 0, 0, 0, 1 },
    { 0, 0, 1, 0, 0, 0 },
    { 0, 1, 0, 1, 0, 0 }
  };
  Console.WriteLine("Оцветяване на върховете по алгоритъм 1:");
  int[] colors1 = Solve1(A);
  ShowColor(colors1);
  Console.WriteLine("Оцветяване на върховете по алгоритъм 2:");
  int[] colors2 = Solve2(A);
  ShowColor(colors2);
}
