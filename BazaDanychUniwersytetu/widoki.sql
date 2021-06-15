DROP VIEW STYPENDYSCI ;
CREATE VIEW Stypendysci AS SELECT s.imie , s.nazwisko , s2.srednia , s2.kwota, s2.decyzja FROM  STUDENCI s  JOIN STYPENDIA s2 ON 
s2.ID_STYPENDIUM = s.ID_STYPENDIUM WHERE s2.decyzja LIKE 'przyznano';

SELECT * FROM Stypendysci;

DROP VIEW WYPOZYCZENIA ;
CREATE VIEW Wypozyczenia AS SELECT s.imie , s.nazwisko , b.ilosc_wypo¿_ksi¹¿, b.termin_oddania FROM  studenci s JOIN biblioteka b ON 
b.ID_WYPOZYCZENIA = s.ID_WYPOZYCZENIA ;

SELECT*FROM Wypozyczenia;

DROP VIEW kursanci;
CREATE VIEW kursanci AS SELECT s.imie , s.nazwisko ,nazwa_kursu, NAZWISKO_WYKLADOWCY FROM STUDENCI s JOIN STUDENCI_KURSY sk ON s.ID_STUDENTA = sk.ID_STUDENTA JOIN (SELECT k.nazwa AS nazwa_kursu, w.nazwisko AS nazwisko_wykladowcy, k.ID_KURSU AS id_kursu FROM KURSY k JOIN WYKLADOWCY_KURSY wk ON k.ID_KURSU = wk.ID_KURSU JOIN wykladowcy w ON w.ID_WYKLADOWCY = wk.ID_WYKLADOWCY ) wykurs ON  wykurs.id_kursu=sk.ID_KURSU ORDER BY NAZWISKO_WYKLADOWCY ;

SELECT * FROM kursanci;


DROP VIEW plan_zajec;
CREATE VIEW plan_zajec as SELECT g.nazwa AS grupa,p.nazwa AS nazwa_przedmiotu,sala,h.dzien_tygodnia, h.tydzien  FROM HARMONOGRAMY h JOIN PRZEDMIOTY p  ON h.ID_PRZEDMIOTU = p.ID_PRZEDMIOTU JOIN GRUPY g ON h.ID_GRUPY = g.ID_GRUPY order BY g.nazwa ;

SELECT * FROM plan_zajec;

DROP VIEW ZAJECIA_WYKLADOWCOW ;
CREATE VIEW zajecia_wykladowcow AS SELECT w.imie, w.nazwisko, p.nazwa AS nazwa_przedmiotu, p.rodzaj, p.ile_godzin FROM WYKLADOWCY w JOIN  HARMONOGRAMY h ON h.ID_WYKLADOWCY = w.ID_WYKLADOWCY JOIN PRZEDMIOTY p ON 
p.ID_PRZEDMIOTU = h.ID_PRZEDMIOTU ORDER BY nazwisko;

SELECT * FROM zajecia_wykladowcow;

DROP VIEW KIERUNKI_GRUPY ;
CREATE VIEW kierunki_grupy AS SELECT k.nazwa AS nazwa_kierunku , k.wydzial , k.budynek , g.nazwa AS nazwa_grupy FROM KIERUNKI k JOIN GRUPY g ON k.ID_KIERUNKU =g.ID_KIERUNKU ORDER BY k.nazwa;

SELECT*FROM kierunki_grupy;