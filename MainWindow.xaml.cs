using Magirenko.MMPL;
using Microsoft.Win32;
using System.IO;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
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
        private OpenFileDialog dialog = new OpenFileDialog();
        public Playlist pl;
        public MainWindow()
        {
            try
            {
                Console.WriteLine("Cargando Ventana...");
                InitializeComponent();
                dialog.Multiselect = true;
                Loaded += Cargado;
                Closed += Cerrar;
                ListaGeneral.Drop += drop;
                ListaPlView.Drop += drop;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Desconocido", MessageBoxButton.OK, MessageBoxImage.Error);
                App.Current.Shutdown();
            }
        }

        string[] acceptedFormats = { ".mp3", ".aac", ".ogg", ".wav", ".flac", ".m4a" };

        public class MusicItem()
        {
            public string? portada { get; set; }
            public string? titulo { get; set; }
            public string? duracion { get; set; }
            public string? carpeta { get; set; }
            public string? ubicacion { get; set; }
        }
        public class PlaylistItem()
        {
            public string? portada { get; set; }
            public string? titulo { get; set; }
            public string? musicas { get; set; }
            public string? carpeta { get; set; }
            public string? ubicacion { get; set; }
        }

        enum ViewType
        {
            Musicas,
            Playlists
        }

        private ViewType ver = ViewType.Musicas;

        private void Boton1_Clicked(object sender, RoutedEventArgs e)
        {
            try
            {
                grid1.Visibility = Visibility.Hidden;
                grid1.IsEnabled = false;
                grid2.Visibility = Visibility.Visible;
                grid2.IsEnabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Desconocido", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Cargado(object? sender, EventArgs e)
        {
            try
            {
                Run savedrun = firstrun;
                Cambios.Inlines.Clear();
                Cambios.Inlines.Add(savedrun);
                ListaGeneral.Items.Clear();
                ListaPlView.Items.Clear();
                if (ver == ViewType.Musicas)
                {
                    ListaGeneral.Visibility = Visibility.Visible;
                    ListaPlView.Visibility = Visibility.Hidden;
                }
                else if (ver == ViewType.Playlists)
                {
                    ListaGeneral.Visibility = Visibility.Hidden;
                    ListaPlView.Visibility = Visibility.Visible;
                }
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
                    MusicItem MusicItem = new MusicItem() { ubicacion = musicInfo.FullName, portada = "𝆕", titulo = music.Tag.Title ?? System.IO.Path.GetFileNameWithoutExtension(music.Name), duracion = music.Properties.Duration.ToString(@"mm\:ss"), carpeta = musicInfo.Directory == null ? "?" : musicInfo.Directory.Name };
                    ListaGeneral.Items.Add(MusicItem);
                    music.Dispose();
                }

                foreach (string path in Directory.EnumerateFiles(@"C:\Users\" + Environment.UserName + @"\Music", "*.*", SearchOption.AllDirectories)
               .Where(s => s.EndsWith(".mmpl")))
                {
                    Playlist pl = new Playlist(path);
                    FileInfo info = new FileInfo(path);
                    PlaylistItem plitem = new PlaylistItem() { ubicacion = pl.ruta, portada = "♫", titulo = pl.titulo, musicas = pl.CantidadDeMusicas.ToString(), carpeta = info.Directory == null ? "?" : info.Directory.Name };
                    ListaPlView.Items.Add(plitem);
                }
                // Hyperlink hlink = new Hyperlink();
                // hlink.NavigateUri = new Uri("https://github.com/Magirenko/Magirenko-Music/releases/tag/v0.2-alpha");
                // hlink.RequestNavigate += (sender, e) =>
                // {
                //    try
                //    {
                //        System.Diagnostics.Process.Start("explorer.exe", e.Uri.ToString());
                //    }
                //    catch (Win32Exception ex)
                //    {
                //        MessageBox.Show("Su antivirus ha bloqueado el proceso de abrir este link de github, algunos antiviruses bloquean el proceso de abrir los links de Magirenko Music por usar explorer.exe para abrirlo.\n\nPuede permitir esta accion la proxima vez si su antivirus tiene una opcion de permitirlo, solo si confias con Magirenko Music o no lo hagas si quieres.", "Nota sobre la deteccion de antiviruses", MessageBoxButton.OK, MessageBoxImage.Information);
                //    }
                // };
                // Run hlinktxt = new Run();
                // hlinktxt.Text = "El release de Github.";
                // hlink.Inlines.Add(hlinktxt);
                Run ChangelogRun = new Run();
                ChangelogRun.Text = "\n" + changelog;

                Cambios.Inlines.Add(ChangelogRun);
                // Cambios.Inlines.Add(hlink);

                // Deshabilitado temporalmente por la deteccion de antivirus
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Desconocido", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public string? ActualMusic;
        public MusicOverlay overlay = new MusicOverlay();
        public void ReproducirMusica(string musicPath, bool OpenedWith, ListView lista, Playlist? pl = null, int musica = 0)
        {
            try
            {
                overlay.LoadMusic(musicPath, pl, musica);
                overlay.Show();
                ActualMusic = OpenedWith == false ? ((MusicItem)(lista.SelectedItem)).ubicacion : musicPath;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Desconocido", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Cerrar(object? sender, EventArgs e)
        {
            try
            {
                overlay.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Desconocido", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ListViewItem_MouseDoubleClick(object? sender, MouseEventArgs e)
        {
            try
            {
                if (ListaGeneral.Visibility == Visibility.Visible)
                {
                    if (ActualMusic != ((MusicItem)(ListaGeneral.SelectedItem)).ubicacion)
                    {
                        ReproducirMusica(((MusicItem)(ListaGeneral.SelectedItem)).ubicacion, false, ListaGeneral);
                    }
                }
                else if (ListaPlView.Visibility == Visibility.Visible)
                {
                    abrirpl(((PlaylistItem)(ListaPlView.SelectedItem)).ubicacion, false);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Desconocido", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void importarmusica(object sender, RoutedEventArgs e)
        {
            try
            {
                dialog.DefaultExt = ".mp3";
                dialog.Filter = "Archivos de musica (*.mp3, *.wav, *.ogg, *.flac, *.aac, .m4a)|*.mp3;*.wav;*.ogg;*.flac;*.aac;*.m4a";
                bool? result = dialog.ShowDialog();
                if (result == true)
                {
                    foreach (string p in dialog.FileNames)
                    {
                        System.IO.File.Copy(p, @"C:\Users\" + Environment.UserName + @"\Music\" + Path.GetFileName(p));
                        Cargado(sender, e);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Desconocido", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void abrirmusica(object sender, RoutedEventArgs e)
        {
            try
            {
                dialog.DefaultExt = ".mp3";
                dialog.Filter = "Archivos de musica (*.mp3, *.wav, *.ogg, *.flac, *.aac, .m4a)|*.mp3;*.wav;*.ogg;*.flac;*.aac;*.m4a";
                dialog.Multiselect = false;
                bool? result = dialog.ShowDialog();
                if (result == true)
                {
                    ReproducirMusica(dialog.FileName, true, ListaGeneral);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Desconocido", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void importarplaylist(object sender, RoutedEventArgs e)
        {
            try
            {
                dialog.DefaultExt = ".mmpl";
                dialog.Filter = "Playlist de Magirenko Music (.mmpl)|*.mmpl";
                bool? result = dialog.ShowDialog();
                if (result == true)
                {
                    foreach (string p in dialog.FileNames)
                    {
                        System.IO.File.Copy(p, @"C:\Users\" + Environment.UserName + @"\Music\" + Path.GetFileName(p));
                        Cargado(sender, e);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Desconocido", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void reproducirplmusica(object? sender, MouseEventArgs e)
        {
            try
            {
                ReproducirMusica(((MusicItem)(ListaPl.SelectedItem)).ubicacion, false, ListaPl, pl, ListaPl.Items.IndexOf((MusicItem)(ListaPl.SelectedItem)));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Desconocido", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void abrirpl(string ruta, bool OpenWith = false)
        {
            try
            {
                if (pl != null)
                {
                    pl.DescargarMusicas();
                }
                ListaPl.Items.Clear();
                pl = new Playlist(ruta);
                titulo.Content = pl.titulo;
                autor.Content = pl.autor;
                desc1.Text = pl.desc;
                foreach (string p in pl.CargarMusicas())
                {
                    TagLib.File file = TagLib.File.Create(p);
                    FileInfo info = new FileInfo(p);
                    MusicItem item = new MusicItem() { titulo = file.Tag.Title ?? "Sin nombre", duracion = file.Properties.Duration.ToString(@"mm\:ss"), portada = "𝆕", carpeta = "?", ubicacion = info.FullName };
                    ListaPl.Items.Add(item);
                }
                grid1.Visibility = Visibility.Hidden;
                grid2.Visibility = Visibility.Hidden;
                PlCreation.Visibility = Visibility.Hidden;
                PlScreen.Visibility = Visibility.Visible;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al abrir playlist", MessageBoxButton.OK, MessageBoxImage.Error);
                if (OpenWith == true)
                {
                    App.Current.Shutdown();
                }
            }
        }

        private void abrirplaylist(object sender, RoutedEventArgs e)
        {
            try
            {
                dialog.DefaultExt = ".mmpl";
                dialog.Filter = "Playlist de Magirenko Music (.mmpl)|*.mmpl";
                dialog.Multiselect = false;
                bool? result = dialog.ShowDialog();
                if (result == true)
                {
                    abrirpl(dialog.FileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Desconocido", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void nuevaplaylist(object sender, RoutedEventArgs e)
        {
            try
            {
                grid2.Visibility = Visibility.Hidden;
                PlCreation.Visibility = Visibility.Visible;
                PlScreen.Visibility = Visibility.Hidden;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Desconocido", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Examinarmusicas(object sender, RoutedEventArgs e)
        {
            try
            {
                dialog.Multiselect = true;
                dialog.DefaultExt = ".mp3";
                dialog.Filter = "Archivos de musica (*.mp3, *.wav, *.ogg, *.flac, *.aac, .m4a)|*.mp3;*.wav;*.ogg;*.flac;*.aac;*.m4a";
                bool? result = dialog.ShowDialog();
                if (result == true)
                {
                    plmusicas.Text = string.Empty;
                    foreach (string p in dialog.FileNames)
                    {
                        plmusicas.Text += p + "\r\n";
                    }
                    plmusicas.Text = plmusicas.Text.Substring(0, plmusicas.Text.Length - 2);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Desconocido", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void creapl(object sender, RoutedEventArgs e)
        {
            try
            {
                List<string> temps = new List<string>();
                bool IsValid = true;
                foreach (string l in plmusicas.Text.Replace("\r", string.Empty).Split(char.Parse("\n")))
                {
                    if (!string.IsNullOrEmpty(Path.GetDirectoryName(l)) || !string.IsNullOrEmpty(Path.GetFileName(l)))
                    {
                        if (System.IO.File.Exists(l))
                        {
                            if (acceptedFormats.Contains(Path.GetExtension(l)))
                            {
                                IsValid = true;
                                break;
                            }
                            else
                            {
                                MessageBox.Show("Alguna de las rutas de las musicas tienen un formato incompatible.", "Error al crear musica", MessageBoxButton.OK, MessageBoxImage.Error);
                                IsValid = false;
                                break;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Alguna de las rutas de las no son archivos.", "Error al crear musica", MessageBoxButton.OK, MessageBoxImage.Error);
                            IsValid = false;
                            break;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Alguna de las rutas de las musicas no existen.", "Error al crear musica", MessageBoxButton.OK, MessageBoxImage.Error);
                        IsValid = false;
                        break;
                    }
                }
                if (IsValid == true)
                {
                    foreach (string l in plmusicas.Text.Replace("\r", string.Empty).Split(char.Parse("\n")))
                    {
                        string temp = System.IO.Path.GetTempFileName();
                        File.Move(temp, Path.Combine(Path.GetDirectoryName(temp), Path.GetFileNameWithoutExtension(temp) + ".mp3"));
                        temp = Path.Combine(Path.GetDirectoryName(temp), Path.GetFileNameWithoutExtension(temp) + ".mp3");
                        using (FileStream f = File.Open(temp, FileMode.Open, FileAccess.Write))
                        {
                            f.Write(File.ReadAllBytes(l), 0, File.ReadAllBytes(l).Length);
                        }
                        TagLib.File? file = TagLib.File.Create(temp);
                        file.Tag.Title = Path.GetFileNameWithoutExtension(l);
                        file.Save();
                        file.Dispose();
                        file = null;
                        temps.Add(temp);
                    }
                    Playlist pl = new Playlist($@"C:\Users\{Environment.UserName}\Music\" + plnombre.Text + ".mmpl", plnombre.Text, pldesc.Text, plautor.Text, temps.ToArray());
                    foreach (string temp in temps)
                    {
                        File.Delete(temp);
                    }
                    temps.Clear();
                    MessageBox.Show("Se ha creado la playlist!\nEncuentralo en " + $@"C:\Users\{Environment.UserName}\Music!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Desconocido", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void atras(object sender, RoutedEventArgs e)
        {
            try
            {
                grid2.Visibility = Visibility.Visible;
                PlScreen.Visibility = Visibility.Hidden;
                PlCreation.Visibility = Visibility.Hidden;
                if (pl != null)
                {
                    pl.DescargarMusicas();
                    overlay.music.Close();
                    overlay.Hide();
                    overlay = new MusicOverlay();
                }
                ListaPl.Items.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Desconocido", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void cambiarver(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                int index = ((ComboBox)(sender)).Items.IndexOf(e.AddedItems[0]);
                switch (index)
                {
                    case 0:
                        ver = ViewType.Musicas;
                        break;
                    case 1:
                        ver = ViewType.Playlists;
                        break;
                    default:
                        MessageBox.Show("Se puso un tipo de vista desconocido.", "Error al cambiar Vista", MessageBoxButton.OK, MessageBoxImage.Error);
                        break;
                }
                Cargado(null, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Desconocido", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void drop(object sender, DragEventArgs e)
        {
            try
            {
                if (e.Data.GetDataPresent(DataFormats.FileDrop))
                {
                    string[]? dropped = (string[])e.Data.GetData(DataFormats.FileDrop);
                    foreach (string p in dropped)
                    {
                        if (Path.GetExtension(p) == ".mmpl")
                        {
                            if (ListaPlView.Visibility == Visibility.Visible)
                            {
                                System.IO.File.Copy(p, @"C:\Users\" + Environment.UserName + @"\Music\" + Path.GetFileName(p));
                                Cargado(sender, EventArgs.Empty);
                            }
                        }
                        else if (acceptedFormats.Contains(Path.GetExtension(p)))
                        {
                            if (ListaGeneral.Visibility == Visibility.Visible)
                            {
                                System.IO.File.Copy(p, @"C:\Users\" + Environment.UserName + @"\Music\" + Path.GetFileName(p));
                                Cargado(sender, EventArgs.Empty);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Desconocido", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}