This is homework that you're supposed to do over the weekend!! :(((

1. Finish reading chapter 1 and chapter 2 (in polish) of ISTQB Foundation Syllabus (Link in ISTQB section)
2. Bugi, will prepare Glossary entries for it (with polish descriptions)
3. YOU WILL show me your solutions (might not be working) for ProjectEuler problems Largest prime factor (https://projecteuler.net/problem=3) and Largest palindrome product (https://projecteuler.net/problem=4)
4. Think about Defects that you can find for PasswordValidator
5. Programing courses. Please... Write tests that check how each of those operatotrs work!. You need to know this:

    * Value types:
        * bool (1 bit == true/false), 
        * sbyte/byte (8 bits == 1 byte == 256)
        * short/ushort (16 bits == 2 bytes == 65536)
        * int/uint (32 bits == 4 bytes) 
        * long/ulong (64 bits == 8 bytes)
        * char
        * float (32 bits == 4 bytes)
        * double (64 bits == 8 bytes)
        * decimal (128 bits == 16 bytes)
        * string
        * enum
    * Reference types:
        * int[] - array of ints
        * char[] - arracy of chars
        * IEnumerable\<T> - Enumerable of T
        * ICollection\<T> - Collection of T
        * IList\<T> - List of T

    * Operators: 
        * =
        * ==
        * !=
        * <= 
        * <
        * \>
        * \>=
        * \*
        * ^
        * &
        * &&
        * |
        * +=
        * -=
        * *=
        * /=
        * &=
        * |=
        * ++i
        * i++

    * Commnads/Keywords:
        * if..else if..else
        * for, 
        * foreach, 
        * while.., 
        * switch..case, 
        * do..while

    * LINQ (optional)
        * .Where(a => isOdd(a)) - filtruje kolkcje przy p omocy predykatu  (czy nieprzyste)
        * .Select(a => b) - konwertuje koleckję z a na b
        * .Sum(a => isOdd(a)) - sumuje te któe spełniają predykat (nieparzyste), 
        * .Count()- liczy te któe spełniają predykat (nieparzyste)
        * .First() - zwraca pierwszy, który spełnina predykat, 
        * .Last() - zwraca ostatni który z wraca predykat 
        * .Single()- zwraca jedyny element który spełnia predykat albo rzuca exception
        * .GroupBy(p => p.Age) - grupuje elementy po predykacie 
        * .OrderBy(p => p.Age) - sortuje kolekcje po Age, (OrderByDescending)
        * .ToList() - twory listę z wyrażenia, które wpisaliśmy wcześniej (.ToArray())

## Example 1

    var Names = new List<string>() { "Ania", "Kamil", "Jezus" }; // Lista 3 imion
    Names.Add("Tolek");     // Dodajemy Tolka
    Names.Remove("Kamil");  // Usuwamy Kamila (może nie istnieć na liście)
    foreach (var name in Names.Where(name => name != "Ania")) 
    {
        // Ta pętla wykona się 2 razy (Jezus, Tolek)
    }

## Example 2
    var i = 3;
    console.writeline(++i);  // 4
    // i == 4

    var i = 3
    console.writeLine(i++);  // 3
    // i == 4;

## Example 3
    // TO JEST ZŁO
    if (a = b)
    {
        // Zawsze się wykona!!!!
    }
