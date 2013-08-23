﻿#include <stdio.h>

/* Максимален брой върхове в графа */
#define MAXN 150

/* Брой върхове в графа */
const unsigned n = 10;
/* Матрица на теглата на графа */
int A[MAXN][MAXN] = {
  { 0, 23,  0, 0,  0,  0,  0,  8, 0,  0 },
  { 0,  0,  0, 3,  0,  0, 34,  0, 0,  0 },
  { 0,  0,  0, 0,  0,  0,  0, 25, 0,  0 },
  { 0,  0,  6, 0,  0,  0,  0,  0, 0,  0 },
  { 0,  0,  0, 0,  0, 10,  0,  0, 0,  0 },
  { 0,  0,  0, 0, 12,  0,  0,  0, 0,  0 },
  { 0,  0,  0, 0,  0,  0,  0,  0, 0,  0 },
  { 0,  0, 25, 0,  0,  0,  0,  0, 0, 30 },
  { 0,  0,  0, 0,  0,  0,  0,  0, 0,  0 },
  { 0,  0,  0, 0,  0,  0,  0,  0, 0,  0 }
};

const int MAX_VALUE = 10000;

/* Намира дължината на минималния път между всяка двойка върхове */
void floyd(void)
{ unsigned i, j, k;
  /* стойностите 0 се променят на MAX_VALUE */
  for (i = 0; i < n; i++)
    for (j = 0; j < n; j++)
      if (0 == A[i][j]) A[i][j] = MAX_VALUE;
  /* Алгоритъм на Флойд */
  for (k = 0; k < n; k++)
    for (i = 0; i < n; i++)
      for (j = 0; j < n; j++)
        if (A[i][j] > (A[i][k] + A[k][j]))
          A[i][j] = A[i][k] + A[k][j];

  for (i = 0; i < n; i++) A[i][i] = 0;
}

void printMinPaths(void)
{ unsigned i, j;
  printf("Матрицата на теглата след изпълнението на алгоритъма на Флойд: \n");
  for (i = 0; i < n; i++) {
    for (j = 0; j < n; j++)
      printf("%3d ", (MAX_VALUE == A[i][j]) ? 0 : A[i][j]);
    printf("\n");
  }

}

int main(void) {
  floyd();
  printMinPaths();
  return 0;
}