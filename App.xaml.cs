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
        private MainWindow? main;
        string[] acceptedFormats = { ".mp3", ".aac", ".ogg", ".wav", ".flac", ".m4a" };
        void StartUp(object sender, StartupEventArgs e)
        {
            try
            {
                if (e.Args.Length > 0)
                {
                    if (Path.GetDirectoryName(e.Args[0]) != string.Empty || Path.GetFileName(e.Args[0]) != string.Empty)
                    {
                        switch (acceptedFormats.Contains(Path.GetExtension(e.Args[0])))
                        {
                            case (true):
                                Process[] process = Process.GetProcessesByName("Magirenko Music");
                                main = new MainWindow();
                                main.WindowState = WindowState.Minimized;
                                main.ReproducirMusica(e.Args[0], true, main.ListaGeneral);
                                main.Show();
                                if (process.Length > 1)
                                {
                                    process[0].Kill();
                                }
                                break;

                            case (false):
                                if (Path.GetExtension(e.Args[0]) == ".mmpl")
                                {
                                    MainWindow main7 = new MainWindow();
                                    main7.abrirpl(e.Args[0], true);
                                    main7.Show();
                                }
                                else
                                {
                                    MessageBox.Show("No se pudo cargar el archivo seleccionado por que es corrupto o es un formato incompatible.", "Error al cargar archivo | Magirenko Music", MessageBoxButton.OK, MessageBoxImage.Error);
                                }
                                break;
                        }
                        if (main != null)
                        {
                            MainWindow = main;
                        }
                    }
                    else
                    {
                        MessageBox.Show("No se pudo cargar el archivo seleccionado por que no existe.", "Error al cargar archivo | Magirenko Music", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    main = new MainWindow();
                    MainWindow = main;
                    main.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Desconocido", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        void exit(object sender, ExitEventArgs e)
        {
            if (main != null)
            {
                if (main.pl != null)
                {
                    main.pl.DescargarMusicas();
                }
            }
        }
    }

}
