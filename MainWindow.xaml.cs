using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;

namespace Magirenko_Music
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string changelog;
        public MainWindow()
        {
            Console.WriteLine("Cargando Ventana...");
            InitializeComponent();
            Loaded += Cargado;
            Closed += Cerrar;
        }

        public class MusicItem()
        {
            public required string portada { get; set; }
            public required string titulo { get; set; }
            public required string playlist { get; set; }
            public required string duracion { get; set; }
            public required string carpeta { get; set; }
            public required string ubicacion { get; set; }
        }

        private void Boton1_Clicked(object sender, RoutedEventArgs e)
        {
            grid1.Visibility = Visibility.Hidden;
            grid1.IsEnabled = false;
            grid2.Visibility = Visibility.Visible;
            grid2.IsEnabled = true;
        }

        private void Cargado(object? sender, RoutedEventArgs e)
        {
            using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("Magirenko_Music.changelog.txt"))
            {
                TextReader tr = new StreamReader(stream);
                changelog = tr.ReadToEnd();
            }
            Console.WriteLine("Cargando musicas...");
            foreach (string path in Directory.EnumerateFiles(@"C:\Users\" + Environment.UserName + @"\Music", "*.*", SearchOption.AllDirectories)
            .Where(s => s.EndsWith(".mp3") || s.EndsWith(".wav") || s.EndsWith(".ogg") || s.EndsWith(".flac") || s.EndsWith(".aac") || s.EndsWith(".m4a")))
            {
                TagLib.File music = TagLib.File.Create(path);
                FileInfo musicInfo = new FileInfo(path);
                MusicItem MusicItem = new MusicItem() { ubicacion = musicInfo.FullName, portada = "♫", titulo = music.Tag.Title ?? System.IO.Path.GetFileNameWithoutExtension(music.Name), duracion = music.Properties.Duration.ToString(@"mm\:ss"), playlist = "No implementado", carpeta = musicInfo.Directory == null ? "?" : musicInfo.Directory.Name };
                ListaGeneral.Items.Add(MusicItem);
            }
            Hyperlink hlink = new Hyperlink();
            hlink.NavigateUri = new Uri("https://github.com/Magirenko/Magirenko-Music/releases/tag/v0.2-alpha");
            hlink.RequestNavigate += (sender, e) =>
            {
                try
                {
                    System.Diagnostics.Process.Start("explorer.exe", e.Uri.ToString());
                }
                catch (Win32Exception ex)
                {
                    MessageBox.Show("Su antivirus ha bloqueado el proceso de abrir este link de github, algunos antiviruses bloquean el proceso de abrir los links de Magirenko Music por usar explorer.exe para abrirlo.\n\nPuede permitir esta accion la proxima vez si su antivirus tiene una opcion de permitirlo, solo si confias con Magirenko Music o no lo hagas si quieres.", "Nota sobre la deteccion de antiviruses", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            };
            Run hlinktxt = new Run();
            hlinktxt.Text = "El release de Github.";
            hlink.Inlines.Add(hlinktxt);
            Run ChangelogRun = new Run();
            ChangelogRun.Text = "\n" + changelog;

            Cambios.Inlines.Add(ChangelogRun);
            Cambios.Inlines.Add(hlink);
        }

        public string? ActualMusic;
        public MusicOverlay overlay = new MusicOverlay();
        public void ReproducirMusica(string musicPath, bool OpenedWith)
        {
            overlay.LoadMusic(musicPath);
            overlay.Show();
            ActualMusic = OpenedWith == false ? ((MusicItem)(ListaGeneral.SelectedItem)).ubicacion : musicPath;
        }

        private void Cerrar(object? sender, EventArgs e)
        {
            overlay.Close();
        }

        private void ListViewItem_MouseDoubleClick(object? sender, MouseEventArgs e)
        {
            if (ActualMusic != ((MusicItem)(ListaGeneral.SelectedItem)).ubicacion)
            {
                ReproducirMusica(((MusicItem)(ListaGeneral.SelectedItem)).ubicacion, false);
            }
        }
    }
}