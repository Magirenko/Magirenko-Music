   M S B A M L   `   `   `  ����J  Fmagirenko_music, Version=0.4.2.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Magirenko_MusicMagirenko_Music  5   	   "    Magirenko_Music.MusicOverlay   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:Magirenko_Music     5   	   -   5          �Name$  MusicOverlayWindow��5   	    � Title$' !Superposición de Magirenko Music��5   	   $��80��5	   	   $	��375��5
   	    � WindowStyle$
 None=�5   	    � AllowsTransparency$
 True��5   	    � 
ResizeMode$ NoResize=�5   	    � ShowInTaskbar$ False��5   	    � Topmost$
 True��5   	   $|�False��5   	    � Left$ 10��5   	   
 � Top$	 905��5   	   ��5   	   Z� ��5      �� 5   
   	 �� Color$	 Black��6   
 �� Opacity$	
 0.4Q�6(   .��5      � -   5         �Name$ MainGrid��5      $	��350��6   $	��100��6)   $��Bottom=�66   $��0,5,0,0q�6Q   .+�5   
   � -   5        $ MusicOptions��5      $	��350��6%   $��40��61   $��Bottom=�6=   $��0,0,0,0q�6X   .+�5      �� -   5         ��Name$ MusicProgress��5       � Maximum$ 0Q�6B   $��Bottom=�6N   $��0,0,0,22q�6i    � SmallChange$ 1Q�6{    � ToolTip$ Volumen��6�   $��18��6�   ��6,   Z� 6�   �� 5      -   5         ��Name$ Position��5      $��Cargando...��6&   
�������$	��Top=�6O   $��Center=�6g   $��14(�6�   $��18��6�   $��0,0,0,0q�6�   $��0,16,0,0q�6�   �� 5      -   5        $��16��5   X   $��20��6c   $��0,0,13,4q�6o   $��Right=�6�   $��Bottom=�6�   ��6   Z� ��6+   Z� ��6B   Z� .��5      �� $��Center=�6   $��Center=�68   .+�5      �� -   5         ��Name$ Estado��5      $��Assets/Iconos/Pausa.png��6,   $��UniformToFill=�6M   $ Pausar Musica��6e   5      5      �� 5       -   5        $ Volumen��5       $	��100��6&   $��18��6H   $ 4Q�6T   $��Bottom=�6`   $
��Left=�6{   $��23,0,0,4q�6�   $ 1Q�6�   $ Volumen��6�   ��62   Z� 6�   �� 5!      -	   5        $ VolumenLabel��5!      $��Cargando...��6*   
�������$��Bottom=�6S   $
��Left=�6n   $��14��6�   $��0,0,0,0q�6�   $��49,0,0,0q�6�   $��10(�6�   �� 5"      -
   5        $��20��5"   X   $��20��6c   $��0,0,36,4q�6o   $��Right=�6�   $��Bottom=�6�   $��0,0,0,0q�6�   ��6   Z� ��6+   Z� ��6B   Z� .��5#      �� $��Center=�6   $��Center=�68   .+�5$      �� -   5        $ Bucle��5$      $)��#Assets/Iconos/bucle_o_refrescar.png��6+   $��UniformToFill=�6X   $ Quitar el Bucle��6p   5%      5&      5'      � 5(   
   -   5        $ MusicPlaying��5(      $	��350��6%   $��30��61   $��Center=�6=   $��Center=�6X   $��0,0,0,15q�6u   .+�5)      �� $��20��6   $��20��6    $
��Left=�6+   $%��/Assets/Iconos/nota_musical.png��6F   $��10,2,0,3q�6o   � 5*      -   5        $ 	LabelGrid��5*      $	��315��6&   $��20��62   $��35,0,0,0q�6>   $
}�True��6P   .+�5+      �� -   5        $ 
musiclabel��5+      $��Reproduciendo: ???��6,   $
��Left=�6I   $	��340��6d   $��20��6p   ���	#FFFDFDFD���	#00000000$��Center=�6�   $��Center=�6�   4  .System.Windows.Automation.AutomationProperties   IsOffscreenBehavior$ Onscreen=�6�   $��0,0,0,0q�6  $��0,0,0,0q�6-  $��16(�6>  5,      5-      � 5.   
   $��26��6   $	��Top=�6   .+�5/      �� -   5        $ 	ndemusica��5/      $��Cargando...��6'   
�������$��11(�6P   50      51      52      