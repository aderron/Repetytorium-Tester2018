// Copyright 2018 by Agnieszka Tarkowska

1.    Po co coś testujemy? Jakie są cele testowania?
		- odpowiedź cyniczna - dla pieniążków
		- chcemy zredukować straty firmy
		- żeby zapewnić jak najlepszą jakość produktu
		- w ekstremalnych sytuacjach - żeby zapobiec utracie życia lub zdrowia

2.    Jakie są poziomy testowania?
		- modułowe/jednostkowe
		- integracyjne
		- systemowe
		- akceptacyjne
		
3.    Czym się różni weryfikacja od walidacji?
		- Weryfikacja - sprawdzamy czy wymagania są spełnione, czy coś działa (np. czy defekt został naprawiony)
		- Walidacja - sprawdzamy, czy coś jest poprawne. W skrócie - testowanie.

4.    Wyjaśnić na przykładzie, na czym polegają poszczególne poziomy testowania.

5.    Wymienić kilka komend w konsoli. (jakiej?)
		- **mkdir** - win/linux
		- **git push**
		- **exit**
		- **ipconfig** (win) - - ifconflict (linux)
		- **nuget** (VisualStudio) - **apt-get** (linux) -> menadżery pakietów (**yarn**, **npm**)
		- **mount** (linux) -> do montowania dysków twardych
		- **cd** (change directory)
		- **sudo** (linux) -> wykonuje polecenie z uprawnieniami admina
		- **su** (linux) - switch user -> pozwala na zmianę na dowolnego użytkownika

6.    Kilka zadań odnośnie testowania – wymienić przypadki testowe podczas testowania 
      aplikacji/ strony typu filmweb, logowania się na stronę czy użycia pendrive 
      (od strony użytkownika, administratora, baz danych) – dość długo drążony temat
	  NA GŁOS:
	  1. zdefiniować aktorów
	  2. wymagania
	  3. use casy (co można z tym zrobić)
	  4. robienie testów
	  
	  - filmweb
		- od strony użytkownika (aktor) -> np. użytkownik 
			- wyszukiwanie filmów 
			- przeglądanie katalogów
			- recenzja filmów
			- dodawanie komentarzy
		- od strony admina (aktor)
			- zablokowanie użytkownika
			- nadanie uprawnień moderatora
		- od strony moderatora (aktor)(może dużo, ale nie ma uprawnień admina)
			- dodawanie/usuwanie filmów
			- usuwanie postów/komentarzy
			- ostrzeżenia dla użytkowników
			- powinien móc robić to co zwykły użytkownik
			
	- pendrive
		- podłączenie pendriva
		- uzyskanie dostępu do urządzenia przez system
		- system określa czy użytkownik ma uprawnienia do przeglądania zawartości pendriva
		- użytkownik może przeglądać zawartość, dodawać, usuwać
		
	- kubek
		aktorzy: operator kubka, użytkownik kubka
		- kto będzie użytkownikiem kubka? jakie są dla niego wymagania?
		/jak nie ma wymagań, to możemy założyć że ma to być kubek dla obcych pijących przez odbyt/
		- z jakiego materiału, czy nie ma ostrych krawędzi, czy nie ma sznurka (xd)
		- use case: rzucić kubkiem, wlać wodę, dziecko może kubek gryźć, czy da się łatwo odkręcić, 
			czy instrukcja jest jasna
			
	- samochód
		rodzinny, dla 4 osób
		- sprawdź, czy 4 osoby się zmieszczą i czują się komfortowo
		- sprawdź, czy jeździ

	- krzesło
		dla dorosłych
		- jaką wagę ma krzesło
		- jaka wytrzymałość wagowa
		- czy da się siedzieć
		- czy da się przesunąć
	

7.    Napisać program na tablicy w dowolnym języku programowania: użytkownik wprowadza dwie dowolne liczby, odczytujemy je (np. w Java użyć odczytywania Scanner – wymagane było to), napisać program, który będzie zwracał wynik mnożenia tych liczb bez używania znaku mnożenia * -> dodawanie w pętli (trzeba było napisać pełen kod w danym języku na tablicy).
	  
    Main
    {
        var suma = 0;
        var a = ConsoleReadLine();
        var b = ConsoleReadLine();
        var l1=int.Parse(a));
        var l2=int.Parse(b));
        
                        if (l1==0)(l2==0) 			| ta część jest niekonieczna
                        {							|
                            console.WriteLine(suma);	|
                        }							|
        for (var i=0; i<a; i++)
        {
            suma = suma+l2;
        }
        console. WriteLine(suma);
    }
	
		
Lub

    Main
    {
        var suma = 0;
        var a = int.Parse(Console.ReadLine());
        var b = int.Parse(Console.ReadLine());
        
        if (a==0 | b==0)
        {
            console.WriteLine(suma);
        }
        
        for (var i=0; i<a; i++)
        {
            suma = suma+a;
        }

        console.WriteLine(suma)
    }


8.    Czy znam system Linux
		- zainstalowaliśmy liveCD na kompie, Ubuntu, z tego roku, nie wiem jaki kernel xd
		- znamy uprawnienia plików na linuxie
		- tworzyliśmy klucz dla gita
		- używaliśmy basha
		- jeśli jest potrzeba to mogę pracować na linuxa

9.	  programowanie obiektowe.
		-  Programowałam na kursie, znam podstawy C# 
		Wiem co to jest, ale nie uznałabym  że to potrafię - nie zasługuję nawet na miano juniora w tym temacie xd

10.    Jak sobie poradzę, gdy komputer się rozwali (czarny ekran), itp.
		- najczęściej psują się częśći, które najwięcej pracują -> kable
		- można zrestartować komputer 
			(jedno BIP od biosa oznaczało, że wszystko działa, 
			więcej BIPów oznaczało że coś nie działa z płytą główną lub innymi komponentami,
			jak w ogóle nie BIPał to w ogóle masakra)
		- możemy podłączyć ekran (myszkę, klawiaturę, coś na USB) do innego komputera (portu) 
			albo inny ekran (urządzenie) podłączyć do naszego kompa
	

11.    Jak sobie poradzę, gdy jest problem z Internetem – różne przypadki.
		- sprawdzić CO nie działa
			- strona internetowa (wpisać w CMD ping 8.8.8.8 -t ENTER. Plus ping 9.9.9.9 -t lub 1.1.1.1 -t)
			- można w CMD wpisać też spingować nasze IP (jeśli się nie da, to problem jest między kompem a routerem. 
			jeśli da się - to problem jest między routerem a dostawcą internetu)
		- reset routera 

12.    Jak połączyć się zdalnie z innym komputerem, jakie znam możliwości.
		- zdalny pulpit (TeamViewer, Remote Desktop Connection)
		- PuTTy / SSH / Telnet (jak usłyszą Telnet, to mogą się uśmiać)