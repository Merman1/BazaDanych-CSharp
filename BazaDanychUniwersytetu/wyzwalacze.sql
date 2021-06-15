-----SPRAWDZA CZY PODANA SREDNIA JEST POPRAWNA-----
CREATE OR REPLACE TRIGGER CZY_DOBRA_SREDNIA
BEFORE INSERT OR UPDATE OF SREDNIA ON STYPENDIA
FOR EACH ROW WHEN (NEW.srednia<2 OR NEW.srednia>5.5)
BEGIN 
	RAISE_APPLICATION_ERROR(-20000, 'Œrednia o wartoœci ' || :NEW.srednia || ' jest niepoprawna.');
END;

-----SPRWDZA CZY PODANY WIEK STUDENTA JEST POPRAWNY-----
CREATE OR REPLACE TRIGGER CZY_ODPOWIEDNI_WIEK
BEFORE INSERT OR UPDATE OF WIEK ON STUDENCI
FOR EACH ROW WHEN (NEW.WIEK<17)
BEGIN 
	RAISE_APPLICATION_ERROR(-20001, 'Osoba w wieku ' || :NEW.wiek || ' nie mo¿e studiowaæ.');
END;

-----TABELA Z ARCHIWUM-----
CREATE TABLE STUDENCI_ARCHIWUM 
   (TYP VARCHAR2(20), 
    data_operacji DATE,
    nazwa_uzytkownika varchar2(20),
    stare_id_studenta NUMBER,
	stare_imie VARCHAR(20),
	stare_nazwisko VARCHAR(20),
	stary_wiek NUMBER,
	stary_pesel CHAR(11),
	stary_Telefon NUMBER(12),
	stary_E_mail VARCHAR(30),
	stare_Miasto VARCHAR(20),
	stara_Ulica VARCHAR(30),
	stary_Nr NUMBER(10),
	stary_Indeks NUMBER(5),
	stara_Forma_studiow VARCHAR(15),
	stara_Data_zakonczenia DATE,
	stare_Id_grupy NUMBER,
	stare_Id_stypendium NUMBER,
	stare_Id_wypozyczenia NUMBER, 
	nowe_id_studenta NUMBER,
	nowe_imie VARCHAR(20),
	nowe_nazwisko VARCHAR(20),
	nowe_wiek NUMBER,
	nowy_pesel CHAR(11),
	nowy_Telefon NUMBER(12),
	nowy_E_mail VARCHAR(30),
	nowe_Miasto VARCHAR(30),
	nowa_Ulica VARCHAR(30),
	nowy_Nr NUMBER(10),
	nowy_Indeks NUMBER(5),
	nowa_Forma_studiow VARCHAR(15),
	nowa_Data_zakonczenia DATE,
	nowe_Id_grupy NUMBER,
	nowe_Id_stypendium NUMBER,
	nowe_Id_wypozyczenia NUMBER
   )

-----ARCHIWUM STUDENTOW-----
CREATE OR REPLACE TRIGGER STUDENCI_AIUD_ARCHIWIZUJ
AFTER INSERT OR UPDATE OR DELETE
ON STUDENCI
FOR EACH ROW
DECLARE
BEGIN
	CASE 
	WHEN INSERTING THEN
INSERT INTO STUDENCI_ARCHIWUM( Typ, data_operacji,nazwa_uzytkownika,stare_id_studenta,stare_imie,stare_nazwisko,stary_wiek,stary_pesel,
stary_Telefon,stary_E_mail,stare_Miasto,stara_Ulica,stary_Nr,stary_Indeks,stara_Forma_studiow,
stara_Data_zakonczenia,stare_Id_grupy,stare_Id_stypendium,stare_Id_wypozyczenia, 
nowe_id_studenta,nowe_imie,nowe_nazwisko,nowe_wiek,nowy_pesel,nowy_Telefon,nowy_E_mail,nowe_Miasto,
nowa_Ulica,nowy_Nr,nowy_Indeks,nowa_Forma_studiow,nowa_Data_zakonczenia,nowe_Id_grupy,nowe_Id_stypendium,nowe_Id_wypozyczenia)
VALUES('DODANIE',SYSDATE,USER,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,
:NEW.id_studenta,:NEW.imie,:NEW.nazwisko,:NEW.wiek,:NEW.pesel,:NEW.Telefon,:NEW.E_mail,:NEW.Miasto,
:NEW.Ulica,:NEW.Nr,:NEW.Indeks,:NEW.Forma_studiow,:NEW.Data_zakonczenia,:NEW.Id_grupy,:NEW.Id_stypendium,:NEW.Id_wypozyczenia); 
    WHEN UPDATING THEN
INSERT INTO STUDENCI_ARCHIWUM (TYP,data_operacji,nazwa_uzytkownika,stare_id_studenta,stare_imie,stare_nazwisko,stary_wiek,stary_pesel,
stary_Telefon,stary_E_mail,stare_Miasto,stara_Ulica,stary_Nr,stary_Indeks,stara_Forma_studiow,
stara_Data_zakonczenia,stare_Id_grupy,stare_Id_stypendium,stare_Id_wypozyczenia, 
nowe_id_studenta,nowe_imie,nowe_nazwisko,nowe_wiek,nowy_pesel,nowy_Telefon,nowy_E_mail,nowe_Miasto,
nowa_Ulica,nowy_Nr,nowy_Indeks,nowa_Forma_studiow,nowa_Data_zakonczenia,nowe_Id_grupy,nowe_Id_stypendium,nowe_Id_wypozyczenia)
VALUES('EDYCJA',SYSDATE,USER,:OLD.id_studenta,:OLD.imie,:OLD.nazwisko,:OLD.wiek,:OLD.pesel,:OLD.Telefon,:OLD.E_mail,:OLD.Miasto,:OLD.Ulica,
:OLD.Nr,:OLD.Indeks,:OLD.Forma_studiow,:OLD.Data_zakonczenia,:OLD.Id_grupy,:OLD.Id_stypendium,:OLD.Id_wypozyczenia,
:NEW.id_studenta,:NEW.imie,:NEW.nazwisko,:NEW.wiek,:NEW.pesel,:NEW.Telefon,:NEW.E_mail,:NEW.Miasto,
:NEW.Ulica,:NEW.Nr,:NEW.Indeks,:NEW.Forma_studiow,:NEW.Data_zakonczenia,:NEW.Id_grupy,:NEW.Id_stypendium,:NEW.Id_wypozyczenia);
   WHEN DELETING THEN
INSERT INTO STUDENCI_ARCHIWUM (TYP,data_operacji,nazwa_uzytkownika, stare_id_studenta,stare_imie,stare_nazwisko,stary_wiek,stary_pesel,
stary_Telefon,stary_E_mail,stare_Miasto,stara_Ulica,stary_Nr,stary_Indeks,stara_Forma_studiow,
stara_Data_zakonczenia,stare_Id_grupy,stare_Id_stypendium,stare_Id_wypozyczenia, 
nowe_id_studenta,nowe_imie,nowe_nazwisko,nowe_wiek,nowy_pesel,nowy_Telefon,nowy_E_mail,nowe_Miasto,
nowa_Ulica,nowy_Nr,nowy_Indeks,nowa_Forma_studiow,nowa_Data_zakonczenia,nowe_Id_grupy,nowe_Id_stypendium,nowe_Id_wypozyczenia)
VALUES('USUNIÊCIE',SYSDATE,USER,:OLD.id_studenta,:OLD.imie,:OLD.nazwisko,:OLD.wiek,:OLD.pesel,:OLD.Telefon,:OLD.E_mail,:OLD.Miasto,:OLD.Ulica,
:OLD.Nr,:OLD.Indeks,:OLD.Forma_studiow,:OLD.Data_zakonczenia,:OLD.Id_grupy,:OLD.Id_stypendium,:OLD.Id_wypozyczenia,
NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL);
   END CASE;
   END;