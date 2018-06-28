// Copyright 2018 by Agnieszka Tarkowska

1. Co to jest TCP/IP?
    Transfer Control Protocol/Internet Protocol - protokół komunikacyjny używany w internecie. Do kontroli transmisji danych. 

2. Co to jest WebService?
	usługa na stronie internetowej (zwykle API (Application Programming Interface))

3. Czym się różni SOAP od REST?
	Są to protokoły komunikacji.
	https://kobietydokodu.pl/22-web-services/

4. Co to jest Continous Integration i Continous Deployment?

	Continuous Integration - budowanie i testowanie po każdej zmianie. 
							 Każdy commit jest integrowany (np. TeamCity)
							 
	Continuous Deployment - automatyzacja procesu wdrażania (np. Octopus)
							dużo tańsze oprogramowanie (w stosunku do ncruncha)

5. Co to jest API?
	Application Programming Interface - interfejs programowania aplikacji. Zestaw reguł i opisów, w jaki programy komputerowe komunikują się między sobą.

6. Co to jest serwer?
	Komputer, do którego inne komputery łączą się w jakimś celu.

7. Co to jest SQL?
	Język zapytań strukturalnych.
	Używany do tworzenia, modyfikowania oraz do umieszczania i wyciągania danych z baz danych

8. Co to jest transakcja w bazie danych?
	Zbiór operacji na bazie danych, które stanowią w istocie pewną całość i jako takie powinny być wykonane wszystkie lub żadna z nich
	Atomowość - transakcja może być albo wykonana w całości albo wcale.

9. Co to jest LEFT JOIN i podaj przykład użycia.
	Połącz wiersze z prawej i lewej tablicy, zachowując wszystkie wiersze z lewej.

10. Co to jest indeks w bazie danych?
	Umożliwia szybsze wyszukiwanie obiektów.

11. Czy stosowanie indeksu to zawsze dobra decyzja?
	To zależy. Jeśli nie potrzebujemy wyszukiwania danych to nie.
	Przy dużej ilości indeksów wstawianie jest wolne, ale czytanie szybkie.

12. Co to jest HTTP?
	Protokół przesyłania dokumentów hipertekstowych.
	Umożliwia nam oglądanie stron internetowych w przeglądarkach.
			Inne protokoły: https, SSH, Telnet, ftp, ftps, sftp, SMD, Torrent, TCP/IP, IRC, POP3, IMTP, 
			(Slack to taki IRC po http)
			//Jeśli ktoś powie TELNET to możemy się z niego śmiać (bo telnet nie ma szyfrowania w ogóle!!!!)//

13. Jakie są metody HTTP?
	- **GET** – pobranie zasobu wskazanego przez URI, może mieć postać warunkową jeśli w nagłówku występują pola warunkowe takie jak "If-Modified-Since"
	- **PUT** – przyjęcie danych przesyłanych od klienta do serwera, najczęściej aby zaktualizować wartość encji
	- **POST** – przyjęcie danych przesyłanych od klienta do serwera (np. wysyłanie zawartości formularzy)
	- **DELETE** – żądanie usunięcia zasobu, włączone dla uprawnionych użytkowników
    - **PATCH** – aktualizacja części danych
	----
	- OPTIONS – informacje o opcjach i wymaganiach istniejących w kanale komunikacyjnym
	- TRACE – diagnostyka, analiza kanału komunikacyjnego
	- CONNECT – żądanie przeznaczone dla serwerów pośredniczących pełniących funkcje tunelowania
	- HEAD – pobiera informacje o zasobie, stosowane do sprawdzania dostępności zasobu

14. Czym się różni POST od PUT?
	to zależy od aplikacji.
	Jedno robi create a drugie update -> zgadnijcie se które.

15. Czym się różni POST od GET?
	- GET - tylko ściąga, nie może mieć zawartości
	- POST - może mieć wysłany content

16. Co to jest dziedziczenie?
	Klasy mogą po sobie dziedziczyć - dziedzicząca klasa dostaje od parenta(?) wszystko poza tym, co jest oznaczone jako **private**

17. Co to jest polimorfizm?   ===> WAŻNE, DOUCZYĆ SIĘ NIEUKI.
	Wielopostaciowość.
	- Paradygmat programowania obiektowego.
    - Maciek jest IPerson (czyli maciek jednocześnie może (i musi) robic wszystko to co IPerson oraz wszystko to co robi Maciek)

18. Czym się różni klasa od instancji?
	Mein Kampf to klasa, Hitler to obiekt (instancja). Klasa to blueprint (plan) a samolot obiekt (ucieleśnienie)

19. Czym się różni klasa abstrakcyjna od interfejsu?
	Klasa abstrakcyjna posiada implementację, przynajmniej częściową (ktoś napisał już kod).
	Interfejs - nie ma implementacji.

20. Czym się różni pętla WHILE od pętli DO-WHILE?
	WHILE - wykona się tyle razy, ile zakłada warunek (może to być 0)
	DO-WHILE - wykona się przynajmniej raz

21. Co to jest przeciążenie metody (OVERLOAD)?
	Metoda ma wiele implementacji w zależności od parametrów jakie przymuje (np. AreEqual(bool, bool), AreEqual(string, strong), AreEqual(int, int)...).

22. Co do jest nadpisanie metody (OVERRIDE)?
	Nadpisanie metody już zaimplementowanej przez klasę po której dziedziczymy
    - override - ok, implementujemy metodę z klasy abstrakcyjnej, lub nadpisujemy metodę wirtualną (virtual)
    - new - public **new** string ToString() - rzadko używane w praktyce, wskazuje na błąd architektoniczny (jest fuj)
    

23. Co to jest konstruktor?
	Metoda wywołana, gdy tworzymy obiekt. Konstruktor obiektu.

24. Co to jest algorytm?
	Sposób na rozwiązanie danego zadania.

25. Co to jest złożoność obliczeniowa?
	Ilość zasobów komputerowych (cykli procesora) koniecznych do wykonania programu realizującego algorytm

26. Co to jest XML?
	Uniwersalny język znaczników przeznaczony do reprezentowania różnych danych w strukturalizowany sposób.

27. Co to jest XPATH?
	Język ścieżek XML.
	Język służący do adresowania części dokumentu XML.

28. Jak w systemie unixowym/Linux
    * przejść do katalogu wyżej?
	    * cd .. -> "ce de spacja kropka kropka" xd
	    //NIE MÓWIĆ, ŻE UNIX TO LINUX, BO SPŁONIEMY NA STOSIE.
    * wyświetlić zawartość folderu?
	    * ls (skrót od LIST)
    * wyświetlić na ekranie zawartość pliku?
	    * cat *file*
    * stworzyć plik
        * touch *file*
    * edytować plik
        W kolejności pożądalności
        * mcedit *file*  (jeśli jest MidnightCommander - mc zainstalowany)
        * nano *file*
        * vim *file*
        * vi *file*

