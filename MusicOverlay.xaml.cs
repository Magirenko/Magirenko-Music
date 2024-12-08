using System.IO;
using System.Reflection.Emit;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using TagLib;

namespace Magirenko_Music
{
    /// <summary>
    /// Lógica de interacción para MusicOverlay.xaml
    /// </summary>
    public partial class MusicOverlay : Window
    {
        private System.Windows.Threading.DispatcherTimer timer = new System.Windows.Threading.DispatcherTimer();
        private MediaPlayer music = new MediaPlayer();
        public MusicOverlay()
        {
            InitializeComponent();
            timer.Interval = new TimeSpan(0, 0, 0, 0, 17);
            timer.IsEnabled = true;
            timer.Tick += tick;
            Loaded += loaded;
            Volumen.ValueChanged += ActualizarVolumen;
            CambiarBucle(null, EventArgs.Empty);
        }
        string[] acceptedFormats = { ".mp3", ".aac", ".ogg", ".wav", ".flac", ".m4a" };
        public void LoadMusic(string path)
        {
            music.Stop();
            try
            {
                TagLib.File musicInfo = TagLib.File.Create(path);
                if (musicInfo.PossiblyCorrupt)
                {
                    MessageBox.Show("No se pudo cargar la musica seleccionada por que es corrupto", "Error al cargar musica | Magirenko Music", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else if (acceptedFormats.Contains(Path.GetExtension(path)) == false)
                {
                    MessageBox.Show("El archivo seleccionado no es un archivo de musica o es un formato de musica incompatible.", "Error al cargar musica | Magirenko Music", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                musiclabel.Content = "Reproduciendo: " + ((musicInfo.Tag.Title != "") ? Path.GetFileNameWithoutExtension(musicInfo.Name) : musicInfo.Tag.Title);
                music.Open(new Uri(path));
                music.Play();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo cargar la musica seleccionada por que es corrupto\n" + ex.Message, "Error al cargar musica | Magirenko Music", MessageBoxButton.OK, MessageBoxImage.Error);
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
                    MusicProgress.Margin = new Thickness(10 + ((music.Position.TotalSeconds / music.NaturalDuration.TimeSpan.TotalSeconds) * 319), 0, 0, 0);
                    Position.Content = music.Position.ToString(@"mm\:ss");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Data.ToString(), "Error Desconocido", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void loaded(object? sender, RoutedEventArgs e)
        {
            timer.Start();
            Volumen.Value = 2;
        }

        int State = 1;
        private void CambiarEstado(object? sender, EventArgs e)
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

        private void startAgain(object? sender, EventArgs e)
        {
            music.Position = TimeSpan.Zero;
            music.Play();
        }

        int Loop = 0;
        private void CambiarBucle(object? sender, EventArgs e)
        {
            if (Loop == 1)
            {
                music.MediaEnded += startAgain;
                Bucle.Source = new BitmapImage(new Uri("/Assets/Iconos/bucle.png", UriKind.Relative));
                Loop = 0;
                Bucle.ToolTip = "Quitar el Bucle";
            }
            else if (Loop == 0)
            {
                music.MediaEnded -= startAgain;
                Bucle.Source = new BitmapImage(new Uri("/Assets/Iconos/sinbucle.png", UriKind.Relative));
                Loop = 1;
                Bucle.ToolTip = "Activar el Bucle";
            }
        }

        private void ActualizarVolumen(object? sender, EventArgs e)
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
    }
}
