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
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
     
        OracleConnection con = null;
        public MainWindow()
        {
           
            this.setConnection();
            InitializeComponent();
        }
        private void updateDataGrid()
        {
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT * FROM STUDENCI order by ID_STUDENTA ";
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.updateDataGrid();
          
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            con.Close();
        }

        private void Kierunki_grupy_btn_Click(object sender, RoutedEventArgs e)
        {
            Kierunki_grupy kie = new Kierunki_grupy();
            kie.Show();
        }

        private void Stypendysci_btn_Click(object sender, RoutedEventArgs e)
        {
           Stypendysci styp = new Stypendysci();
            styp.Show();
        }

        private void Wypozyczenia_btn_Click(object sender, RoutedEventArgs e)
        {
            Wypozyczenia wyp = new Wypozyczenia();
            wyp.Show();
        }

        private void Kursanci_btn_Click(object sender, RoutedEventArgs e)
        {
            Kursanci kur = new Kursanci();
            kur.Show();
        }

        private void Zajecia_wykladowcow_btn_Click(object sender, RoutedEventArgs e)
        {
            Zajecia_wykladowcow zaj = new Zajecia_wykladowcow();
            zaj.Show();
        }

        private void Plan_zajec_btn_Click(object sender, RoutedEventArgs e)
        {
            Plan_zajec plan = new Plan_zajec();
            plan.Show();
        }

        private void Dodaj_studenta_btn_Click(object sender, RoutedEventArgs e)
        {
            Dodaj dod = new Dodaj();
            dod.Show();
        }

        private void Studenci_btn_Click(object sender, RoutedEventArgs e)
        {
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT * FROM STUDENCI order by ID_STUDENTA ";
            cmd.CommandType = CommandType.Text;
            OracleDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            MyDataGrid.ItemsSource = dt.DefaultView;
            dr.Close();
        }

        private void Grupy_btn_Click(object sender, RoutedEventArgs e)
        {
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT * FROM GRUPY order by NAZWA ";
            cmd.CommandType = CommandType.Text;
            OracleDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            MyDataGrid.ItemsSource = dt.DefaultView;
            dr.Close();
        }

        private void Kierunki_btn_Click(object sender, RoutedEventArgs e)
        {
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT * FROM KIERUNKI order by NAZWA ";
            cmd.CommandType = CommandType.Text;
            OracleDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            MyDataGrid.ItemsSource = dt.DefaultView;
            dr.Close();
        }

        private void Przedmioty_btn_Click(object sender, RoutedEventArgs e)
        {
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT * FROM PRZEDMIOTY order by NAZWA ";
            cmd.CommandType = CommandType.Text;
            OracleDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            MyDataGrid.ItemsSource = dt.DefaultView;
            dr.Close();
        }

        private void Harmonogram_btn_Click(object sender, RoutedEventArgs e)
        {
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT * FROM HARMONOGRAMY order by DZIEN_TYGODNIA ";
            cmd.CommandType = CommandType.Text;
            OracleDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            MyDataGrid.ItemsSource = dt.DefaultView;
            dr.Close();
        }

        private void Wykladowcy_btn_Click(object sender, RoutedEventArgs e)
        {
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT * FROM WYKLADOWCY order by NAZWISKO ";
            cmd.CommandType = CommandType.Text;
            OracleDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            MyDataGrid.ItemsSource = dt.DefaultView;
            dr.Close();
        }

        private void Biblioteka_btn_Click(object sender, RoutedEventArgs e)
        {
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT * FROM BIBLIOTEKA order by TERMIN_ODDANIA ";
            cmd.CommandType = CommandType.Text;
            OracleDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            MyDataGrid.ItemsSource = dt.DefaultView;
            dr.Close();
        }

        private void Stypendia_btn_Click(object sender, RoutedEventArgs e)
        {
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT * FROM STYPENDIA order by DECYZJA ";
            cmd.CommandType = CommandType.Text;
            OracleDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            MyDataGrid.ItemsSource = dt.DefaultView;
            dr.Close();
        }

        private void Modyfikowanie_biblioteki_btn_Click(object sender, RoutedEventArgs e)
        {
            Modyfikowanie_biblioetki Mod = new Modyfikowanie_biblioetki();
            Mod.Show();
        }
    }
    }

