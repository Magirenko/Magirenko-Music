using Magirenko.MMPL;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Magirenko_Music
{
    /// <summary>
    /// Lógica de interacción para MusicOverlay.xaml
    /// </summary>
    public partial class MusicOverlay : Window
    {
        private System.Windows.Threading.DispatcherTimer timer = new System.Windows.Threading.DispatcherTimer();
        private MediaPlayer music = new MediaPlayer();
        private Playlist? pl = null;
        private int musicaactual = 0;
        public MusicOverlay()
        {
            try
            {
                InitializeComponent();
                timer.Interval = new TimeSpan(0, 0, 0, 0, 17);
                timer.IsEnabled = true;
                timer.Tick += tick;
                Loaded += loaded;
                Volumen.ValueChanged += ActualizarVolumen;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Desconocido", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        string[] acceptedFormats = { ".mp3", ".aac", ".ogg", ".wav", ".flac", ".m4a" };
        bool firsttime = true;
        public void LoadMusic(string? path, Playlist? playlist = null, int musica = 0)
        {
            music.Stop();
            try
            {
                if (firsttime == true)
                {
                    CambiarBucle(null, EventArgs.Empty);
                    firsttime = false;
                }
                if (playlist != null)
                {
                    pl = playlist;
                    this.Height = 100;
                    this.Top = 885;
                    ndemusica.Content = "Musica " + (musica + 1).ToString() + " de " + pl.CantidadDeMusicas.ToString();
                    musicaactual = musica;
                    CambiarBucle(null, EventArgs.Empty);
                    CambiarBucle(null, EventArgs.Empty);
                }
                else
                {
                    pl = null;
                    this.Height = 80;
                    this.Top = 905;
                    ndemusica.Content = "Cargando...";
                    musicaactual = 0;

                }
                TagLib.File musicInfo = TagLib.File.Create(pl == null ? path : pl.Musicas[musica]);
                if (musicInfo.PossiblyCorrupt)
                {
                    MessageBox.Show("No se pudo cargar la musica seleccionada por que es corrupto", "Error al cargar musica | Magirenko Music", MessageBoxButton.OK, MessageBoxImage.Error);
                    Process.GetCurrentProcess().Kill();
                }
                else if (acceptedFormats.Contains(Path.GetExtension(pl == null ? path : pl.Musicas[musica])) == false)
                {
                    MessageBox.Show("El archivo seleccionado no es un archivo de musica o es un formato de musica incompatible.", "Error al cargar musica | Magirenko Music", MessageBoxButton.OK, MessageBoxImage.Error);
                    Process.GetCurrentProcess().Kill();
                }
                MusicProgress.Maximum = musicInfo.Properties.Duration.TotalSeconds;
                musiclabel.Content = "Reproduciendo: " + (pl != null ? ((musicInfo.Tag.Title != "") ? "Sin Nombre" : musicInfo.Tag.Title) : ((musicInfo.Tag.Title != "") ? Path.GetFileNameWithoutExtension(musicInfo.Name) : musicInfo.Tag.Title));
                music.Open(pl == null ? new Uri(path) : new Uri(pl.Musicas[musica]));
                music.Play();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo cargar la musica seleccionada por que es corrupto\n" + ex.Message, "Error al cargar musica | Magirenko Music", MessageBoxButton.OK, MessageBoxImage.Error);
                Process.GetCurrentProcess().Kill();
            }
        }

        private void tick(object? sender, EventArgs e)
        {
            try
            {
                if (musiclabel.Margin.Left > (((string)(musiclabel.Content)).Length * 2.5) + 350)
                {
                    musiclabel.Margin = new Thickness(-8 * ((string)(musiclabel.Content)).Length, 0, 0, 0);
                }
                else
                {
                    musiclabel.Margin = new Thickness(musiclabel.Margin.Left + 2, 0, 0, 0);
                }

                if (music.NaturalDuration.HasTimeSpan == true)
                {
                    MusicProgress.Value = music.Position.TotalSeconds;
                    Position.Content = music.Position.ToString(@"mm\:ss");
                }

                if (Keyboard.IsKeyDown(Key.Right))
                {
                    timer.Tick += moveright;
                }

                if (Keyboard.IsKeyDown(Key.Left))
                {
                    timer.Tick += moveleft;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Desconocido", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        double acc = 1;
        private void moveright(object sender, EventArgs e)
        {
            music.Pause();
            music.Position += new TimeSpan(0, 0, 0, 0, (int)(music.NaturalDuration.HasTimeSpan == true ? music.NaturalDuration.TimeSpan.TotalSeconds / 4 : 1 * acc));
            acc = acc + 0.25;
            if (Keyboard.IsKeyUp(Key.Right))
            {
                acc = 1;
                timer.Tick -= moveright;
                if (State == 1)
                {
                    music.Play();
                }
            }
        }

        private void moveleft(object sender, EventArgs e)
        {
            music.Pause();
            music.Position -= new TimeSpan(0, 0, 0, 0, (int)(music.NaturalDuration.HasTimeSpan == true ? music.NaturalDuration.TimeSpan.TotalSeconds / 4 : 1 * acc));
            acc = acc + 0.25;
            if (Keyboard.IsKeyUp(Key.Left))
            {
                acc = 1;
                timer.Tick -= moveleft;
               if (State == 1)
                {
                    music.Play();
                }
            }
        }
        private void loaded(object? sender, RoutedEventArgs e)
        {
            try
            {
                timer.Start();
                Volumen.Value = 2;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Desconocido", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        int State = 1;
        private void CambiarEstado(object? sender, EventArgs e)
        {
            try
            {
                if (State == 1)
                {
                    music.Pause();
                    Estado.Source = new BitmapImage(new Uri("/Assets/Iconos/Reanudar.png", UriKind.Relative));
                    State = 0;
                    Estado.ToolTip = "Reanudar Musica";
                }
                else if (State == 0)
                {
                    if (music.Position >= music.NaturalDuration)
                    {
                        music.Pause();
                        music.Position = TimeSpan.Zero;
                    }
                    music.Play();
                    Estado.Source = new BitmapImage(new Uri("/Assets/Iconos/Pausa.png", UriKind.Relative));
                    State = 1;
                    Estado.ToolTip = "Pausar Musica";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Desconocido", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void startAgain(object? sender, EventArgs e)
        {
            try
            {
                music.Position = TimeSpan.Zero;
                music.Play();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Desconocido", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void siguientemusica(object? sender, EventArgs e)
        {
            if (musicaactual < (pl.CantidadDeMusicas - 1))
            {
                musicaactual += 1;
                LoadMusic(null, pl, musicaactual);
            }
        }

        int Loop = 0;
        private void CambiarBucle(object? sender, EventArgs e)
        {
            try
            {
                if (Loop == 1)
                {
                    music.MediaEnded += startAgain;
                    Bucle.Source = new BitmapImage(new Uri("/Assets/Iconos/bucle_o_refrescar.png", UriKind.Relative));
                    Loop = 0;
                    Bucle.ToolTip = "Quitar el Bucle";
                }
                else if (Loop == 0)
                {
                    music.MediaEnded -= startAgain;
                    Trace.WriteLine(pl);
                    if (pl != null)
                    {
                        music.MediaEnded += siguientemusica;
                    }
                    Bucle.Source = new BitmapImage(new Uri("/Assets/Iconos/sinbucle.png", UriKind.Relative));
                    Loop = 1;
                    Bucle.ToolTip = "Activar el Bucle";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Desconocido", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ActualizarVolumen(object? sender, EventArgs e)
        {
            try
            {
                string NivelDeVol = "Desconocido";
                int vol = (int)Math.Floor(Volumen.Value);
                if (vol == 0)
                {
                    NivelDeVol = "Muy Bajo";
                }
                else if (vol == 1)
                {
                    NivelDeVol = "Bajo";
                }
                else if (vol == 2)
                {
                    NivelDeVol = "Normal";
                }
                else if (vol == 3)
                {
                    NivelDeVol = "Alto";
                }
                else if (vol == 4)
                {
                    NivelDeVol = "Muy Alto";
                }
                VolumenLabel.Content = "Vol: " + NivelDeVol;
                music.Volume = 0.1 + Volumen.Value / 3.9;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Desconocido", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void drag(object sender, DragStartedEventArgs e)
        {
            timer.Tick -= tick;
            music.Pause();
        }

        private void stopdrag(object sender, DragCompletedEventArgs e)
        {
            if (music.NaturalDuration.HasTimeSpan == true)
            {
                music.Position = new TimeSpan(0, 0, 0, (int)(MusicProgress.Value));
                timer.Tick += tick;
                if (State == 1)
                {
                    music.Play();
                }
            }
        }
    }
}