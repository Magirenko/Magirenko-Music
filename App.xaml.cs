using System.Diagnostics;
using System.IO;
using System.Windows;

namespace Magirenko_Music
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        void StartUp(object sender, StartupEventArgs e)
        {
            try
            {
                if (e.Args.Length > 0)
                {
                    if (Path.Exists(e.Args[0]) == true)
                    {
                        Process[] process = Process.GetProcessesByName("Magirenko Music");
                        MainWindow main = new MainWindow();
                        main.WindowState = WindowState.Minimized;
                        main.ReproducirMusica(e.Args[0], true);
                        main.Show();
                        if (process.Length > 1)
                        {
                            process[0].Kill();
                        }
                    }
                    else
                    {
                        MessageBox.Show("No se pudo cargar el archivo seleccionado por que no existe.", "Error al cargar archivo | Magirenko Music", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    MainWindow main = new MainWindow();
                    main.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Desconocido", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }

}
