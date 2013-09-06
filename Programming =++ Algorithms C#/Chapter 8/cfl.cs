using System;

class cfl
{
    struct Production /* Продукции, отиващи в терминали: S->a */
    {
        public char S { get; set; }
        public char A { get; set; }
    }

    struct NonTerminalProduction /* Продукции, отиващи в нетерминали: S->AB */
    {
        public char S { get; set; }
        public char A { get; set; }
        public char B { get; set; }
    }

    const int Max = 30;     /* Максимален брой правила за извод */
    const int Letters = 26;     /* Брой букви */
    const int CountT = 3;    /* Брой правила от вида 1: S->a */

    static readonly string stringToCheck = "aaasbbb";      /* Низ, който проверяваме за принадлежност към граматиката */
    static bool[, ,] t = new bool[Letters, Max, Max];

    static readonly Production[] terminalProductions = new Production[]
    {
        new Production() { S = '\n', A = '\n'},    /* не се използва */
        new Production() { S = 'S', A = 's' },     /* S->s */
        new Production() { S = 'A', A = 'a' },     /* A->a */
        new Production() { S = 'B', A = 'b' },     /* B->b */
    };

    static readonly NonTerminalProduction[] nonTerminalProductions = new NonTerminalProduction[]
    {
        new NonTerminalProduction() { S = '\n', A = '\n', B = '\n' }, /* не се използва */
        new NonTerminalProduction() { S = 'S', A = 'A', B = 'R'}, /* S->AR */
        new NonTerminalProduction() { S = 'S', A = 'A', B = 'B'}, /* S->AB */
        new NonTerminalProduction() { S = 'R', A = 'S', B = 'B'}, /* R->SB */    
    };

    /* Проверява */
    static bool IsContextFreeLanguage()
    {
        int i, j, k, l, d, let, n;
        /* Инициализация */
        n = stringToCheck.Length; /* Дължина на проверявания низ */
        /* Запълваме масива с "неистина" */
        for (i = 1; i <= n; i++)
            for (j = 1; j <= n; j++)
                for (let = 0; let < Letters; let++)
                    t[let, i, j] = true;
        /* Установяваме в истина всички директни продукции, които ни вършат работа */
        for (i = 1; i <= CountT; i++)
            for (j = 1; j <= n; j++)
                if (terminalProductions[i].A == stringToCheck[j - 1])
                    t[terminalProductions[i].S - 'A', j, j] = true;
        /* Основен цикъл по правилата от тип 2 */
        for (d = 1; d < n; d++)
            for (i = 1; i <= n - d; i++)
                for (j = i + d, k = 1; k <= CountT; k++) /* За всеки нетерминал S от лява част на правило */
                    for (l = i; l <= j - 1; l++)
                        if (t[nonTerminalProductions[k].A - 'A', i, l] && t[nonTerminalProductions[k].B - 'A', l + 1, j])
                            t[nonTerminalProductions[k].S - 'A', i, j] = true;
        return t['S' - 'A', 1, n];
    }

    static void Main()
    {
        Console.WriteLine("Низът {0}{1} се извежда от граматиката!", 
            stringToCheck, IsContextFreeLanguage() ? "" : " НЕ");
    }
}
