-----AKTUALIZACJA STYPENDIUM DLA SREDNIEJ Z PRZEDZIALU O PODANA KWOTE----
CREATE OR REPLACE PROCEDURE przydziel_stypendium(srednia_min NUMBER, srednia_maks NUMBER, nowa_kwota NUMBER) IS 
CURSOR daj_stypendium IS SELECT * FROM STYPENDIA FOR UPDATE;
BEGIN 
	dbms_output.put_line('Stypendia:');
FOR i IN daj_stypendium LOOP 
IF ((i.srednia>srednia_min) AND (i.srednia<srednia_maks)) THEN
dbms_output.put_line('Stypendium zaktualizowano dla œredniej równej ' || i.srednia);
UPDATE STYPENDIA s SET s.kwota = nowa_kwota
WHERE CURRENT OF DAJ_STYPENDIUM ;
END IF;
END LOOP;
END;
CALL DODAJ_STUDENTA("Anna", "Maj", 23, '97120845678','789432156' , :E_MAIL_DOD, :MIASTO_DOD, :ULICA_DOD, :NR_DOD, :INDEKS_DOD, :FORMA_STUDIOW_DOD, :DATA_ZAKONCZENIA_DOD, :ID_GRUPY_DOD, :ID_STYPENDIUM_DOD, :ID_WYPOZYCZENIA_DOD) 
-----WYSWIETLA LISTE OSOB W GRUPIE-----
create or replace PROCEDURE pokaz_grupy(grupa_do_pokazania varchar2) IS 
CURSOR wyswietl_osoby_z_grupy IS SELECT s.imie, s.nazwisko FROM studenci s JOIN grupy g ON s.ID_GRUPY =g.ID_GRUPY WHERE g.nazwa = grupa_do_pokazania;
BEGIN 
	DBMS_OUTPUT.PUT_LINE('W grupie ' || grupa_do_pokazania|| ' znajduj¹ siê nastpêpuj¹ce osoby: ');
	FOR i IN wyswietl_osoby_z_grupy LOOP 
	DBMS_OUTPUT.PUT_LINE(i.nazwisko || ' '|| i.imie);
END LOOP;
END;

-----ZMIANA GRUPY U STUDENTA-----
CREATE OR REPLACE PROCEDURE zmien_grupe(podaj_imie varchar2, podaj_nazwisko varchar2, podaj_stara_grupe varchar2, podaj_nowa_grupe varchar2) IS 
CURSOR daj_nowa_grupe IS SELECT * FROM studenci s,grupy g WHERE s.ID_GRUPY=g.ID_GRUPY;
BEGIN 
	DBMS_OUTPUT.PUT_LINE('Student '||podaj_imie||' ' ||podaj_nazwisko||' zmieni³ grupê z '|| podaj_stara_grupe ||' na '||podaj_nowa_grupe);
UPDATE studenci s SET s.ID_GRUPY =(SELECT g2.ID_GRUPY FROM grupy g2 WHERE g2.NAZWA = podaj_nowa_grupe) 
WHERE s.IMIE=podaj_imie AND s.NAZWISKO=podaj_nazwisko AND s.ID_GRUPY=(SELECT g3.id_grupy FROM grupy g3 WHERE g3.nazwa = podaj_stara_grupe);
END;

-----WYSWIETLA OSOBY KTORE NIE ODDALY KSIAZEK----
CREATE OR REPLACE PROCEDURE oddaj_ksiazke IS 
CURSOR czy_oddane_ksiazki IS SELECT imie, NAZWISKO, indeks, ID_WYPOZYCZENIA FROM studenci WHERE ID_WYPOZYCZENIA IS NOT NULL ;
wyjatek EXCEPTION;
BEGIN 
FOR i IN czy_oddane_ksiazki LOOP
	dbms_output.put_line('Student '||i.imie||' ' ||i.nazwisko||' o indeksie ' ||i.indeks||' nie odda³ ksi¹¿ek');
END LOOP;
END;