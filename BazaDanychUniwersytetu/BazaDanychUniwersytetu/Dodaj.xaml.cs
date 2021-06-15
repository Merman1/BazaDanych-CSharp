using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System.Configuration;
using System.Data.SqlTypes;

namespace BazaDanychUniwersytetu
{
    /// <summary>
    /// Logika interakcji dla klasy Dodaj.xaml
    /// </summary>

    public partial class Dodaj : Window
    {
        OracleConnection con = null;
        public Dodaj()
        {
            this.setConnection();
            InitializeComponent();
        }
        private void updateDataGrid()
        {
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT ID_STUDENTA, IMIE, NAZWISKO, WIEK, PESEL, TELEFON, E_MAIL, MIASTO, ULICA, NR, INDEKS, FORMA_STUDIOW, DATA_ZAKONCZENIA, ID_GRUPY, ID_STYPENDIUM, ID_WYPOZYCZENIA FROM STUDENCI ORDER BY ID_STUDENTA";
            cmd.CommandType = CommandType.Text;
            OracleDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            MyDataGrid.ItemsSource = dt.DefaultView;
            dr.Close();
        }
        private void setConnection()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
            con = new OracleConnection(connectionString);
            try
            {
                con.Open();

            }
            catch (Exception exp) { }
        }
        private void DZU(String sql_stmt, int state)
        {
            String msg = "";
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = sql_stmt;
            cmd.CommandType = CommandType.Text;


            switch (state)
            {
                case 0:
                    msg = "Dodano studenta pomyślnie!";
                  
                    cmd.Parameters.Add("IMIE", OracleDbType.Varchar2, 25).Value = IMIE_txt.Text;
                    cmd.Parameters.Add("NAZWISKO", OracleDbType.Varchar2, 25).Value = NAZWISKO_txt.Text;
                    cmd.Parameters.Add("WIEK", OracleDbType.Int64, 10).Value = Int64.Parse(WIEK_txt.Text);
                    cmd.Parameters.Add("PESEL", OracleDbType.Int64, 11).Value = Int64.Parse(PESEL_txt.Text);
                    cmd.Parameters.Add("TELEFON", OracleDbType.Int64, 9).Value = Int64.Parse(TELEFON_txt.Text);
                    cmd.Parameters.Add("E_MAIL", OracleDbType.Varchar2, 30).Value = E_MAIL_txt.Text;
                    cmd.Parameters.Add("MIASTO", OracleDbType.Varchar2, 25).Value = MIASTO_txt.Text;
                    cmd.Parameters.Add("ULICA", OracleDbType.Varchar2, 25).Value = ULICA_txt.Text;
                    cmd.Parameters.Add("NR", OracleDbType.Int64, 6).Value = Int64.Parse(NR_txt.Text);
                    cmd.Parameters.Add("INDEKS", OracleDbType.Int64, 6).Value = Int64.Parse(INDEKS_txt.Text);
                    cmd.Parameters.Add("FORMA_STUDIOW", OracleDbType.Varchar2, 20).Value = FORMA_STUDIOW_txt.Text;
                    cmd.Parameters.Add("DATA_ZAKONCZENIA", OracleDbType.Date, 7).Value = DATA_ZAKONCZENIA_txt.SelectedDate;
                    cmd.Parameters.Add("ID_GRUPY", OracleDbType.Int64, 10).Value = Int64.Parse(ID_GRUPY_txt.Text);
                    //cmd.Parameters.Add("ID_STYPENDIUM", OracleDbType.Int64, 10).Value = Int64.Parse(ID_STYPENDIUM_txt.Text);
                    //cmd.Parameters.Add("ID_WYPOZYCZENIA", OracleDbType.Int64, 10).Value = Int64.Parse(ID_WYPOZYCZENIA_txt.Text);


                    break;
                case 1:
                    msg = "Zaktualizowano studenta pomyślnie!";
                    cmd.Parameters.Add("IMIE", OracleDbType.Varchar2, 25).Value = IMIE_txt.Text;
                    cmd.Parameters.Add("NAZWISKO", OracleDbType.Varchar2, 25).Value = NAZWISKO_txt.Text;
                    cmd.Parameters.Add("WIEK", OracleDbType.Int32, 30).Value = Int32.Parse(WIEK_txt.Text);
                    cmd.Parameters.Add("PESEL", OracleDbType.Int64, 11).Value = Int64.Parse(PESEL_txt.Text);
                    cmd.Parameters.Add("TELEFON", OracleDbType.Int32, 9).Value = Int32.Parse(TELEFON_txt.Text);
                    cmd.Parameters.Add("E_MAIL", OracleDbType.Varchar2, 30).Value = E_MAIL_txt.Text;
                    cmd.Parameters.Add("MIASTO", OracleDbType.Varchar2, 25).Value = MIASTO_txt.Text;
                    cmd.Parameters.Add("ULICA", OracleDbType.Varchar2, 25).Value = ULICA_txt.Text;
                    cmd.Parameters.Add("NR", OracleDbType.Int32, 6).Value = Int32.Parse(NR_txt.Text);
                    cmd.Parameters.Add("INDEKS", OracleDbType.Int64, 6).Value = Int64.Parse(INDEKS_txt.Text);
                    cmd.Parameters.Add("FORMA_STUDIOW", OracleDbType.Varchar2, 20).Value = FORMA_STUDIOW_txt.Text;
                    cmd.Parameters.Add("DATA_ZAKONCZENIA", OracleDbType.Date, 7).Value = DATA_ZAKONCZENIA_txt.SelectedDate;
                    cmd.Parameters.Add("ID_GRUPY", OracleDbType.Int32, 10).Value = Int32.Parse(ID_GRUPY_txt.Text);
                    //cmd.Parameters.Add("ID_STYPENDIUM", OracleDbType.Int32, 10).Value = Int32.Parse(ID_STYPENDIUM_txt.Text);
                    //cmd.Parameters.Add("ID_WYPOZYCZENIA", OracleDbType.Int32, 10).Value = Int32.Parse(ID_WYPOZYCZENIA_txt.Text);
                    cmd.Parameters.Add("ID_STUDENTA", OracleDbType.Int32, 6).Value = Int32.Parse(ID_STUDENTA_txt.Text);


                    break;
                case 2:
                    msg = "Usunięto studenta pomyślnie!";

                    cmd.Parameters.Add("ID_STUDENTA", OracleDbType.Int32, 6).Value = Int32.Parse(ID_STUDENTA_txt.Text);

                    break;
            }
            try
            {
                int n = cmd.ExecuteNonQuery();
                if (n > 0)
                {
                    MessageBox.Show(msg);
                    this.updateDataGrid();
                }
            }
            catch (Exception expe)
            {
                MessageBox.Show("Błąd danych. " + expe.Message, "Error");
            }
        }
        private void MyDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dg = sender as DataGrid;
            DataRowView dr = dg.SelectedItem as DataRowView;
            if (dr != null)
            {

                ID_STUDENTA_txt.Text = dr["ID_STUDENTA"].ToString();
                IMIE_txt.Text = dr["IMIE"].ToString();
                NAZWISKO_txt.Text = dr["NAZWISKO"].ToString();
                WIEK_txt.Text = dr["WIEK"].ToString();
                PESEL_txt.Text = dr["PESEL"].ToString();
                TELEFON_txt.Text = dr["TELEFON"].ToString();
                E_MAIL_txt.Text = dr["E_MAIL"].ToString();
                MIASTO_txt.Text = dr["MIASTO"].ToString();
                ULICA_txt.Text = dr["ULICA"].ToString();
                NR_txt.Text = dr["NR"].ToString();
                INDEKS_txt.Text = dr["INDEKS"].ToString();
                FORMA_STUDIOW_txt.Text = dr["FORMA_STUDIOW"].ToString();
                DATA_ZAKONCZENIA_txt.SelectedDate = DateTime.Parse(dr["DATA_ZAKONCZENIA"].ToString());
                ID_GRUPY_txt.Text = dr["ID_GRUPY"].ToString();
                ID_STYPENDIUM_txt.Text = dr["ID_STYPENDIUM"].ToString();
                ID_WYPOZYCZENIA_txt.Text = dr["ID_WYPOZYCZENIA"].ToString();

                Dodaj_btn.IsEnabled = false;
                Zaktualizuj_btn.IsEnabled = true;
                Usun_btn.IsEnabled = true;
            }
        }

        private void Dodaj_btn_Click(object sender, RoutedEventArgs e)
        {
            String sql = "CALL DODAJ_STUDENTA(:ID_STUDENTA ,:IMIE, :NAZWISKO, :WIEK, :PESEL, :TELEFON, :E_MAIL, :MIASTO, :ULICA, :NR, :INDEKS, :FORMA_STUDIOW, :DATA_ZAKONCZENIA, :ID_GRUPY, NULL,NULL) " 
                   ;
            this.DZU(sql, 0);
            Dodaj_btn.IsEnabled = false;
            Zaktualizuj_btn.IsEnabled = true;
            Usun_btn.IsEnabled = true;
        }

        private void Zresetuj_btn_Click(object sender, RoutedEventArgs e)
        {
            this.resetAll();
        }
        private void resetAll()
        {
            ID_STUDENTA_txt.Text = "";
            IMIE_txt.Text = "";
            NAZWISKO_txt.Text = "";
            WIEK_txt.Text = "";
            PESEL_txt.Text = "";
            TELEFON_txt.Text = "";
            E_MAIL_txt.Text = "";
            MIASTO_txt.Text = "";
            ULICA_txt.Text = "";
            NR_txt.Text = "";
            INDEKS_txt.Text = "";
            FORMA_STUDIOW_txt.Text = "";
            DATA_ZAKONCZENIA_txt.SelectedDate = null;
            ID_GRUPY_txt.Text = "";
            ID_STYPENDIUM_txt.Text = "";
            ID_WYPOZYCZENIA_txt.Text = "";

            Dodaj_btn.IsEnabled = true;
            Zaktualizuj_btn.IsEnabled = false;
            Usun_btn.IsEnabled = false;
        }

        private void Usun_btn_Click(object sender, RoutedEventArgs e)
        {
            String sql = "DELETE FROM STUDENCI " +
                "WHERE ID_STUDENTA = :ID_STUDENTA";
            this.DZU(sql, 2);
            this.resetAll();
        }

        private void Zaktualizuj_btn_Click(object sender, RoutedEventArgs e)
        {
            String sql =
                  "UPDATE STUDENCI SET IMIE = :IMIE,NAZWISKO=:NAZWISKO, WIEK=:WIEK, PESEL=:PESEL, TELEFON=:TELEFON, E_MAIL=:E_MAIL, MIASTO=:MIASTO, ULICA=:ULICA, NR=:NR, INDEKS=:INDEKS, FORMA_STUDIOW=:FORMA_STUDIOW, DATA_ZAKONCZENIA=:DATA_ZAKONCZENIA, ID_GRUPY=:ID_GRUPY, ID_STYPENDIUM=:ID_STYPENDIUM WHERE ID_STUDENTA = :ID_STUDENTA";
            this.DZU(sql, 1);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.updateDataGrid();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            con.Close();
        }
    }
}
