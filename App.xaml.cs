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
        private MainWindow main;
        void StartUp(object sender, StartupEventArgs e)
        {
            try
            {
                if (e.Args.Length > 0)
                {
                    if (Path.Exists(e.Args[0]) == true)
                    {
                       switch (Path.GetExtension(e.Args[0]))
                        {
                            case ".mp3":
                                Process[] process = Process.GetProcessesByName("Magirenko Music");
                                MainWindow main = new MainWindow();
                                main.WindowState = WindowState.Minimized;
                                main.ReproducirMusica(e.Args[0], true, main.ListaGeneral);
                                main.Show();
                                if (process.Length > 1)
                                {
                                    process[0].Kill();
                                }
                                break;
                            case ".wav":
                                Process[] process2 = Process.GetProcessesByName("Magirenko Music");
                                MainWindow main2 = new MainWindow();
                                main2.WindowState = WindowState.Minimized;
                                main2.ReproducirMusica(e.Args[0], true, main2.ListaGeneral);
                                main2.Show();
                                if (process2.Length > 1)
                                {
                                    process2[0].Kill();
                                }
                                break;
                            case ".flac":
                                Process[] process3 = Process.GetProcessesByName("Magirenko Music");
                                MainWindow main3 = new MainWindow();
                                main3.WindowState = WindowState.Minimized;
                                main3.ReproducirMusica(e.Args[0], true, main3.ListaGeneral);
                                main3.Show();
                                if (process3.Length > 1)
                                {
                                    process3[0].Kill();
                                }
                                break;
                            case ".ogg":
                                Process[] process4 = Process.GetProcessesByName("Magirenko Music");
                                MainWindow main4 = new MainWindow();
                                main4.WindowState = WindowState.Minimized;
                                main4.ReproducirMusica(e.Args[0], true, main4.ListaGeneral);
                                main4.Show();
                                if (process4.Length > 1)
                                {
                                    process4[0].Kill();
                                }
                                break;
                            case ".aac":
                                Process[] process5 = Process.GetProcessesByName("Magirenko Music");
                                MainWindow main5 = new MainWindow();
                                main5.WindowState = WindowState.Minimized;
                                main5.ReproducirMusica(e.Args[0], true, main5.ListaGeneral);
                                main5.Show();
                                if (process5.Length > 1)
                                {
                                    process5[0].Kill();
                                }
                                break;
                            case ".m4a":
                                Process[] process6 = Process.GetProcessesByName("Magirenko Music");
                                MainWindow main6 = new MainWindow();
                                main6.WindowState = WindowState.Minimized;
                                main6.ReproducirMusica(e.Args[0], true, main6.ListaGeneral);
                                main6.Show();
                                if (process6.Length > 1)
                                {
                                    process6[0].Kill();
                                }
                                break;

                            case ".mmpl":
                                MainWindow main7 = new MainWindow();
                                main7.abrirpl(e.Args[0], true);
                                main7.Show();
                                break;
                            default:
                                MessageBox.Show("No se pudo cargar el archivo seleccionado por que es corrupto o es un formato incompatible.", "Error al cargar archivo | Magirenko Music", MessageBoxButton.OK, MessageBoxImage.Error);
                                break;
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
           if (main.pl != null)
           {
                main.pl.DescargarMusicas();
           }
        }
    }

}
