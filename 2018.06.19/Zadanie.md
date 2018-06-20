1. Dopisać zawartość metody IsLengthOk_OkPasswords_ShouldReturnOk()
2. Napisać metodę IsDigitsOk_1Digit_ShouldThrowException
3. Napisać metodę IsDigitsOk_0Digit_ShouldThrowException - powinno rzucić Application Exception dla stirnga bez cyfr (ie. "xx")
4. Napisać metodę, która sprawdzi 2..20 cyfr - nie powinno rzucić wyjątku: IsDigitsOk_20Digits_ShouldBeOk 


for (var i = 2; i < 20; i++) 
{
    var stringWithNDigits = string.Join(
                "", 
                Enumerable.Range(0, i).Select(j => 5));
}

// 55
// 555
// 5555
...
// 55555555555555555555  (20)

----------------------

To ozancza, że ktoś nie zresolvovał conflictu poprawnie!

>>>>>>>>>>>>

<<<<<<<<<<<<


----------------------

Assert.IsTrue(expr); == Assert.AreEqual(true, expr)
Assert.IsFalse(expr);
Assert.AreEqual(2, 3);  // Nie są
Assert.AreEqual("ALAMA", "KOTA") // też nie są
Assert.AreEqual(1.00000001, 1.0000003, 0.000000000000000005); // false

Assert.Catch(() => sut.IsPasswordValid("xx"));
Assert.Throws<ApplicationException>(() => sut.IsPasswordValid("xx"));  // Zadziała bo rzucamy ApplicationException
Assert.Throws<Exception>(() => sut.IsPasswordValid("xx"));  // Nie zadziała bo rzucamy ApplicationException

async await - funkcje asynchroniczne w C#

