   M S B A M L   `   `   `  ���� J  Fmagirenko_music, Version=0.2.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Magirenko_MusicMagirenko_Music       Magirenko_Music.MainWindow   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     /localclr-namespace:Magirenko_Music     -     �Name$
  Main�� � Title$ Magirenko Music��$	��450��$	��825��$��Center=�$��Center=� � Icon$ /Assets/Iconos/logo.png��$	��700��$	��425��$	��625��$	��900�� � 
ResizeMode$ CanMinimize=�.��� -    �Name$ MainGrid��$��Center=�$��Center=�$	��411��$	��809��.+�� -   $ grid1��$	��779��.+��� $!��Magirenko Music v0.4.1 Alfa��$��25��$	��152��$
��Left=�$��Bottom=�$��0,0,0,0q��� $#��Bienvenido a Magirenko Music!��$��22(�$��Center=�$��Center=�$��Black"�$��250,0,0,325q�$��Center=�$��Center=��� $��Center=�$��Center=�$��Center=�$��Center=�$	��374��$��14(�$��250,110,0,0q�.���� -    ��Name$
 desc��$
��Wrap=�$t��nMagirenko Music es un reproductor de musica para escuchar musica de fondo en tu pc mientras haces otras cosas!���� -    ��Name$ Boton1��$��	Continuar��$��25��$��76��$��Center=�$��Center=�$��250,250,0,0q��� $	��167��$	��256��$��/Assets/Iconos/logo.png��$��250,0,0,120q�$��UniformToFill=�$��Center=�$��Center=��� $��Center=�$
��Left=�$	��350��$	��325��$��Stretch=�$��Center=�.���� .���� -   $ Cambios��$
��Wrap=�$��10(��� -    ��Name$ firstrun��$��20(�$$�Que hay de nuevo en la v0.4.1?�� �� BaselineAlignment$ TextTop=�� -   $ grid2��$y�Hidden=�.+��� -	   	 ��Name$	 ListaGeneral��$	��Top=�$��Center=�
 �� SelectionMode$
 Single=�$	��Top=�$��Center=�$ �� IsSynchronizedWithCurrentItem$
 TrueY�$��0,93,0,0q�$	��750�� J� 	AllowDrop$
 True����Z� ��Z�  �� View ��  �� AllowsColumnReorder$ False��.P��� $�� �� �� Width$ 25�� �� DisplayMemberBinding �� *	portada+�� $��Titulo��$	 350�� �� *titulo+�� $��Duracion��$ 90�� �� *
duracion+�� $��Carpeta��$	 300�� �� *	carpeta+����  �� 
TargetType" ��.�-
   �� -   $	 ListaPlView��$	��Top=�$��Center=�$
 Single=�$	��Top=�$��Center=�$
 TrueY�$��0,93,0,0q�$	��750��$y�Hidden=�$
 True����Z� ��Z�  �� $ False��.P��� $�� ��$ 25�� �� *	portada+�� $��Titulo��$	 350�� �� *titulo+�� $��Musicas��$ 90�� �� *	musicas+�� $��Carpeta��$	 300�� �� *	carpeta+���� " ��.�-   �� $��Center=�$��Center=�$��Center=�$	��500��$��12(�$��	0,0,0,300q�.���� -   $ 	empezando��$��WrapWithOverflow=�$����Esta es la seleccion de musicas que tienes guardado en C:\users\nombre\Music!                            para empezar, Dale doble click a la musica que quieres reproducir.��$��Center=�$��Center=�$��13(�$	��458��o� $	��Top=�.@�m� $��Archivo��.@�m� $��Musicas��.@�m� -   $��Importar Musica��m� -   $��Abrir Musica��m� $��	Playlists��.@�m� -   $��Importar Playlist��m� -   $��Abrir Playlist��m� -   $��Nueva Playlist���� -   $��25��$��25��$��0,0,525,275q�$��Center=�$��Center=�$��0,0,0,0q���Z� ��Z� ��Z� .���� $��Center=�$��Center=�.+��� -    ��Name$ 	Recargar3��$0��*Assets/Iconos/bucle_o_refrescar_oscuro.png��$��UniformToFill=� � ToolTip$ Recargar���� -   $��Center=�$��Center=�$��0,0,650,275q� �� SelectedItem ��  �� ElementName$ comboBoxItem�� �� Mode$ OneWay=�.@��� -    ��Name$ comboBoxItem��$��Musicas���� $��	Playlists��� -   $ PlScreen��$y�Hidden=�.+�o� $	��Top=�.@�m� $��Archivo��.@�m� $��Musicas��.@�m� -   $��Importar Musica��m� -   $��Abrir Musica��m� $��	Playlists��.@�m� -   $��Importar Playlist��m� -   $��Abrir Playlist��m� -   $��Nueva Playlist���� $��Playlist��$��Center=�$��Center=�$��	0,0,0,350q��� $	��♫��$��Center=�$��Center=�$��0,0,550,300q�$��48(��� -    ��Name$ titulo��$��PlName��$��Center=�$
��Left=�$��24(�$��150,0,0,280q��� -   $ autor��$��PlAuthor��$��Center=�$��Center=�$��0,0,475,230q��� $��Center=�$��Center=�$��14(�$��	0,0,0,175q�$��Center=�$��Center=�.���� -   $ desc1��$��Center=�$��Center=�$
��Wrap=�$��PlDesc���� -    $	 ListaPl��$	��Top=�$��Center=�$
 Single=�$	��Top=�$��Center=�$
 TrueY�$��	0,140,0,0q�$	��750����Z� ��Z�  �� $ False��.P��� $�� ��$ 25�� �� *	portada+�� $��Titulo��$	 350�� �� *titulo+�� $��Duracion��$ 90�� �� *
duracion+�� $��Carpeta��$	 300�� �� *	carpeta+���� " ��.�-!   �� -"   $��<<��$��Center=�$��Center=�$��18(�$��0,350,750,0q�� -#   $ 
PlCreation��$y�Hidden=�.+�o� $	��Top=�.@�m� $��Archivo��.@�m� $��Musicas��.@�m� -$   $��Importar Musica��m� -%   $��Abrir Musica��m� $��	Playlists��.@�m� -&   $��Importar Playlist��m� -'   $��Abrir Playlist��m� -(   $��Nueva Playlist���� $��Creacion de Playlist��$��Center=�$��Center=�$��	0,0,0,350q�$��Center=�$��Center=��� -)    ��Name$ plnombre�� �� TextWrapping$
 Wrap=�$�� ��$	��300��$��Center=�$��
0,0,75,100q�$��Center=�$��30��$��Center=�$��14(� �� AcceptsReturn$
 True�� �� AutoWordSelection$
 True�� �� 	MaxLength$ 20���� $#��Nombre (20 caracteres maximo)��$��Right=�$��Center=�$��0,0,600,100q�$��Right=��� -*   $ pldesc��$
 Wrap=�$�� ��$	��300��$��Center=�$��0,0,75,0q�$��Center=�$��30��$��Center=�$��14(�$
 True��$
 True��$ 50���� $(��"Descripcion (50 caracteres maximo)��$��Right=�$��Center=�$��	0,0,600,0q�$��Right=��� -+   $ plautor��$
 Wrap=�$�� ��$	��300��$��Center=�$��
0,100,75,0q�$��Center=�$��30��$��Center=�$��14(�$
 True��$
 True��$ 20���� $"��Autor (20 caracteres maximo)��$��Right=�$��Center=�$��0,100,600,0q�$��Right=��� -,   $ 	plmusicas��$
 Wrap=�$�� ��$	��300��$��Center=�$��
0,200,75,0q�$��Center=�$��30��$��Center=�$��14(�$
 True��$
 True���� $��Musicas��$��Right=�$��Center=�$��0,200,600,0q�$��Right=��� --   $��Examinar��$��Center=�$��Center=�$��300,200,0,0q�$��14(��� -.   $��Crear��$��Center=�$��Center=�$��	0,325,0,0q�$��14(��� -/   $��<<��$��Center=�$��Center=�$��18(�$��0,325,725,0q�