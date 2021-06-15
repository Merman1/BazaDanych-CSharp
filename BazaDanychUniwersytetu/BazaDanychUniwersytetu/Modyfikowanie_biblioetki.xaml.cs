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
    /// Logika interakcji dla klasy Modyfikowanie_biblioetki.xaml
    /// </summary>
    public partial class Modyfikowanie_biblioetki : Window
    {
        OracleConnection con = null;
        public Modyfikowanie_biblioetki()
        {
            this.setConnection();
            InitializeComponent();
        }
        private void updateDataGrid()
        {
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT ID_WYPOZYCZENIA, ILOSC_WYPOŻ_KSIĄŻ, TERMIN_ODDANIA FROM BIBLIOTEKA ORDER BY ID_WYPOZYCZENIA";
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
                    msg = "Dodano wypożyczenia pomyślnie!";

                   
                    cmd.Parameters.Add("ILOSC_WYPOŻ_KSIĄŻ", OracleDbType.Int32, 10).Value = Int32.Parse(Ilosc_wypoz_ksiaz_txt.Text);
                    cmd.Parameters.Add("TERMIN_ODDANIA", OracleDbType.Date, 7).Value = Termin_oddania_txt.SelectedDate;




                    break;
                case 1:
                    msg = "Zaktualizowano wypożyczenie skutecznie!";

                    cmd.Parameters.Add("ID_WYPOZYCZENIA", OracleDbType.Int64, 6).Value = Int64.Parse(Id_wypozyczenia_txt.Text);
                    cmd.Parameters.Add("ILOSC_WYPOŻ_KSIĄŻ", OracleDbType.Int32, 10).Value = Int32.Parse(Ilosc_wypoz_ksiaz_txt.Text);
                    cmd.Parameters.Add("TERMIN_ODDANIA", OracleDbType.Date, 7).Value = Termin_oddania_txt.SelectedDate;



                    break;
                case 2:
                    msg = "Usunięto wypożyczenie pomyślnie!";

                    cmd.Parameters.Add("ID_WYPOZYCZENIA", OracleDbType.Int64, 6).Value = Int64.Parse(Id_wypozyczenia_txt.Text);

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
     

        private void Dodaj_btn_Click(object sender, RoutedEventArgs e)
        {
            String sql = "INSERT INTO BIBLIOTEKA(ID_WYPOZYCZENIA,ILOSC_WYPOŻ_KSIĄŻ,TERMIN_ODDANIA) " +
                   "VALUES(BIBLIOTEKA_SEQ.NEXTVAL,:ILOSC_WYPOŻ_KSIĄŻ,:TERMIN_ODDANIA)";
            this.DZU(sql, 0);
            Dodaj_btn.IsEnabled = false;
            Zaktualizuj_btn.IsEnabled = true;
            Usun_btn.IsEnabled = true;
        }
        private void resetAll()
        {
            Id_wypozyczenia_txt.Text = "";
            Ilosc_wypoz_ksiaz_txt.Text = "";
            Termin_oddania_txt.SelectedDate = null;


            Dodaj_btn.IsEnabled = true;
            Zaktualizuj_btn.IsEnabled = false;
            Usun_btn.IsEnabled = false;
        }
        private void Zresteuj_btn_Click(object sender, RoutedEventArgs e)
        {
            this.resetAll();
        }

        private void Usun_btn_Click(object sender, RoutedEventArgs e)
        {
            String sql = "DELETE FROM BIBLIOTEKA " +
               "WHERE ID_WYPOZYCZENIA = :ID_WYPOZYCZENIA";
            this.DZU(sql, 2);
            this.resetAll();
        }

        private void Zaktualizuj_btn_Click(object sender, RoutedEventArgs e)
        {
            String sql =
                 "UPDATE BIBLIOTEKA SET ID_WYPOZYCZENIA = :ID_WYPOZYCZENIA,ILOSC_WYPOŻ_KSIĄŻ = :ILOSC_WYPOŻ_KSIĄŻ, TERMIN_ODDANIA = :TERMIN_ODDANIA WHERE ID_WYPOZYCZENIA = :ID_WYPOZYCZENIA";
            this.DZU(sql, 1);
        }

        private void Window_Closed(object sender, EventArgs e)
        {

            con.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            this.updateDataGrid();
        }

        private void MyDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dg = sender as DataGrid;
            DataRowView dr = dg.SelectedItem as DataRowView;
            if (dr != null)
            {

                Id_wypozyczenia_txt.Text = dr["ID_WYPOZYCZENIA"].ToString();
                Ilosc_wypoz_ksiaz_txt.Text = dr["ILOSC_WYPOŻ_KSIĄŻ"].ToString();
                Termin_oddania_txt.SelectedDate = DateTime.Parse(dr["TERMIN_ODDANIA"].ToString());


                Dodaj_btn.IsEnabled = false;
                Zaktualizuj_btn.IsEnabled = true;
                Usun_btn.IsEnabled = true;
            }
        }
    }
}
