   M S B A M L   `   `   `  ���� J  Fmagirenko_music, Version=0.2.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Magirenko_MusicMagirenko_Music  "    Magirenko_Music.MusicOverlay   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     /localclr-namespace:Magirenko_Music     -     �Name$  MusicOverlayWindow�� � Title$' !Superposición de Magirenko Music��$��80��$	��375�� � WindowStyle$
 None=� � AllowsTransparency$
 True�� � 
ResizeMode$ NoResize=� � ShowInTaskbar$ False�� � Topmost$
 True��$|�False�� � Left$ 10��
 � Top$	 905����Z� ���� 	 �� Color$	 Black��
 �� Opacity$	
 0.4Q�.��� -    �Name$ MainGrid��$	��350��$	��100��$��Bottom=�$��0,5,0,0q�.+�� -   $ MusicOptions��$	��350��$��40��$��Bottom=�$��0,0,0,0q�.+��� -    ��Name$ MusicProgress�� � Maximum$ 0Q�$��Bottom=�$��0,0,0,22q� � SmallChange$ 1Q� � ToolTip$ Volumen��$��18����Z� �� -    ��Name$ Position��$��Cargando...��
�������$	��Top=�$��Center=�$��14(�$��18��$��0,0,0,0q�$��0,16,0,0q��� -   $��16��$��20��$��0,0,13,4q�$��Right=�$��Bottom=���Z� ��Z� ��Z� .���� $��Center=�$��Center=�.+��� -    ��Name$ Estado��$��Assets/Iconos/Pausa.png��$��UniformToFill=�$ Pausar Musica���� -   $ Volumen��$	��100��$��18��$ 4Q�$��Bottom=�$
��Left=�$��23,0,0,4q�$ 1Q�$ Volumen����Z� �� -	   $ VolumenLabel��$��Cargando...��
�������$��Bottom=�$
��Left=�$��14��$��0,0,0,0q�$��49,0,0,0q�$��10(��� -
   $��20��$��20��$��0,0,36,4q�$��Right=�$��Bottom=�$��0,0,0,0q���Z� ��Z� ��Z� .���� $��Center=�$��Center=�.+��� -   $ Bucle��$)��#Assets/Iconos/bucle_o_refrescar.png��$��UniformToFill=�$ Quitar el Bucle��� -   $ MusicPlaying��$	��350��$��30��$��Center=�$��Center=�$��0,0,0,15q�.+��� $��20��$��20��$
��Left=�$%��/Assets/Iconos/nota_musical.png��$��10,2,0,3q�� -   $ 	LabelGrid��$	��315��$��20��$��35,0,0,0q�$
}�True��.+��� -   $ 
musiclabel��$��Reproduciendo: ???��$
��Left=�$	��340��$��20�����	#FFFDFDFD���	#00000000$��Center=�$��Center=�4  .System.Windows.Automation.AutomationProperties   IsOffscreenBehavior$ Onscreen=�$��0,0,0,0q�$��0,0,0,0q�$��16(�� $��26��$	��Top=�.+��� -   $ 	ndemusica��$��Cargando...��
�������$��11(�